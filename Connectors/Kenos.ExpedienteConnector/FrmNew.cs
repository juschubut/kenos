using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenos.ExpedienteConnector
{
    public partial class FrmNew : Kenos.Common.FormularioBase
    {
        public ExpedienteMetadata MetadataResult { get; set; }


        public FrmNew()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.MetadataResult.Descripcion = string.Format("Expediente {0}/{1}", txtNumero.Text, txtAnio.Text);
            this.MetadataResult.Etiqueta = string.Format("exp: {0}/{1}", txtNumero.Text, txtAnio.Text);

            try
            {
                this.MetadataResult.Numero = Convert.ToInt32(txtNumero.Text);
            }
            catch { }
            try
            {
                this.MetadataResult.Anio = Convert.ToInt32(txtAnio.Text);
            }
            catch { }

            if (cboSecretaria.SelectedItem == null)
            {
                MessageBox.Show(this, "Debe seleccionar un organismo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.MetadataResult.Organismo = (Organismo)cboSecretaria.SelectedItem;

            if (this.MetadataResult.Numero == 0 || this.MetadataResult.Anio == 0)
            {
                MessageBox.Show(this, "Debe ingresar un número de expediente válido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.MetadataResult.Anio > DateTime.Now.Year)
            {
                MessageBox.Show(this, "El año del expediente no es válido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.MetadataResult.Anio < 1900)
            {
                MessageBox.Show(this, "El año del expediente no es válido, debe estar expresado con 4 dígitos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void FrmNew_Load(object sender, EventArgs e)
        {
            this.MetadataResult = new ExpedienteMetadata();

            var val = System.Configuration.ConfigurationManager.AppSettings["expediente:organismos"];

            if (!string.IsNullOrEmpty(val))
            {
                var items = val.Split('|');

                cboSecretaria.Items.Clear();

                foreach (string item in items)
                {
                    if (string.IsNullOrEmpty(item))
                        continue;

                    var aux = item.Split(':');

                    var nombre = item;
                    var key = item;

                    if (aux.Length > 1)
                    {
                        key = aux[0];
                        nombre = aux[1];
                    }

                    cboSecretaria.Items.Add(new Organismo(key, nombre));
                }
            }
            else
            {
                cboSecretaria.Items.Add(new Organismo());
            }

            if (cboSecretaria.Items.Count == 1)
            {
                cboSecretaria.SelectedIndex = 0;
            }
        }
    }
}
