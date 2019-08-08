using Kenos.Onvif.Operations;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VidGrab;

namespace Kenos.Win.Controls.VideoGrabberControl
{
    public class VideoGrabberBaseWrapper : VidGrab.VideoGrabber
    {
        public Onvif.OnvifDevice OnvifDevice { get; private set; }

        public VideoSetting VideoSettings { get; private set; }

        #region Delegates
        public event CriticalErrorEventHandler CriticalError;
        #endregion 

        public VideoGrabberBaseWrapper()
        {
            this.LicenseString = Properties.Settings.Default.DatasteadLicenseKey;
            this.LicenseString = Properties.Settings.Default.DatasteadLicenseKeyRTSP;

            #region Eventos Attachs
            this.OnLog += videoGrabber_OnLog;
            this.OnDeviceLost += VideoGrabberBaseWrapper_OnDeviceLost;
            #endregion
        }

        void VideoGrabberBaseWrapper_OnDeviceLost(object sender, EventArgs e)
        {
            string msg = string.Format("[{0}] Se perdió conexion con el dispositivo", this.Name);

            Log(msg);

            OnCriticalError(new TOnLogEventArgs
            {
                severity = "ERROR",
                infoMsg = msg,
                logType = TLogType.e_no_device_available,
                sender = System.IntPtr.Zero
            });
        }
        
        #region Log
        private void videoGrabber_OnLog(object sender, VidGrab.TOnLogEventArgs e)
        {
            if (e.logType == TLogType.i_discovering_device)
                return;

            Log(string.Format("[{0}] {1} - {2}", this.Name, e.severity, e.infoMsg));

            if (e.logType == TLogType.i_streaming_client_disconnected)
            {
                VideoGrabberBaseWrapper_OnDeviceLost(sender, new EventArgs());
                return;
            }

            if (e.severity.Equals("ERROR", StringComparison.InvariantCultureIgnoreCase)
                || e.logType == TLogType.w_server_lost_next_retry)
            {
                OnCriticalError(e);
            }
        }

        void OnvifDevice_OnLog(object sender, Onvif.Events.OnLogEventArgs e)
        {
            Log(string.Format("[ONVIF] - {0}", e.Message));

            if (e.Exception != null)
                Log(string.Format("-------- [ONVIF-Exeption] - {0}", e.Exception.Message));
        }

        protected virtual void Log(string log)
        {
            Logger.Log.Info(log);
        }

        protected virtual void Log(string template, params object[] param)
        {
            Log(string.Format(template, param));
        }
        #endregion

        #region Configure
        
        public bool ConfigureVideoGrabberToVideo(VideoSetting setting)
        {
            bool isValid = setting.Apply(this);

            this.VideoSettings = setting;
            this.OnvifDevice = null;

            if (isValid)
            {

                if (setting.VideoSource == Kenos.Win.VideoSources.IpCamera)
                {
                    this.OnvifDevice = new Onvif.OnvifDevice(setting.Host, setting.Port, setting.Username, setting.Password);

                    this.OnvifDevice.OnLog += OnvifDevice_OnLog;

                    OperationResponse rs = this.OnvifDevice.Ping();

                    if (rs.IsSuccess)
                    {

                        if (!string.IsNullOrEmpty(setting.PresetStartupPosition))
                        {
                            this.OnvifDevice.GoToPreset(setting.PresetStartupPosition);
                        }
                    }
                    else
                    {
                        this.Log("No se puede conectar realizar la conexion ONVIF");
                        /*
                        isValid = false;

                        MessageBox.Show(rs.Message, "ONVIF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         * */
                    }



                    // TODO Corroborar si en versiones mas nuevas no hace falta este fix
                    // Fix: Activo esta opcion cuando uso camara IP sin modo nativo. Sino no se guarda el auto.
                    if (Config.Current.OutputSetting.UseAudioFromCamera)
                    {
                        this.AudioDeviceRendering = true;
                        Config.Current.AudioSetting.AudioDeviceRendering = true;

                    }
                }


               
            }

            return isValid;
        }

        #endregion

        #region Raise Events
        private void OnCriticalError(VidGrab.TOnLogEventArgs e)
        {
            if (this.CriticalError != null)
            {
                OnCriticalError(this, new CriticalErrorEventArgs(this.Name, e));
            }
        }

        protected void OnCriticalError(object sender, CriticalErrorEventArgs e)
        {
            if (this.CriticalError != null)
            {
                this.CriticalError(sender, e);
            }
        }
        #endregion

    }
}
