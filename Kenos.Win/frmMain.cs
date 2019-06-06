using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Kenos.Win.Controls;
using VidGrab;
using Kenos.Win.Controls.VideoGrabberControl;

/**
 * 
 * 
 * 
 * */
namespace Kenos.Win
{
    public partial class frmMain : Form
    {
        private Config _config;
        private Common.IConnector _connector;
        private Common.Metadata _metadata;
        private FileMonitor _fileMonitor = null;
        private CaptureState _estado = CaptureState.NoSet;

        private Test.PruebaGrabacion _pruebaGrabacion = null;
        
        private TimeSpan _marcaTiempoActual;    // Mantiene el tiempo actual de grabación
        private TimeSpan _marcaTiempoInicial;   // Mantiene el tiempo total de la grabacion hasta la última pausa
        private DataTable _dtMarcaTiempo;

        private bool IsPaused
        {
            get { return lnkResume.Visible; }
        }

        public frmMain()
        {
            InitializeComponent();           
        }

        #region Form
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.videoGrabber.LicenseString = Properties.Settings.Default.DatasteadLicenseKey;
            this.videoGrabber.LicenseString = Properties.Settings.Default.DatasteadLicenseKeyRTSP;
             
            AplicarStyles();

            Log("******************* Cargando Kenos *******************");
            LogKenosInformation();

            Common.ModosGrabacion modo = Common.ModosGrabacion.Video;

            if (Properties.Settings.Default.ModoGrabacionPredeterminado.Equals("audio", StringComparison.InvariantCultureIgnoreCase))
                modo = Common.ModosGrabacion.Audio;

            ModoGrabacion(modo);

            ResetGrabacion();

            ConfigurarForm();

            _dtMarcaTiempo = CreateDataSourceMarcaTiempo();

            _config = Config.Current;

            Log("Cargando conectores");

            bool connectorOk = false;

            Logger.Log.IncreaseLogIndentation();

            foreach (string connectorClassName in Properties.Settings.Default.Connectors)
            {
                if (!string.IsNullOrEmpty(connectorClassName))
                {
                    Log("Cargando " + connectorClassName);

                    try
                    {
                        Common.IConnector connector = (Common.IConnector)Activator.CreateInstance(Type.GetType(connectorClassName, true));

                        _connector = connector;

                        AddConnectorMenuItem(connector);
                        connectorOk = true;
                    }
                    catch (Exception ex)
                    {
                        Log("Error al cargar connector " + connectorClassName);
                        Logger.Log.Error(ex);
                    }
                }
            }

            Logger.Log.DecreaseLogIndentation();

            if (!connectorOk)
            {
                _connector = null;

                MessageBox.Show(this, "No se puede cargar el connector, llame al administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _pruebaGrabacion = new Test.PruebaGrabacion();
            _pruebaGrabacion.PasoPrueba += PruebaGrabacion_PasoPrueba;
            _pruebaGrabacion.Iniciando += PruebaGrabacion_Iniciando;
            _pruebaGrabacion.Finalizado += PruebaGrabacion_Finalizado;
            _pruebaGrabacion.Cancelado += PruebaGrabacion_Cancelado;

            AlertaEspacioDisco();

            Log("******************* Kenos Iniciado *******************");
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoGrabber.CurrentState == TCurrentState.cs_Recording)
            {
                MessageBox.Show(this, "Actualmente se encuentra grabando. Termine correctamente el proceso antes de salir.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            if (_estado == CaptureState.Started || _estado == CaptureState.Paused || _estado == CaptureState.Completed)
            {
                MessageBox.Show(this, "Inicio una grabación y no se termino correctamente. Debe presionar el boton \"Confirmar\" o \"Cancelar\" para completar el proceso de grabación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            Log("******************* Kenos Finalizado *******************");
        }
        #endregion 

        #region Botones
        private void lnkNueva_MouseClick(object sender, MouseEventArgs e)
        {
            if (mnuNueva.Items.Count > 1)
            {
                Point location = new Point(lnkNueva.Location.X-3, lnkNueva.Location.Y + 20);

                lnkNueva.ContextMenuStrip.Show(lnkNueva, location);
            }
            else if (_connector != null)
            {
                NuevaGrabacion();
            }
        }
        
        private void lnkPlay_MouseClick(object sender, MouseEventArgs e)
        {
            Reproducir();
        }

        private void lnkGrabar_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Grabar");

            if (this.IsPaused)
            {
                MessageBox.Show(this, "No puede iniciar una nueva grabación porque el proceso se encuentra pausado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Log("Click en boton Grabar - Sin efecto por estar pausado");

                return;
            }

            IniciarGrabacion();
        }

        private void lnkPausar_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Pausar");

            if (videoGrabber.CurrentState == TCurrentState.cs_Recording || _estado == CaptureState.Started)
                Pausar();
            else
                Log("Click en boton Pausar - Sin efecto por estar grabando");
        }

        private void lnkResume_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Resume");

            if (_estado == CaptureState.Paused)
                ContinuarGrabacion();
            else
                Log("Click en boton Resume - Sin efecto por no estar grabando");
        }

        private void lnkParar_MouseClick(object sender, MouseEventArgs e)
        {            
            if (videoGrabber.CurrentState == TCurrentState.cs_Recording || _estado == CaptureState.Paused)
            {
                DialogResult result = MessageBox.Show(this, "¿Está seguro que desea parar la grabación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Parar();

                    if (Properties.Settings.Default.ConfirmacionAutomatica)
                    {
                        Finalizar();
                    }
                }
            }
            else
            {
                Parar();
            }
        }

        private void lnkCancelar_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Cancelar");

            Logger.Log.IncreaseLogIndentation();

            DialogResult result = DialogResult.No;

            if (_estado == CaptureState.NoSet || _estado == CaptureState.Initialized)
                result = System.Windows.Forms.DialogResult.Yes;
            else
                result = MessageBox.Show(this, "Si cancela la grabación se perderán todos los datos (audio/video/eventos) registrados hasta el momento \n¿Está seguro que desea cancelar la grabación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CancelarGrabacion();
            }
            else
            {
                Log("Click en boton Cancelar - Sin efecto");
            }

            Logger.Log.DecreaseLogIndentation();
        }

        private void lnkFinalizar_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Confirmar");

            Logger.Log.IncreaseLogIndentation();

            if (_estado == CaptureState.Completed)
                Finalizar();
            else
                MessageBox.Show(this, "No existe ninguna grabación iniciada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            Logger.Log.DecreaseLogIndentation();
        }

        private void lnkTest_MouseClick(object sender, MouseEventArgs e)
        {
            _pruebaGrabacion.Comenzar();
        }

        private void lnkConfigurar_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Configuración");

            Logger.Log.IncreaseLogIndentation();

            if (ValidarUsuarioConfig())
            {
                frmConfiguracion frm = new frmConfiguracion(videoGrabber);

                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    Log("Configuración completada");
                else
                    Log("Configuración cancelada");
            }

            Logger.Log.DecreaseLogIndentation();
        }
        #endregion 

