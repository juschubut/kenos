using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kenos.SimpleConnector
{
    public partial class FrmCopia : Kenos.Common.FormularioBase
    {
        public SimpleMetadata Metadata { get; set; }
        private bool _cancelado = false;

        public FrmCopia()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            SeleccionarDestino();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        { 
            DialogResult result = System.Windows.Forms.DialogResult.No;

            do
            {
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SeleccionarDestino())
                        break;
                }

                Copiar();

                result = MessageBox.Show(this, "¿Desea realizar otra copia?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }
            while (result == System.Windows.Forms.DialogResult.Yes);

            this.Close();
        }

        private bool SeleccionarDestino()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            FileInfo fi = new FileInfo(this.Metadata.FullFileName);

            dlg.DefaultExt = fi.Extension;

            DialogResult result = dlg.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtDestino.Text = dlg.FileName;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Copiar()
        {
            int chunk = 0;
            int chunkSize = 32 * 1024;
            long acumulado = 0;
            long total = new FileInfo(this.Metadata.FullFileName).Length;


            lblProgress.Text = "Copiando....";
            pbCopia.Maximum = Convert.ToInt32(total / chunkSize) + 1;
            pbCopia.Value = 0;
            pbCopia.Visible = true;
            _cancelado = false;

            Application.DoEvents();

            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(this.Metadata.FullFileName, FileMode.Open, FileAccess.Read)))
                {
                    using (BinaryWriter bw = new BinaryWriter(File.Open(txtDestino.Text, FileMode.Create, FileAccess.Write)))
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
            }
            catch (Exception ex)
            {
                Logger.Log.Error(new ApplicationException("Error mientras se copiaba archivo de grabación", ex));

                lblProgress.Text = "";
                pbCopia.Visible = false;

                MessageBox.Show(this, "Se produjo un error mientras se copiaba el archivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (_cancelado)
            {
                MessageBox.Show(this, "Se canceló la copia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "¿Está seguro que desea cancelar la copia del video?", "Copiando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.Yes)
                _cancelado = true;
        }
    }
}
