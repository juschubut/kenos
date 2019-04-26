using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kenos.Web
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);

            /*
             
             
             var domains = new List<string> {"domain2.com", "domain1.com"};

        if (domains.Contains(filterContext.RequestContext.HttpContext.Request.UrlReferrer.Host))
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }

        base.OnActionExecuting(filterContext);
             * 
             */
        }
    }
}