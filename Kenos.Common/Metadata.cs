using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kenos.Common
{
    public class Metadata
    {
        public string HashFile { get; set; }
        public string FullFileName { get; set; }
        public string Etiqueta { get; set; }
        public string Descripcion { get; set; }
        public List<MarcaTiempo> MarcasTiempo { get; set; }

        /// <summary>
        /// Indica si se debe forzar el modo de grabación.
        /// Si esta propiedad es true, debe indicarse el modo en ModoGrabacion.
        /// </summary>
        public virtual bool ForzarModoGrabacion { get; set; }

        /// <summary>
        /// Indica el modo de grabacion (audio/video) que debe realizar el sistema.
        /// </summary>
        public virtual ModosGrabacion ModoGrabacion { get; set; }

        public Metadata()
        {
            this.MarcasTiempo = new List<MarcaTiempo>();
            this.ForzarModoGrabacion = false;
            this.ModoGrabacion = ModosGrabacion.Video;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("...... Descripcion: {0}\n", this.Descripcion);
            sb.AppendFormat("...... File: {0}\n", this.FullFileName);

            return sb.ToString();
        }
    }
}
