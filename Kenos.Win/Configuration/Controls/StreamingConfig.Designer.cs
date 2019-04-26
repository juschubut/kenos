namespace Kenos.Win.ConfigControls
{
    partial class StreamingConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdVideo = new System.Windows.Forms.RadioButton();
            this.rdAudio = new System.Windows.Forms.RadioButton();
            this.rdAudioVideo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puerto";
            // 
            // txtPuerto
            // 
            this.txtPuerto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPuerto.Location = new System.Drawing.Point(0, 25);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(100, 23);
            this.txtPuerto.TabIndex = 1;
            this.txtPuerto.TextChanged += new System.EventHandler(this.txtPuerto_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdVideo);
            this.panel1.Controls.Add(this.rdAudio);
            this.panel1.Controls.Add(this.rdAudioVideo);
            this.panel1.Location = new System.Drawing.Point(394, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 86);
            this.panel1.TabIndex = 2;
            // 
            // rdVideo
            // 
            this.rdVideo.AutoSize = true;
            this.rdVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdVideo.Location = new System.Drawing.Point(3, 57);
            this.rdVideo.Name = "rdVideo";
            this.rdVideo.Size = new System.Drawing.Size(93, 21);
            this.rdVideo.TabIndex = 0;
            this.rdVideo.Text = "Solo Video";
            this.rdVideo.UseVisualStyleBackColor = true;
            // 
            // rdAudio
            // 
            this.rdAudio.AutoSize = true;
            this.rdAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdAudio.Location = new System.Drawing.Point(3, 30);
            this.rdAudio.Name = "rdAudio";
            this.rdAudio.Size = new System.Drawing.Size(93, 21);
            this.rdAudio.TabIndex = 0;
            this.rdAudio.Text = "Solo Audio";
            this.rdAudio.UseVisualStyleBackColor = true;
            // 
            // rdAudioVideo
            // 
            this.rdAudioVideo.AutoSize = true;
            this.rdAudioVideo.Checked = true;
            this.rdAudioVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdAudioVideo.Location = new System.Drawing.Point(3, 3);
            this.rdAudioVideo.Name = "rdAudioVideo";
            this.rdAudioVideo.Size = new System.Drawing.Size(112, 21);
            this.rdAudioVideo.TabIndex = 0;
            this.rdAudioVideo.TabStop = true;
            this.rdAudioVideo.Text = "Audio y Video";
            this.rdAudioVideo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Limite de usuarios conectados";
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            ""});
            this.cboUsuarios.Location = new System.Drawing.Point(0, 102);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(100, 24);
            this.cboUsuarios.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ejemplo de url:";
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrl.Location = new System.Drawing.Point(0, 181);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(518, 23);
            this.txtUrl.TabIndex = 1;
            // 
            // StreamingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 468);
            this.Controls.Add(this.cboUsuarios);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StreamingConfig";
            this.Text = "StreamingConfig";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdVideo;
        private System.Windows.Forms.RadioButton rdAudio;
        private System.Windows.Forms.RadioButton rdAudioVideo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUrl;
    }
}