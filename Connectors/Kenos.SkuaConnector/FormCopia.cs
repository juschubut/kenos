using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kenos.SkuaConnector
{
    public partial class FormCopia : Form
    {
        public SkuaMetadata Metadata { get; set; }
        private bool _cancelado = false;

        public FormCopia()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "¿Está seguro que desea cancelar la copia del video?", "Copiando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                _cancelado = true;

                string userName = Properties.Settings.Default.UserName;
                string domainName = Properties.Settings.Default.DomainName;
                string password = Properties.Settings.Default.Password;

                string name = Metadata.IdAudiencia.ToString() + "_" + DateTime.Now.Ticks.ToString() + Properties.Settings.Default.Formato;
                string path = this.Metadata.FullFileName.Substring(0, this.Metadata.FullFileName.LastIndexOf("\\") + 1) + this.Metadata.Etiqueta + "." + name;

                using (new Impersonator(userName, domainName, password))
                {
                   File.Move(this.Metadata.FullFileName, path);
                }

                string fecha = (DateTime.Now.Day < 9 ? "0" : "") + DateTime.Now.Day.ToString() + "/" + (DateTime.Now.Month < 9 ? "0" : "") + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " " + (DateTime.Now.Hour < 9 ? "0" : "") + DateTime.Now.Hour.ToString() + ":" + (DateTime.Now.Minute < 9 ? "0" : "") + DateTime.Now.Minute.ToString() + ":" + (DateTime.Now.Second < 9 ? "0" : "") + DateTime.Now.Second.ToString();
                                
                string insert = "INSERT INTO tKenosVideo (Ruta,IdAudiencia,Servidor,Fecha,EsMigrado) " +
                "VALUES ('" + path + "'," + Metadata.IdAudiencia + ",'" + Properties.Settings.Default.Servidor + "','" + fecha + "',0) " +
                "SELECT SCOPE_IDENTITY()";

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
                SqlCommand queryInsert = new SqlCommand(insert, conexion);
                conexion.Open();
                object idKenosVideo = queryInsert.ExecuteScalar();

                List<Kenos.Common.MarcaTiempo> marcas = Metadata.MarcasTiempo;
                foreach (Kenos.Common.MarcaTiempo marca in marcas)
                {
                    insert = "INSERT INTO tKenosVideoMarca (IdKenosVideo,Descripcion,Tiempo) " +
                   " VALUES (" + idKenosVideo.ToString() + ",'" + marca.Descripcion + "','" + marca.Tiempo + "') ";
                    queryInsert = new SqlCommand(insert, conexion);
                    queryInsert.ExecuteNonQuery();
                }
                              

                Connector cn = new Connector();
                cn.Log.Info("Transferencia Cancelada - Audiencia :" + Metadata.IdAudiencia.ToString());
                MessageBox.Show("Se cancelo la transferencia de grabación.","Kenos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }






        }


        private void btnTransferir_Click(object sender, EventArgs e)
        {
            Connector cn = new Connector();

            int chunk = 0;
            int chunkSize = 32 * 1024;
            long acumulado = 0;
            long total = new FileInfo(this.Metadata.FullFileName).Length;


            lblProgress.Text = "Transfiriendo....";
            pbCopia.Maximum = Convert.ToInt32(total / chunkSize) + 1;
            pbCopia.Value = 0;
            pbCopia.Visible = true;
            _cancelado = false;


            string name = Metadata.IdAudiencia.ToString() + "_" + DateTime.Now.Ticks.ToString() + Properties.Settings.Default.Formato;
            string subFolder = Metadata.Etiqueta.Replace(":", "");
            string destination = Properties.Settings.Default.VideosRealPath + subFolder + @"\" + name;


            string userName = Properties.Settings.Default.UserName;
            string domainName = Properties.Settings.Default.DomainName;
            string password = Properties.Settings.Default.Password;

            Application.DoEvents();

            try
            {
                using (new Impersonator(userName, domainName, password))
                {
                    string directorio = Properties.Settings.Default.VideosRealPath + subFolder;
                    if (!Directory.Exists(directorio))
                        Directory.CreateDirectory(directorio);

                    using (BinaryReader br = new BinaryReader(File.Open(this.Metadata.FullFileName, FileMode.Open, FileAccess.Read)))
                    {

                        using (BinaryWriter bw = new BinaryWriter(File.Open(destination, FileMode.Create, FileAccess.Write)))
                        {
                            byte[] buffer = new byte[chunkSize];

                            while ((chunk = br.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                if (_cancelado)
                                {
                                    break;
                                }
                                acumulado += chunk;

                                bw.Write(buffer, 0, chunk);

                                pbCopia.Value++;

                                Application.DoEvents();
                            }
                        }
                    }

                    string path = this.Metadata.FullFileName.Substring(0, this.Metadata.FullFileName.LastIndexOf("\\") + 1) + this.Metadata.Etiqueta + "." + name;
                    File.Move(this.Metadata.FullFileName, path);

                    string pathXML = path + ".xml";
                    File.Move(this.Metadata.FullFileName + ".xml", pathXML);

                }
                              

                string fecha = (DateTime.Now.Day < 9 ? "0" : "") + DateTime.Now.Day.ToString() + "/" + (DateTime.Now.Month < 9 ? "0" : "") + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " " + (DateTime.Now.Hour < 9 ? "0" : "") + DateTime.Now.Hour.ToString() + ":" + (DateTime.Now.Minute < 9 ? "0" : "") + DateTime.Now.Minute.ToString() + ":" + (DateTime.Now.Second < 9 ? "0" : "") + DateTime.Now.Second.ToString();

                string insert = "INSERT INTO tVideo (Nombre,Ruta,Fecha) " +
                " VALUES ('" + name + "', '" + Properties.Settings.Default.VideosPath + "/" + subFolder + "/" + name + "','"+ fecha +"') " +
                "SELECT SCOPE_IDENTITY()";

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
                SqlCommand queryInsert = new SqlCommand(insert, conexion);
                conexion.Open();
                object idVideo = queryInsert.ExecuteScalar();
                

                insert = "INSERT INTO tRecurso (IdTipoModelo1,IdObjeto1,IdTipoModelo2,IdObjeto2) " +
                    " VALUES ( 2," + Metadata.IdAudiencia.ToString() + ", 43," + idVideo.ToString() + ") ";

                queryInsert = new SqlCommand(insert, conexion);
                queryInsert.ExecuteNonQuery();


                List<Kenos.Common.MarcaTiempo> marcas = Metadata.MarcasTiempo;
                foreach (Kenos.Common.MarcaTiempo marca in marcas)
                {
                    insert = "INSERT INTO tKenosVideoMarca (IdVideo,Descripcion,Tiempo) " +
                   " VALUES (" + idVideo.ToString() + ",'" + marca.Descripcion + "','" + marca.Tiempo + "') ";
                    queryInsert = new SqlCommand(insert, conexion);
                    queryInsert.ExecuteNonQuery();
                }

                conexion.Close();
                cn.Log.Info("Video capturados por Skua con éxito! - Audiencia :" + Metadata.IdAudiencia.ToString());
                MessageBox.Show("Video transferido a Skua con éxito! - Audiencia","Kenos - Skua", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Integración de Video Skua fracasada: " + ex.Message, "Skua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cn.Log.Info("ERROR Fin grabación Audiencia: " + Metadata.IdAudiencia.ToString());
                return;
            }

            if (_cancelado)
            {
                MessageBox.Show(this, "Se canceló la copia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cn.Log.Info("Se canceló la copia - Audiencia :" + Metadata.IdAudiencia.ToString());
            }

            this.Close();
        }


    }
}
