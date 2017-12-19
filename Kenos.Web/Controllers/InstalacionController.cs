using Kenos.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Kenos.Web.Controllers
{
    public class InstalacionController : Controller
    {
        public string Registrar(RegistrarModel model)
        {
            string ip = WebHelper.GetClientIpAddress(this.Request);

            Instancia.Registrar(
                model.MachineName,
                model.AssemblyName,
                model.Version,
                model.Path,
                ip);

            return "ok";
        }
    }
}
