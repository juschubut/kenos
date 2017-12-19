using System;
using System.Collections.Generic;
using System.Text;

namespace Kenos.EjemploConnector
{
    public class Connector :  Kenos.Common.ConnectorBase
    {

        public override Common.Metadata Nueva()
        {
            // consumir ws y traer audiencias
            // listar

            MetadataTest metadata = new MetadataTest();

            metadata.Descripcion = "Test de descripcion";
            metadata.Etiqueta = "T001";
            metadata.IdAudiencia = 120;

            return metadata;
        }

        public override void Finalizar(Common.Metadata config)
        {
            Log.Info(string.Format("Finalizando audiencia {0}", ((MetadataTest)config).IdAudiencia));
           
        }

        public override string Nombre
        {
            get {  return "Test"; }
        }
    }
}
