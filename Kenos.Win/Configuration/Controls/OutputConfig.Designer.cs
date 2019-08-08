namespace Kenos.Win.ConfigControls
{
    partial class OutputConfig
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
            this.LabelCalidad = new System.Windows.Forms.Label();
            this.LabelBitRates = new System.Windows.Forms.Label();
            this.tbVideoQuality = new System.Windows.Forms.TrackBar();
            this.tbBitRates = new System.Windows.Forms.TrackBar();
            this.LabelCompresor = new System.Windows.Forms.Label();
            this.cbAudioCompressor = new System.Windows.Forms.ComboBox();
            this.LabelFrames = new System.Windows.Forms.Label();
            this.cbFrames = new System.Windows.Forms.ComboBox();
            this.lblBitRates = new System.Windows.Forms.Label();
            this.lblVideoQuality = new System.Windows.Forms.Label();
            this.cboVideoFormat = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlWMV = new System.Windows.Forms.Panel();
            this.pnlMP4 = new System.Windows.Forms.Panel();
            this.lblCompressorAudioMP4 = new System.Windows.Forms.Label();
            this.cboCompressorAudioMP4 = new System.Windows.Forms.ComboBox();
            this.btnVideoCompressorConfig = new System.Windows.Forms.Button();
            this.lblVideoCompressor = new System.Windows.Forms.Label();
            this.cboVideoCompressor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkModoNativo = new System.Windows.Forms.CheckBox();
            this.lblModoNativo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBitRates)).BeginInit();
            this.pnlWMV.SuspendLayout();
            this.pnlMP4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelCalidad
            // 
            this.LabelCalidad.AutoSize = true;
            this.LabelCalidad.Location = new System.Drawing.Point(0, 128);
            this.LabelCalidad.Name = "LabelCalidad";
            this.LabelCalidad.Size = new System.Drawing.Size(59, 17);
            this.LabelCalidad.TabIndex = 11;
            this.LabelCalidad.Text = "Calidad:";
            // 
            // LabelBitRates
            // 
            this.LabelBitRates.AutoSize = true;
            this.LabelBitRates.Location = new System.Drawing.Point(0, 61);
            this.LabelBitRates.Name = "LabelBitRates";
            this.LabelBitRates.Size = new System.Drawing.Size(69, 17);
            this.LabelBitRates.TabIndex = 12;
            this.LabelBitRates.Text = "Bit Rates:";
            // 
            // tbVideoQuality
            // 
            this.tbVideoQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVideoQuality.LargeChange = 10;
            this.tbVideoQuality.Location = new System.Drawing.Point(4, 147);
            this.tbVideoQuality.Maximum = 100;
            this.tbVideoQuality.Minimum = 1;
            this.tbVideoQuality.Name = "tbVideoQuality";
            this.tbVideoQuality.Size = new System.Drawing.Size(469, 45);
            this.tbVideoQuality.TabIndex = 13;
            this.tbVideoQuality.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbVideoQuality.Value = 100;
            this.tbVideoQuality.Scroll += new System.EventHandler(this.tbVideoQuality_Scroll);
            // 
            // tbBitRates
            // 
            this.tbBitRates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBitRates.LargeChange = 300000;
            this.tbBitRates.Location = new System.Drawing.Point(4, 80);
            this.tbBitRates.Maximum = 1500000;
            this.tbBitRates.Minimum = 300000;
            this.tbBitRates.Name = "tbBitRates";
            this.tbBitRates.Size = new System.Drawing.Size(469, 45);
            this.tbBitRates.SmallChange = 100000;
            this.tbBitRates.TabIndex = 10;
            this.tbBitRates.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbBitRates.Value = 300000;
            this.tbBitRates.Scroll += new System.EventHandler(this.tbBitRates_Scroll);
            // 
            // LabelCompresor
            // 
            this.LabelCompresor.AutoSize = true;
            this.LabelCompresor.Location = new System.Drawing.Point(0, 0);
            this.LabelCompresor.Name = "LabelCompresor";
            this.LabelCompresor.Size = new System.Drawing.Size(140, 17);
            this.LabelCompresor.TabIndex = 15;
            this.LabelCompresor.Text = "Compresor de audio:";
            // 
            // cbAudioCompressor
            // 
            this.cbAudioCompressor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioCompressor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioCompressor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAudioCompressor.FormattingEnabled = true;
            this.cbAudioCompressor.Location = new System.Drawing.Point(0, 22);
            this.cbAudioCompressor.Name = "cbAudioCompressor";
            this.cbAudioCompressor.Size = new System.Drawing.Size(492, 24);
            this.cbAudioCompressor.TabIndex = 14;
            // 
            // LabelFrames
            // 
            this.LabelFrames.AutoSize = true;
            this.LabelFrames.Location = new System.Drawing.Point(0, 3);
            this.LabelFrames.Name = "LabelFrames";
            this.LabelFrames.Size = new System.Drawing.Size(59, 17);
            this.LabelFrames.TabIndex = 17;
            this.LabelFrames.Text = "Frames:";
            // 
            // cbFrames
            // 
            this.cbFrames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFrames.FormattingEnabled = true;
            this.cbFrames.Location = new System.Drawing.Point(1, 23);
            this.cbFrames.Name = "cbFrames";
            this.cbFrames.Size = new System.Drawing.Size(125, 24);
            this.cbFrames.TabIndex = 16;
            // 
            // lblBitRates
            // 
            this.lblBitRates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBitRates.Location = new System.Drawing.Point(72, 61);
            this.lblBitRates.Name = "lblBitRates";
            this.lblBitRates.Size = new System.Drawing.Size(50, 16);
            this.lblBitRates.TabIndex = 18;
            // 
            // lblVideoQuality
            // 
            this.lblVideoQuality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVideoQuality.Location = new System.Drawing.Point(72, 128);
            this.lblVideoQuality.Name = "lblVideoQuality";
            this.lblVideoQuality.Size = new System.Drawing.Size(50, 16);
            this.lblVideoQuality.TabIndex = 19;
            // 
            // cboVideoFormat
            // 
            this.cboVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVideoFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboVideoFormat.FormattingEnabled = true;
            this.cboVideoFormat.Items.AddRange(new object[] {
            "wmv"});
            this.cboVideoFormat.Location = new System.Drawing.Point(11, 48);
            this.cboVideoFormat.Name = "cboVideoFormat";
            this.cboVideoFormat.Size = new System.Drawing.Size(125, 24);
            this.cboVideoFormat.TabIndex = 34;
            this.cboVideoFormat.SelectedIndexChanged += new System.EventHandler(this.cbVideoFormat_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "Formato de video";
            // 
            // pnlWMV
            // 
            this.pnlWMV.Controls.Add(this.LabelFrames);
            this.pnlWMV.Controls.Add(this.tbBitRates);
            this.pnlWMV.Controls.Add(this.tbVideoQuality);
            this.pnlWMV.Controls.Add(this.LabelBitRates);
            this.pnlWMV.Controls.Add(this.lblVideoQuality);
            this.pnlWMV.Controls.Add(this.LabelCalidad);
            this.pnlWMV.Controls.Add(this.lblBitRates);
            this.pnlWMV.Controls.Add(this.cbFrames);
            this.pnlWMV.Location = new System.Drawing.Point(11, 79);
            this.pnlWMV.Name = "pnlWMV";
            this.pnlWMV.Size = new System.Drawing.Size(492, 196);
            this.pnlWMV.TabIndex = 35;
            // 
            // pnlMP4
            // 
            this.pnlMP4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMP4.Controls.Add(this.lblModoNativo);
            this.pnlMP4.Controls.Add(this.chkModoNativo);
            this.pnlMP4.Controls.Add(this.lblCompressorAudioMP4);
            this.pnlMP4.Controls.Add(this.cboCompressorAudioMP4);
            this.pnlMP4.Controls.Add(this.btnVideoCompressorConfig);
            this.pnlMP4.Controls.Add(this.lblVideoCompressor);
            this.pnlMP4.Controls.Add(this.cboVideoCompressor);
            this.pnlMP4.Location = new System.Drawing.Point(12, 80);
            this.pnlMP4.Name = "pnlMP4";
            this.pnlMP4.Size = new System.Drawing.Size(490, 191);
            this.pnlMP4.TabIndex = 36;
            // 
            // lblCompressorAudioMP4
            // 
            this.lblCompressorAudioMP4.AutoSize = true;
            this.lblCompressorAudioMP4.Location = new System.Drawing.Point(-3, 124);
            this.lblCompressorAudioMP4.Name = "lblCompressorAudioMP4";
            this.lblCompressorAudioMP4.Size = new System.Drawing.Size(153, 17);
            this.lblCompressorAudioMP4.TabIndex = 43;
            this.lblCompressorAudioMP4.Text = "Compresor Audio MP4:";
            // 
            // cboCompressorAudioMP4
            // 
            this.cboCompressorAudioMP4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCompressorAudioMP4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompressorAudioMP4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCompressorAudioMP4.FormattingEnabled = true;
            this.cboCompressorAudioMP4.Location = new System.Drawing.Point(-3, 146);
            this.cboCompressorAudioMP4.Name = "cboCompressorAudioMP4";
            this.cboCompressorAudioMP4.Size = new System.Drawing.Size(403, 24);
            this.cboCompressorAudioMP4.TabIndex = 42;
            // 
            // btnVideoCompressorConfig
            // 
            this.btnVideoCompressorConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideoCompressorConfig.Location = new System.Drawing.Point(411, 86);
            this.btnVideoCompressorConfig.Name = "btnVideoCompressorConfig";
            this.btnVideoCompressorConfig.Size = new System.Drawing.Size(75, 27);
            this.btnVideoCompressorConfig.TabIndex = 41;
            this.btnVideoCompressorConfig.Text = "Config";
            this.btnVideoCompressorConfig.UseVisualStyleBackColor = true;
            this.btnVideoCompressorConfig.Click += new System.EventHandler(this.btnVideoCompressorConfig_Click);
            // 
            // lblVideoCompressor
            // 
            this.lblVideoCompressor.AutoSize = true;
            this.lblVideoCompressor.Location = new System.Drawing.Point(0, 65);
            this.lblVideoCompressor.Name = "lblVideoCompressor";
            this.lblVideoCompressor.Size = new System.Drawing.Size(153, 17);
            this.lblVideoCompressor.TabIndex = 40;
            this.lblVideoCompressor.Text = "Compresor Video MP4:";
            // 
            // cboVideoCompressor
            // 
            this.cboVideoCompressor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVideoCompressor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVideoCompressor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboVideoCompressor.FormattingEnabled = true;
            this.cboVideoCompressor.Location = new System.Drawing.Point(0, 87);
            this.cboVideoCompressor.Name = "cboVideoCompressor";
            this.cboVideoCompressor.Size = new System.Drawing.Size(403, 24);
            this.cboVideoCompressor.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Video output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-2, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Audio output";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LabelCompresor);
            this.panel1.Controls.Add(this.cbAudioCompressor);
            this.panel1.Location = new System.Drawing.Point(11, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 64);
            this.panel1.TabIndex = 39;
            // 
            // chkModoNativo
            // 
            this.chkModoNativo.AutoSize = true;
            this.chkModoNativo.Location = new System.Drawing.Point(0, 13);
            this.chkModoNativo.Name = "chkModoNativo";
            this.chkModoNativo.Size = new System.Drawing.Size(186, 21);
            this.chkModoNativo.TabIndex = 44;
            this.chkModoNativo.Text = "Grabar en formato nativo";
            this.chkModoNativo.UseVisualStyleBackColor = true;
            this.chkModoNativo.CheckedChanged += new System.EventHandler(this.chkModoNativo_CheckedChanged);
            // 
            // lblModoNativo
            // 
            this.lblModoNativo.Location = new System.Drawing.Point(246, 13);
            this.lblModoNativo.Name = "lblModoNativo";
            this.lblModoNativo.Size = new System.Drawing.Size(240, 52);
            this.lblModoNativo.TabIndex = 45;
            this.lblModoNativo.Text = "Solo en modo nativo se puede obtener audio desde la camara.";
            // 
            // OutputConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 392);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMP4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboVideoFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlWMV);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OutputConfig";
            this.Text = "OutputConfig";
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBitRates)).EndInit();
            this.pnlWMV.ResumeLayout(false);
            this.pnlWMV.PerformLayout();
            this.pnlMP4.ResumeLayout(false);
            this.pnlMP4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelCalidad;
        private System.Windows.Forms.Label LabelBitRates;
        private System.Windows.Forms.TrackBar tbVideoQuality;
        private System.Windows.Forms.TrackBar tbBitRates;
        private System.Windows.Forms.Label LabelCompresor;
        private System.Windows.Forms.ComboBox cbAudioCompressor;
        private System.Windows.Forms.Label LabelFrames;
        private System.Windows.Forms.ComboBox cbFrames;
        private System.Windows.Forms.Label lblBitRates;
        private System.Windows.Forms.Label lblVideoQuality;
        private System.Windows.Forms.ComboBox cboVideoFormat;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlWMV;
        private System.Windows.Forms.Panel pnlMP4;
        private System.Windows.Forms.Label lblVideoCompressor;
        private System.Windows.Forms.ComboBox cboVideoCompressor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVideoCompressorConfig;
        private System.Windows.Forms.Label lblCompressorAudioMP4;
        private System.Windows.Forms.ComboBox cboCompressorAudioMP4;
        private System.Windows.Forms.CheckBox chkModoNativo;
        private System.Windows.Forms.Label lblModoNativo;
    }
}