using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenos.Web.Models
{
    public class AutenticacionModel
    {
        public string Dominio { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}