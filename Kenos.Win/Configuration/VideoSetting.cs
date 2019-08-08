using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenos.Win
{
    [Serializable]
    public class VideoSetting
    {
        public string VideoSource { get; set; }

        public bool IsEnabled { get; set; }

        //Camara Digital/Analogica
        public string VideoDevice { get; set; }
        public string VideoSize { get; set; }
        public string VideoFormatSubType { get; set; }
        public string VideoNorma { get; set; }

        //Camara IP
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }
        public string StreamUrl { get; set; }
        public string PresetStartupPosition { get; set; }

        public VideoSetting() 
        {
            this.IsEnabled = false;
        }

        internal void Clean()
        {
            this.VideoDevice = "";
            this.VideoSize = "";
            this.VideoFormatSubType = "";
            this.VideoNorma = "";

            this.Host = "";
            this.Port = 0;
            this.Profile = "";
            this.PresetStartupPosition = "";
            this.StreamUrl = "";
            this.Username = "";
            this.Password = "";
        }

        public bool IsValid()
        {
            if (this.IsEnabled)
            {

                if (this.VideoSource == VideoSources.IpCamera)
                {
                    return !string.IsNullOrEmpty(this.StreamUrl);
                }
                else
                {
                    return !string.IsNullOrEmpty(this.VideoDevice);
                }
            }
            else
            {
                return false;
            }
        }

        public bool Apply(VidGrab.VideoGrabber capture)
        {
            if (this.VideoSource == VideoSources.IpCamera)
            {
                if (string.IsNullOrEmpty(this.StreamUrl))
                {
                    string message = "No se puede iniciar la grabación porque no tiene configurado la URL de la camara IP.";
                    Logger.Log.Info(message);

                    MessageBox.Show(message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }

                capture.VideoSource = VidGrab.TVideoSource.vs_IPCamera;
                capture.IPCameraURL = this.StreamUrl;

                if (!string.IsNullOrEmpty(this.Username))
                {
                    capture.SetAuthentication(VidGrab.TAuthenticationType.at_IPCamera, this.Username, this.Password);
                }
            }
            else
            {
                capture.VideoSource = VidGrab.TVideoSource.vs_VideoCaptureDevice;

                if (string.IsNullOrEmpty(this.VideoDevice))
                {
                    string message = "No se puede iniciar la grabación porque no tiene configurado un dispositivo de grabación.";
                    Logger.Log.Info(message);

                    MessageBox.Show(message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }

                // Captura de audio y video
                capture.VideoDevice = capture.FindIndexInListByName(capture.VideoDevices, this.VideoDevice, false, true);

                if (capture.VideoDevice == -1)
                {
                    MessageBox.Show("No se puede iniciar la grabación porque no tiene configurado un dispositivo de grabación.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }

                capture.VideoSize = capture.FindIndexInListByName(capture.VideoSizes, this.VideoSize, false, true);
                capture.VideoSubtype = capture.FindIndexInListByName(capture.VideoSubtypes, this.VideoFormatSubType, false, true);

                if (!string.IsNullOrEmpty(this.VideoNorma))
                    capture.AnalogVideoStandard = capture.FindIndexInListByName(capture.AnalogVideoStandards, this.VideoNorma, false, true);
            }

            return true;
        }

        internal void ToLog()
        {
            try
            {
                Logger.Log.IncreaseLogIndentation();

                if (this.IsEnabled)
                {
                    Logger.Log.Info(string.Format("VideoSource: {0}", this.VideoSource));

                    if (this.VideoSource == VideoSources.IpCamera)
                    {
                        Logger.Log.Info(string.Format("Host: {0}, Port: {1}, Username: {2}, Pw: {3}, PresetStartupPosition: {4}, Profile: {5}, StreamURL: {6}", 
                            this.Host,
                            this.Port, 
                            this.Username,
                            this.Password, 
                            this.PresetStartupPosition, 
                            this.Profile, 
                            this.StreamUrl
                            ));
                    }
                    else
                    {
                        Logger.Log.Info(string.Format("VideoDevice: {0}, VideoSize: {1}, VideoNorma: {2}, VideoFormatSubType:{3}", 
                            this.VideoDevice,
                            this.VideoSize, 
                            this.VideoNorma, 
                            this.VideoFormatSubType));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error al loguear informacion de Audio Setting");
                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }
        }
    }
}
