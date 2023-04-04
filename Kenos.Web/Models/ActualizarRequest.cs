using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenos.Web.Models
{
    public class ActualizarRequest : AutenticacionModel
    {
        public string NombreInstancia { get; set; }
        public string Release { get; set; }
        public string Version { get; set; }

        public List<string> Archivos { get; set; }

        public ActualizarRequest()
        {
            this.Archivos = new List<string>();
        }
    }
}