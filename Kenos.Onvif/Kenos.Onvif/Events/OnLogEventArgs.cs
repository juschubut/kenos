using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Onvif.Events
{
    public class OnLogEventArgs : System.EventArgs
    {

        public string Message { get; private set; }
        public Exception Exception { get; private set; }

        public OnLogEventArgs(string message, Exception exception)
        {
            this.Message = message;
            this.Exception = exception;
        }
    }
}
