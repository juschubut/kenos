using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenos.Win
{
    [Serializable]
    public class AudioSetting
    {
        public string AudioDevice { get; set; }
        public string AudioFormat { get; set; }
        public string AudioOutputDevice { get; set; }
        public string AudioDeviceLine { get; set; }
        public bool AudioDeviceRendering { get; set; }

        public AudioSetting()
        {
        }

        public void LoadDefaults()
        {
        }

        public bool IsValid() 
        {
            if (!Config.Current.OutputSetting.UseAudioFromCamera)
            {
                if (string.IsNullOrEmpty(this.AudioDevice))
                    return false;
            }

            if (string.IsNullOrEmpty(this.AudioOutputDevice) && this.AudioDeviceRendering)
                return false;

            return true;
        }

        public bool Apply(VidGrab.VideoGrabber capture)
        {
            capture.AudioRecording = true;
            capture.AudioDeviceRendering = this.AudioDeviceRendering;

            if (!Config.Current.OutputSetting.UseAudioFromCamera)
            {
                capture.AudioDevice = capture.FindIndexInListByName(capture.AudioDevices, this.AudioDevice, false, true);

                capture.AudioRenderer = capture.FindIndexInListByName(capture.AudioRenderers, this.AudioOutputDevice, false, true);
                capture.AudioInput = capture.FindIndexInListByName(capture.AudioInputs, this.AudioDeviceLine, false, true);
                capture.AudioFormat = (VidGrab.TAudioFormat)capture.FindIndexInListByName(capture.AudioFormats, this.AudioFormat, false, true);

                capture.AudioInputLevel = 65535; // Maximo valor

                if (capture.AudioDevice < 0)
                {
                    string message = "No se encontró el dispositivo de grabación de audio";

                    Logger.Log.Info(message);

                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }


        internal void ToLog()
        {
            try
            {
                Logger.Log.IncreaseLogIndentation();

                Logger.Log.Info(string.Format("AudioDevice: {0}", this.AudioDevice));
                Logger.Log.Info(string.Format("AudioDeviceLine: {0}", this.AudioDeviceLine));
                Logger.Log.Info(string.Format("AudioDeviceRendering: {0}", this.AudioDeviceRendering));
                Logger.Log.Info(string.Format("AudioFormat: {0}", this.AudioFormat));
                Logger.Log.Info(string.Format("AudioOutputDevice: {0}", this.AudioOutputDevice));
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
