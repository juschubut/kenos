namespace Kenos.SimpleConnector
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
            this.LabelDescripcion = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlBotonera = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtEtiqueta = new System.Windows.Forms.TextBox();
            this.LabelEtiqueta = new System.Windows.Forms.Label();
            this.LabelAyuda1 = new System.Windows.Forms.Label();
            this.LabelAyuda2 = new System.Windows.Forms.Label();
            this.pnlBotonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelDescripcion
            // 
            this.LabelDescripcion.AutoSize = true;
            this.LabelDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDescripcion.Location = new System.Drawing.Point(12, 77);
            this.LabelDescripcion.Name = "LabelDescripcion";
            this.LabelDescripcion.Size = new System.Drawing.Size(86, 17);
            this.LabelDescripcion.TabIndex = 0;
            this.LabelDescripcion.Text = "Descripción:";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(15, 97);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(462, 23);
            this.txtDescription.TabIndex = 1;
            // 
            // pnlBotonera
            // 
            this.pnlBotonera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBotonera.BackColor = System.Drawing.Color.LightSlateGray;
            this.pnlBotonera.Controls.Add(this.btnCancelar);
            this.pnlBotonera.Controls.Add(this.btnAceptar);
            this.pnlBotonera.Location = new System.Drawing.Point(0, 151);
            this.pnlBotonera.Name = "pnlBotonera";
            this.pnlBotonera.Size = new System.Drawing.Size(499, 58);
            this.pnlBotonera.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(392, 17);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 27);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(294, 17);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 27);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtEtiqueta
            // 
            this.txtEtiqueta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEtiqueta.Location = new System.Drawing.Point(15, 29);
            this.txtEtiqueta.MaxLength = 20;
            this.txtEtiqueta.Name = "txtEtiqueta";
            this.txtEtiqueta.Size = new System.Drawing.Size(151, 23);
            this.txtEtiqueta.TabIndex = 0;
            // 
            // LabelEtiqueta
            // 
            this.LabelEtiqueta.AutoSize = true;
            this.LabelEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEtiqueta.Location = new System.Drawing.Point(12, 9);
            this.LabelEtiqueta.Name = "LabelEtiqueta";
            this.LabelEtiqueta.Size = new System.Drawing.Size(64, 17);
            this.LabelEtiqueta.TabIndex = 4;
            this.LabelEtiqueta.Text = "Etiqueta:";
            // 
            // LabelAyuda1
            // 
            this.LabelAyuda1.AutoSize = true;
            this.LabelAyuda1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAyuda1.ForeColor = System.Drawing.Color.DimGray;
            this.LabelAyuda1.Location = new System.Drawing.Point(12, 55);
            this.LabelAyuda1.Name = "LabelAyuda1";
            this.LabelAyuda1.Size = new System.Drawing.Size(334, 13);
            this.LabelAyuda1.TabIndex = 5;
            this.LabelAyuda1.Text = "(Este texto aparecerá como referencia dentro del video de grabación)";
            // 
            // LabelAyuda2
            // 
            this.LabelAyuda2.AutoSize = true;
            this.LabelAyuda2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAyuda2.ForeColor = System.Drawing.Color.DimGray;
            this.LabelAyuda2.Location = new System.Drawing.Point(12, 123);
            this.LabelAyuda2.Name = "LabelAyuda2";
            this.LabelAyuda2.Size = new System.Drawing.Size(241, 13);
            this.LabelAyuda2.TabIndex = 6;
            this.LabelAyuda2.Text = "(Este texto aparecerá como titulo en la grabación)";
            // 
            // FrmNew
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(497, 209);
            this.Controls.Add(this.LabelAyuda2);
            this.Controls.Add(this.LabelAyuda1);
            this.Controls.Add(this.txtEtiqueta);
            this.Controls.Add(this.LabelEtiqueta);
            this.Controls.Add(this.pnlBotonera);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.LabelDescripcion);
            this.Name = "FrmNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Grabación";
            this.Load += new System.EventHandler(this.FrmNew_Load);
            this.pnlBotonera.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelDescripcion;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlBotonera;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtEtiqueta;
        private System.Windows.Forms.Label LabelEtiqueta;
        private System.Windows.Forms.Label LabelAyuda1;
        private System.Windows.Forms.Label LabelAyuda2;
    }
}