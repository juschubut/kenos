using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Win
{
    [Serializable]
    public class StreamingSetting
    {
        public int Port { get; set; }
        public string Type { get; set; }
        public int MaxUsers { get; set; }

        public StreamingSetting()
        {
            this.Port = 5000;
            this.Type = StreamingTypes.AudioVideo;
            this.MaxUsers = 2;
        }

        public bool IsValid() 
        {
            if (this.Port <= 0)
                return false;

            if (string.IsNullOrEmpty(this.Type))
                return false;

            return true;
        }

        public bool Apply(VidGrab.VideoGrabber capture)
        {
            capture.NetworkStreamingType = VidGrab.TNetworkStreamingType.nst_AudioVideoStreaming;

            if (this.Type == StreamingTypes.Audio)
                capture.NetworkStreamingType = VidGrab.TNetworkStreamingType.nst_AudioStreaming;
            if (this.Type == StreamingTypes.Video)
                capture.NetworkStreamingType = VidGrab.TNetworkStreamingType.nst_VideoStreaming;

            capture.ASFNetworkPort = this.Port;
            capture.ASFNetworkMaxUsers = this.MaxUsers;

            return true;
        }
    }
}
