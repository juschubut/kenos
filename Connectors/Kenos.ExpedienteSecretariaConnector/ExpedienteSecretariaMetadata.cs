using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.ExpedienteSecretariaConnector
{
    public class ExpedienteSecretariaMetadata : Kenos.Common.Metadata
    {
        public int Numero { get; set; }
        public int Anio { get; set; }
        public Secretaria Secretaria { get; set; }

        public ExpedienteSecretariaMetadata()
        {
            this.Secretaria = new Secretaria();
        }
    }
}
