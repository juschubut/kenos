using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kenos.ExpedienteSecretariaConnector
{
    public partial class FrmCopia : Kenos.Common.FormularioBase
    {
        private string sourceFileName;
        private string destinationFileName;

        public FrmCopia(string sourceFileName, string destinationFileName)
        {
            this.sourceFileName = sourceFileName;
            this.destinationFileName = destinationFileName;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.BeginInvoke((MethodInvoker)this.Copiar);
        }

        public void Copiar()
        {
            ValidarDestino();

            int chunk = 0;
            int chunkSize = 32 * 1024;
            long acumulado = 0;
            long total = new FileInfo(this.sourceFileName).Length;

            pbCopia.Maximum = Convert.ToInt32(total / chunkSize) + 1;
            pbCopia.Value = 0;
            pbCopia.Visible = true;

            Application.DoEvents();

            Logger.Log.Info(string.Format("Iniciando copia. {0} -> {1}", this.sourceFileName, this.destinationFileName));

            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(this.sourceFileName, FileMode.Open, FileAccess.Read)))
                {
                    using (BinaryWriter bw = new BinaryWriter(File.Open(this.destinationFileName, FileMode.Create, FileAccess.Write)))
                    {
                        byte[] buffer = new byte[chunkSize];

                        while ((chunk = br.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            acumulado += chunk;

                            bw.Write(buffer, 0, chunk);

                            pbCopia.Value++;

                            Application.DoEvents();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(new ApplicationException("Error mientras se realizaba copia de resguardo", ex));

                pbCopia.Visible = false;

                MessageBox.Show(this, "Se produjo un error mientras se realizaba la copia de seguridad", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ValidarDestino()
        {


            if (File.Exists(this.destinationFileName))
            { 
            }
        }
    }
}
