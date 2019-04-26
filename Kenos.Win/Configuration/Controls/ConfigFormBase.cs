using Kenos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Win.ConfigControls
{
    public class ConfigFormBase : FormularioBase
    {
        private VidGrab.VideoGrabber _capture;

        public VidGrab.VideoGrabber VideoGrabber { get { return _capture; } }

        public ConfigFormBase()
        { }

        public ConfigFormBase(VidGrab.VideoGrabber videoGrabber) :this()
        {
            _capture = videoGrabber;
        }

        public virtual void SaveConfig(Config config)
        {
        }
    }
}
