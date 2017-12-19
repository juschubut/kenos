using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kenos.Common
{
    public interface IConnector
    {
        Metadata Nueva();

        void Finalizar(Metadata config);

        void Cancelar(Metadata config);

        string Nombre { get; }
         
    }
}
