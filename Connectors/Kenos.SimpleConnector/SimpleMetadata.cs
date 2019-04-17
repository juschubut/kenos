using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kenos.SimpleConnector
{
    public class SimpleMetadata : Common.Metadata
    {
        /*
         * A modo de ejemplo, datos extra que se requieran pasar. 
         * */
        public int ExtraData
        {
            get;
            set;
        }

    }
}
