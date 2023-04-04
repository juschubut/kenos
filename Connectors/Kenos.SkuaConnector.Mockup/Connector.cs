using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Kenos.SkuaConnector
{
    public class ConexionConnector : Common.ConnectorBase
    {
        public override Common.Metadata Nueva()
        {
            FrmData frm = new FrmData();

            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Log.Info("Creando grabacion para audiencia " + frm.MetadataResult.IdAudiencia);

                return frm.MetadataResult;
            }
            else
               return null; 
        }

        public override void Finalizar(Common.Metadata config)
        {
            SkuaMetadata skuaMetadata = (SkuaMetadata)config;
            
            string name = skuaMetadata.IdAudiencia.ToString() + "_" + DateTime.Now.Ticks.ToString() + ".wmv";
            string subFolder = skuaMetadata.Etiqueta.Replace(":", "_").Replace(" ", "");
            string destination = Properties.Settings.Default.VideosRealPath + subFolder + @"\";

            string userName = Properties.Settings.Default.UserName;
            string domainName = Properties.Settings.Default.DomainName;
            string password = Properties.Settings.Default.Password;

            List<Kenos.Common.MarcaTiempo> marcas = skuaMetadata.MarcasTiempo;            

            try
            {
                //using (new Impersonator(userName, domainName, password))
                //{

                    for (int i = 0; i < 3; i++)
                    {
                        if (!File.Exists(destination + name))
                        {
                            System.IO.File.Move(skuaMetadata.FullFileName, destination + name);       
                            System.IO.File.Move(skuaMetadata.FullFileName + ".xml", destination + name + ".xml");
                            break;
                        }
                        name = skuaMetadata.IdAudiencia.ToString() + "_" + Path.GetRandomFileName() + ".wmv";
                    }


                    if (!File.Exists(destination + name))
                    {
                        MessageBox.Show("No se pudo mover a la carpeta destino", "Skua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Log.Info("Error Move - Audiencia: " + skuaMetadata.IdAudiencia.ToString() + " - Archivo: " + skuaMetadata.FullFileName + " - Destino:" + destination + name);
                        return;
                       
                    }
                //}
                string insert = "INSERT INTO tVideo (Nombre,Ruta,Fecha) " +
                   " VALUES ('" + name + "', '" + Properties.Settings.Default.VideosPath + "/" + subFolder + "/" + name + "', '" + DateTime.Now + "') " +
                   "SELECT SCOPE_IDENTITY()";

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
                SqlCommand queryInsert = new SqlCommand(insert,conexion);
                conexion.Open();
                int idVideo = (int)queryInsert.ExecuteScalar();

                insert = "INSERT INTO tRecurso (IdTipoModelo1,IdObjeto1,IdTipoModelo2,IdObjeto2) " +
                    " VALUES ( 2," + skuaMetadata.IdAudiencia.ToString() + ", 43," + idVideo.ToString() + ") ";

                queryInsert = new SqlCommand(insert, conexion);
                queryInsert.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Video capturados por Skua con éxito!", "Skua", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Integración de Video Skua fracasada: " + ex.Message, "Skua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Log.Info("ERROR Fin grabación Audiencia: " + skuaMetadata.IdAudiencia.ToString());
                return;
            }

            // Hacer aca lo necesario.
            
            this.Log.Info("Fin grabación - Audiencia: " + skuaMetadata.IdAudiencia + " - File: " + skuaMetadata.FullFileName);
        }

        public override void Cancelar(Common.Metadata config)
        {
            SkuaMetadata skuaMetadata = (SkuaMetadata)config; 
            // Hacer aca lo necesario.

            this.Log.Info("Cancela grabación - Audiencia: " + skuaMetadata.IdAudiencia);
        }

        public override string Nombre
        {
            get { return "Skua"; }
        }
    }
}
