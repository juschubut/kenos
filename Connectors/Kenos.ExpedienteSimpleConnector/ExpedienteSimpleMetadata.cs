using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.ExpedienteSimpleConnector
{
    public class ExpedienteSimpleMetadata : Kenos.Common.Metadata
    {
        public int Numero { get; set; }
        public int Anio { get; set; }
    }
}
