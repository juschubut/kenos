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
            this.cbVideoDevice = new System.Windows.Forms.ComboBox();
            this.LabelDispositivo = new System.Windows.Forms.Label();
            this.groupBoxVideo = new System.Windows.Forms.GroupBox();
            this.lblBitRates = new System.Windows.Forms.Label();
            this.lblVideoQuality = new System.Windows.Forms.Label();
            this.LabelCalidad = new System.Windows.Forms.Label();
            this.LabelBitRates = new System.Windows.Forms.Label();
            this.LabelNorma = new System.Windows.Forms.Label();
            this.cbNorma = new System.Windows.Forms.ComboBox();
            this.LabelFrames = new System.Windows.Forms.Label();
            this.LabelSubtipo = new System.Windows.Forms.Label();
            this.LabelTamanio = new System.Windows.Forms.Label();
            this.cbFrames = new System.Windows.Forms.ComboBox();
            this.cbVideoSize = new System.Windows.Forms.ComboBox();
            this.cbVideoSubtype = new System.Windows.Forms.ComboBox();
            this.tbVideoQuality = new System.Windows.Forms.TrackBar();
            this.tbBitRates = new System.Windows.Forms.TrackBar();
            this.LabelDispositivoAudio = new System.Windows.Forms.Label();
            this.cbAudioDevice = new System.Windows.Forms.ComboBox();
            this.pnlBotonera = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBoxAudio = new System.Windows.Forms.GroupBox();
            this.chkAudioDeviceRendering = new System.Windows.Forms.CheckBox();
            this.cmdAudioCompressorConfig = new System.Windows.Forms.Button();
            this.LabelCompresor = new System.Windows.Forms.Label();
            this.cbAudioCompressor = new System.Windows.Forms.ComboBox();
            this.LabelLine = new System.Windows.Forms.Label();
            this.lblFormatoAudio = new System.Windows.Forms.Label();
            this.LabelReproduccion = new System.Windows.Forms.Label();
            this.cbAudioLine = new System.Windows.Forms.ComboBox();
            this.cbAudioFormat = new System.Windows.Forms.ComboBox();
            this.cbAudioOutput = new System.Windows.Forms.ComboBox();
            this.groupBoxVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBitRates)).BeginInit();
            this.pnlBotonera.SuspendLayout();
            this.groupBoxAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbVideoDevice
            // 
            this.cbVideoDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoDevice.FormattingEnabled = true;
            this.cbVideoDevice.Location = new System.Drawing.Point(17, 38);
            this.cbVideoDevice.Name = "cbVideoDevice";
            this.cbVideoDevice.Size = new System.Drawing.Size(650, 24);
            this.cbVideoDevice.TabIndex = 0;
            this.cbVideoDevice.SelectedIndexChanged += new System.EventHandler(this.cbVideoDevice_SelectedIndexChanged);
            // 
            // LabelDispositivo
            // 
            this.LabelDispositivo.AutoSize = true;
            this.LabelDispositivo.Location = new System.Drawing.Point(14, 19);
            this.LabelDispositivo.Name = "LabelDispositivo";
            this.LabelDispositivo.Size = new System.Drawing.Size(78, 16);
            this.LabelDispositivo.TabIndex = 1;
            this.LabelDispositivo.Text = "Dispositivo:";
            // 
            // groupBoxVideo
            // 
            this.groupBoxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxVideo.Controls.Add(this.lblBitRates);
            this.groupBoxVideo.Controls.Add(this.lblVideoQuality);
            this.groupBoxVideo.Controls.Add(this.LabelCalidad);
            this.groupBoxVideo.Controls.Add(this.LabelBitRates);
            this.groupBoxVideo.Controls.Add(this.LabelNorma);
            this.groupBoxVideo.Controls.Add(this.cbNorma);
            this.groupBoxVideo.Controls.Add(this.LabelFrames);
            this.groupBoxVideo.Controls.Add(this.LabelSubtipo);
            this.groupBoxVideo.Controls.Add(this.LabelTamanio);
            this.groupBoxVideo.Controls.Add(this.LabelDispositivo);
            this.groupBoxVideo.Controls.Add(this.cbFrames);
            this.groupBoxVideo.Controls.Add(this.cbVideoSize);
            this.groupBoxVideo.Controls.Add(this.cbVideoDevice);
            this.groupBoxVideo.Controls.Add(this.cbVideoSubtype);
            this.groupBoxVideo.Controls.Add(this.tbVideoQuality);
            this.groupBoxVideo.Controls.Add(this.tbBitRates);
            this.groupBoxVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVideo.Location = new System.Drawing.Point(12, 11);
            this.groupBoxVideo.Name = "groupBoxVideo";
            this.groupBoxVideo.Size = new System.Drawing.Size(682, 195);
            this.groupBoxVideo.TabIndex = 2;
            this.groupBoxVideo.TabStop = false;
            this.groupBoxVideo.Text = "Video";
            // 
            // lblBitRates
            // 
            this.lblBitRates.AutoSize = true;
            this.lblBitRates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBitRates.Location = new System.Drawing.Point(90, 133);
            this.lblBitRates.Name = "lblBitRates";
            this.lblBitRates.Size = new System.Drawing.Size(0, 16);
            this.lblBitRates.TabIndex = 8;
            // 
            // lblVideoQuality
            // 
            this.lblVideoQuality.AutoSize = true;
            this.lblVideoQuality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVideoQuality.Location = new System.Drawing.Point(417, 133);
            this.lblVideoQuality.Name = "lblVideoQuality";
            this.lblVideoQuality.Size = new System.Drawing.Size(0, 16);
            this.lblVideoQuality.TabIndex = 8;
            // 
            // LabelCalidad
            // 
            this.LabelCalidad.AutoSize = true;
            this.LabelCalidad.Location = new System.Drawing.Point(357, 133);
            this.LabelCalidad.Name = "LabelCalidad";
            this.LabelCalidad.Size = new System.Drawing.Size(58, 16);
            this.LabelCalidad.TabIndex = 8;
            this.LabelCalidad.Text = "Calidad:";
            // 
            // LabelBitRates
            // 
            this.LabelBitRates.AutoSize = true;
            this.LabelBitRates.Location = new System.Drawing.Point(16, 133);
            this.LabelBitRates.Name = "LabelBitRates";
            this.LabelBitRates.Size = new System.Drawing.Size(65, 16);
            this.LabelBitRates.TabIndex = 8;
            this.LabelBitRates.Text = "Bit Rates:";
            // 
            // LabelNorma
            // 
            this.LabelNorma.AutoSize = true;
            this.LabelNorma.Location = new System.Drawing.Point(405, 75);
            this.LabelNorma.Name = "LabelNorma";
            this.LabelNorma.Size = new System.Drawing.Size(49, 16);
            this.LabelNorma.TabIndex = 3;
            this.LabelNorma.Text = "Norma";
            // 
            // cbNorma
            // 
            this.cbNorma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNorma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNorma.FormattingEnabled = true;
            this.cbNorma.Location = new System.Drawing.Point(408, 94);
            this.cbNorma.Name = "cbNorma";
            this.cbNorma.Size = new System.Drawing.Size(136, 24);
            this.cbNorma.TabIndex = 2;
            // 
            // LabelFrames
            // 
            this.LabelFrames.AutoSize = true;
            this.LabelFrames.Location = new System.Drawing.Point(604, 75);
            this.LabelFrames.Name = "LabelFrames";
            this.LabelFrames.Size = new System.Drawing.Size(57, 16);
            this.LabelFrames.TabIndex = 1;
            this.LabelFrames.Text = "Frames:";
            // 
            // LabelSubtipo
            // 
            this.LabelSubtipo.AutoSize = true;
            this.LabelSubtipo.Location = new System.Drawing.Point(242, 75);
            this.LabelSubtipo.Name = "LabelSubtipo";
            this.LabelSubtipo.Size = new System.Drawing.Size(57, 16);
            this.LabelSubtipo.TabIndex = 1;
            this.LabelSubtipo.Text = "Subtipo:";
            // 
            // LabelTamanio
            // 
            this.LabelTamanio.AutoSize = true;
            this.LabelTamanio.Location = new System.Drawing.Point(14, 75);
            this.LabelTamanio.Name = "LabelTamanio";
            this.LabelTamanio.Size = new System.Drawing.Size(62, 16);
            this.LabelTamanio.TabIndex = 1;
            this.LabelTamanio.Text = "Tamaño:";
            // 
            // cbFrames
            // 
            this.cbFrames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrames.FormattingEnabled = true;
            this.cbFrames.Location = new System.Drawing.Point(605, 94);
            this.cbFrames.Name = "cbFrames";
            this.cbFrames.Size = new System.Drawing.Size(62, 24);
            this.cbFrames.TabIndex = 0;
            // 
            // cbVideoSize
            // 
            this.cbVideoSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoSize.FormattingEnabled = true;
            this.cbVideoSize.Location = new System.Drawing.Point(16, 94);
            this.cbVideoSize.Name = "cbVideoSize";
            this.cbVideoSize.Size = new System.Drawing.Size(209, 24);
            this.cbVideoSize.TabIndex = 0;
            // 
            // cbVideoSubtype
            // 
            this.cbVideoSubtype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoSubtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoSubtype.FormattingEnabled = true;
            this.cbVideoSubtype.Location = new System.Drawing.Point(245, 94);
            this.cbVideoSubtype.Name = "cbVideoSubtype";
            this.cbVideoSubtype.Size = new System.Drawing.Size(136, 24);
            this.cbVideoSubtype.TabIndex = 0;
            // 
            // tbVideoQuality
            // 
            this.tbVideoQuality.LargeChange = 10;
            this.tbVideoQuality.Location = new System.Drawing.Point(357, 148);
            this.tbVideoQuality.Maximum = 100;
            this.tbVideoQuality.Minimum = 1;
            this.tbVideoQuality.Name = "tbVideoQuality";
            this.tbVideoQuality.Size = new System.Drawing.Size(310, 45);
            this.tbVideoQuality.TabIndex = 9;
            this.tbVideoQuality.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbVideoQuality.Value = 100;
            this.tbVideoQuality.Scroll += new System.EventHandler(this.tbVideoQuality_Scroll);
            // 
            // tbBitRates
            // 
            this.tbBitRates.LargeChange = 300000;
            this.tbBitRates.Location = new System.Drawing.Point(16, 148);
            this.tbBitRates.Maximum = 1500000;
            this.tbBitRates.Minimum = 300000;
            this.tbBitRates.Name = "tbBitRates";
            this.tbBitRates.Size = new System.Drawing.Size(310, 45);
            this.tbBitRates.SmallChange = 100000;
            this.tbBitRates.TabIndex = 7;
            this.tbBitRates.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbBitRates.Value = 300000;
            this.tbBitRates.Scroll += new System.EventHandler(this.tbBitRates_Scroll);
            // 
            // LabelDispositivoAudio
            // 
            this.LabelDispositivoAudio.AutoSize = true;
            this.LabelDispositivoAudio.Location = new System.Drawing.Point(14, 18);
            this.LabelDispositivoAudio.Name = "LabelDispositivoAudio";
            this.LabelDispositivoAudio.Size = new System.Drawing.Size(78, 16);
            this.LabelDispositivoAudio.TabIndex = 1;
            this.LabelDispositivoAudio.Text = "Dispositivo:";
            // 
            // cbAudioDevice
            // 
            this.cbAudioDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioDevice.FormattingEnabled = true;
            this.cbAudioDevice.Location = new System.Drawing.Point(17, 37);
            this.cbAudioDevice.Name = "cbAudioDevice";
            this.cbAudioDevice.Size = new System.Drawing.Size(329, 24);
            this.cbAudioDevice.TabIndex = 0;
            this.cbAudioDevice.SelectedIndexChanged += new System.EventHandler(this.cbAudioDevice_SelectedIndexChanged);
            // 
            // pnlBotonera
            // 
            this.pnlBotonera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBotonera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.pnlBotonera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBotonera.Controls.Add(this.btnAceptar);
            this.pnlBotonera.Controls.Add(this.btnCancelar);
            this.pnlBotonera.Location = new System.Drawing.Point(0, 448);
            this.pnlBotonera.Name = "pnlBotonera";
            this.pnlBotonera.Size = new System.Drawing.Size(709, 56);
            this.pnlBotonera.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(522, 14);
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
            this.btnCancelar.Location = new System.Drawing.Point(619, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBoxAudio
            // 
            this.groupBoxAudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAudio.Controls.Add(this.chkAudioDeviceRendering);
            this.groupBoxAudio.Controls.Add(this.cmdAudioCompressorConfig);
            this.groupBoxAudio.Controls.Add(this.LabelCompresor);
            this.groupBoxAudio.Controls.Add(this.cbAudioCompressor);
            this.groupBoxAudio.Controls.Add(this.LabelLine);
            this.groupBoxAudio.Controls.Add(this.lblFormatoAudio);
            this.groupBoxAudio.Controls.Add(this.LabelReproduccion);
            this.groupBoxAudio.Controls.Add(this.LabelDispositivoAudio);
            this.groupBoxAudio.Controls.Add(this.cbAudioLine);
            this.groupBoxAudio.Controls.Add(this.cbAudioFormat);
            this.groupBoxAudio.Controls.Add(this.cbAudioOutput);
            this.groupBoxAudio.Controls.Add(this.cbAudioDevice);
            this.groupBoxAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAudio.Location = new System.Drawing.Point(12, 215);
            this.groupBoxAudio.Name = "groupBoxAudio";
            this.groupBoxAudio.Size = new System.Drawing.Size(682, 221);
            this.groupBoxAudio.TabIndex = 4;
            this.groupBoxAudio.TabStop = false;
            this.groupBoxAudio.Text = "Audio";
            // 
            // chkAudioDeviceRendering
            // 
            this.chkAudioDeviceRendering.AutoSize = true;
            this.chkAudioDeviceRendering.Location = new System.Drawing.Point(16, 124);
            this.chkAudioDeviceRendering.Name = "chkAudioDeviceRendering";
            this.chkAudioDeviceRendering.Size = new System.Drawing.Size(242, 20);
            this.chkAudioDeviceRendering.TabIndex = 8;
            this.chkAudioDeviceRendering.Text = "Reproducir audio mientras se graba";
            this.chkAudioDeviceRendering.UseVisualStyleBackColor = true;
            // 
            // cmdAudioCompressorConfig
            // 
            this.cmdAudioCompressorConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAudioCompressorConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAudioCompressorConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAudioCompressorConfig.ForeColor = System.Drawing.Color.White;
            this.cmdAudioCompressorConfig.Location = new System.Drawing.Point(632, 183);
            this.cmdAudioCompressorConfig.Name = "cmdAudioCompressorConfig";
            this.cmdAudioCompressorConfig.Size = new System.Drawing.Size(29, 24);
            this.cmdAudioCompressorConfig.TabIndex = 7;
            this.cmdAudioCompressorConfig.Text = "...";
            this.cmdAudioCompressorConfig.UseVisualStyleBackColor = true;
            this.cmdAudioCompressorConfig.Visible = false;
            this.cmdAudioCompressorConfig.Click += new System.EventHandler(this.cmdAudioCompressorConfig_Click);
            // 
            // LabelCompresor
            // 
            this.LabelCompresor.AutoSize = true;
            this.LabelCompresor.Location = new System.Drawing.Point(14, 162);
            this.LabelCompresor.Name = "LabelCompresor";
            this.LabelCompresor.Size = new System.Drawing.Size(134, 16);
            this.LabelCompresor.TabIndex = 3;
            this.LabelCompresor.Text = "Compresor de audio:";
            // 
            // cbAudioCompressor
            // 
            this.cbAudioCompressor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioCompressor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioCompressor.FormattingEnabled = true;
            this.cbAudioCompressor.Location = new System.Drawing.Point(17, 184);
            this.cbAudioCompressor.Name = "cbAudioCompressor";
            this.cbAudioCompressor.Size = new System.Drawing.Size(609, 24);
            this.cbAudioCompressor.TabIndex = 2;
            // 
            // LabelLine
            // 
            this.LabelLine.AutoSize = true;
            this.LabelLine.Location = new System.Drawing.Point(361, 70);
            this.LabelLine.Name = "LabelLine";
            this.LabelLine.Size = new System.Drawing.Size(36, 16);
            this.LabelLine.TabIndex = 1;
            this.LabelLine.Text = "Line:";
            // 
            // lblFormatoAudio
            // 
            this.lblFormatoAudio.AutoSize = true;
            this.lblFormatoAudio.Location = new System.Drawing.Point(361, 18);
            this.lblFormatoAudio.Name = "lblFormatoAudio";
            this.lblFormatoAudio.Size = new System.Drawing.Size(61, 16);
            this.lblFormatoAudio.TabIndex = 1;
            this.lblFormatoAudio.Text = "Formato:";
            // 
            // LabelReproduccion
            // 
            this.LabelReproduccion.AutoSize = true;
            this.LabelReproduccion.Location = new System.Drawing.Point(14, 70);
            this.LabelReproduccion.Name = "LabelReproduccion";
            this.LabelReproduccion.Size = new System.Drawing.Size(96, 16);
            this.LabelReproduccion.TabIndex = 1;
            this.LabelReproduccion.Text = "Reproducción:";
            // 
            // cbAudioLine
            // 
            this.cbAudioLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioLine.FormattingEnabled = true;
            this.cbAudioLine.Location = new System.Drawing.Point(364, 89);
            this.cbAudioLine.Name = "cbAudioLine";
            this.cbAudioLine.Size = new System.Drawing.Size(303, 24);
            this.cbAudioLine.TabIndex = 0;
            // 
            // cbAudioFormat
            // 
            this.cbAudioFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioFormat.FormattingEnabled = true;
            this.cbAudioFormat.Location = new System.Drawing.Point(364, 37);
            this.cbAudioFormat.Name = "cbAudioFormat";
            this.cbAudioFormat.Size = new System.Drawing.Size(303, 24);
            this.cbAudioFormat.TabIndex = 0;
            // 
            // cbAudioOutput
            // 
            this.cbAudioOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioOutput.FormattingEnabled = true;
            this.cbAudioOutput.Location = new System.Drawing.Point(17, 89);
            this.cbAudioOutput.Name = "cbAudioOutput";
            this.cbAudioOutput.Size = new System.Drawing.Size(329, 24);
            this.cbAudioOutput.TabIndex = 0;
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(709, 504);
            this.Controls.Add(this.groupBoxAudio);
            this.Controls.Add(this.pnlBotonera);
            this.Controls.Add(this.groupBoxVideo);
            this.Name = "frmConfiguracion";
            this.Text = "Configuración";
            this.groupBoxVideo.ResumeLayout(false);
            this.groupBoxVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBitRates)).EndInit();
            this.pnlBotonera.ResumeLayout(false);
            this.groupBoxAudio.ResumeLayout(false);
            this.groupBoxAudio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbVideoDevice;
        private System.Windows.Forms.Label LabelDispositivo;
        private System.Windows.Forms.GroupBox groupBoxVideo;
        private System.Windows.Forms.Label LabelDispositivoAudio;
        private System.Windows.Forms.ComboBox cbAudioDevice;
        private System.Windows.Forms.Panel pnlBotonera;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBoxAudio;
        private System.Windows.Forms.Label LabelTamanio;
        private System.Windows.Forms.ComboBox cbVideoSize;
        private System.Windows.Forms.Label LabelReproduccion;
        private System.Windows.Forms.ComboBox cbAudioOutput;
        private System.Windows.Forms.Label LabelFrames;
        private System.Windows.Forms.ComboBox cbFrames;
        private System.Windows.Forms.Label lblFormatoAudio;
        private System.Windows.Forms.ComboBox cbAudioFormat;
        private System.Windows.Forms.Label LabelLine;
        private System.Windows.Forms.ComboBox cbAudioLine;
        private System.Windows.Forms.Label LabelSubtipo;
        private System.Windows.Forms.ComboBox cbVideoSubtype;
        private System.Windows.Forms.Label LabelNorma;
        private System.Windows.Forms.ComboBox cbNorma;
        private System.Windows.Forms.Label LabelCompresor;
        private System.Windows.Forms.ComboBox cbAudioCompressor;
        private System.Windows.Forms.Button cmdAudioCompressorConfig;
        private System.Windows.Forms.Label LabelBitRates;
        private System.Windows.Forms.TrackBar tbBitRates;
        private System.Windows.Forms.TrackBar tbVideoQuality;
        private System.Windows.Forms.Label LabelCalidad;
        private System.Windows.Forms.Label lblBitRates;
        private System.Windows.Forms.Label lblVideoQuality;
        private System.Windows.Forms.CheckBox chkAudioDeviceRendering;
    }
}