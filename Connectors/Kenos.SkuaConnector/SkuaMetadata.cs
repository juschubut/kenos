using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kenos.SkuaConnector
{
    public class SkuaMetadata : Common.Metadata
    {
        public int IdAudiencia
        {
            get;
            set;
        }
          

        public string Caratula
        {
            get;
            set;
        }

        public override bool ForzarModoGrabacion
        {
            get
            {
                return base.ForzarModoGrabacion;
            }
            set
            {
                base.ForzarModoGrabacion = value;
            }
        }

        public override Common.ModosGrabacion ModoGrabacion
        {
            get
            {
                return base.ModoGrabacion;
            }
            set
            {
                base.ModoGrabacion = value;
            }
        }
    }
}
