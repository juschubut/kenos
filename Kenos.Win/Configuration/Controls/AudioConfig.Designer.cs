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
            this.SuspendLayout();
            // 
            // chkAudioDeviceRendering
            // 
            this.chkAudioDeviceRendering.AutoSize = true;
            this.chkAudioDeviceRendering.Location = new System.Drawing.Point(0, 110);
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
            this.LabelLine.Location = new System.Drawing.Point(370, 56);
            this.LabelLine.Name = "LabelLine";
            this.LabelLine.Size = new System.Drawing.Size(39, 17);
            this.LabelLine.TabIndex = 25;
            this.LabelLine.Text = "Line:";
            // 
            // lblFormatoAudio
            // 
            this.lblFormatoAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormatoAudio.AutoSize = true;
            this.lblFormatoAudio.Location = new System.Drawing.Point(370, 4);
            this.lblFormatoAudio.Name = "lblFormatoAudio";
            this.lblFormatoAudio.Size = new System.Drawing.Size(64, 17);
            this.lblFormatoAudio.TabIndex = 26;
            this.lblFormatoAudio.Text = "Formato:";
            // 
            // LabelReproduccion
            // 
            this.LabelReproduccion.AutoSize = true;
            this.LabelReproduccion.Location = new System.Drawing.Point(0, 56);
            this.LabelReproduccion.Name = "LabelReproduccion";
            this.LabelReproduccion.Size = new System.Drawing.Size(100, 17);
            this.LabelReproduccion.TabIndex = 27;
            this.LabelReproduccion.Text = "Reproducción:";
            // 
            // LabelDispositivoAudio
            // 
            this.LabelDispositivoAudio.AutoSize = true;
            this.LabelDispositivoAudio.Location = new System.Drawing.Point(0, 4);
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
            this.cbAudioLine.Location = new System.Drawing.Point(370, 75);
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
            this.cbAudioFormat.Location = new System.Drawing.Point(370, 23);
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
            this.cbAudioOutput.Location = new System.Drawing.Point(0, 75);
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
            this.cbAudioDevice.Location = new System.Drawing.Point(0, 23);
            this.cbAudioDevice.Name = "cbAudioDevice";
            this.cbAudioDevice.Size = new System.Drawing.Size(364, 24);
            this.cbAudioDevice.TabIndex = 0;
            this.cbAudioDevice.SelectedIndexChanged += new System.EventHandler(this.cbAudioDevice_SelectedIndexChanged);
            // 
            // AudioConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 235);
            this.Controls.Add(this.chkAudioDeviceRendering);
            this.Controls.Add(this.LabelLine);
            this.Controls.Add(this.lblFormatoAudio);
            this.Controls.Add(this.LabelReproduccion);
            this.Controls.Add(this.LabelDispositivoAudio);
            this.Controls.Add(this.cbAudioLine);
            this.Controls.Add(this.cbAudioFormat);
            this.Controls.Add(this.cbAudioOutput);
            this.Controls.Add(this.cbAudioDevice);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AudioConfig";
            this.Text = "AudioConfig";
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
    }
}