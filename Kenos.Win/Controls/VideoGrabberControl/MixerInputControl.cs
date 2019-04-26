using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Win.Controls.VideoGrabberControl
{
    public class MixerInputControl
    {
        public string SettingKey { get; set; }
        public int CamaraIndex { get; set; }
        public VidGrab.VideoGrabber VideoGrabber { get; set; }
        public Onvif.OnvifDevice OnvifDevice { get; set; }

        public MixerInputControl(int camara, string settingKey) 
        {
            this.SettingKey = settingKey;
            this.CamaraIndex = camara;
        }

        public void Destroy()
        {
            this.VideoGrabber.Stop();
            this.VideoGrabber.Dispose();

            if (this.OnvifDevice != null)
            {
                this.OnvifDevice = null;
            }
        }
    }
}
