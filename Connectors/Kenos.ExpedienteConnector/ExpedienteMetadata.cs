using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.ExpedienteConnector
{
    public class ExpedienteMetadata : Common.Metadata
    {
        public int Numero { get; set; }
        public int Anio { get; set; }

        public Organismo Organismo { get; set; }

        public ExpedienteMetadata()
        {
            this.Organismo = new Organismo();
        }
    }
}
