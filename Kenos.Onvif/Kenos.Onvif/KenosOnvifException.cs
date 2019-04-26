using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Onvif
{
    public class KenosOnvifException : ApplicationException
    {
        public KenosOnvifException()
            : base()
        { }


        public KenosOnvifException(string message)
            : base(message)
        { }

    }
}
