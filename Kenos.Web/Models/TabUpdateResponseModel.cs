using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenos.Web.Models
{
    public class TabUpdateResponseModel
    {
        public string ReleasePath { get; set; }
        public System.Web.Mvc.SelectList Releases { get; set; }
        public System.Web.Mvc.SelectList Versiones{ get; set; }

        public TabUpdateResponseModel()
        {
        }
    }
}