using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenos.Win
{
    [Serializable]
    public class OutputVideoSetting
    {
        public string Format { get; set; }
        public bool UseNativeFormat { get; set; }

        public OutputVideoSetting.ConfigMP4 _mp4 { get; set; }
        public OutputVideoSetting.ConfigWMV _wmv { get; set; }

        public OutputVideoSetting()
        {
            if (string.IsNullOrWhiteSpace(this.Format))
                this.Format = "wmv";
            
            this.UseNativeFormat = false;
        }

        public OutputVideoSetting.ConfigMP4 Mp4
        {
            get
            {
                if (_mp4 == null)
                    _mp4 = new OutputVideoSetting.ConfigMP4();
                return _mp4;
            }
            set { _mp4 = value; }
        }

        public OutputVideoSetting.ConfigWMV WMV
        {
            get
            {
                if (_wmv == null)
                    _wmv = new OutputVideoSetting.ConfigWMV();
                return _wmv;
            }
            set { _wmv = value; }
        }

        #region Inner Class
        [Serializable]
        public abstract class OutputVideoConfig
        {
            public abstract bool Apply(VidGrab.VideoGrabber capture, ExtraConfig extraConfig);

            public abstract void LoadDefaults();
        }

        [Serializable]
        public class ConfigWMV : OutputVideoConfig
        {
            public int VideoBitRate { get; set; }
            public int VideoQuality { get; set; }
            public double FramesRate { get; set; }

            public override bool Apply(VidGrab.VideoGrabber capture, ExtraConfig extraConfig)
            {
                capture.RecordingMethod = VidGrab.TRecordingMethod.rm_ASF;

                capture.FrameRate = this.FramesRate;
                capture.ASFVideoFrameRate = this.FramesRate;
                capture.ASFVideoBitRate = this.VideoBitRate;
                capture.ASFVideoQuality = this.VideoQuality;

                if (Properties.Settings.Default.WmvProfileVersion == 8)
                    capture.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_8;
                else
                    capture.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_9;


                capture.CompressionType = VidGrab.TCompressionType.ct_AudioVideo;
                capture.CompressionMode = VidGrab.TCompressionMode.cm_CompressOnTheFly;
               
                return true;
            }

            public override void LoadDefaults()
            {
                if (this.VideoBitRate == 0)
                    this.VideoBitRate = Properties.Settings.Default.WmvVideoBitRates;
                if (this.VideoQuality == 0)
                    this.VideoQuality = Properties.Settings.Default.WmvVideoQuality;
                if (this.FramesRate == 0)
                    this.FramesRate = Properties.Settings.Default.FrameRatePredeterminado;
            }

            public bool IsValid()
            {
                return true;
            }
        }

        [Serializable]
        public class ConfigMP4 : OutputVideoConfig
        {
            public string AudioCompressor { get; set; }
            public string VideoCompressor { get; set; }

            public override bool Apply(VidGrab.VideoGrabber capture, ExtraConfig extraConfig)
            {
                bool isValid = true;
                bool audioCompress = false;
                bool videoCompress = false;
                var output = Config.Current.OutputSetting;

                capture.RecordingMethod = VidGrab.TRecordingMethod.rm_MP4;

                if (!output.Video.UseNativeFormat)
                {
                    videoCompress = true;
                    isValid = OutputSetting.ConfigureVideoCompressor(capture, this.VideoCompressor);
                }

                if (!isValid)
                    return false;

                if (output.Video.UseNativeFormat && !Config.Current.OutputSetting.UseAudioFromCamera)
                {
                    audioCompress = true;
                    isValid = OutputSetting.ConfigureAudioCompressor(capture, this.AudioCompressor);
                }

                if (!isValid)
                    return false;

                if (videoCompress && audioCompress)
                {
                    capture.CompressionType = VidGrab.TCompressionType.ct_AudioVideo;
                    capture.CompressionMode = VidGrab.TCompressionMode.cm_CompressOnTheFly;
                }
                else if (videoCompress)
                {
                    capture.CompressionType = VidGrab.TCompressionType.ct_Video;
                    capture.CompressionMode = VidGrab.TCompressionMode.cm_CompressOnTheFly;
                }
                else if (audioCompress)
                {
                    capture.CompressionType = VidGrab.TCompressionType.ct_Audio;
                    capture.CompressionMode = VidGrab.TCompressionMode.cm_CompressOnTheFly;
                }

                return true;
            }

            public override void LoadDefaults()
            {
                if (string.IsNullOrWhiteSpace(this.AudioCompressor))
                    this.AudioCompressor = "MONOGRAM AAC Encoder";
            }

            public bool IsValid()
            {
                if (Config.Current.OutputSetting.Video.UseNativeFormat)
                    return true;

                if (string.IsNullOrWhiteSpace(this.AudioCompressor))
                {
                    MessageBox.Show("No se encontró configuración para compresion de audio en mp4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(this.VideoCompressor))
                {
                    MessageBox.Show("No se encontró configuración para compresion de video en mp4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
        }
        #endregion

        internal bool Apply(VidGrab.VideoGrabber capture, ExtraConfig extraConfig)
        {
            capture.VideoRenderer = VidGrab.TVideoRenderer.vr_AutoSelect;
            capture.DVTimeCodeEnabled = false;
            capture.DVDateTimeEnabled = false;

            // TODO: Ver como hacer para agregar audio de entrada de linea utilizando esta opcion
            capture.RecordingInNativeFormat = this.UseNativeFormat;
            
            if (this.Format == "mp4")
            {
                return this.Mp4.Apply(capture, extraConfig);
            }
            else
            {
                return this.WMV.Apply(capture, extraConfig);
            }
        }
    }

    [Serializable]
    public class OutputSetting
    {
        public string AudioCompressor { get; set; }
        public string AudioFormat { get { return "mp3"; } }
        public bool UseAudioFromCamera { get; set; }

        private OutputVideoSetting _video;
        public OutputVideoSetting Video 
        {
            get 
            {
                if (_video == null)
                    _video = new OutputVideoSetting();

                return _video;
            }
            set { _video = value; }
        }

        public OutputSetting() 
        {
            this.LoadDefaults();
        }

        public void LoadDefaults()
        {
            this.Video.Mp4.LoadDefaults();
            this.Video.WMV.LoadDefaults();

            if (string.IsNullOrWhiteSpace(this.AudioCompressor))
                this.AudioCompressor = "LAME Audio Encoder";
        }

        public bool Apply(VidGrab.VideoGrabber capture, ExtraConfig extraConfig)
        {
            if (extraConfig.Video)
                return ConfigureToVideoOutput(capture, extraConfig);
            else
                return ConfigureToAudioOutput(capture, extraConfig);            
        }

        private bool ConfigureToVideoOutput(VidGrab.VideoGrabber capture, ExtraConfig extraConfig)
        {
            this.Video.Apply(capture, extraConfig);

            // capture.ASFFixedFrameRate = true;
            capture.FrameGrabber = VidGrab.TFrameGrabber.fg_Disabled;
            
            if (Properties.Settings.Default.TextoVideoHabilitado)
            {
                int target = 0;

                capture.SetTextOverlay_TargetDisplay(target, -1);

                Font font = new Font(FontFamily.GenericSansSerif, Properties.Settings.Default.TextoVideoFontSize, FontStyle.Regular);

                capture.SetTextOverlay_Top(target, 0);
                capture.SetTextOverlay_Left(target, -1);
                capture.SetTextOverlay_Right(target, 0);
                capture.SetTextOverlay_Font(target, font.ToHfont());
                capture.SetTextOverlay_HighResFont(target, false);
                capture.SetTextOverlay_VideoAlignment(target, VidGrab.TVideoAlignment.oa_RightBottom);
                capture.SetTextOverlay_Shadow(target, false);
                capture.SetTextOverlay_Transparent(target, false);
                capture.SetTextOverlay_BkColor(target, ColorTranslator.ToWin32(Color.Black));
                capture.SetTextOverlay_FontColor(target, ColorTranslator.ToWin32(Color.White));
                capture.SetTextOverlay_String(target, string.Format(Properties.Settings.Default.TextoVideoTemplate, extraConfig.Etiqueta));

                capture.SetTextOverlay_Enabled(target, true);

                capture.FrameGrabber = VidGrab.TFrameGrabber.fg_CaptureStream;
            }
            else
            {
                capture.FrameGrabber = VidGrab.TFrameGrabber.fg_Disabled;
            }
            
            return true;
        }

        private bool ConfigureToAudioOutput(VidGrab.VideoGrabber capture, ExtraConfig extraConfig)
        {
            Config config = Config.Current;

            // Captura de audio
            capture.VideoRenderer = VidGrab.TVideoRenderer.vr_None;

            capture.CompressionMode = VidGrab.TCompressionMode.cm_CompressOnTheFly;
            capture.CompressionType = VidGrab.TCompressionType.ct_Audio;
            capture.RecordingInNativeFormat = false;
            capture.RecordingMethod = VidGrab.TRecordingMethod.rm_AVI;

            bool isValid = ConfigureAudioCompressor(capture, this.AudioCompressor);

            return isValid;
        }

        internal static bool ConfigureAudioCompressor(VidGrab.VideoGrabber capture, string compressor)
        {
            capture.AudioCompressor = capture.FindIndexInListByName(capture.AudioCompressors, compressor, false, true);

            if (capture.AudioCompressor == -1)
            {
                MessageBox.Show("Para grabar solo audio en formato MP3 se requiere \"LAME Audio Encoder\"", "Audio Encoder", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        internal static bool ConfigureVideoCompressor(VidGrab.VideoGrabber capture, string compressor)
        {
            capture.VideoCompressor = capture.FindIndexInListByName(capture.VideoCompressors, compressor, false, true);

            if (capture.VideoCompressor == -1)
            {
                MessageBox.Show("No se encontro el compresor de video", "Video Encoder", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        public bool IsValid()
        {
            if (this.Video.Format == "mp4")
                return this.Video.Mp4.IsValid();
            else
                return this.Video.WMV.IsValid();
        }

        public string CreateTemporalFullFileName(bool isVideoOutput)
        {
            var ext = OutputFileExtension(isVideoOutput);

            return string.Format("{0}{1}.{2}", Properties.Settings.Default.PathGrabacion, Guid.NewGuid(), ext);
        }

        public string OutputFileExtension(bool videoOutput)
        {
            if (videoOutput)
                return this.Video.Format;
            else
                return this.AudioFormat;
        }
    }
}
