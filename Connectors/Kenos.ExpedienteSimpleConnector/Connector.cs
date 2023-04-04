using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenos.ExpedienteSimpleConnector
{
    public class Connector : Kenos.Common.ConnectorBase
    {

        private ExpedienteSimpleMetadata Metadata {get;set;}

        public override string Nombre
        {
            get { return "Expediente Simple"; }
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

            this.Metadata = (ExpedienteSimpleMetadata)config;

            FileInfo fi = new FileInfo(this.Metadata.FullFileName);
            string localDirectory = fi.Directory.FullName;
            string networkDirectoryName = "";

            if (this.DirectoriosSeparados)
            { 
                localDirectory = string.Format("{0}\\{1}", fi.Directory.FullName, this.LocalDirectoryName);
                CrearDirectorio(localDirectory);

                if (this.CopiarResultado)
                {
                    networkDirectoryName =  this.CopiarRuta + this.LocalDirectoryName + "\\";

                    bool isDirectorioCreado = CrearDirectorio(networkDirectoryName);
                    
                    if (!isDirectorioCreado)
                    {
                        networkDirectoryName = this.CopiarRuta;
                    }
                }
            }

            // Renombra el archivo
            string fileName = localDirectory + string.Format("\\Exp_{0}.{1}-{2:yyyy.MM.dd}{3}", this.Metadata.Numero, this.Metadata.Anio, DateTime.Now, fi.Extension);

            if (File.Exists(fileName))
                fileName = localDirectory + string.Format("\\Exp_{0}.{1}-{2:yyyy.MM.dd.HH.ss}{3}", this.Metadata.Numero, this.Metadata.Anio, DateTime.Now, fi.Extension);

            Log.Info(string.Format("Renombrando archivo {0} -> {1}", config.FullFileName, fileName));

            File.Move(config.FullFileName, fileName);

            // Borra el xml
            string xmlFile = config.FullFileName + ".xml";

            if (File.Exists(xmlFile))
            {                
                File.Delete(xmlFile);                
            }

            // Copia el archivo 
            if (this.CopiarResultado)
            {
                string destino = networkDirectoryName + Path.GetFileName(fileName);

                FrmCopia copiar = new FrmCopia(fileName, destino);

                copiar.ShowDialog();                 
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

        private bool CrearDirectorio(string directorio)
        {
            try
            {
                if (!Directory.Exists(directorio))
                    Directory.CreateDirectory(directorio);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(new ApplicationException(string.Format("Error al intentar crear directorio {0}", directorio), ex));

                return false;
            }
        }

        protected bool CopiarResultado
        {
            get
            {
                string val = System.Configuration.ConfigurationManager.AppSettings["expediente-simple:copiar-resultado"];

                return !string.IsNullOrEmpty(val) 
                    && (val.ToLower() == "true" || val == "1")
                    && !string.IsNullOrEmpty(this.CopiarRuta);
            }
        }

        protected string CopiarRuta
        {
            get
            {
                string val = System.Configuration.ConfigurationManager.AppSettings["expediente-simple:copiar-ruta"];

                if (!string.IsNullOrEmpty(val))
                {
                    val = val.Trim();

                    if (val[val.Length - 1] != '\\')
                    {
                        val += "\\";
                    }
                }
                else
                {
                    val = null;
                }

                return val;
            }
        }

        private bool DirectoriosSeparados
        {
            get
            {
                string val = System.Configuration.ConfigurationManager.AppSettings["expediente-simple:directorios-separados"].ToLower();
                return (val == "true" || val == "1");
            }
        }

        private string LocalDirectoryName
        {
            get
            {
                return string.Format("Exp_{0}_{1}", this.Metadata.Numero, this.Metadata.Anio);
            }
        }
    }
}
