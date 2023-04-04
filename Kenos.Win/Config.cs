using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace Kenos.Win
{
    [Serializable]
    public class Config
    {
        [NonSerialized]
        private static Config _instance = Load();
        [NonSerialized]
        private static string _configFileName;

         
        public static string ConfigFileName 
        {
            get
            {
                if (string.IsNullOrEmpty(_configFileName))
                {
                    _configFileName = AppDomain.CurrentDomain.BaseDirectory + "Kenos.data";
                }

                return _configFileName;
            }
            set { _configFileName = value; }        
        }

        //Video
        public string VideoDevice { get; set; }
        public string VideoSize { get; set; }
        public string VideoFormatSubType { get; set; }
        public double FramesRate { get; set; }
        public string VideoNorma { get; set; }
        public int VideoBitRate { get; set; }
        public int VideoQuality { get; set; }
        
        //Audio
        public string AudioDevice { get; set; }
        public string AudioFormat { get; set; }
        public string AudioOutputDevice { get; set; }
        public string AudioDeviceLine { get; set; }
        public string AudioCompressor { get; set; }
        public bool AudioDeviceRendering { get; set; }

        //Output
        //public string WmvProfile { get; set; }


        private Config()
        {
            this.FramesRate = Properties.Settings.Default.FrameRatePredeterminado;
            this.VideoBitRate = Properties.Settings.Default.WmvVideoBitRates;
            this.VideoQuality = Properties.Settings.Default.WmvVideoQuality;
            this.AudioCompressor = Properties.Settings.Default.AudioCompressor;
            this.AudioDeviceRendering = false;
        }

        
        public static Config Current { get { return _instance; } }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(this.AudioDevice))
                return false;

            if (string.IsNullOrEmpty(this.AudioOutputDevice))
                return false;

            //if (string.IsNullOrEmpty(this.WmvProfile))
            //    return false;


            return true;
        }

        public bool IsValidToVideo()
        {
            bool result = this.IsValid();



            return result;
        }

        public bool IsValidToAudio()
        {
            bool result = this.IsValid();

            if (string.IsNullOrEmpty(this.AudioDevice))
                return false;

            if (string.IsNullOrEmpty(this.AudioFormat))
                return false;

            return result;
        }

        public bool Configure(VidGrab.VideoGrabber capture, CaptureConfig extraConfig)
        {
            string pathRoot = Path.GetDirectoryName(extraConfig.FileName);
            string fileName = Path.GetFileNameWithoutExtension(extraConfig.FileName);

            capture.VideoSize = -1;

            if (extraConfig.Video)
            {
                if (string.IsNullOrEmpty(this.VideoDevice))
                {
                    MessageBox.Show("No se puede iniciar la grabación porque no tiene configurado un dispositivo de grabación.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                } 
                
                capture.RecordingMethod = VidGrab.TRecordingMethod.rm_ASF;

                // Captura de audio y video
                capture.VideoDevice = capture.FindIndexInListByName(capture.VideoDevices, this.VideoDevice, false, true);

                if (capture.VideoDevice == -1)
                {
                    MessageBox.Show("No se puede iniciar la grabación porque no tiene configurado un dispositivo de grabación.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                } 

                capture.VideoSize = capture.FindIndexInListByName(capture.VideoSizes, this.VideoSize, false, true);
                capture.VideoSubtype = capture.FindIndexInListByName(capture.VideoSubtypes, this.VideoFormatSubType, false, true);

                capture.FrameRate = this.FramesRate;
                capture.ASFVideoFrameRate = this.FramesRate;
                capture.ASFVideoBitRate = this.VideoBitRate;
                capture.ASFVideoQuality = this.VideoQuality;
                
                //capture.ASFAudioChannels = 1;

                capture.VideoRenderer = VidGrab.TVideoRenderer.vr_AutoSelect;

                if (Properties.Settings.Default.WmvProfileVersion == 8)
                {
                    capture.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_8;
                }
                else
                {
                    capture.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_9;
                }
                                     

                //capture.UseNearestVideoSize(640, 480, false);
                capture.RecordingFileName = string.Format("{0}\\{1}.wmv", pathRoot, fileName);
                

               // capture.ASFFixedFrameRate = true;
                capture.FrameGrabber = VidGrab.TFrameGrabber.fg_Disabled;

                if (!string.IsNullOrEmpty(this.VideoNorma))
                    capture.AnalogVideoStandard = capture.FindIndexInListByName(capture.AnalogVideoStandards, this.VideoNorma, false, true);

                
                if (Properties.Settings.Default.TextoVideoHabilitado)
                {
                    int target = 0;

                    capture.SetTextOverlay_TargetDisplay(target, -1);

                    Font font = new Font(FontFamily.GenericSansSerif, Properties.Settings.Default.TextoVideoFontSize, FontStyle.Regular);

                    capture.SetTextOverlay_Top(target, 0);
                    capture.SetTextOverlay_Left(target, -1);
                    capture.SetTextOverlay_Right(target, 0);
                    capture.SetTextOverlay_Font(target,  font.ToHfont());
                    capture.SetTextOverlay_HighResFont(target, false);
                    capture.SetTextOverlay_VideoAlignment(target, VidGrab.TVideoAlignment.oa_RightBottom);
                    capture.SetTextOverlay_Shadow(target, false);
                    capture.SetTextOverlay_Transparent(target, false);
                    capture.SetTextOverlay_BkColor(target, ColorTranslator.ToWin32(Color.Black));
                    capture.SetTextOverlay_FontColor(target, ColorTranslator.ToWin32(Color.White));
                    capture.SetTextOverlay_String(target, string.Format(Properties.Settings.Default.TextoVideoTemplate, extraConfig.Etiqueta));

                    capture.SetTextOverlay_Enabled(target, true);
                }
            }
            else
            {
                // Captura de audio
                capture.VideoRenderer = VidGrab.TVideoRenderer.vr_None;

                capture.CompressionMode = VidGrab.TCompressionMode.cm_CompressOnTheFly;
                capture.CompressionType = VidGrab.TCompressionType.ct_Audio;
                capture.RecordingInNativeFormat = false;
                capture.RecordingMethod = VidGrab.TRecordingMethod.rm_AVI;
                capture.RecordingFileName = string.Format("{0}\\{1}.mp3", pathRoot, fileName);
                
                capture.AudioCompressor = capture.FindIndexInListByName(capture.AudioCompressors, this.AudioCompressor, false, true);

                if (capture.AudioCompressor == -1)
                {
                    MessageBox.Show("Para grabar solo audio en formato MP3 se requiere \"LAME Audio Encoder\"", "Audio Encoder", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            }

            capture.AudioDevice = capture.FindIndexInListByName(capture.AudioDevices, this.AudioDevice, false, true);

            if (capture.AudioDevice == -1)
            {
                MessageBox.Show("No se encontró el dispositivo de grabación de audio.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            } 

            capture.AudioRenderer = capture.FindIndexInListByName(capture.AudioRenderers, this.AudioOutputDevice, false, true);
            capture.AudioRecording = true;
            capture.AudioInput = capture.FindIndexInListByName(capture.AudioInputs, this.AudioDeviceLine, false, true);
            capture.AudioFormat = (VidGrab.TAudioFormat)capture.FindIndexInListByName(capture.AudioFormats, this.AudioFormat, false, true);
            capture.AudioInputLevel = 65535; // Maximo valor

            capture.PlayerAudioRendering = false;
            capture.AudioDeviceRendering = this.AudioDeviceRendering;
            capture.RecordingCanPause = false;
            
 
            // TODO: Ver de poder hacer streaming del audio.
            capture.NetworkStreaming = VidGrab.TNetworkStreaming.ns_Disabled;

            if (Properties.Settings.Default.TextoVideoHabilitado)
            {
                capture.FrameGrabber = VidGrab.TFrameGrabber.fg_CaptureStream;
            }
            else
            {
                capture.FrameGrabber = VidGrab.TFrameGrabber.fg_Disabled;
            }

            return true;
        }

        public void Save()
        {
            try
            {
                Logger.Log.Info("Grabando configuración");

                using (FileStream fs = new FileStream(ConfigFileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(fs, this);
                }
            }
            catch (Exception ex)
            {
                Kenos.Logger.Log.Error("No se pudo guardar la configuración");
                Kenos.Logger.Log.Error(ex);
            }
        
        }

        private static Config Load()
        {
            try
            {
                Logger.Log.Info("Iniciando carga de configuración");

                Config c = null;

                if (File.Exists(ConfigFileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(ConfigFileName, FileMode.Open))
                    {
                        c = (Config)formatter.Deserialize(fs);
                    }
                }
                else 
                {
                    c = new Config();
                }

                return c;
            }
            catch (Exception ex)
            {
                Kenos.Logger.Log.Error("No se pudo cargar la configuración");
                Kenos.Logger.Log.Error(ex);

                return new Config();
            }
        }

        
    }
}
