using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace Kenos.Web
{
    public class Registro
    {
        public DateTime Fecha { get; set; }
        public string Version { get; set; }
        public string AssemblyName { get; set; }
        public string Ip { get; set; }
        public string Path { get; set; } 
    }
}