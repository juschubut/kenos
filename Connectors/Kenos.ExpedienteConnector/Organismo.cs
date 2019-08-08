using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.ExpedienteConnector
{
    public class Organismo
    {
        public string Nombre { get; set; }
        public string Key { get; set; }

        public Organismo()
        {
            this.Nombre = "Organismo";
        }

        public Organismo(string key, string nombre)
        {
            this.Key = key;
            this.Nombre = nombre;
        }

        public override string ToString()
        {
            return this.Nombre;
        }

        public bool CreaCarpetaLocal
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.CarpetaLocal);
            }
        }

        public bool CopiarRutaRed
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.RutaRed);
            }
        }

        public string CarpetaLocal
        {
            get
            {
                string val = GetStringConfig("carpeta-local");

                if (!string.IsNullOrEmpty(val))
                {
                    val = val.Trim().TrimEnd('\\') + "\\";
                }
                else
                {
                    val = null;
                }

                return val;
            }
        }

        public string RutaRed
        {
            get
            {
                string val = GetStringConfig("ruta-red");

                if (!string.IsNullOrEmpty(val))
                {
                    val = val.Trim().TrimEnd('\\') + "\\";
                }
                else
                {
                    val = null;
                }

                return val;
            }
        }

        private string GetStringConfig(string configKeyName)
        {
            var baseKey = "expediente";


            if (!string.IsNullOrEmpty(this.Key))
                baseKey += "-" + this.Key;

            return System.Configuration.ConfigurationManager.AppSettings[baseKey + ":" + configKeyName];
        }
    }
}
