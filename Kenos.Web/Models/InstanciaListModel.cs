using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenos.Web.Models
{
    public class InstanciaListModel : List<InstanciaModel>
    {

    }

    public class InstanciaModel
    {
        public string MachineName { get; set; }
        public DateTime Fecha { get; set; }
        public string Version { get; set; }
        public string Ip { get; set; }
    }
}