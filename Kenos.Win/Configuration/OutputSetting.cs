using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Win
{
    [Serializable]
    public class OutputSetting
    {
        public int VideoBitRate { get; set; }
        public int VideoQuality { get; set; }
        public double FramesRate { get; set; }
        public string AudioCompressor { get; set; }

        public OutputSetting() 
        {
            this.VideoBitRate = Properties.Settings.Default.WmvVideoBitRates;
            this.VideoQuality = Properties.Settings.Default.WmvVideoQuality;
            this.FramesRate = Properties.Settings.Default.FrameRatePredeterminado;
            this.AudioCompressor = "LAME Audio Encoder";
        }

        public bool Apply(VidGrab.VideoGrabber capture)
        {
            capture.FrameRate = this.FramesRate;
            capture.RecordingMethod = VidGrab.TRecordingMethod.rm_ASF;
            capture.ASFVideoFrameRate = this.FramesRate;
            capture.ASFVideoBitRate = this.VideoBitRate;
            capture.ASFVideoQuality = this.VideoQuality;
            capture.VideoRenderer = VidGrab.TVideoRenderer.vr_AutoSelect;

            if (Properties.Settings.Default.WmvProfileVersion == 8)
            {
                capture.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_8;
            }
            else
            {
                capture.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_9;
            }


            return true;
        }
    }
}
