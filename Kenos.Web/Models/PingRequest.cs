using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenos.Web.Models
{
    public class PingRequest : AutenticacionModel
    {
        public string NombreInstancia { get; set; }
    }
}