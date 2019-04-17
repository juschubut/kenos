using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Kenos.Web
{
    public class WebHelper
    {
        public static string GetClientIpAddress(HttpRequestBase request)
        {
            try
            {
                var userHostAddress = request.UserHostAddress;

                var xForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(xForwardedFor))
                    return userHostAddress;

                return xForwardedFor;
            }
            catch (Exception)
            {
                return "0.0.0.0";
            }
        }

    }
}