namespace Kenos.ExpedienteConnector
{
    partial class FrmCopia
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
            this.pbCopia = new System.Windows.Forms.ProgressBar();
            this.LabelDestino = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbCopia
            // 
            this.pbCopia.Location = new System.Drawing.Point(12, 30);
            this.pbCopia.Name = "pbCopia";
            this.pbCopia.Size = new System.Drawing.Size(465, 23);
            this.pbCopia.TabIndex = 6;
            this.pbCopia.Visible = false;
            // 
            // LabelDestino
            // 
            this.LabelDestino.AutoSize = true;
            this.LabelDestino.Location = new System.Drawing.Point(9, 6);
            this.LabelDestino.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelDestino.Name = "LabelDestino";
            this.LabelDestino.Size = new System.Drawing.Size(162, 13);
            this.LabelDestino.TabIndex = 5;
            this.LabelDestino.Text = "Realizando copia de seguridad...";
            // 
            // FrmCopia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 66);
            this.Controls.Add(this.pbCopia);
            this.Controls.Add(this.LabelDestino);
            this.Name = "FrmCopia";
            this.Text = "FrmCopia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbCopia;
        private System.Windows.Forms.Label LabelDestino;
    }
}