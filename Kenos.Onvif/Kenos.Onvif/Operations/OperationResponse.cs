using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Onvif.Operations
{
    public class OperationResponse
    {
        private bool _isSuccess = true;

        public bool IsSuccess 
        {
            get{return this.Exception == null && _isSuccess;}
            set{_isSuccess = value;}
        }

        public string Message { get; set; }

        public Exception Exception  { get; set; }


        public void Attach(OperationResponse rs)
        {
            if (rs.Exception != null)
                this.Exception = rs.Exception;

            this.IsSuccess = rs.IsSuccess;
            this.Message = rs.Message;
        }
    }
}
