using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.ExpedienteSecretariaConnector
{
    public class Secretaria
    {
        public string Nombre { get; set; }
        public string Key { get; set; }

        public Secretaria() 
        {
            this.Nombre = "Organismo";
        }

        public Secretaria(string key, string nombre)
        {
            this.Key = key;
            this.Nombre = nombre;
        }

        public override string ToString()
        {
            return this.Nombre;
        }

        public bool DirectoriosSeparados
        {
            get
            {
                string val = GetStringConfig("directorios-separados");

                return (val == "true" || val == "1");
            }
        }

        public bool CopiarResultado
        {
            get
            {
                string val = GetStringConfig("copiar-resultado");

                return !string.IsNullOrEmpty(val)
                    && (val.ToLower() == "true" || val == "1")
                    && !string.IsNullOrEmpty(this.CopiarRuta);
            }
        }

        public string CopiarRuta
        {
            get
            {
                string val = GetStringConfig("copiar-ruta");

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
            var baseKey = "expediente-secretaria";
            
            
            if (!string.IsNullOrEmpty(this.Key))
                baseKey += "-" + this.Key;

            return System.Configuration.ConfigurationManager.AppSettings[baseKey+configKeyName];
        }
    }
}
