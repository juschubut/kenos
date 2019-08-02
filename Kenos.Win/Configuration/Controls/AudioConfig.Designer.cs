namespace Kenos.Win.ConfigControls
{
    partial class AudioConfig
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
            this.chkAudioDeviceRendering = new System.Windows.Forms.CheckBox();
            this.LabelLine = new System.Windows.Forms.Label();
            this.lblFormatoAudio = new System.Windows.Forms.Label();
            this.LabelReproduccion = new System.Windows.Forms.Label();
            this.LabelDispositivoAudio = new System.Windows.Forms.Label();
            this.cbAudioLine = new System.Windows.Forms.ComboBox();
            this.cbAudioFormat = new System.Windows.Forms.ComboBox();
            this.cbAudioOutput = new System.Windows.Forms.ComboBox();
            this.cbAudioDevice = new System.Windows.Forms.ComboBox();
            this.cboFuente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDispositivo = new System.Windows.Forms.Panel();
            this.pnlCamaraIp = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDispositivo.SuspendLayout();
            this.pnlCamaraIp.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAudioDeviceRendering
            // 
            this.chkAudioDeviceRendering.AutoSize = true;
            this.chkAudioDeviceRendering.Location = new System.Drawing.Point(1, 180);
            this.chkAudioDeviceRendering.Name = "chkAudioDeviceRendering";
            this.chkAudioDeviceRendering.Size = new System.Drawing.Size(254, 21);
            this.chkAudioDeviceRendering.TabIndex = 4;
            this.chkAudioDeviceRendering.Text = "Reproducir audio mientras se graba";
            this.chkAudioDeviceRendering.UseVisualStyleBackColor = true;
            // 
            // LabelLine
            // 
            this.LabelLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelLine.AutoSize = true;
            this.LabelLine.Location = new System.Drawing.Point(371, 126);
            this.LabelLine.Name = "LabelLine";
            this.LabelLine.Size = new System.Drawing.Size(39, 17);
            this.LabelLine.TabIndex = 25;
            this.LabelLine.Text = "Line:";
            // 
            // lblFormatoAudio
            // 
            this.lblFormatoAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormatoAudio.AutoSize = true;
            this.lblFormatoAudio.Location = new System.Drawing.Point(370, 0);
            this.lblFormatoAudio.Name = "lblFormatoAudio";
            this.lblFormatoAudio.Size = new System.Drawing.Size(64, 17);
            this.lblFormatoAudio.TabIndex = 26;
            this.lblFormatoAudio.Text = "Formato:";
            // 
            // LabelReproduccion
            // 
            this.LabelReproduccion.AutoSize = true;
            this.LabelReproduccion.Location = new System.Drawing.Point(1, 126);
            this.LabelReproduccion.Name = "LabelReproduccion";
            this.LabelReproduccion.Size = new System.Drawing.Size(100, 17);
            this.LabelReproduccion.TabIndex = 27;
            this.LabelReproduccion.Text = "Reproducción:";
            // 
            // LabelDispositivoAudio
            // 
            this.LabelDispositivoAudio.AutoSize = true;
            this.LabelDispositivoAudio.Location = new System.Drawing.Point(1, 0);
            this.LabelDispositivoAudio.Name = "LabelDispositivoAudio";
            this.LabelDispositivoAudio.Size = new System.Drawing.Size(80, 17);
            this.LabelDispositivoAudio.TabIndex = 28;
            this.LabelDispositivoAudio.Text = "Dispositivo:";
            // 
            // cbAudioLine
            // 
            this.cbAudioLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAudioLine.FormattingEnabled = true;
            this.cbAudioLine.Location = new System.Drawing.Point(371, 145);
            this.cbAudioLine.Name = "cbAudioLine";
            this.cbAudioLine.Size = new System.Drawing.Size(143, 24);
            this.cbAudioLine.TabIndex = 3;
            // 
            // cbAudioFormat
            // 
            this.cbAudioFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAudioFormat.FormattingEnabled = true;
            this.cbAudioFormat.Location = new System.Drawing.Point(370, 19);
            this.cbAudioFormat.Name = "cbAudioFormat";
            this.cbAudioFormat.Size = new System.Drawing.Size(143, 24);
            this.cbAudioFormat.TabIndex = 1;
            // 
            // cbAudioOutput
            // 
            this.cbAudioOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAudioOutput.FormattingEnabled = true;
            this.cbAudioOutput.Location = new System.Drawing.Point(1, 145);
            this.cbAudioOutput.Name = "cbAudioOutput";
            this.cbAudioOutput.Size = new System.Drawing.Size(364, 24);
            this.cbAudioOutput.TabIndex = 2;
            // 
            // cbAudioDevice
            // 
            this.cbAudioDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAudioDevice.FormattingEnabled = true;
            this.cbAudioDevice.Location = new System.Drawing.Point(1, 19);
            this.cbAudioDevice.Name = "cbAudioDevice";
            this.cbAudioDevice.Size = new System.Drawing.Size(364, 24);
            this.cbAudioDevice.TabIndex = 0;
            this.cbAudioDevice.SelectedIndexChanged += new System.EventHandler(this.cbAudioDevice_SelectedIndexChanged);
            // 
            // cboFuente
            // 
            this.cboFuente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFuente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFuente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFuente.FormattingEnabled = true;
            this.cboFuente.Items.AddRange(new object[] {
            "Dispositivo",
            "Tomar audio de Camara IP"});
            this.cboFuente.Location = new System.Drawing.Point(1, 30);
            this.cboFuente.Name = "cboFuente";
            this.cboFuente.Size = new System.Drawing.Size(513, 24);
            this.cboFuente.TabIndex = 29;
            this.cboFuente.SelectedIndexChanged += new System.EventHandler(this.cboFuente_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Fuente de sonido:";
            // 
            // pnlDispositivo
            // 
            this.pnlDispositivo.Controls.Add(this.LabelDispositivoAudio);
            this.pnlDispositivo.Controls.Add(this.cbAudioDevice);
            this.pnlDispositivo.Controls.Add(this.cbAudioFormat);
            this.pnlDispositivo.Controls.Add(this.lblFormatoAudio);
            this.pnlDispositivo.Location = new System.Drawing.Point(0, 67);
            this.pnlDispositivo.Name = "pnlDispositivo";
            this.pnlDispositivo.Size = new System.Drawing.Size(513, 56);
            this.pnlDispositivo.TabIndex = 31;
            // 
            // pnlCamaraIp
            // 
            this.pnlCamaraIp.Controls.Add(this.label2);
            this.pnlCamaraIp.Location = new System.Drawing.Point(0, 67);
            this.pnlCamaraIp.Name = "pnlCamaraIp";
            this.pnlCamaraIp.Size = new System.Drawing.Size(513, 56);
            this.pnlCamaraIp.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Asegurese de configurar una cámara IP con audio.";
            // 
            // AudioConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 227);
            this.Controls.Add(this.pnlDispositivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboFuente);
            this.Controls.Add(this.chkAudioDeviceRendering);
            this.Controls.Add(this.LabelLine);
            this.Controls.Add(this.LabelReproduccion);
            this.Controls.Add(this.cbAudioLine);
            this.Controls.Add(this.cbAudioOutput);
            this.Controls.Add(this.pnlCamaraIp);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AudioConfig";
            this.Text = "AudioConfig";
            this.pnlDispositivo.ResumeLayout(false);
            this.pnlDispositivo.PerformLayout();
            this.pnlCamaraIp.ResumeLayout(false);
            this.pnlCamaraIp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAudioDeviceRendering;
        private System.Windows.Forms.Label LabelLine;
        private System.Windows.Forms.Label lblFormatoAudio;
        private System.Windows.Forms.Label LabelReproduccion;
        private System.Windows.Forms.Label LabelDispositivoAudio;
        private System.Windows.Forms.ComboBox cbAudioLine;
        private System.Windows.Forms.ComboBox cbAudioFormat;
        private System.Windows.Forms.ComboBox cbAudioOutput;
        private System.Windows.Forms.ComboBox cbAudioDevice;
        private System.Windows.Forms.ComboBox cboFuente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDispositivo;
        private System.Windows.Forms.Panel pnlCamaraIp;
        private System.Windows.Forms.Label label2;
    }
}