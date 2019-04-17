using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenos.FamiliaConnector
{
    public class Connector : Kenos.Common.ConnectorBase
    {

        public override string Nombre
        {
            get { return "Juzgado de Familia"; }
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
            if (!File.Exists(config.FullFileName))
                return;

            FamiliaMetadata metadata = (FamiliaMetadata)config;

            FileInfo fi = new FileInfo(metadata.FullFileName);
            string dir = fi.Directory.FullName;
            string dirSeparadosVal = System.Configuration.ConfigurationManager.AppSettings["familia:directorios-separados"];

            if (!string.IsNullOrEmpty(dirSeparadosVal))
            { 
                dirSeparadosVal = dirSeparadosVal.Trim().ToLower();

                if (dirSeparadosVal == "true" || dirSeparadosVal == "1")
                {
                    dir = string.Format("{0}\\Exp_{1}_{2}", fi.Directory.FullName, metadata.Numero, metadata.Anio);

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                }
            }

            string fileName = dir + string.Format("\\Exp_{0}.{1}-{2:yyy.MM.dd}{3}", metadata.Numero, metadata.Anio, DateTime.Now, fi.Extension);

            if (File.Exists(fileName))
                fileName = dir + string.Format("\\Exp_{0}.{1}-{2:yyy.MM.dd.HH.ss}{3}", metadata.Numero, metadata.Anio, DateTime.Now, fi.Extension);

            File.Move(config.FullFileName, fileName);

            string xmlFile = config.FullFileName + ".xml";

            if (File.Exists(xmlFile))
            {                
                File.Delete(xmlFile);                
            }

            MessageBox.Show("El archivo se guardó en " + fileName, "Finalizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
