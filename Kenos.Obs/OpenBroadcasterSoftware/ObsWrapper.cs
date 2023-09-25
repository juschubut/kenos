using Kenos.Common;
using Kenos.Win.OpenBroadcasterSoftware;
using OBSWebsocketDotNet;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Kenos.Win.OpebBroacasterSoftware
{
	public class ObsWrapper : IDisposable
	{
		private Panel _previewPanel;
		private Process _obsProcess;
		private OBSWebsocket _obsWebsocket;
		private bool _wsConnected = false;

		public string RecordingFileName { get; set; }
		public ObsStates State { get; private set; } = ObsStates.NotSet;

		//TODO ver cuando lanzar
		public delegate void OnRecordingStartedDelegate(object sender, ObsRecordingStartedEventArgs args);
		public event OnRecordingStartedDelegate OnRecordingStarted;

		public delegate void OnLogDelegate(object sender, ObsLogEventArgs args);
		public event OnLogDelegate OnLog;

		public delegate void OnReadyDelegate(object sender, EventArgs args);
		public event OnReadyDelegate OnReady;


		public void Stop()
		{

		}

		public bool Configure(CaptureConfig extraConfig)
		{
			var scene = GetScene(extraConfig.Video);

			_obsWebsocket.SetCurrentProgramScene(scene);
			_obsWebsocket.SetProfileParameter("SimpleOutput", "FilePath", Properties.Settings.Default.PathGrabacion);



			return true;
		}

		public void StartRecording()
		{
			_obsWebsocket.StartRecord();
		}

		public void StopPlayer()
		{
			_obsWebsocket.StopRecord();
		}

		public void Initialize(Panel previewPanel)
		{
			State = ObsStates.NotSet;

			_previewPanel = previewPanel;

			// Creo el proceso para levantar OBS
			_obsProcess = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					WorkingDirectory = Properties.Settings.Default.ObsWorkingDirectory,
					FileName = Properties.Settings.Default.ObsFileName,
					Arguments = Properties.Settings.Default.ObsArguments
				}
			};

			_obsProcess.Start();
			_obsProcess.WaitForInputIdle();

			while (_obsProcess.MainWindowHandle == IntPtr.Zero)
			{
				Thread.Sleep(100);
				_obsProcess.Refresh();
			}

			// Muestro la interfaz gráfica de OBS en el panel 
			WindowsWrapper.DisplayOnPanel(_obsProcess, previewPanel);
			WindowsWrapper.MoveWindow(_obsProcess.MainWindowHandle, 0, 0, _previewPanel.Width, _previewPanel.Height, true);

			// Connecto via websocket
			previewPanel.Resize += PreviewPanel_Resize;

			ConnectWebsocket();
		}

		public void ConnectWebsocket()
		{
			var url = Properties.Settings.Default.ObsUrl;

			_obsWebsocket = new OBSWebsocket();

			_obsWebsocket.Connected += Websocket_Connected;
			_obsWebsocket.Disconnected += Websocket_Disconnected;
			_obsWebsocket.RecordStateChanged += Websocket_RecordStateChanged;
			_obsWebsocket.VendorEvent += Websocket_VendorEvent;

			System.Threading.Tasks.Task.Run(() =>
			{
				try
				{
					_obsWebsocket.ConnectAsync(url, "");
				}
				catch (Exception ex)
				{
					LogError($"No se pudo conectar al websocket ({url})", ex);
				}
			});
		}

		private void Websocket_VendorEvent(object sender, OBSWebsocketDotNet.Types.Events.VendorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(e.VendorName);
			System.Diagnostics.Debug.WriteLine(e.EventType);
			System.Diagnostics.Debug.WriteLine(e.eventData);

		}

		private void Websocket_RecordStateChanged(object sender, OBSWebsocketDotNet.Types.Events.RecordStateChangedEventArgs e)
		{
			if (e.OutputState.IsActive && e.OutputState.State == OBSWebsocketDotNet.Types.OutputState.OBS_WEBSOCKET_OUTPUT_STARTED)
			{
				State = ObsStates.Recording;
				RecordingFileName = e.OutputState.OutputPath;

				if (OnRecordingStarted != null)
				{
					OnRecordingStarted(this, new ObsRecordingStartedEventArgs
					{
						OutputFileName = e.OutputState.OutputPath
					});
				}
			}
		}

		private void Websocket_Disconnected(object sender, OBSWebsocketDotNet.Communication.ObsDisconnectionInfo e)
		{
			//TODO ver que hacer
		}

		private void Websocket_Connected(object sender, EventArgs e)
		{
			_wsConnected = true;
			ConfigureObs();
		}

		private void ConfigureObs()
		{
			var profileName = Properties.Settings.Default.ObsProfileName;
			var profiles = _obsWebsocket.GetProfileList();

			if (profiles.Profiles != null)
			{
				var p = profiles.Profiles.FirstOrDefault(x => x.Equals(profileName, StringComparison.InvariantCultureIgnoreCase));

				if (p == null)
				{
					LogInfo($"Creando perfil por no existir - \"{profileName}\".");
					_obsWebsocket.CreateProfile(profileName);
				}
			}

			LogInfo($"Estableciendo perfil - \"{profileName}\".");

			_obsWebsocket.SetCurrentProfile(profileName);

			if (OnReady != null)
				OnReady(this, new EventArgs());
		}

		private void PreviewPanel_Resize(object sender, EventArgs e)
		{
			WindowsWrapper.MoveWindow(_obsProcess.MainWindowHandle, 0, 0, _previewPanel.Width, _previewPanel.Height, true);
		}


		private void LogInfo(string message)
		{
			if (this.OnLog != null)
				this.OnLog(this, new ObsLogEventArgs
				{
					IsError = false,
					Message = message
				});
		}

		private void LogError(string message, Exception ex)
		{
			if (this.OnLog != null)
				this.OnLog(this, new ObsLogEventArgs
				{
					IsError = true,
					Exception = ex,
					Message = message
				});
		}

		public bool ValidateConfig(CaptureConfig extraConfig)
		{
			if (!_wsConnected)
			{
				MessageBox.Show($"No se pudo establecer conexión con OBS. {Properties.Settings.Default.ObsUrl}", "Kenos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (!System.IO.Directory.Exists(Properties.Settings.Default.PathGrabacion))
			{
				MessageBox.Show($"La ruta de grabación no existe. {Properties.Settings.Default.PathGrabacion}", "Kenos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			// Prueba si tiene permisos de grabacion 
			if (!PruebaDeEscrituraEnDisco())
			{
				MessageBox.Show($"No se puede escribir en la ruta configurada. {Properties.Settings.Default.PathGrabacion}", "Kenos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			var scences = _obsWebsocket.ListScenes();

			if (scences == null)
			{
				MessageBox.Show($"Configuración inválida de audio y video en OBS", "Kenos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			var scene = GetScene(extraConfig.Video);

			if (!scences.Any(x => x.Name.Equals(scene, StringComparison.InvariantCultureIgnoreCase)))
			{
				MessageBox.Show($"Configuración inválida para \"{scene}\"", "Kenos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private bool PruebaDeEscrituraEnDisco()
		{
			var fileName = Path.Combine(Properties.Settings.Default.PathGrabacion, $"_{Guid.NewGuid().ToString().Replace("-", "")}.dat");

			try
			{
				File.WriteAllText(fileName, DateTime.Now.ToString());

				File.Delete(fileName);

				return true;
			}
			catch { }

			return false;
		}

		public void SetRecordingMode(ModosGrabacion modo)
		{
			if (_wsConnected)
			{
				var scene = GetScene(modo);
				_obsWebsocket.SetCurrentProgramScene(scene);
			}
		}

		public void Dispose()
		{
			if (_obsProcess != null)
				_obsProcess.Close();
		}

		private string GetScene(ModosGrabacion modo)
		{
			return GetScene(modo == ModosGrabacion.Video);
		}

		private string GetScene(bool video)
		{
			if (video)
				return Properties.Settings.Default.ObsVideoMode;
			else
				return Properties.Settings.Default.ObsAudioMode;
		}
	}
}
