using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenos.Web.Models
{
    public class ListarArchivosRequest : AutenticacionModel
    {
        public string Release { get; set; }
        public string Version { get; set; }
    }
}