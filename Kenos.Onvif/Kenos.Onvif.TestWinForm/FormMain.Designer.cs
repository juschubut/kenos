namespace Kenos.Onvif.TestWinForm
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.videoGrabber = new VidGrab.VideoGrabber();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnDerecha = new System.Windows.Forms.Button();
            this.btnIzquierda = new System.Windows.Forms.Button();
            this.btnArriba = new System.Windows.Forms.Button();
            this.btnAbajo = new System.Windows.Forms.Button();
            this.cboPresets = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TrackBar();
            this.tbY = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCentro = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.cboProfiles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDiscovery = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbY)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoGrabber
            // 
            this.videoGrabber.AdjustOverlayAspectRatio = true;
            this.videoGrabber.AdjustPixelAspectRatio = true;
            this.videoGrabber.Aero = VidGrab.TAero.ae_Default;
            this.videoGrabber.AnalogVideoStandard = -1;
            this.videoGrabber.ApplicationPriority = VidGrab.TApplicationPriority.ap_default;
            this.videoGrabber.ASFAudioBitRate = -1;
            this.videoGrabber.ASFAudioChannels = -1;
            this.videoGrabber.ASFBufferWindow = -1;
            this.videoGrabber.ASFDeinterlaceMode = VidGrab.TASFDeinterlaceMode.adm_NotInterlaced;
            this.videoGrabber.ASFFixedFrameRate = true;
            this.videoGrabber.ASFMediaServerPublishingPoint = "";
            this.videoGrabber.ASFMediaServerRemovePublishingPointAfterDisconnect = false;
            this.videoGrabber.ASFMediaServerTemplatePublishingPoint = "";
            this.videoGrabber.ASFNetworkMaxUsers = 5;
            this.videoGrabber.ASFNetworkPort = 0;
            this.videoGrabber.ASFProfile = -1;
            this.videoGrabber.ASFProfileFromCustomFile = "";
            this.videoGrabber.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_8;
            this.videoGrabber.ASFVideoBitRate = -1;
            this.videoGrabber.ASFVideoFrameRate = 0D;
            this.videoGrabber.ASFVideoHeight = -1;
            this.videoGrabber.ASFVideoMaxKeyFrameSpacing = -1;
            this.videoGrabber.ASFVideoQuality = -1;
            this.videoGrabber.ASFVideoWidth = -1;
            this.videoGrabber.AspectRatioToUse = -1D;
            this.videoGrabber.AssociateAudioAndVideoDevices = false;
            this.videoGrabber.AudioBalance = 0;
            this.videoGrabber.AudioChannelRenderMode = VidGrab.TAudioChannelRenderMode.acrm_Normal;
            this.videoGrabber.AudioCompressor = 0;
            this.videoGrabber.AudioDevice = -1;
            this.videoGrabber.AudioDeviceRendering = false;
            this.videoGrabber.AudioFormat = VidGrab.TAudioFormat.af_default;
            this.videoGrabber.AudioInput = -1;
            this.videoGrabber.AudioInputBalance = 0;
            this.videoGrabber.AudioInputLevel = 65535;
            this.videoGrabber.AudioInputMono = false;
            this.videoGrabber.AudioPeakEvent = false;
            this.videoGrabber.AudioRecording = false;
            this.videoGrabber.AudioRenderer = -1;
            this.videoGrabber.AudioSource = VidGrab.TAudioSource.as_Default;
            this.videoGrabber.AudioStreamNumber = -1;
            this.videoGrabber.AudioSyncAdjustment = 0;
            this.videoGrabber.AudioSyncAdjustmentEnabled = false;
            this.videoGrabber.AudioVolume = 32767;
            this.videoGrabber.AutoConnectRelatedPins = true;
            this.videoGrabber.AutoFileName = VidGrab.TAutoFileName.fn_Sequential;
            this.videoGrabber.AutoFileNameDateTimeFormat = "yymmdd_hhmmss_zzz";
            this.videoGrabber.AutoFileNameMinDigits = 6;
            this.videoGrabber.AutoFilePrefix = "vg";
            this.videoGrabber.AutoRefreshPreview = false;
            this.videoGrabber.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.videoGrabber.AutoStartPlayer = true;
            this.videoGrabber.AVIDurationUpdated = true;
            this.videoGrabber.AVIFormatOpenDML = true;
            this.videoGrabber.AVIFormatOpenDMLCompatibilityIndex = true;
            this.videoGrabber.BackColor = System.Drawing.Color.DarkGray;
            this.videoGrabber.BackgroundColor = 0;
            this.videoGrabber.BufferCount = -1;
            this.videoGrabber.BurstCount = 3;
            this.videoGrabber.BurstInterval = 0;
            this.videoGrabber.BurstMode = false;
            this.videoGrabber.BurstType = VidGrab.TFrameCaptureDest.fc_TBitmap;
            this.videoGrabber.BusyCursor = VidGrab.TCursors.cr_HourGlass;
            this.videoGrabber.CameraControlSettings = true;
            this.videoGrabber.CaptureFileExt = "";
            this.videoGrabber.ColorKey = 1048592;
            this.videoGrabber.ColorKeyEnabled = false;
            this.videoGrabber.CompressionMode = VidGrab.TCompressionMode.cm_NoCompression;
            this.videoGrabber.CompressionType = VidGrab.TCompressionType.ct_Video;
            this.videoGrabber.Cropping_Enabled = false;
            this.videoGrabber.Cropping_Height = 120;
            this.videoGrabber.Cropping_Outbounds = true;
            this.videoGrabber.Cropping_Width = 160;
            this.videoGrabber.Cropping_X = 0;
            this.videoGrabber.Cropping_Y = 0;
            this.videoGrabber.Cropping_Zoom = 1D;
            this.videoGrabber.Display_Active = true;
            this.videoGrabber.Display_AlphaBlendEnabled = false;
            this.videoGrabber.Display_AlphaBlendValue = 180;
            this.videoGrabber.Display_AspectRatio = VidGrab.TAspectRatio.ar_Stretch;
            this.videoGrabber.Display_AutoSize = false;
            this.videoGrabber.Display_Embedded = true;
            this.videoGrabber.Display_FullScreen = false;
            this.videoGrabber.Display_Height = 240;
            this.videoGrabber.Display_Left = 10;
            this.videoGrabber.Display_Monitor = 0;
            this.videoGrabber.Display_MouseMovesWindow = true;
            this.videoGrabber.Display_PanScanRatio = 50;
            this.videoGrabber.Display_StayOnTop = false;
            this.videoGrabber.Display_Top = 10;
            this.videoGrabber.Display_TransparentColorEnabled = false;
            this.videoGrabber.Display_TransparentColorValue = 255;
            this.videoGrabber.Display_VideoPortEnabled = true;
            this.videoGrabber.Display_Visible = true;
            this.videoGrabber.Display_Width = 320;
            this.videoGrabber.DoubleBuffered = false;
            this.videoGrabber.DroppedFramesPollingInterval = -1;
            this.videoGrabber.DualDisplay_Active = false;
            this.videoGrabber.DualDisplay_AlphaBlendEnabled = false;
            this.videoGrabber.DualDisplay_AlphaBlendValue = 180;
            this.videoGrabber.DualDisplay_AspectRatio = VidGrab.TAspectRatio.ar_Stretch;
            this.videoGrabber.DualDisplay_AutoSize = false;
            this.videoGrabber.DualDisplay_Embedded = false;
            this.videoGrabber.DualDisplay_FullScreen = false;
            this.videoGrabber.DualDisplay_Height = 240;
            this.videoGrabber.DualDisplay_Left = 20;
            this.videoGrabber.DualDisplay_Monitor = 0;
            this.videoGrabber.DualDisplay_MouseMovesWindow = true;
            this.videoGrabber.DualDisplay_PanScanRatio = 50;
            this.videoGrabber.DualDisplay_StayOnTop = false;
            this.videoGrabber.DualDisplay_Top = 400;
            this.videoGrabber.DualDisplay_TransparentColorEnabled = false;
            this.videoGrabber.DualDisplay_TransparentColorValue = 255;
            this.videoGrabber.DualDisplay_VideoPortEnabled = false;
            this.videoGrabber.DualDisplay_Visible = true;
            this.videoGrabber.DualDisplay_Width = 320;
            this.videoGrabber.DVDateTimeEnabled = true;
            this.videoGrabber.DVDiscontinuityMinimumInterval = 3;
            this.videoGrabber.DVDTitle = 0;
            this.videoGrabber.DVEncoder_VideoFormat = VidGrab.TDVVideoFormat.dvf_DVSD;
            this.videoGrabber.DVEncoder_VideoResolution = VidGrab.TDVSize.dv_Full;
            this.videoGrabber.DVEncoder_VideoStandard = VidGrab.TDVVideoStandard.dvs_Default;
            this.videoGrabber.DVRecordingInNativeFormatSeparatesStreams = false;
            this.videoGrabber.DVReduceFrameRate = false;
            this.videoGrabber.DVRgb219 = false;
            this.videoGrabber.DVTimeCodeEnabled = true;
            this.videoGrabber.EventNotificationSynchrone = true;
            this.videoGrabber.FixFlickerOrBlackCapture = false;
            this.videoGrabber.FrameCaptureHeight = -1;
            this.videoGrabber.FrameCaptureWidth = -1;
            this.videoGrabber.FrameCaptureWithoutOverlay = false;
            this.videoGrabber.FrameCaptureZoomSize = 100;
            this.videoGrabber.FrameGrabber = VidGrab.TFrameGrabber.fg_BothStreams;
            this.videoGrabber.FrameGrabberRGBFormat = VidGrab.TFrameGrabberRGBFormat.fgf_Default;
            this.videoGrabber.FrameNumberStartsFromZero = false;
            this.videoGrabber.FrameRate = 0D;
            this.videoGrabber.FrameRateDivider = 0;
            this.videoGrabber.HoldRecording = false;
            this.videoGrabber.ImageOverlay_AlphaBlend = false;
            this.videoGrabber.ImageOverlay_AlphaBlendValue = 180;
            this.videoGrabber.ImageOverlay_ChromaKey = false;
            this.videoGrabber.ImageOverlay_ChromaKeyLeewayPercent = 25;
            this.videoGrabber.ImageOverlay_ChromaKeyRGBColor = 0;
            this.videoGrabber.ImageOverlay_Height = -1;
            this.videoGrabber.ImageOverlay_LeftLocation = 10;
            this.videoGrabber.ImageOverlay_RotationAngle = 0D;
            this.videoGrabber.ImageOverlay_StretchToVideoSize = false;
            this.videoGrabber.ImageOverlay_TargetDisplay = -1;
            this.videoGrabber.ImageOverlay_TopLocation = 10;
            this.videoGrabber.ImageOverlay_Transparent = false;
            this.videoGrabber.ImageOverlay_TransparentColorValue = 0;
            this.videoGrabber.ImageOverlay_UseTransparentColor = false;
            this.videoGrabber.ImageOverlay_VideoAlignment = VidGrab.TVideoAlignment.oa_LeftTop;
            this.videoGrabber.ImageOverlay_Width = -1;
            this.videoGrabber.ImageOverlayEnabled = false;
            this.videoGrabber.ImageOverlaySelector = 0;
            this.videoGrabber.IPCameraURL = "";
            this.videoGrabber.JPEGPerformance = VidGrab.TJPEGPerformance.jpBestQuality;
            this.videoGrabber.JPEGProgressiveDisplay = false;
            this.videoGrabber.JPEGQuality = 100;
            this.videoGrabber.LicenseString = "N/A";
            this.videoGrabber.Location = new System.Drawing.Point(0, 0);
            this.videoGrabber.LogoDisplayed = false;
            this.videoGrabber.LogoLayout = VidGrab.TLogoLayout.lg_Stretched;
            this.videoGrabber.Margin = new System.Windows.Forms.Padding(4);
            this.videoGrabber.MixAudioSamples_CurrentSourceLevel = 100;
            this.videoGrabber.MixAudioSamples_ExternalSourceLevel = 100;
            this.videoGrabber.Mixer_MosaicColumns = 1;
            this.videoGrabber.Mixer_MosaicLines = 1;
            this.videoGrabber.MotionDetector_CompareBlue = true;
            this.videoGrabber.MotionDetector_CompareGreen = true;
            this.videoGrabber.MotionDetector_CompareRed = true;
            this.videoGrabber.MotionDetector_Enabled = false;
            this.videoGrabber.MotionDetector_GreyScale = false;
            this.videoGrabber.MotionDetector_Grid = "5555555555 5555555555 5555555555 5555555555 5555555555 5555555555 5555555555 5555" +
    "555555 5555555555 5555555555";
            this.videoGrabber.MotionDetector_MaxDetectionsPerSecond = 0D;
            this.videoGrabber.MotionDetector_ReduceCPULoad = 1;
            this.videoGrabber.MotionDetector_ReduceVideoNoise = false;
            this.videoGrabber.MotionDetector_Triggered = false;
            this.videoGrabber.MouseWheelEventEnabled = true;
            this.videoGrabber.MpegStreamType = VidGrab.TMpegStreamType.mpst_Default;
            this.videoGrabber.MultiplexedInputEmulation = true;
            this.videoGrabber.MultiplexedRole = VidGrab.TMultiplexedRole.mr_NotMultiplexed;
            this.videoGrabber.MultiplexedStabilizationDelay = 100;
            this.videoGrabber.MultiplexedSwitchDelay = 0;
            this.videoGrabber.Multiplexer = -1;
            this.videoGrabber.MuteAudioRendering = false;
            this.videoGrabber.Name = "videoGrabber";
            this.videoGrabber.NetworkStreaming = VidGrab.TNetworkStreaming.ns_Disabled;
            this.videoGrabber.NetworkStreamingType = VidGrab.TNetworkStreamingType.nst_AudioVideoStreaming;
            this.videoGrabber.NormalCursor = VidGrab.TCursors.cr_Default;
            this.videoGrabber.NotificationMethod = VidGrab.TNotificationMethod.nm_Thread;
            this.videoGrabber.NotificationPriority = VidGrab.TThreadPriority.tpNormal;
            this.videoGrabber.NotificationSleepTime = -1;
            this.videoGrabber.OnFrameBitmapEventSynchrone = false;
            this.videoGrabber.OpenURLAsync = true;
            this.videoGrabber.OverlayAfterTransform = false;
            this.videoGrabber.OwnerObject = null;
            this.videoGrabber.PlayerAudioRendering = true;
            this.videoGrabber.PlayerDuration = ((long)(1));
            this.videoGrabber.PlayerDVSize = VidGrab.TDVSize.dv_Full;
            this.videoGrabber.PlayerFastSeekSpeedRatio = 4;
            this.videoGrabber.PlayerFileName = "";
            this.videoGrabber.PlayerForcedCodec = "";
            this.videoGrabber.PlayerFramePosition = ((long)(1));
            this.videoGrabber.PlayerRefreshPausedDisplay = false;
            this.videoGrabber.PlayerRefreshPausedDisplayFrameRate = 0D;
            this.videoGrabber.PlayerSpeedRatio = 1D;
            this.videoGrabber.PlayerTimePosition = ((long)(0));
            this.videoGrabber.PlayerTrackBarSynchrone = false;
            this.videoGrabber.PlaylistIndex = 0;
            this.videoGrabber.PreallocCapFileCopiedAfterRecording = true;
            this.videoGrabber.PreallocCapFileEnabled = false;
            this.videoGrabber.PreallocCapFileName = "";
            this.videoGrabber.PreallocCapFileSizeInMB = 100;
            this.videoGrabber.PreviewZoomSize = 100;
            this.videoGrabber.QuickDeviceInitialization = false;
            this.videoGrabber.RawAudioSampleCapture = false;
            this.videoGrabber.RawCaptureAsyncEvent = true;
            this.videoGrabber.RawSampleCaptureLocation = VidGrab.TRawSampleCaptureLocation.rl_SourceFormat;
            this.videoGrabber.RawVideoSampleCapture = false;
            this.videoGrabber.RecordingAudioBitRate = -1;
            this.videoGrabber.RecordingBacktimedFramesCount = 0;
            this.videoGrabber.RecordingCanPause = false;
            this.videoGrabber.RecordingFileName = "";
            this.videoGrabber.RecordingInNativeFormat = true;
            this.videoGrabber.RecordingMethod = VidGrab.TRecordingMethod.rm_AVI;
            this.videoGrabber.RecordingOnMotion_Enabled = false;
            this.videoGrabber.RecordingOnMotion_MotionThreshold = 0D;
            this.videoGrabber.RecordingOnMotion_NoMotionPauseDelayMs = 5000;
            this.videoGrabber.RecordingPauseCreatesNewFile = false;
            this.videoGrabber.RecordingSize = VidGrab.TRecordingSize.rs_Default;
            this.videoGrabber.RecordingTimer = VidGrab.TRecordingTimer.rt_Disabled;
            this.videoGrabber.RecordingTimerInterval = 0;
            this.videoGrabber.RecordingVideoBitRate = -1;
            this.videoGrabber.Reencoding_IncludeAudioStream = true;
            this.videoGrabber.Reencoding_IncludeVideoStream = true;
            this.videoGrabber.Reencoding_Method = VidGrab.TRecordingMethod.rm_ASF;
            this.videoGrabber.Reencoding_NewVideoClip = "";
            this.videoGrabber.Reencoding_SourceVideoClip = "";
            this.videoGrabber.Reencoding_StartFrame = ((long)(-1));
            this.videoGrabber.Reencoding_StartTime = ((long)(-1));
            this.videoGrabber.Reencoding_StopFrame = ((long)(-1));
            this.videoGrabber.Reencoding_StopTime = ((long)(-1));
            this.videoGrabber.Reencoding_UseAudioCompressor = false;
            this.videoGrabber.Reencoding_UseFrameGrabber = true;
            this.videoGrabber.Reencoding_UseVideoCompressor = false;
            this.videoGrabber.Reencoding_WMVOutput = false;
            this.videoGrabber.ScreenRecordingLayeredWindows = false;
            this.videoGrabber.ScreenRecordingMonitor = 0;
            this.videoGrabber.ScreenRecordingNonVisibleWindows = false;
            this.videoGrabber.ScreenRecordingThroughClipboard = false;
            this.videoGrabber.ScreenRecordingWithCursor = true;
            this.videoGrabber.SendToDV_DeviceIndex = -1;
            this.videoGrabber.Size = new System.Drawing.Size(499, 427);
            this.videoGrabber.SpeakerBalance = 0;
            this.videoGrabber.SpeakerControl = false;
            this.videoGrabber.SpeakerVolume = 65535;
            this.videoGrabber.StoragePath = "C:\\Program Files (x86)\\Microsoft Visual Studio 11.0\\Common7\\IDE";
            this.videoGrabber.StoreDeviceSettingsInRegistry = true;
            this.videoGrabber.SyncCommands = true;
            this.videoGrabber.SynchronizationRole = VidGrab.TSynchronizationRole.sr_Master;
            this.videoGrabber.Synchronized = false;
            this.videoGrabber.SyncPreview = VidGrab.TSyncPreview.sp_Auto;
            this.videoGrabber.TabIndex = 0;
            this.videoGrabber.TextOverlay_Align = VidGrab.TTextOverlayAlign.tf_Left;
            this.videoGrabber.TextOverlay_BkColor = 16777215;
            this.videoGrabber.TextOverlay_Enabled = false;
            this.videoGrabber.TextOverlay_FontColor = 16776960;
            this.videoGrabber.TextOverlay_GradientColor = 8388608;
            this.videoGrabber.TextOverlay_GradientMode = VidGrab.TTextOverlayGradientMode.gm_Disabled;
            this.videoGrabber.TextOverlay_HighResFont = true;
            this.videoGrabber.TextOverlay_Left = 0;
            this.videoGrabber.TextOverlay_Right = -1;
            this.videoGrabber.TextOverlay_Scrolling = false;
            this.videoGrabber.TextOverlay_ScrollingSpeed = 1;
            this.videoGrabber.TextOverlay_Selector = 0;
            this.videoGrabber.TextOverlay_Shadow = true;
            this.videoGrabber.TextOverlay_ShadowColor = 0;
            this.videoGrabber.TextOverlay_ShadowDirection = VidGrab.TCardinalDirection.cd_Center;
            this.videoGrabber.TextOverlay_String = resources.GetString("videoGrabber.TextOverlay_String");
            this.videoGrabber.TextOverlay_TargetDisplay = -1;
            this.videoGrabber.TextOverlay_Top = 0;
            this.videoGrabber.TextOverlay_Transparent = true;
            this.videoGrabber.TextOverlay_VideoAlignment = VidGrab.TVideoAlignment.oa_LeftTop;
            this.videoGrabber.ThirdPartyDeinterlacer = "";
            this.videoGrabber.TranslateMouseCoordinates = true;
            this.videoGrabber.TunerFrequency = -1;
            this.videoGrabber.TunerMode = VidGrab.TTunerMode.tm_TVTuner;
            this.videoGrabber.TVChannel = 0;
            this.videoGrabber.TVCountryCode = 0;
            this.videoGrabber.TVTunerInputType = VidGrab.TTunerInputType.TunerInputCable;
            this.videoGrabber.TVUseFrequencyOverrides = false;
            this.videoGrabber.UseClock = true;
            this.videoGrabber.VCRHorizontalLocking = false;
            this.videoGrabber.Version = "v9.2.1.6 (build 141206) - Copyright ©2014 Datastead";
            this.videoGrabber.VideoCompression_DataRate = -1;
            this.videoGrabber.VideoCompression_KeyFrameRate = 15;
            this.videoGrabber.VideoCompression_PFramesPerKeyFrame = 0;
            this.videoGrabber.VideoCompression_Quality = 1D;
            this.videoGrabber.VideoCompression_WindowSize = -1;
            this.videoGrabber.VideoCompressor = 0;
            this.videoGrabber.VideoControlSettings = true;
            this.videoGrabber.VideoCursor = VidGrab.TCursors.cr_Default;
            this.videoGrabber.VideoDelay = ((long)(0));
            this.videoGrabber.VideoDevice = -1;
            this.videoGrabber.VideoFormat = -1;
            this.videoGrabber.VideoFromImages_BitmapsSortedBy = VidGrab.TFileSort.fs_TimeAsc;
            this.videoGrabber.VideoFromImages_RepeatIndefinitely = false;
            this.videoGrabber.VideoFromImages_SourceDirectory = "C:\\Program Files (x86)\\Microsoft Visual Studio 11.0\\Common7\\IDE";
            this.videoGrabber.VideoFromImages_TemporaryFile = "SetOfBitmaps01.dat";
            this.videoGrabber.VideoInput = -1;
            this.videoGrabber.VideoProcessing_Brightness = 0;
            this.videoGrabber.VideoProcessing_Contrast = 0;
            this.videoGrabber.VideoProcessing_Deinterlacing = VidGrab.TVideoDeinterlacing.di_Disabled;
            this.videoGrabber.VideoProcessing_FlipHorizontal = false;
            this.videoGrabber.VideoProcessing_FlipVertical = false;
            this.videoGrabber.VideoProcessing_GrayScale = false;
            this.videoGrabber.VideoProcessing_Hue = 0;
            this.videoGrabber.VideoProcessing_InvertColors = false;
            this.videoGrabber.VideoProcessing_Pixellization = 1;
            this.videoGrabber.VideoProcessing_Rotation = VidGrab.TVideoRotation.rt_0_deg;
            this.videoGrabber.VideoProcessing_RotationCustomAngle = 45.5D;
            this.videoGrabber.VideoProcessing_Saturation = 0;
            this.videoGrabber.VideoQualitySettings = true;
            this.videoGrabber.VideoRenderer = VidGrab.TVideoRenderer.vr_AutoSelect;
            this.videoGrabber.VideoRendererExternal = VidGrab.TVideoRendererExternal.vre_None;
            this.videoGrabber.VideoRendererExternalIndex = -1;
            this.videoGrabber.VideoSize = -1;
            this.videoGrabber.VideoSource = VidGrab.TVideoSource.vs_VideoCaptureDevice;
            this.videoGrabber.VideoSource_FileOrURL = "";
            this.videoGrabber.VideoSource_FileOrURL_StartTime = ((long)(-1));
            this.videoGrabber.VideoSource_FileOrURL_StopTime = ((long)(-1));
            this.videoGrabber.VideoSubtype = -1;
            this.videoGrabber.VideoVisibleWhenStopped = false;
            this.videoGrabber.VirtualAudioStreamControl = -1;
            this.videoGrabber.VirtualVideoStreamControl = -1;
            this.videoGrabber.VuMeter = VidGrab.TVuMeter.vu_Disabled;
            this.videoGrabber.WebcamStillCaptureButton = VidGrab.TWebcamStillCaptureButton.wb_Disabled;
            this.videoGrabber.ZoomCoeff = 1000;
            this.videoGrabber.ZoomXCenter = 0;
            this.videoGrabber.ZoomYCenter = 0;
            this.videoGrabber.OnLog += new VidGrab.OnLogEventHandler(this.videoGrabber_OnLog);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(553, 282);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(92, 25);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(689, 282);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(92, 25);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Desconectar";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(553, 313);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(228, 110);
            this.txtLog.TabIndex = 8;
            // 
            // btnDerecha
            // 
            this.btnDerecha.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDerecha.Location = new System.Drawing.Point(682, 109);
            this.btnDerecha.Name = "btnDerecha";
            this.btnDerecha.Size = new System.Drawing.Size(48, 48);
            this.btnDerecha.TabIndex = 9;
            this.btnDerecha.Text = "►";
            this.btnDerecha.UseVisualStyleBackColor = true;
            this.btnDerecha.Click += new System.EventHandler(this.btnDerecha_Click);
            this.btnDerecha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDerecha_MouseDown);
            this.btnDerecha.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseUp);
            // 
            // btnIzquierda
            // 
            this.btnIzquierda.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzquierda.Location = new System.Drawing.Point(590, 109);
            this.btnIzquierda.Name = "btnIzquierda";
            this.btnIzquierda.Size = new System.Drawing.Size(48, 48);
            this.btnIzquierda.TabIndex = 9;
            this.btnIzquierda.Text = "◄";
            this.btnIzquierda.UseVisualStyleBackColor = true;
            this.btnIzquierda.Click += new System.EventHandler(this.btnIzquierda_Click);
            this.btnIzquierda.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnIzquierda_MouseDown);
            this.btnIzquierda.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseUp);
            // 
            // btnArriba
            // 
            this.btnArriba.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArriba.Location = new System.Drawing.Point(636, 64);
            this.btnArriba.Name = "btnArriba";
            this.btnArriba.Size = new System.Drawing.Size(48, 48);
            this.btnArriba.TabIndex = 9;
            this.btnArriba.Text = "▲";
            this.btnArriba.UseVisualStyleBackColor = true;
            this.btnArriba.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnArriba_MouseDown);
            this.btnArriba.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseUp);
            // 
            // btnAbajo
            // 
            this.btnAbajo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbajo.Location = new System.Drawing.Point(636, 155);
            this.btnAbajo.Name = "btnAbajo";
            this.btnAbajo.Size = new System.Drawing.Size(48, 48);
            this.btnAbajo.TabIndex = 9;
            this.btnAbajo.Text = "▼";
            this.btnAbajo.UseVisualStyleBackColor = true;
            this.btnAbajo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAbajo_MouseDown);
            this.btnAbajo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseUp);
            // 
            // cboPresets
            // 
            this.cboPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPresets.FormattingEnabled = true;
            this.cboPresets.Location = new System.Drawing.Point(550, 34);
            this.cboPresets.Name = "cboPresets";
            this.cboPresets.Size = new System.Drawing.Size(180, 24);
            this.cboPresets.TabIndex = 10;
            this.cboPresets.SelectedIndexChanged += new System.EventHandler(this.cboPresets_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(550, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Presets:";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(0, 429);
            this.tbX.Maximum = 100;
            this.tbX.Minimum = -100;
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(498, 45);
            this.tbX.TabIndex = 12;
            this.tbX.ValueChanged += new System.EventHandler(this.tbX_ValueChanged);
            this.tbX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbPosition_MouseUp);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(499, 0);
            this.tbY.Maximum = 100;
            this.tbY.Minimum = -100;
            this.tbY.Name = "tbY";
            this.tbY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbY.Size = new System.Drawing.Size(45, 427);
            this.tbY.TabIndex = 13;
            this.tbY.ValueChanged += new System.EventHandler(this.tbY_ValueChanged);
            this.tbY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbPosition_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "X:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(29, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(13, 17);
            this.lblX.TabIndex = 15;
            this.lblX.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Y:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(29, 19);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(13, 17);
            this.lblY.TabIndex = 15;
            this.lblY.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblY);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblX);
            this.panel1.Location = new System.Drawing.Point(497, 429);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(65, 45);
            this.panel1.TabIndex = 16;
            // 
            // btnCentro
            // 
            this.btnCentro.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCentro.Location = new System.Drawing.Point(636, 109);
            this.btnCentro.Name = "btnCentro";
            this.btnCentro.Size = new System.Drawing.Size(48, 48);
            this.btnCentro.TabIndex = 17;
            this.btnCentro.Text = "■";
            this.btnCentro.UseVisualStyleBackColor = true;
            this.btnCentro.Click += new System.EventHandler(this.btnCentro_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(689, 251);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(92, 25);
            this.btnInfo.TabIndex = 7;
            this.btnInfo.Text = "info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // cboProfiles
            // 
            this.cboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfiles.FormattingEnabled = true;
            this.cboProfiles.Location = new System.Drawing.Point(761, 34);
            this.cboProfiles.Name = "cboProfiles";
            this.cboProfiles.Size = new System.Drawing.Size(228, 24);
            this.cboProfiles.TabIndex = 10;
            this.cboProfiles.SelectedIndexChanged += new System.EventHandler(this.cboProfiles_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(761, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Profiles";
            // 
            // btnDiscovery
            // 
            this.btnDiscovery.Location = new System.Drawing.Point(689, 220);
            this.btnDiscovery.Name = "btnDiscovery";
            this.btnDiscovery.Size = new System.Drawing.Size(92, 25);
            this.btnDiscovery.TabIndex = 7;
            this.btnDiscovery.Text = "Discovery";
            this.btnDiscovery.UseVisualStyleBackColor = true;
            this.btnDiscovery.Click += new System.EventHandler(this.btnDiscovery_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(914, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 486);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCentro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboProfiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPresets);
            this.Controls.Add(this.btnAbajo);
            this.Controls.Add(this.btnArriba);
            this.Controls.Add(this.btnIzquierda);
            this.Controls.Add(this.btnDerecha);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnDiscovery);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.videoGrabber);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbY)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VidGrab.VideoGrabber videoGrabber;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnDerecha;
        private System.Windows.Forms.Button btnIzquierda;
        private System.Windows.Forms.Button btnArriba;
        private System.Windows.Forms.Button btnAbajo;
        private System.Windows.Forms.ComboBox cboPresets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbX;
        private System.Windows.Forms.TrackBar tbY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCentro;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.ComboBox cboProfiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDiscovery;
        private System.Windows.Forms.Button button1;
    }
}

