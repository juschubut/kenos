using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenos.Web
{
    public class JsonResponse
    {
        private bool _isSuccess = false;
         
        public JsonResponse(object data, bool isSuccess) : this()
        {
            this.Data = data;
            this.IsSuccess = isSuccess;
        }

        public JsonResponse()
        {
            this.Data = null;
            this.IsSuccess = false;
            this.IsFail = false;
        }

        public JsonResponse(string message) : this()
        {
            this.Message = message;
        }

        public bool IsSuccess 
        {
            get { return _isSuccess && !this.IsFail; }

            set { _isSuccess = value; } 
        }

        public bool IsFail { get; set; }
        public bool IsNew { get; set; }
        public object Data { get; set; }
        public string Redirect { get; set; }
        public string Message { get; set; }
    







    }
}