using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kenos.SimpleConnector
{
    public class Connector : Kenos.Common.ConnectorBase
    {
        public override string Nombre
        {
            get { return "Simple"; }
        }

        public override Common.Metadata Nueva()
        {
            FrmNew frmFile = new FrmNew();

            Log.Info("Abriendo formulario");

            DialogResult result = frmFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                Log.Info("Formulario Ok");

                return frmFile.MetadataResult;
            }
            else
            {
                Log.Info("Formulario cancelado");

                return null;
            }
        }

        public override void Finalizar(Common.Metadata config)
        {
            foreach(Common.MarcaTiempo marca in config.MarcasTiempo)
            {
                Console.WriteLine(string.Format("{0} - {1}", marca.Tiempo, marca.Descripcion));
            }


            FrmCopia frm = new FrmCopia();
            frm.Metadata = (SimpleMetadata)config;

            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                Log.Info("Formulario Ok");
            }
        }


        public override void Cancelar(Common.Metadata config)
        {
            Log.Info("Finalizando connector");

            if (File.Exists(config.FullFileName))
            {
                try
                {
                    File.Delete(config.FullFileName);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
        }
    }
}