        #region Metodos
        private void ModoGrabacion(Common.ModosGrabacion modo)
        {
            rdVideo.Checked = modo == Common.ModosGrabacion.Video;
            rdAudio.Checked = modo == Common.ModosGrabacion.Audio;
        }

        private bool IniciarGrabacion()
        {
            Log("Iniciando grabación");

            Logger.Log.IncreaseLogIndentation();

            try
            {
                InicializarMarcasTiempo();

                ExtraConfig extraConfig = GetExtraConfig();

                if (extraConfig == null)
                    return false;

                if (!Validar(extraConfig))
                {
                    Log("Grabación suspendida por configuracion inválida");

                    return false;
                }

                if (_metadata != null)
                {
                    Log("Metadata:");
                    Log(_metadata.ToString());
                }

                if (!videoGrabber.Configure(extraConfig))
                {
                    Log("Suspendiendo incio de grabación por configuración inválida");

                    return false;
                }
                 
                lblArchivo.Text = videoGrabber.RecordingFileName;

                if (_metadata != null)
                    _metadata.FullFileName = videoGrabber.RecordingFileName;

                if (videoGrabber.RecordingMode == RecordingModes.Standard)
                    LogStartRecordingInfo(extraConfig);

                MostrarAlerta(false);

                if (extraConfig.Video)
                {
                    //videoGrabber.StartPreview();
                    videoGrabber.StartRecording();
                    //return true;
                }
                else
                {
                    videoGrabber.StartAudioRecording();
                }

                lnkSeleccionCamara.Visible = videoGrabber.OnvifPTZDevices.Count > 1;

                videoGrabber_CurrentOnvifDeviceIndexChange(videoGrabber, new EventArgs());

                _estado = CaptureState.Started;
                _fileMonitor = new FileMonitor(videoGrabber.RecordingFileName);

                Grabando(true);

                HabilitarForm();

                if (!string.IsNullOrEmpty(Properties.Settings.Default.TextoEnInicio))
                    AgregarMarca(string.Format(Properties.Settings.Default.TextoEnInicio, DateTime.Now));

                timerRecording.Start();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);

                return false;
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }
        }

