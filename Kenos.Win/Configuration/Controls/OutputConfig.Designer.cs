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
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBitRates)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelCalidad
            // 
            this.LabelCalidad.AutoSize = true;
            this.LabelCalidad.Location = new System.Drawing.Point(0, 131);
            this.LabelCalidad.Name = "LabelCalidad";
            this.LabelCalidad.Size = new System.Drawing.Size(59, 17);
            this.LabelCalidad.TabIndex = 11;
            this.LabelCalidad.Text = "Calidad:";
            // 
            // LabelBitRates
            // 
            this.LabelBitRates.AutoSize = true;
            this.LabelBitRates.Location = new System.Drawing.Point(0, 64);
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
            this.tbVideoQuality.Location = new System.Drawing.Point(0, 146);
            this.tbVideoQuality.Maximum = 100;
            this.tbVideoQuality.Minimum = 1;
            this.tbVideoQuality.Name = "tbVideoQuality";
            this.tbVideoQuality.Size = new System.Drawing.Size(503, 45);
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
            this.tbBitRates.Location = new System.Drawing.Point(0, 79);
            this.tbBitRates.Maximum = 1500000;
            this.tbBitRates.Minimum = 300000;
            this.tbBitRates.Name = "tbBitRates";
            this.tbBitRates.Size = new System.Drawing.Size(503, 45);
            this.tbBitRates.SmallChange = 100000;
            this.tbBitRates.TabIndex = 10;
            this.tbBitRates.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbBitRates.Value = 300000;
            this.tbBitRates.Scroll += new System.EventHandler(this.tbBitRates_Scroll);
            // 
            // LabelCompresor
            // 
            this.LabelCompresor.AutoSize = true;
            this.LabelCompresor.Location = new System.Drawing.Point(0, 215);
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
            this.cbAudioCompressor.Location = new System.Drawing.Point(0, 237);
            this.cbAudioCompressor.Name = "cbAudioCompressor";
            this.cbAudioCompressor.Size = new System.Drawing.Size(503, 24);
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
            this.cbFrames.Location = new System.Drawing.Point(0, 22);
            this.cbFrames.Name = "cbFrames";
            this.cbFrames.Size = new System.Drawing.Size(136, 24);
            this.cbFrames.TabIndex = 16;
            // 
            // lblBitRates
            // 
            this.lblBitRates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBitRates.Location = new System.Drawing.Point(80, 64);
            this.lblBitRates.Name = "lblBitRates";
            this.lblBitRates.Size = new System.Drawing.Size(50, 16);
            this.lblBitRates.TabIndex = 18;
            // 
            // lblVideoQuality
            // 
            this.lblVideoQuality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVideoQuality.Location = new System.Drawing.Point(80, 131);
            this.lblVideoQuality.Name = "lblVideoQuality";
            this.lblVideoQuality.Size = new System.Drawing.Size(50, 16);
            this.lblVideoQuality.TabIndex = 19;
            // 
            // OutputConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 285);
            this.Controls.Add(this.lblVideoQuality);
            this.Controls.Add(this.lblBitRates);
            this.Controls.Add(this.LabelFrames);
            this.Controls.Add(this.cbFrames);
            this.Controls.Add(this.LabelCompresor);
            this.Controls.Add(this.cbAudioCompressor);
            this.Controls.Add(this.LabelCalidad);
            this.Controls.Add(this.LabelBitRates);
            this.Controls.Add(this.tbVideoQuality);
            this.Controls.Add(this.tbBitRates);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OutputConfig";
            this.Text = "OutputConfig";
            ((System.ComponentModel.ISupportInitialize)(this.tbVideoQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBitRates)).EndInit();
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
    }
}