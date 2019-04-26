using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Onvif
{
    public class ProfileInfo
    {
        public string Token { get; set; }
        public string Description { get; set; }
        public OnvifServices.v10.Media.Profile Profile { get; set; }
    }
}
