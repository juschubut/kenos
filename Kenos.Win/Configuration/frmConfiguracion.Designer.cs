namespace Kenos.Win
{
    partial class frmConfiguracion
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
            this.pnlBotonera = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.tabOutput = new System.Windows.Forms.RadioButton();
            this.tabAudio = new System.Windows.Forms.RadioButton();
            this.tabVideo = new System.Windows.Forms.RadioButton();
            this.pnlVideo = new System.Windows.Forms.Panel();
            this.pnlAudio = new System.Windows.Forms.Panel();
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.pnlStreaming = new System.Windows.Forms.Panel();
            this.tabStreaming = new System.Windows.Forms.RadioButton();
            this.pnlBotonera.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotonera
            // 
            this.pnlBotonera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBotonera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.pnlBotonera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBotonera.Controls.Add(this.btnAceptar);
            this.pnlBotonera.Controls.Add(this.btnCancelar);
            this.pnlBotonera.Location = new System.Drawing.Point(0, 524);
            this.pnlBotonera.Name = "pnlBotonera";
            this.pnlBotonera.Size = new System.Drawing.Size(541, 56);
            this.pnlBotonera.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(354, 14);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 30);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(451, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(68)))), ((int)(((byte)(80)))));
            this.pnlTabs.Controls.Add(this.tabStreaming);
            this.pnlTabs.Controls.Add(this.tabOutput);
            this.pnlTabs.Controls.Add(this.tabAudio);
            this.pnlTabs.Controls.Add(this.tabVideo);
            this.pnlTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(541, 35);
            this.pnlTabs.TabIndex = 5;
            // 
            // tabOutput
            // 
            this.tabOutput.Appearance = System.Windows.Forms.Appearance.Button;
            this.tabOutput.AutoSize = true;
            this.tabOutput.FlatAppearance.BorderSize = 0;
            this.tabOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabOutput.Location = new System.Drawing.Point(233, 8);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Size = new System.Drawing.Size(61, 27);
            this.tabOutput.TabIndex = 3;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            this.tabOutput.Click += new System.EventHandler(this.tab_Click);
            // 
            // tabAudio
            // 
            this.tabAudio.Appearance = System.Windows.Forms.Appearance.Button;
            this.tabAudio.AutoSize = true;
            this.tabAudio.FlatAppearance.BorderSize = 0;
            this.tabAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabAudio.Location = new System.Drawing.Point(73, 8);
            this.tabAudio.Name = "tabAudio";
            this.tabAudio.Size = new System.Drawing.Size(54, 27);
            this.tabAudio.TabIndex = 1;
            this.tabAudio.Text = "Audio";
            this.tabAudio.UseVisualStyleBackColor = true;
            this.tabAudio.Click += new System.EventHandler(this.tab_Click);
            // 
            // tabVideo
            // 
            this.tabVideo.Appearance = System.Windows.Forms.Appearance.Button;
            this.tabVideo.AutoSize = true;
            this.tabVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(61)))), ((int)(((byte)(59)))));
            this.tabVideo.Checked = true;
            this.tabVideo.FlatAppearance.BorderSize = 0;
            this.tabVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabVideo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(195)))), ((int)(((byte)(201)))));
            this.tabVideo.Location = new System.Drawing.Point(7, 8);
            this.tabVideo.Name = "tabVideo";
            this.tabVideo.Size = new System.Drawing.Size(54, 27);
            this.tabVideo.TabIndex = 0;
            this.tabVideo.TabStop = true;
            this.tabVideo.Text = "Video";
            this.tabVideo.UseVisualStyleBackColor = false;
            this.tabVideo.Click += new System.EventHandler(this.tab_Click);
            // 
            // pnlVideo
            // 
            this.pnlVideo.Location = new System.Drawing.Point(12, 49);
            this.pnlVideo.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(128, 469);
            this.pnlVideo.TabIndex = 6;
            // 
            // pnlAudio
            // 
            this.pnlAudio.Location = new System.Drawing.Point(146, 49);
            this.pnlAudio.Name = "pnlAudio";
            this.pnlAudio.Size = new System.Drawing.Size(127, 469);
            this.pnlAudio.TabIndex = 7;
            // 
            // pnlOutput
            // 
            this.pnlOutput.Location = new System.Drawing.Point(279, 49);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(127, 469);
            this.pnlOutput.TabIndex = 8;
            // 
            // pnlStreaming
            // 
            this.pnlStreaming.Location = new System.Drawing.Point(412, 49);
            this.pnlStreaming.Name = "pnlStreaming";
            this.pnlStreaming.Size = new System.Drawing.Size(127, 469);
            this.pnlStreaming.TabIndex = 8;
            // 
            // tabStreaming
            // 
            this.tabStreaming.Appearance = System.Windows.Forms.Appearance.Button;
            this.tabStreaming.AutoSize = true;
            this.tabStreaming.FlatAppearance.BorderSize = 0;
            this.tabStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabStreaming.Location = new System.Drawing.Point(139, 8);
            this.tabStreaming.Name = "tabStreaming";
            this.tabStreaming.Size = new System.Drawing.Size(82, 27);
            this.tabStreaming.TabIndex = 2;
            this.tabStreaming.Text = "Streaming";
            this.tabStreaming.UseVisualStyleBackColor = true;
            this.tabStreaming.Click += new System.EventHandler(this.tab_Click);
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(541, 580);
            this.Controls.Add(this.pnlStreaming);
            this.Controls.Add(this.pnlOutput);
            this.Controls.Add(this.pnlAudio);
            this.Controls.Add(this.pnlVideo);
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.pnlBotonera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.pnlBotonera.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.pnlTabs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBotonera;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.RadioButton tabVideo;
        private System.Windows.Forms.RadioButton tabAudio;
        private System.Windows.Forms.Panel pnlVideo;
        private System.Windows.Forms.Panel pnlAudio;
        private System.Windows.Forms.Panel pnlOutput;
        private System.Windows.Forms.RadioButton tabOutput;
        private System.Windows.Forms.Panel pnlStreaming;
        private System.Windows.Forms.RadioButton tabStreaming;
    }
}