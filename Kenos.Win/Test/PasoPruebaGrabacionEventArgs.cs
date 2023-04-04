using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Win.Test
{
    public class PasoPruebaGrabacionEventArgs
    {
        private CasoPrueba _casoPrueba;

        public CasoPrueba CasoPrueba
        {
            get { return _casoPrueba; }
        }

        public PasoPruebaGrabacionEventArgs(CasoPrueba casoPrueba)
        {
            _casoPrueba = casoPrueba;
        }

    }
}
