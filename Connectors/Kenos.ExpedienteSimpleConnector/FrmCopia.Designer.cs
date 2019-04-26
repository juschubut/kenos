namespace Kenos.ExpedienteSimpleConnector
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
            this.LabelDestino = new System.Windows.Forms.Label();
            this.pbCopia = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // LabelDestino
            // 
            this.LabelDestino.AutoSize = true;
            this.LabelDestino.Location = new System.Drawing.Point(9, 11);
            this.LabelDestino.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelDestino.Name = "LabelDestino";
            this.LabelDestino.Size = new System.Drawing.Size(216, 17);
            this.LabelDestino.TabIndex = 0;
            this.LabelDestino.Text = "Realizando copia de seguridad...";
            // 
            // pbCopia
            // 
            this.pbCopia.Location = new System.Drawing.Point(12, 35);
            this.pbCopia.Name = "pbCopia";
            this.pbCopia.Size = new System.Drawing.Size(465, 23);
            this.pbCopia.TabIndex = 4;
            this.pbCopia.Visible = false;
            // 
            // FrmCopia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 73);
            this.Controls.Add(this.pbCopia);
            this.Controls.Add(this.LabelDestino);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCopia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kenos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelDestino;
        private System.Windows.Forms.ProgressBar pbCopia;
    }
}