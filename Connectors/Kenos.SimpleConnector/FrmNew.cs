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
    public partial class FrmNew : Kenos.Common.FormularioBase
    {
        public SimpleMetadata MetadataResult { get; set; }

        public FrmNew()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.MetadataResult.Descripcion = txtDescription.Text;
            this.MetadataResult.Etiqueta = txtEtiqueta.Text;
            this.MetadataResult.ExtraData = (new Random()).Next(1000);

            if (string.IsNullOrEmpty(this.MetadataResult.Descripcion))
            {
                MessageBox.Show(this, "Debe ingresar  una descripcion de la audiencia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FrmNew_Load(object sender, EventArgs e)
        {
            this.MetadataResult = new SimpleMetadata();
        }
    }
}