        private void NuevaGrabacion()
        {
            Log("Click en boton Nuevo");

            Logger.Log.IncreaseLogIndentation();

            Common.Metadata metadata = null;

            try
            {

                try
                {
                    Log("Llamando operación \"Nueva\" de connector");

                    Logger.Log.IncreaseLogIndentation();

                    metadata = _connector.Nueva();
                }
                catch (Exception ex)
                {
                    Log("Se produjo un error al intentar crear una grabación nueva.");
                    Logger.Log.Error(ex);

                    MessageBox.Show(this, "Se produjo un error al intentar crear una grabación nueva.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    throw ex;
                }
                finally
                {
                    Logger.Log.DecreaseLogIndentation();
                }

                if (metadata == null)
                {
                    Log("Click en boton Nuevo - Sin efecto por ser cancelada");
                    return;
                }

                if (metadata.ForzarModoGrabacion)
                {
                    ModoGrabacion(metadata.ModoGrabacion);
                    rdAudio.Enabled = false;
                    rdVideo.Enabled = false;
                }

                //string extension = rdVideo.Checked ? "wmv" : "mp3";
                string extension =  "mp3";

                if(rdVideo.Checked){
                    Config config = Config.Current;
                    extension = config.VideoSettings[0].FormatOutput;
                }
                
                lnkTest.Enabled = true;

                metadata.FullFileName = string.Format("{0}{1}.{2}", Properties.Settings.Default.PathGrabacion, Guid.NewGuid(), extension);

                Log("Archivo donde se realiza grabación {0}", metadata.FullFileName);

                ResetGrabacion();

                _metadata = metadata;
                _estado = CaptureState.Initialized;

                lblDescripcion.Text = _metadata.Descripcion;
                lblArchivo.Text = _metadata.FullFileName;

                if (!string.IsNullOrEmpty(_metadata.Descripcion) && !string.IsNullOrEmpty(_metadata.Etiqueta))
                    lblDescripcion.Text = string.Format("{0} - {1}", _metadata.Etiqueta, _metadata.Descripcion);

                if (string.IsNullOrEmpty(_metadata.Descripcion) && !string.IsNullOrEmpty(_metadata.Etiqueta))
                    lblDescripcion.Text = _metadata.Etiqueta;

                if (!string.IsNullOrEmpty(_metadata.Descripcion) && string.IsNullOrEmpty(_metadata.Etiqueta))
                    lblDescripcion.Text = _metadata.Descripcion;


                Log("Nueva grabación");
                Log("...... Archivo: " + _metadata.FullFileName);
                Log("...... Descripción: " + _metadata.Descripcion);

                HabilitarForm();

                if (Path.GetExtension(_metadata.FullFileName).Equals(".wmv", StringComparison.InvariantCultureIgnoreCase) || Path.GetExtension(_metadata.FullFileName).Equals(".mp4", StringComparison.InvariantCultureIgnoreCase))
                    rdVideo.Checked = true;
                else
                    rdAudio.Checked = true;


                if (!_pruebaGrabacion.Realizada)
                {
                    if (!_pruebaGrabacion.Iniciada)
                        MessageBox.Show(this, "Debe realizar la prueba de grabación antes de comenzar a grabar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log("Se produjo un error en operación de NuevaGrabación.");
                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }
        }

        private void CancelarGrabacion()
        {
            Parar();

            if (_connector != null && _metadata != null)
            {
                try
                {
                    _connector.Cancelar(_metadata);

                    Log("Grabación cancelada");
                }
                catch (Exception ex)
                {
                    Log("Se produjo un error al intentar cancelar la grabación.");
                    Logger.Log.Error(ex);

                    MessageBox.Show(this, "Se produjo un error al intentar cancelar la grabación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ResetGrabacion();
        }

        private void Parar()
        {
            Log("Parando grabación");

            Logger.Log.IncreaseLogIndentation();

            try
            {
                if (videoGrabber.CurrentState == TCurrentState.cs_Recording ||  _estado == CaptureState.Paused || _estado == CaptureState.Started)
                {
                    _estado = CaptureState.Completed;
                    videoGrabber.Stop();

                    Grabando(false);

                    MostrarAlerta(false);
                    timerRecording.Stop();

                    Log(string.Format("Grabación parada [{0}]", lblDuracion.Text));

                    if (_metadata != null)
                        _metadata.FullFileName = videoGrabber.MergeOutputFile();

                    HabilitarForm();
                }
                else if (videoGrabber.CurrentState == TCurrentState.cs_Playback)
                {
                    videoGrabber.Stop();
                }
                else if (videoGrabber.CurrentState == TCurrentState.cs_Down && _estado == CaptureState.Started && pnlAlerta.Visible)
                {
                    Log("Parando grabación con problemas");
                    MostrarAlerta(false);
                    ResetGrabacion();
                }

            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }
        }

        private void Pausar()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.TextoEnPausa))
                AgregarMarca(string.Format(Properties.Settings.Default.TextoEnPausa, DateTime.Now));

            _estado = CaptureState.Paused;

            videoGrabber.PauseRecording();

            _marcaTiempoInicial = _marcaTiempoActual;

            lnkPausar.Visible = false;
            lnkResume.Visible = true;
            lnkResume.BringToFront();

            pnlBotonera.BackColor = Kenos.Common.Styles.ColorFondoTerciario;
            lblGrabando.ForeColor = Color.Red;
            lblGrabando.Text = "Pausado...";

            Log(string.Format("Grabación pausada [{0}]", lblDuracion.Text));
        }

        private void Reproducir()
        {
            Reproducir(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posicionInicio">Segundos donde se desea iniciar</param>
        private void Reproducir(long posicionInicio)
        {
            if (!string.IsNullOrEmpty(videoGrabber.RecordingFileName))
                videoGrabber.PlayerFileName = videoGrabber.RecordingFileName;
            else if (_metadata != null)
                videoGrabber.PlayerFileName = _metadata.FullFileName;
            else
                return;

            videoGrabber.PlayerAudioRendering = true;
            videoGrabber.FrameGrabber = VidGrab.TFrameGrabber.fg_Disabled;

            if (videoGrabber.RecordingMode == RecordingModes.Testing)
            {
                if (!_pruebaGrabacion.Verificada)
                    Log("Verificación de Prueba de grabación iniciada.");

                _pruebaGrabacion.Verificada = true;
            }

            if (posicionInicio == 0)
            {
                videoGrabber.OpenPlayer();
            }
            else
            {
                videoGrabber.OpenPlayerAtTimePositions(posicionInicio * 10000000, 0, true, true);
            }

            HabilitarForm();
        }

        private void ContinuarGrabacion()
        {
            Log("Continuando Grabación...");

            if (rdVideo.Checked)
            {
                videoGrabber.ResumeRecording();
            }
            else
            {
                videoGrabber.ResumeAudioRecording();
            }

            _estado = CaptureState.Started;
            lnkResume.Visible = false;
            lnkPausar.Visible = true;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.TextEnReanudar))
                AgregarMarca(string.Format(Properties.Settings.Default.TextEnReanudar, DateTime.Now));

            Log("Grabación continuada");
        }

        private void Finalizar()
        {
            Log("Iniciando proceso de finalización");

            Logger.Log.IncreaseLogIndentation();

            try
            {

                if (videoGrabber.RecordingMode == RecordingModes.Testing)
                {
                    if (_pruebaGrabacion.Verificada)
                    {
                        Log("Finalizando pruebas de grabación");

                        videoGrabber.RecordingMode = RecordingModes.Standard;

                        _pruebaGrabacion.Confirmar();

                        videoGrabber.Stop();

                        GuardarMarcas();

                        GuardarPrueba();

                        ResetGrabacion(false);
                    }
                    else
                    {
                        Log("Informando al usuario que debe reproducir la grabación para poder confirmarla");

                        MessageBox.Show(this, "Debe reproducir la grabación y verificar el correcto funcionamiento antes de poder confirmar la prueba de grabación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (_metadata != null)
                {
                    Log("Finalizando grabación de audiencia");

                    try
                    {
                        if (!string.IsNullOrEmpty(Properties.Settings.Default.TextoEnFin))
                            AgregarMarca(string.Format(Properties.Settings.Default.TextoEnFin, DateTime.Now));

                        if (videoGrabber.CurrentState == TCurrentState.cs_Playback)
                            videoGrabber.StopPlayer();

                        _metadata.MarcasTiempo = GetMarcasTiempo();

                        //Agrega metadata al archivo resultante.
                        AgregarMarcas();

                        Log("Generando hash...");
                        string hashSHA1 = WinHelper.GenerarHashSHA1(_metadata.FullFileName);

                        Log(string.Format("Archivo resultante: {0}", _metadata.FullFileName));
                        Log(string.Format("----- HASH SHA1: {0}", hashSHA1));

                        _metadata.HashFile = hashSHA1;

                        Log("Comenzando proceso de finalización de conector");

                        try
                        {
                            Logger.Log.IncreaseLogIndentation();

                            _connector.Finalizar(_metadata);
                        }
                        catch (Exception ex)
                        {
                            Logger.Log.Error("Error dentro del finalizar del connector");
                            Logger.Log.Error(ex);
                        }
                        finally
                        {
                            Logger.Log.DecreaseLogIndentation();
                        }

                        Log("Grabación finalizada");

                        ResetGrabacion();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log.Error("Error al confirmar grabación");
                        Logger.Log.Error(ex);

                        MessageBox.Show(this, "Error al confirmar grabación. " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error al finalizar grabación");
                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }
        }

        private void AddConnectorMenuItem(Common.IConnector connector)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(connector.Nombre);

            menuItem.BackColor = Kenos.Common.Styles.ColorFondoSecundario;
            menuItem.Image = Kenos.Win.Properties.Resources.item_connector;
            menuItem.ForeColor = Kenos.Common.Styles.ColorFuenteSecundario;
            menuItem.Click += menuConnnectorItem_Click;
            menuItem.Tag = connector;

            mnuNueva.Items.Add(menuItem);
        }

        private void ResetGrabacion()
        {
            ResetGrabacion(true);
        }

        private void ResetGrabacion(bool resetMetadata)
        {
            Log("Inicializando datos de grabación");

            _estado = CaptureState.NoSet;

            if (resetMetadata)
            {
                _metadata = null;
                lblArchivo.Text = "-";
                lblDescripcion.Text = "";
            }
            else
            {
                if (_metadata != null)
                {
                    _estado = CaptureState.Initialized;
                }
            }

            HabilitarForm();

            lblDuracion.Text = "00:00:00";
            lblTamanio.Text = "0MB";

            if (_dtMarcaTiempo != null)
                _dtMarcaTiempo.Clear();

            if (_pruebaGrabacion != null)
                _pruebaGrabacion.Cancelar();

            Log("Datos de grabación inicializados");
        }

        private bool Validar(ExtraConfig extraConfig)
        {
            if (extraConfig.Video)
            {
                if (!_config.IsValidToVideo())
                {
                    MessageBox.Show(this, "La configuración no es válida para comenzar a grabar video.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (!_config.IsValidToAudio())
                {
                    MessageBox.Show(this, "La configuración no es válida para comenzar a grabar audio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (extraConfig.Streaming)
            {
                if (!_config.StreamingSetting.IsValid())
                {
                    MessageBox.Show(this, "La configuración no es válida para iniciar la grabacion con Streaming", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private ExtraConfig GetExtraConfig()
        {
            ExtraConfig extraConfig = new ExtraConfig();

            extraConfig.Video = rdVideo.Checked;
            extraConfig.Streaming = chkStreaming.Checked;

            bool modoPrueba = videoGrabber.RecordingMode == RecordingModes.Testing;

            if (modoPrueba && _metadata == null)
            {
                 Config config = Config.Current;
                extraConfig.FileName = string.Format("{0}{1}."+config.VideoSettings[0].FormatOutput, Properties.Settings.Default.PathGrabacion, Guid.NewGuid());
                extraConfig.Etiqueta = "[Prueba]";
            }
            else
            {
                if (modoPrueba)
                {
                    if (File.Exists(_metadata.FullFileName))
                    {
                        FileInfo fi = new FileInfo(_metadata.FullFileName);

                        if (fi != null && fi.Exists && fi.Length > 0)
                        {
                            MessageBox.Show(this, "No puede iniciar el proceso de grabación porque el archivo donde se registrarán los datos ya fue utilizado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }
                    }
                }

                extraConfig.FileName = _metadata.FullFileName;
                extraConfig.Etiqueta = _metadata.Etiqueta;
            }

            return extraConfig;
        }

        private void InicializarMarcasTiempo()
        {
            _marcaTiempoActual = new TimeSpan();
            _marcaTiempoInicial = new TimeSpan();

            _dtMarcaTiempo.Clear();
            gvMarcas.AutoGenerateColumns = false;
            gvMarcas.DataSource = _dtMarcaTiempo;
        }

        private void MostrarAlerta(bool value)
        {
            if (value)
            {
                Log("Mostrando mensaje de Alerta. Mensaje: " + lblAlerta.Text);
                pnlAlerta.BringToFront();
                pnlAlerta.Visible = true;
            }
            else
            {
                if (pnlAlerta.Visible)
                {
                    pnlAlerta.Visible = false;
                    Log("Ocultando mensaje de Alerta. Mensaje: " + lblAlerta.Text);
                }
            }
        }

        private void HabilitarForm()
        {

            lnkNueva.Enabled = _estado == CaptureState.Initialized || _estado == CaptureState.NoSet;
            lnkGrabar.Enabled = _estado == CaptureState.Initialized && _pruebaGrabacion.Realizada;
            //lnkPausar.Enabled = _estado == CaptureState.Started && videoGrabber.RecordingMode == RecordingModes.Standard;
            lnkParar.Enabled = (_estado == CaptureState.Started && videoGrabber.RecordingMode == RecordingModes.Standard) || videoGrabber.CurrentState == TCurrentState.cs_Playback;
            lnkPlay.Enabled = _estado == CaptureState.Completed;
            lnkFinalizar.Enabled = _estado == CaptureState.Completed;
            lnkCancelar.Enabled = (_estado != CaptureState.NoSet);
            lnkTest.Enabled = _estado == CaptureState.Initialized || _estado == CaptureState.NoSet;

            if (lnkCancelar.Enabled && videoGrabber.RecordingMode == RecordingModes.Standard && Properties.Settings.Default.ConfirmacionAutomatica)
                lnkCancelar.Enabled = _estado != CaptureState.Started;

            btnAgregarMarca.Enabled = _estado == CaptureState.Initialized;

            lnkConfigurar.Enabled = _estado != CaptureState.Started && _estado != CaptureState.Paused;

            bool forzarModoGrabacion = false;

            if (_metadata != null)
                forzarModoGrabacion = _metadata.ForzarModoGrabacion;

            rdAudio.Enabled = _estado != CaptureState.Started && !forzarModoGrabacion;
            rdVideo.Enabled = _estado != CaptureState.Started && !forzarModoGrabacion;

            lblDuracion.Enabled = _estado == CaptureState.Started;
            lblTamanio.Enabled = _estado == CaptureState.Started;

            lnkResume.Visible = _estado == CaptureState.Paused;
            lnkPausar.Visible = _estado != CaptureState.Paused;

            if (lnkParar.Enabled)
            {
                if (videoGrabber.CurrentState == TCurrentState.cs_Playback)
                    toolTip.SetToolTip(lnkParar, "Para la reproducción actual");
                else
                    toolTip.SetToolTip(lnkParar, "Para la grabación actual");
            }

            pnlBotonera.BackColor = Kenos.Common.Styles.ColorFondoTerciario;
            lblGrabando.Visible = _estado == CaptureState.Started;
            lblGrabando.ForeColor = Color.Red;

            pnlOnvifMove.Enabled = (_estado == CaptureState.Started && videoGrabber.OnvifPTZDevices.Count > 0);
        }

        private void ConfigurarForm()
        {
            pnlSoloAudio.Location = videoGrabber.Location;
            pnlSoloAudio.Size = videoGrabber.Size;
            pnlSoloAudio.Visible = rdAudio.Checked;
            if (rdAudio.Checked)
                pnlSoloAudio.BringToFront();
            videoGrabber.Visible = rdVideo.Checked;

            videoGrabber.VuMeter = VidGrab.TVuMeter.vu_Bargraph;

            videoGrabber.SetVUMeterSetting(0, VidGrab.TVUMeterSetting.vu_BkgndColor, (IntPtr)0x000000); // VU_LEFT = 0, VU_RIGHT = 1
            videoGrabber.SetVUMeterSetting(0, VidGrab.TVUMeterSetting.vu_NormalColor, (IntPtr)0x00FF00); // VU_LEFT = 0, VU_RIGHT = 1
            videoGrabber.SetVUMeterSetting(0, VidGrab.TVUMeterSetting.vu_Handle, pnlVUMeter.Handle);

            if (_estado == CaptureState.Paused)
                lnkResume.Visible = true;
            else 
                lnkResume.Visible = false;
            lnkParar.Visible = true;

            toolTip.SetToolTip(chkStreaming, string.Format("Habilita la publicación de la audiencia en la url -> mms://{0}:{1}", Environment.MachineName, Config.Current.StreamingSetting.Port));
        }

        private void Probando(bool probando)
        {
            if (probando)
            {
                lblProbando.Font = new Font(lblProbando.Font.FontFamily, 14);

                lblProbando.Text = "Iniciando pruebas";
            }

            pnlProbando.Visible = probando;

            if (probando)
                videoGrabber.RecordingMode = RecordingModes.Testing;
            else
                videoGrabber.RecordingMode = RecordingModes.Standard;
        }

        private void Grabando(bool grabando)
        {
            rdAudio.Enabled = !grabando;
            rdVideo.Enabled = !grabando;

            lblDuracion.Enabled = grabando;
            lblTamanio.Enabled = grabando;
        }

        private string PositionToTime(TimeSpan ts)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        }

        private string PositionToTime(int position, out int hours, out int minutes, out int seconds)
        {
            seconds = position / 1000;
            minutes = seconds / 60;
            hours = minutes / 60;

            return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes % 60, seconds % 60);
        }

        private bool ValidarUsuarioConfig()
        {
            foreach (string userAdmin in Properties.Settings.Default.Administradores)
            {
                if (WindowsIdentity.GetCurrent().Name.Equals(userAdmin, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }

            foreach (string role in Properties.Settings.Default.Administradores)
            {
                if (SecurityHelper.IsInGroup(role))
                    return true;
            }

            MessageBox.Show(this, "El usuario actual no tiene permisos para poder modificar la configuración del sistema.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return false;

        }

        private bool AlertaEspacioDisco()
        {
            Log("Comprobando espacio en disco");
            Logger.Log.IncreaseLogIndentation();

            double espacio = WinHelper.GetEspacioLibreDisco();

            espacio = espacio / 1024 / 1024 / 1024;

            Log(string.Format("Espacio libre {0:N2}GB", espacio));

            Logger.Log.DecreaseLogIndentation();

            if (espacio < Properties.Settings.Default.AlertaEspacioLibre)
            {
                lblAlerta.Text = string.Format("El disco donde se graba la audiencia tiene poco espacio libre {0:N2}GB. Comuniquese con el responsable de informática", espacio);
                MostrarAlerta(true);

                return false;
            }

            return true;
        }

        public void AplicarStyles()
        {
            this.BackColor = Common.Styles.ColorFondoPrimario;

            pnlInfo.BackColor = Common.Styles.ColorFondoSecundario;
            LabelTamanio.ForeColor = Common.Styles.ColorFuenteSecundario;
            LabelArchivo.ForeColor = Common.Styles.ColorFuenteSecundario;
            LabelTiempo.ForeColor = Common.Styles.ColorFuenteSecundario;

            LabelDescripcion.ForeColor = Common.Styles.ColorFuentePrimario;

            gvMarcas.BackgroundColor = Common.Styles.ColorFondoSecundario;
            
        }
        #endregion

        #region Pruebas de grabación
        private void PruebaGrabacion_Cancelado(object sender, EventArgs e)
        {
            Probando(false);
        }

        private void PruebaGrabacion_Finalizado(object sender, EventArgs e)
        {
            Log("Prueba de grabación finalizada.");

            lblProbando.Text = "Finalizando pruebas de grabación";
            Parar();

            MessageBox.Show(this, "Verifique el sonido en las marcas de tiempo correspondientes.", "Prueba de grabación", MessageBoxButtons.OK, MessageBoxIcon.Information);


            lblProbando.Font = new Font(lblProbando.Font.FontFamily, 10);
            lblProbando.Text = "Pruebe que el sonido de cada micrófono se escuche correctamente. Luego presione el botón \"Confirmar\" para finalizar la prueba de grabación";

            lnkPlay.Visible = true;
        }

        private void PruebaGrabacion_Iniciando(object sender, EventArgs e)
        {
            Probando(true);

            if (!IniciarGrabacion())
            {
                _pruebaGrabacion.Cancelar();
            }
        }

        private void PruebaGrabacion_PasoPrueba(object sender, Test.PasoPruebaGrabacionEventArgs e)
        {
            lblProbando.Text = string.Format("Probando {0}...", e.CasoPrueba.Nombre);

            AgregarMarca(string.Format("Prueba de grabación {0}", e.CasoPrueba.Nombre));
        }
        #endregion

        #region Marcas de Tiempo
        private void gvMarcas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show(this, string.Format("¿Está seguro que desea borrar la marca de tiempo de {0}?", e.Row.Cells[0].FormattedValue), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        private void gvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (videoGrabber.CurrentState == TCurrentState.cs_Playback)
            {
                if (gvMarcas.CurrentRow != null)
                {
                    long seconds = (long)_dtMarcaTiempo.Rows[gvMarcas.CurrentRow.Index]["Posicion"];

                    Reproducir(seconds);
                }
            }
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (videoGrabber.CurrentState != TCurrentState.cs_Recording)
                return;

            AgregarMarca(txtDescripcion.Text, false);

            txtDescripcion.Text = "";
            txtDescripcion.Focus();
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAgregarMarca_Click(null, null);
        }

        private void AgregarMarcas()
        {
            if (_metadata != null)
            {
                try
                {
                    Log("Agregando marcas de tiempo al archivo resultante");

                    Kenos.TagsLib.KenosFile file = Kenos.TagsLib.KenosFile.Load(_metadata.FullFileName);

                    file.Description = _metadata.Descripcion;
                    file.Label = _metadata.Etiqueta;
                    file.KenosVersion = WinHelper.Version;

                    foreach (var r in _metadata.MarcasTiempo)
                    {
                        file.Tags.Add(new TagsLib.Tag()
                        {
                            Time = string.Format("{0:hh\\:mm\\:ss}", r.Tiempo),
                            Description = r.Descripcion
                        });
                    }

                    file.Save();

                    Log("... marcas guardadas satisfactoriamente");
                }
                catch (Exception ex)
                {
                    Logger.Log.Error(ex);
                }
            }
        }

        private void AgregarMarca(string texto, bool log = true)
        {
            DataRow row = _dtMarcaTiempo.NewRow();

            try
            {
                string tiempo = PositionToTime(_marcaTiempoActual);
                row["Posicion"] = _marcaTiempoActual.TotalSeconds;
                row["Tiempo"] = tiempo;
                row["Descripcion"] = texto;

                _dtMarcaTiempo.Rows.Add(row);

                if (log)
                    Log(string.Format("Marca de tiempo [{0}] - {1}", tiempo, texto));
                else
                    Log(string.Format("Marca de tiempo [{0}]", tiempo));
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }
        }

        private void GuardarMarcas()
        {

            if (_dtMarcaTiempo != null && _metadata != null)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(_metadata.FullFileName + ".xml", false))
                    {
                        _dtMarcaTiempo.DataSet.WriteXml(sw);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log.Error(ex);
                }
            }
        }

        private List<Common.MarcaTiempo> GetMarcasTiempo()
        {
            Log("Obteniendo marcas de tiempo");

            List<Common.MarcaTiempo> marcas = new List<Common.MarcaTiempo>();

            foreach (DataRow r in _dtMarcaTiempo.Rows)
            {
                Common.MarcaTiempo marca = new Common.MarcaTiempo();

                marca.Tiempo = new TimeSpan(0, 0, Convert.ToInt32(r["Posicion"]));
                marca.Descripcion = r["Descripcion"].ToString();

                marcas.Add(marca);
            }

            return marcas;
        }

        private DataTable CreateDataSourceMarcaTiempo()
        {
            DataTable dt = new DataTable("Marcas");

            dt.Columns.Add("Posicion", typeof(long));
            dt.Columns.Add("Tiempo", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));

            DataSet ds = new DataSet();

            ds.DataSetName = "Root";
            ds.Tables.Add(dt);

            return dt;
        }
        #endregion

        #region Eventos Video Grabber
        private void videoGrabber_OnDiskFull(object sender, EventArgs e)
        {
            lblAlerta.Text = "Alerta: El disco se encuentra lleno";

            MostrarAlerta(true);
        }

        private void videoCapture_OnDeviceLost(object sender, EventArgs e)
        {
            lblAlerta.Text = "Alerta: Existen problemas con la grabación de la audiencia";

            Pausar();

            MostrarAlerta(true);
        }

        private void videoGrabber_OnFrameProgress2(object sender, VidGrab.TOnFrameProgress2EventArgs e)
        {
            if (this.IsPaused)
                return;

            if (videoGrabber.CurrentState == VidGrab.TCurrentState.cs_Recording
                || videoGrabber.CurrentState == TCurrentState.cs_Playback)
            {
                TFrameInfo frameInfo = (TFrameInfo)Marshal.PtrToStructure((IntPtr)e.frameInfo, typeof(TFrameInfo));
                int h = 0;
                int m = 0;
                int s = 0;

                if (frameInfo.dVTimeCode_IsAvailable > 0) // if available
                {
                    h = frameInfo.dVTimeCode_Hour;
                    m = frameInfo.dVTimeCode_Min;
                    s = frameInfo.dVTimeCode_Sec;
                }else
                    if (frameInfo.dVDateTime_IsAvailable > 0) // if available
                    {
                        h = frameInfo.dVDateTime_Hour;
                        m = frameInfo.dVDateTime_Min;
                        s = frameInfo.dVDateTime_Sec;
                    }
                    else {
                        h = frameInfo.frameTime_Hour;
                        m = frameInfo.frameTime_Min;
                        s = frameInfo.frameTime_Sec;
                    }
                                
                

                TimeSpan ts = new TimeSpan(h, m, s).Add(_marcaTiempoInicial);

                lblDuracion.Text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);


                if (videoGrabber.CurrentState == VidGrab.TCurrentState.cs_Recording)
                {
                    if (!ts.Equals(_marcaTiempoActual))
                    {
                        if (_marcaTiempoActual.Ticks > 0 && ts < _marcaTiempoActual)
                        {
                            Log("ERROR: Se reseteó la posición del archivo");
                            Logger.Log.Error("ERROR: Se reseteó la posición del archivo");


                            lblAlerta.Text = "ERROR: Se reseteó la posición del archivo";
                            MostrarAlerta(true);
                        }

                        _marcaTiempoActual = ts;

                    }
                }
            }
        }

        private void videoGrabber_OnDeviceLost(object sender, EventArgs e)
        {
            lblAlerta.Text = "Alerta: Existen problemas con la grabación de la audiencia";
            MostrarAlerta(true);
        }

        private void videoGrabber_OnRecordingStarted(object sender, TOnFileNotificationEventArgs e)
        {
            lblGrabando.Text = "Grabando...";
        }
        #endregion

        #region Otors
        private void menuConnnectorItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            _connector = (Common.IConnector)menuItem.Tag;

            NuevaGrabacion();
        }

        private void timerRecording_Tick(object sender, EventArgs e)
        {
            if (videoGrabber.CurrentState != VidGrab.TCurrentState.cs_Recording)
                return;

            if (this.IsPaused)
                return;

            try
            {
                lblGrabando.Text = "Grabando...";

                if (pnlBotonera.BackColor == Kenos.Common.Styles.ColorFondoTerciario)
                {
                    pnlBotonera.BackColor = Color.Red;
                    lblGrabando.ForeColor = Color.White;
                }
                else
                {
                    pnlBotonera.BackColor = Kenos.Common.Styles.ColorFondoTerciario;
                    lblGrabando.ForeColor = Color.Red;
                }

                FileInfo fi = new FileInfo(videoGrabber.CurrentFileName);

                if (fi == null || !fi.Exists)
                    return;


                long size = fi.Length;
                bool fileOk = _fileMonitor.Verify(size);

                if (!fileOk)
                {
                    lblAlerta.Text = "Alerta: Existen problemas con la grabación de la audiencia";

                    MostrarAlerta(true);
                }

                long totalSize = videoGrabber.RecordingFileSize;

                lblTamanio.Text = string.Format("{0:N2}Mb", totalSize / 1024.00 / 1024.00);

                int count = 0;

                if (timerRecording.Tag != null)
                    count = (int)timerRecording.Tag;

                count++;

                // Cada 10 pasadas, guarda las marcas de tiempo
                if (count > 10)
                {
                    count = 0;
                 //   GuardarMarcas();
                }

                timerRecording.Tag = count;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                timerRecording.Stop();
            }
        }
        
        private void btnCerrarAlerta_Click(object sender, EventArgs e)
        {
            MostrarAlerta(false);
        }

        private void rdTipoGrabacion_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurarForm();
        }

        private void rdAudio_Click(object sender, EventArgs e)
        {
            Log("Seleccion de grabacion de audio");
        }

        private void rdVideo_Click(object sender, EventArgs e)
        {
            Log("Seleccion de grabacion de video");
        }
        #endregion

        #region Log
        private void Log(string template, params object[] param)
        {
            Log(string.Format(template, param));
        }

        private void Log(string log)
        {
            if (this.videoGrabber.RecordingMode == RecordingModes.Testing)
                log += " [Testing]";

            Logger.Log.Info(log);
        }

        private void LogKenosInformation()
        {
            Log("Kenos info:");

            Logger.Log.IncreaseLogIndentation();

            try
            {
                Log(string.Format("Path: {0}", AppDomain.CurrentDomain.BaseDirectory));
                Log(string.Format("Version: {0}", WinHelper.Version));
                Log(string.Format("MachineName: {0}", System.Environment.MachineName));
                Log(string.Format("AssemblyName: {0}", System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name));
                Log(string.Format("Username: {0}\\{1}", System.Environment.UserDomainName , System.Environment.UserName));
                Log(string.Format("OS: {0}", System.Environment.OSVersion));
                Log(string.Format("ConfirmacionAutomatica: {0}", Properties.Settings.Default.ConfirmacionAutomatica));
                Log(string.Format("PathGrabacion: {0}", Properties.Settings.Default.PathGrabacion));

            }
            catch (Exception ex)
            {
                Log("Error al loguear informacion de la aplicacion");
                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }
        }

        private void LogStartRecordingInfo(ExtraConfig extraConfig)
        {
            try
            {
                Logger.Log.Info("---------------------------");
                Logger.Log.Info("Datos de inicio de grabacion:");
                Logger.Log.IncreaseLogIndentation();

                Config config = Config.Current;

                Logger.Log.Info("Extra Settings");
                Logger.Log.IncreaseLogIndentation();
                Logger.Log.Info(string.Format("Streaming: {0}", extraConfig.Streaming));
                Logger.Log.Info(string.Format("Grabacion de Audio y Video: {0}", extraConfig.Video));
                Logger.Log.DecreaseLogIndentation();

                Logger.Log.Info("Audio Settings");
                config.AudioSetting.ToLog();


                Logger.Log.Info("Video Settings");
                Logger.Log.IncreaseLogIndentation();
                Logger.Log.Info(string.Format("VideoSourceCount: {0}", config.VideoSourceCount));
                
                for(int i =0; i<config.VideoSettings.Length; i++)
                {
                    VideoSetting videoSetting = config.VideoSettings[i];

                    if (videoSetting.IsEnabled)
                    {
                        Logger.Log.Info(string.Format("VideoConfig {0}", i));
                        videoSetting.ToLog();
                    }
                }

                Logger.Log.DecreaseLogIndentation();
                 
                

                Logger.Log.Info("---------------------------");
            }
            catch(Exception ex)
            {
                Log("Error al loguear informacion de inicio de grabación");
                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }
        }

        #endregion 

        private void chkStreaming_CheckedChanged(object sender, EventArgs e)
        {
            if (_estado == CaptureState.Started)
            {

                string mensaje = chkStreaming.Checked ?
                    "Para activar el streaming de la audiencia, se pausara y reiniciara el proceso de grabación. ¿Está seguro que desea continuar?"
                    : "Para desactivar el streaming de la audiencia, se pausara y reiniciara el proceso de grabación. ¿Está seguro que desea continuar?";

                DialogResult result = MessageBox.Show(this, mensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Log("Pausa por inicio de streaming");

                    Pausar();

                    videoGrabber.EnableStreaming = chkStreaming.Checked;

                    Log("Reinicio luego de activación de streaming");

                    ContinuarGrabacion();                    
                }
            }
            else 
            {
                videoGrabber.EnableStreaming = chkStreaming.Checked;
            }
        }

        private void lnkMoveLeft_MouseDown(object sender, MouseEventArgs e)
        {
            videoGrabber.MoveLeft();

        }

        private void lnkMove_MouseUp(object sender, MouseEventArgs e)
        {
            videoGrabber.MoveStop();
        }

        private void lnkMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            videoGrabber.MoveUp();
        }

        private void lnkMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            videoGrabber.MoveDown();
        }

        private void lnkMoveRight_MouseDown(object sender, MouseEventArgs e)
        {
            videoGrabber.MoveRight();
        }

        private void lnkMoveStartup_MouseClick(object sender, MouseEventArgs e)
        {
            videoGrabber.MoveStartUp();
        }

        private void videoGrabber_CurrentOnvifDeviceIndexChange(object sender, EventArgs e)
        {
            lnkSeleccionCamara.Text = string.Format("Cam.{0}", videoGrabber.CurrentOnvifIndex+1);
        }
        
        private void lnkSeleccionCamara_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (videoGrabber.OnvifPTZDevices.Count > 1)
            {
                int idx = videoGrabber.CurrentOnvifIndex;

                int newIndex = videoGrabber.OnvifPTZDevices.Find(x => x > idx);

                //Verifica que el indice exista en la lista de dispositivos (si no encuentra resultado devuelve 0)
                if (newIndex == 0)
                {
                    if (!videoGrabber.OnvifPTZDevices.Contains(newIndex))
                        newIndex = videoGrabber.OnvifPTZDevices[0];
                }

                videoGrabber.CurrentOnvifIndex = newIndex;
            }
        }

        private void videoGrabber_CriticalError(object sender, CriticalErrorEventArgs evt)
        {
            if (videoGrabber.CurrentState == TCurrentState.cs_Recording)
            {
                lblAlerta.Text = evt.Log.infoMsg;
                MostrarAlerta(true);
            }
        }

        private void GuardarPrueba()
        {
            string origen = videoGrabber.RecordingFileName;
            string ext = Path.GetExtension(origen);

            FileInfo fi = new FileInfo(origen);

            if (!fi.Exists)
                return;

            string destinoTemplate = fi.Directory.FullName + "\\Prueba.{0:yyyMMdd}.{1}" + ext;
            int i = 0;
            string destino = "";


            do
            {
                i++;
                destino = string.Format(destinoTemplate, DateTime.Now, i);
            }
            while (File.Exists(destino));

            try
            {
                File.Move(origen, destino);
                Logger.Log.Info(string.Format("Prueba de grabación guardada: {0}", destino));
            }
            catch (Exception ex)
            {
                Logger.Log.Error(new Exception("Error guardando archivo de prueba de grabación", ex));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            videoGrabber.StartPreview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            videoGrabber.StopPreview();
        }

        
    }
}
