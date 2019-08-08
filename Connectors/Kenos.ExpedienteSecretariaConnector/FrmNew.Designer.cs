namespace Kenos.ExpedienteSecretariaConnector
{
    partial class FrmNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.LabelNumero = new System.Windows.Forms.Label();
            this.LabelDescripcion = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.LabelAnio = new System.Windows.Forms.Label();
            this.LabelSeparador = new System.Windows.Forms.Label();
            this.pnlBotonera = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cboSecretaria = new System.Windows.Forms.ComboBox();
            this.pnlBotonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(15, 98);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(83, 23);
            this.txtNumero.TabIndex = 0;
            // 
            // LabelNumero
            // 
            this.LabelNumero.AutoSize = true;
            this.LabelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNumero.Location = new System.Drawing.Point(12, 78);
            this.LabelNumero.Name = "LabelNumero";
            this.LabelNumero.Size = new System.Drawing.Size(62, 17);
            this.LabelNumero.TabIndex = 6;
            this.LabelNumero.Text = "Numero:";
            // 
            // LabelDescripcion
            // 
            this.LabelDescripcion.AutoSize = true;
            this.LabelDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDescripcion.Location = new System.Drawing.Point(12, 17);
            this.LabelDescripcion.Name = "LabelDescripcion";
            this.LabelDescripcion.Size = new System.Drawing.Size(219, 17);
            this.LabelDescripcion.TabIndex = 7;
            this.LabelDescripcion.Text = "Ingrese el numero de expediente:";
            // 
            // txtAnio
            // 
            this.txtAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(133, 98);
            this.txtAnio.MaxLength = 4;
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(83, 23);
            this.txtAnio.TabIndex = 1;
            // 
            // LabelAnio
            // 
            this.LabelAnio.AutoSize = true;
            this.LabelAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAnio.Location = new System.Drawing.Point(130, 78);
            this.LabelAnio.Name = "LabelAnio";
            this.LabelAnio.Size = new System.Drawing.Size(37, 17);
            this.LabelAnio.TabIndex = 9;
            this.LabelAnio.Text = "Año:";
            // 
            // LabelSeparador
            // 
            this.LabelSeparador.AutoSize = true;
            this.LabelSeparador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSeparador.Location = new System.Drawing.Point(109, 100);
            this.LabelSeparador.Name = "LabelSeparador";
            this.LabelSeparador.Size = new System.Drawing.Size(12, 17);
            this.LabelSeparador.TabIndex = 10;
            this.LabelSeparador.Text = "/";
            // 
            // pnlBotonera
            // 
            this.pnlBotonera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBotonera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.pnlBotonera.Controls.Add(this.btnCancelar);
            this.pnlBotonera.Controls.Add(this.btnAceptar);
            this.pnlBotonera.Location = new System.Drawing.Point(1, 150);
            this.pnlBotonera.Name = "pnlBotonera";
            this.pnlBotonera.Size = new System.Drawing.Size(366, 58);
            this.pnlBotonera.TabIndex = 11;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(271, 17);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 27);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(173, 17);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 27);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboSecretaria
            // 
            this.cboSecretaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSecretaria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSecretaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSecretaria.FormattingEnabled = true;
            this.cboSecretaria.Location = new System.Drawing.Point(15, 45);
            this.cboSecretaria.Name = "cboSecretaria";
            this.cboSecretaria.Size = new System.Drawing.Size(340, 26);
            this.cboSecretaria.TabIndex = 12;
            // 
            // FrmNew
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(369, 209);
            this.Controls.Add(this.cboSecretaria);
            this.Controls.Add(this.pnlBotonera);
            this.Controls.Add(this.LabelSeparador);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.LabelAnio);
            this.Controls.Add(this.LabelDescripcion);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.LabelNumero);
            this.Name = "FrmNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva audiencia";
            this.Load += new System.EventHandler(this.FrmNew_Load);
            this.pnlBotonera.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label LabelNumero;
        private System.Windows.Forms.Label LabelDescripcion;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label LabelAnio;
        private System.Windows.Forms.Label LabelSeparador;
        private System.Windows.Forms.Panel pnlBotonera;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cboSecretaria;
    }
}