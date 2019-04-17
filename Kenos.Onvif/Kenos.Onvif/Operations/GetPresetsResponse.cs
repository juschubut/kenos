using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Onvif.Operations
{
    public class GetPresetsResponse : OperationResponse
    {
        public string[] Presets { get; set; }
    }
}
