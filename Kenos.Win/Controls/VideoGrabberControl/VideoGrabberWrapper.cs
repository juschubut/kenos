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
    public class VideoGrabberWrapper : VideoGrabberBaseWrapper
    {
        #region Controls
        private Panel pnlReencodingProgress;
        private Label lblReencodingProgress;
        private Label label1;
        private ProgressBar prgReencoding;
        #endregion

        #region Private members
        private bool _videoReencoding = false;
        private RecordingFile _output = null;
        private int _currentOnvifIndex = 0;

        private List<VideoGrabberBaseWrapper> _mixerSources;
        #endregion 

        #region Delegates
        public event CurrentOnvifDeviceIndexChangeEventHandler CurrentOnvifDeviceIndexChange;
        #endregion 

        #region Properties
        public RecordingModes RecordingMode { get; set; }

        public int CurrentOnvifIndex { get { return _currentOnvifIndex; } set { _currentOnvifIndex = value; OnCurrentOnvifDeviceIndexChange(); } }

        public List<int> OnvifPTZDevices { get; private set; }

        public string CurrentFileName
        {
            get
            {
                if (_output != null)
                    return _output.CurrentFileName;
                else
                    return "";
            }
        }

        public long RecordingFileSize
        {
            get
            {
                if (_output != null)
                    return _output.TotalFileSize;
                else
                    return 0;
            }
        }

        public bool EnableStreaming
        {
            get { return this.NetworkStreaming == TNetworkStreaming.ns_ASFDirectNetworkStreaming; }
            set
            {
                ConfigureStreaming(value);
            }
        }

        public Onvif.OnvifDevice CurrentOnvifDevice
        {
            get
            {
                if (this.CurrentOnvifIndex >= 0 && _mixerSources != null)
                    return _mixerSources[this.CurrentOnvifIndex].OnvifDevice;
                else
                    return null;
                
            }
        }

        public VideoGrabberBaseWrapper CurrentDevice
        {
            get
            {
                if (this.CurrentOnvifIndex >= 0 && _mixerSources != null)
                    return _mixerSources[this.CurrentOnvifIndex];
                else
                    return null;
            }
        }

        #endregion

        public VideoGrabberWrapper()
        {
            this.InitializeComponent();

            this.LicenseString = Properties.Settings.Default.DatasteadLicenseKey;
            this.LicenseString = Properties.Settings.Default.DatasteadLicenseKeyRTSP;

            this.RecordingMode = RecordingModes.Standard;
            this.OnvifPTZDevices = new List<int>();

            #region Events
            this.OnReencodingCompleted += videoGrabber_OnReencodingCompleted;
            this.OnReencodingStarted += videoGrabber_OnReencodingStarted;
            this.OnReencodingProgress += videoGrabber_OnReencodingProgress;
            this.OnLog += videoGrabber_OnLog;
            #endregion
        }

        #region VideoGrabber Events
        private void videoGrabber_OnReencodingStarted(object sender, TOnSourceFileToDestFileStartedEventArgs e)
        {
            prgReencoding.Value = 0;
            pnlReencodingProgress.Visible = true;
        }

        private void videoGrabber_OnReencodingCompleted(object sender, TOnSourceFileToDestFileCompletedEventArgs e)
        {
            _videoReencoding = true;

            pnlReencodingProgress.Visible = false;
        }

        private void videoGrabber_OnReencodingProgress(object sender, TOnProgressEventArgs e)
        {
            prgReencoding.Value = e.percent;
            lblReencodingProgress.Text = string.Format("{0}%", e.percent);
        }

        private void videoGrabber_OnLog(object sender, VidGrab.TOnLogEventArgs e)
        {
            Log(string.Format("{0} - {1}", e.severity, e.infoMsg));
        }

        void videoGrabberMixer_OnLog(object sender, TOnLogEventArgs e)
        {
            VideoGrabber control = sender as VideoGrabber;

            if (control != null)
                Log(string.Format("[{0}] {1} - {2}", control.Name, e.severity, e.infoMsg));
        }
        #endregion

        #region Recording
        public new void StartRecording()
        {
            MixerStart();

            this.PrepareRecording();

            Log("Grabación de audio y video");
            base.StartRecording();
        }

        public new void ResumeRecording()
        {
            Log("Continuando Grabación de audio y video");

            MixerStart();

            Log("Mixer iniciado");

            base.StartRecording();
        }

        public new void StartAudioRecording()
        {
            this.PrepareRecording();

            Log("Grabación de audio");
            base.StartAudioRecording();
        }

        public new void ResumeAudioRecording()
        {
            Log("Continuando Grabación de audio");
            base.StartAudioRecording();
        }

        public new void PauseRecording()
        {
            MixerStop();

            base.Stop();

            this.RecordingFileName = _output.CreateNew();
        }

        public new void Stop()
        {
            base.Stop();

            MixerDestroy();
        }

        private void PrepareRecording()
        {
            _output = new RecordingFile(this.RecordingFileName);
        }
        #endregion

        #region Merge Output File
        public string MergeOutputFile()
        {
            Log("Combinando archivos");

            string outputFileName = "";

            if (_output.Files.Count > 0)
            {
                if (_output.Files.Last().FullName != _output.CurrentFileName)
                {
                    _output.Files.Add(new FileInfo(_output.CurrentFileName));
                }
            }
            else
            {
                Log("...... Combinacion cancelada por existir un solo archivo");

                return _output.CurrentFileName;
            }

            try
            {
                foreach (FileInfo file in _output.Files)
                    Log(string.Format("...... {0}", file.Name));

                FileInfo fi = new FileInfo(_output.BaseFileName);

                outputFileName = string.Format("{0}\\{1}_total{2}", fi.Directory.FullName, Path.GetFileNameWithoutExtension(fi.Name), fi.Extension);

                Log("Archivo resultante {0}", outputFileName);

                if (fi.Extension.ToLower() == ".mp3")
                    MergeAudioFilesToMp3(outputFileName);
                else if (fi.Extension.ToLower() == ".wmv")
                    MergeVideoFilesToWmv(outputFileName);
                else
                    throw new ApplicationException("No se reconoce el tipo de archivo para unir");

            }
            catch (Exception ex)
            {
                Log(ex.Message);

                throw new ApplicationException("Se produjo un error grave cuando se estaba intentando combinar los archivos. Llame al administrador del sistema", ex);
            }

            return outputFileName;
        }

        private void MergeVideoFilesToWmv(string outputFileName)
        {
            this.Playlist(TPlaylist.pl_Clear, "");

            foreach (FileInfo fi in _output.Files)
            {
                this.Playlist(TPlaylist.pl_Add, fi.FullName);
            }

            this.Reencoding_SourceVideoClip = "PLAYLIST";
            this.Reencoding_NewVideoClip = outputFileName;
            this.Reencoding_Method = TRecordingMethod.rm_ASF;
            this.Reencoding_WMVOutput = true;
            this.Reencoding_UseFrameGrabber = false;

            _videoReencoding = false;

            TVuMeter vuMeter = this.VuMeter;

            this.VuMeter = VidGrab.TVuMeter.vu_Disabled;


            this.StartReencoding();

            do
            {
                Application.DoEvents();

                Thread.Sleep(100);

            } while (!_videoReencoding);


            this.VuMeter = vuMeter;
        }

        private void MergeAudioFilesToMp3(string outputFileName)
        {
            Log("... Union MP3");

            try
            {
                using (FileStream output = File.Create(outputFileName))
                {
                    Log("... Archivo creado");

                    foreach (FileInfo file in _output.Files)
                    {
                        Log("... Leyendo archivo {0}", file);

                        if (file.Exists)
                        {
                            if (file.Length > 0)
                            {
                                Mp3FileReader reader = new Mp3FileReader(file.FullName);
                                if ((output.Position == 0) && (reader.Id3v2Tag != null))
                                {
                                    Log("... Escribiendo header");

                                    output.Write(reader.Id3v2Tag.RawData, 0, reader.Id3v2Tag.RawData.Length);
                                }

                                Log("... Escribiendo fames");

                                NAudio.Wave.Mp3Frame frame;
                                while ((frame = reader.ReadNextFrame()) != null)
                                {
                                    output.Write(frame.RawData, 0, frame.RawData.Length);
                                }

                                Log("... fin archivo {0}", file);

                                reader.Close();
                            }
                            else
                            {
                                Log("... El archivo {0} no tiene datos.", file);
                            }
                        }
                        else
                        {
                            Log("... El archivo no existe. {0}", file);
                        }
                    }
                }

                Log("Union MP3 satisfactoria");
            }
            catch (Exception ex)
            {
                Log("Error grave mientras se unian los archivos mp3. Archivo base: {0}. Error:{1}", outputFileName, ex.Message);

                throw new ApplicationException("Se produjo un error grave cuando se estaba intentando combinar los archivos MP3. Llame al administrador del sistema");
            }
        }
        #endregion

        #region Log
        protected override void Log(string log)
        {
            if (this.RecordingMode == RecordingModes.Testing)
                log += " [Testing]";

            base.Log(log);
        }
        #endregion

        #region Configure
        public bool Configure(ExtraConfig extraConfig)
        {
            Config config = Config.Current;
            string pathRoot = Path.GetDirectoryName(extraConfig.FileName);
            string fileName = Path.GetFileNameWithoutExtension(extraConfig.FileName);

            this.CurrentOnvifIndex = -1;
            this.VideoSize = -1;
            this.OnvifPTZDevices = new List<int>();
            bool isValid = true;

            
            if (extraConfig.Video)
            {
                isValid = this.ConfigureToVideo(extraConfig);

                this.RecordingFileName = string.Format("{0}\\{1}." + config.VideoSettings[0].FormatOutput, pathRoot, fileName);

                if (!isValid)
                    return false;
            }
            else
            {
                // Captura de audio
                isValid = this.ConfigureToAudio();

                this.RecordingFileName = string.Format("{0}\\{1}.mp3", pathRoot, fileName);

                if (!isValid)
                    return false;
            }
           

            isValid = config.AudioSetting.Apply(this);

            if (!isValid)
                return false;
            
            ConfigureStreaming(extraConfig.Streaming);

            this.PlayerAudioRendering = false;
            this.RecordingCanPause = false;

            return true;
        }

        private bool ConfigureStreaming(bool streamingEnabled)
        {

            if (streamingEnabled)
            {
                Config config = Config.Current;

                this.NetworkStreaming = VidGrab.TNetworkStreaming.ns_ASFDirectNetworkStreaming;
                return config.StreamingSetting.Apply(this);
            }
            else
            {
                this.NetworkStreaming = VidGrab.TNetworkStreaming.ns_Disabled;
            }

            return true;
        }

        private bool ConfigureToAudio()
        {
            Config config = Config.Current;

            // Captura de audio
            this.VideoRenderer = VidGrab.TVideoRenderer.vr_None;

            this.CompressionMode = VidGrab.TCompressionMode.cm_CompressOnTheFly;
            this.CompressionType = VidGrab.TCompressionType.ct_Audio;
            this.RecordingInNativeFormat = false;
            this.RecordingMethod = VidGrab.TRecordingMethod.rm_AVI;

            this.AudioCompressor = this.FindIndexInListByName(this.AudioCompressors, config.OutputSetting.AudioCompressor, false, true);

            if (this.AudioCompressor == -1)
            {
                MessageBox.Show("Para grabar solo audio en formato MP3 se requiere \"LAME Audio Encoder\"", "Audio Encoder", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private bool ConfigureToVideo(ExtraConfig extraConfig)
        {
            Config config = Config.Current;

            this.CurrentOnvifIndex = 0;
            _mixerSources = new List<VideoGrabberBaseWrapper>();

            // bool isValid = ConfigureVideoMixer(config);
            
            /*bool isValid = true;
            config.VideoSettings.FirstOrDefault().Apply(this);
            */

            //this.UseNearestVideoSize(640, 480, true);

            //if (!isValid)
            //    return false;
            if(!this.ConfigureVideoGrabberToVideo(config.VideoSettings[0]))
                return false;

            this.FrameRate = config.OutputSetting.FramesRate;
            //this.RecordingMethod = VidGrab.TRecordingMethod.rm_ASF;
            //this.ASFVideoFrameRate = config.OutputSetting.FramesRate;
            //this.ASFVideoBitRate = config.OutputSetting.VideoBitRate;
            //this.ASFVideoQuality = config.OutputSetting.VideoQuality;
            this.DVTimeCodeEnabled = false;
            this.VideoRenderer = VidGrab.TVideoRenderer.vr_AutoSelect;
            this.UseNearestVideoSize(0,0,false);
            //this.AutoRefreshPreview = true;

            if (config.VideoSettings[0].FormatOutput == "mp4")
            {
                this.RecordingInNativeFormat = false;
                this.RecordingMethod = VidGrab.TRecordingMethod.rm_MP4;
                this.VideoCompressor = this.VideoCompressorIndex(config.VideoSettings[0].VideoCompressors);
                this.CompressionMode = VidGrab.TCompressionMode.cm_CompressOnTheFly;
                this.AudioRecording = true;
            }
            else {
                this.RecordingInNativeFormat = true;
                this.RecordingMethod = VidGrab.TRecordingMethod.rm_ASF;
                this.ASFVideoFrameRate = config.OutputSetting.FramesRate;
                this.ASFVideoBitRate = config.OutputSetting.VideoBitRate;
                this.ASFVideoQuality = config.OutputSetting.VideoQuality;
            }

            if (Properties.Settings.Default.WmvProfileVersion == 8)
            {
                this.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_8;
            }
            else
            {
                this.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_9;
            }

            // capture.ASFFixedFrameRate = true;
            this.FrameGrabber = VidGrab.TFrameGrabber.fg_Disabled;


            if (Properties.Settings.Default.TextoVideoHabilitado)
            {
                int target = 0;

                this.SetTextOverlay_TargetDisplay(target, -1);

                Font font = new Font(FontFamily.GenericSansSerif, Properties.Settings.Default.TextoVideoFontSize, FontStyle.Regular);

                this.SetTextOverlay_Top(target, 0);
                this.SetTextOverlay_Left(target, -1);
                this.SetTextOverlay_Right(target, 0);
                this.SetTextOverlay_Font(target, font.ToHfont());
                this.SetTextOverlay_HighResFont(target, false);
                this.SetTextOverlay_VideoAlignment(target, VidGrab.TVideoAlignment.oa_RightBottom);
                this.SetTextOverlay_Shadow(target, false);
                this.SetTextOverlay_Transparent(target, false);
                this.SetTextOverlay_BkColor(target, ColorTranslator.ToWin32(Color.Black));
                this.SetTextOverlay_FontColor(target, ColorTranslator.ToWin32(Color.White));
                this.SetTextOverlay_String(target, string.Format(Properties.Settings.Default.TextoVideoTemplate, extraConfig.Etiqueta));

                this.SetTextOverlay_Enabled(target, true);

                this.FrameGrabber = VidGrab.TFrameGrabber.fg_BothStreams;
            }
            else
            {
                this.FrameGrabber = VidGrab.TFrameGrabber.fg_Disabled;
            }

            return true;
        }

        private bool ConfigureVideoMixer(Config config)
        {
            this.CurrentOnvifIndex = -1;
            int camara = 0;

            foreach (VideoSetting setting in config.VideoSettings)
            {
                if (setting.IsValid())
                {
                    VideoGrabberBaseWrapper vg = new VideoGrabberBaseWrapper();

                    vg.Name = string.Format("Camara_{0}", camara);
                    vg.CriticalError += videoGrabberSourceMixer_CriticalError;

                    bool isValid = vg.ConfigureVideoGrabberToVideo(setting);

                    if (isValid)
                    {
                        if (setting.VideoSource == Kenos.Win.VideoSources.IpCamera)
                        {
                            this.CurrentOnvifIndex = camara;
                            if (vg.OnvifDevice.IsPTZSupported)
                                this.OnvifPTZDevices.Add(camara);
                        }
                    }

                    if (!isValid)
                    {
                        MixerDestroy();
                        return false;
                    }

                    _mixerSources.Add(vg);

                    camara++;
                }
            }

            this.VideoSource = VidGrab.TVideoSource.vs_Mixer;
            //this.UseNearestVideoSize(1280, 720, false);

            int cols = 1;
            int rows = 1;
            int mixerCount = config.VideoSourceCount <= 0 ? _mixerSources.Count : config.VideoSourceCount;

            if (mixerCount >= 2)
            {
                cols = 2;
            }
            if (mixerCount >= 3)
            {
                cols = 2;
                rows = 2;
            }
            if (mixerCount >= 5)
            {
                cols = 2;
                rows = 2;
            }
            if (mixerCount >= 6)
            {
                cols = 3;
                rows = 2;
            }


            this.Mixer_MosaicLines = rows;
            this.Mixer_MosaicColumns = cols;

            int idx = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    idx = (row * cols) + col;

                    if (_mixerSources.Count > idx)
                    {
                        VidGrab.VideoGrabber vg = _mixerSources[idx];

                        this.Mixer_AddToMixer(vg.UniqueID, 0, row + 1, col + 1, 0, 0, true, true);
                    }
                }
            }

            /*
            double w = 680;
            double h = 480/2;

            this.AspectRatioToUse = w/h;
            this.ASFVideoWidth =(int)(w);
            this.ASFVideoHeight = (int)h;
            */
            return true;

        }

        void videoGrabberSourceMixer_CriticalError(object sender, CriticalErrorEventArgs evt)
        {
            this.OnCriticalError(sender, evt);
        }

        #endregion

        #region Mixer
        /*public bool IsMixerMode
        {
            get { return Config.Current.VideoSourceCount > 1; }
        }*/

        private void MixerDestroy()
        {
            if (_mixerSources != null)
            {
                for (int i = 0; i < _mixerSources.Count; i++)
                {
                    _mixerSources[i].DestroyVideoGrabber();
                }
            }

            _mixerSources = null;
        }

        private void MixerStart()
        {
            if (_mixerSources != null)
            {
                for (int i = 0; i < _mixerSources.Count; i++)
                {
                    _mixerSources[i].StartPreview();
                }
            }
        }

        private void MixerStop()
        {
            if (_mixerSources != null)
            {
                for (int i = 0; i < _mixerSources.Count; i++)
                {
                    _mixerSources[i].Stop();
                }
            }

        }
        #endregion

        #region Move
        public void MoveLeft()
        {
            if (this.CurrentOnvifDevice != null)
                this.CurrentOnvifDevice.MoveLeft();
        }

        public void MoveRight()
        {
            if (this.CurrentOnvifDevice != null)
                this.CurrentOnvifDevice.MoveRight();
        }
        public void MoveUp()
        {
            if (this.CurrentOnvifDevice != null)
                this.CurrentOnvifDevice.MoveUp();
        }
        public void MoveDown()
        {
            if (this.CurrentOnvifDevice != null)
                this.CurrentOnvifDevice.MoveDown();
        }

        public void MoveStartUp()
        {
            if (this.CurrentOnvifDevice != null)
            {
                VideoGrabberBaseWrapper vg = this.CurrentDevice;

                if (vg.OnvifDevice != null)
                {
                    if (!string.IsNullOrEmpty(vg.VideoSettings.PresetStartupPosition))
                        vg.OnvifDevice.GoToPreset(vg.VideoSettings.PresetStartupPosition);
                    else
                        vg.OnvifDevice.AbsoluteMove(0, 0);
                }
            }
        }

        public void MoveStop()
        {
            if (this.CurrentOnvifDevice != null)
                this.CurrentOnvifDevice.MoveStop();
        }
        #endregion

        #region Raise Events

        private void OnCurrentOnvifDeviceIndexChange()
        {
            if (this.CurrentOnvifDeviceIndexChange != null)
            {
                this.CurrentOnvifDeviceIndexChange(this, new EventArgs());
            }
        }
        #endregion

        private void InitializeComponent()
        {
            this.pnlReencodingProgress = new System.Windows.Forms.Panel();
            this.lblReencodingProgress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.prgReencoding = new System.Windows.Forms.ProgressBar();
            this.pnlReencodingProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReencodingProgress
            // 
            this.pnlReencodingProgress.BackColor = System.Drawing.Color.Black;
            this.pnlReencodingProgress.Controls.Add(this.lblReencodingProgress);
            this.pnlReencodingProgress.Controls.Add(this.label1);
            this.pnlReencodingProgress.Controls.Add(this.prgReencoding);
            this.pnlReencodingProgress.Location = new System.Drawing.Point(3, 70);
            this.pnlReencodingProgress.Name = "pnlReencodingProgress";
            this.pnlReencodingProgress.Size = new System.Drawing.Size(441, 100);
            this.pnlReencodingProgress.TabIndex = 21;
            this.pnlReencodingProgress.Visible = false;
            // 
            // lblReencodingProgress
            // 
            this.lblReencodingProgress.AutoSize = true;
            this.lblReencodingProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReencodingProgress.ForeColor = System.Drawing.Color.White;
            this.lblReencodingProgress.Location = new System.Drawing.Point(404, 31);
            this.lblReencodingProgress.Name = "lblReencodingProgress";
            this.lblReencodingProgress.Size = new System.Drawing.Size(23, 13);
            this.lblReencodingProgress.TabIndex = 21;
            this.lblReencodingProgress.Text = "0%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Finalizando la grabación. Esta tarea puede demorar algunos minutos.";
            // 
            // prgReencoding
            // 
            this.prgReencoding.ForeColor = System.Drawing.Color.White;
            this.prgReencoding.Location = new System.Drawing.Point(4, 47);
            this.prgReencoding.Name = "prgReencoding";
            this.prgReencoding.Size = new System.Drawing.Size(431, 23);
            this.prgReencoding.TabIndex = 19;
            this.prgReencoding.Value = 50;
            // 
            // VideoGrabberWrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.pnlReencodingProgress);
            this.Name = "VideoGrabberWrapper";
            this.Size = new System.Drawing.Size(447, 419);
            this.pnlReencodingProgress.ResumeLayout(false);
            this.pnlReencodingProgress.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
