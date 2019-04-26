using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kenos.Win
{
    public class ExtraConfig
    {
        public string FileName { get; set; }

        public string Etiqueta { get; set; }

        public bool Video { get; set; }

        public bool Streaming { get; set; }

        public ExtraConfig()
        {
            this.Streaming = false;
        }
    }
}
