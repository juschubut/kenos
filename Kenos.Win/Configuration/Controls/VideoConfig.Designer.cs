﻿namespace Kenos.Win.ConfigControls
{
    partial class VideoConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoConfig));
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdCamara6 = new System.Windows.Forms.RadioButton();
            this.rdCamara5 = new System.Windows.Forms.RadioButton();
            this.rdCamara4 = new System.Windows.Forms.RadioButton();
            this.rdCamara3 = new System.Windows.Forms.RadioButton();
            this.rdCamara2 = new System.Windows.Forms.RadioButton();
            this.rdCamara1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rdLayout2 = new System.Windows.Forms.RadioButton();
            this.rdLayout4 = new System.Windows.Forms.RadioButton();
            this.rdLayout6 = new System.Windows.Forms.RadioButton();
            this.rdLayout1 = new System.Windows.Forms.RadioButton();
            this.pnlCamaraIp = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkMoveStartup = new System.Windows.Forms.LinkLabel();
            this.lnkMoveDown = new System.Windows.Forms.LinkLabel();
            this.lnkMoveUp = new System.Windows.Forms.LinkLabel();
            this.lnkMoveRight = new System.Windows.Forms.LinkLabel();
            this.lnkMoveLeft = new System.Windows.Forms.LinkLabel();
            this.btnPreviewStop = new System.Windows.Forms.Button();
            this.btnPreviewStart = new System.Windows.Forms.Button();
            this.txtLogPreview = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboPerfiles = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboPresetPosition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.vgPreview = new VidGrab.VideoGrabber();
            this.txtIpPassword = new System.Windows.Forms.TextBox();
            this.txtIpUsuario = new System.Windows.Forms.TextBox();
            this.txtIpPort = new System.Windows.Forms.TextBox();
            this.txtIpHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LabelDispositivo = new System.Windows.Forms.Label();
            this.pnlCamara = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.cbVideoInput = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbVideoFormat = new System.Windows.Forms.ComboBox();
            this.LabelNorma = new System.Windows.Forms.Label();
            this.cbNorma = new System.Windows.Forms.ComboBox();
            this.LabelSubtipo = new System.Windows.Forms.Label();
            this.LabelTamanio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbVideoSize = new System.Windows.Forms.ComboBox();
            this.cbVideoDevice = new System.Windows.Forms.ComboBox();
            this.cbVideoSubtype = new System.Windows.Forms.ComboBox();
            this.chkHabilitada = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.cbCodec = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlCamaraIp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlCamara.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Cámara Digital / Analógica",
            "Cámara IP"});
            this.cboTipo.Location = new System.Drawing.Point(0, 136);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(392, 24);
            this.cboTipo.TabIndex = 0;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tipo";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdCamara6);
            this.panel3.Controls.Add(this.rdCamara5);
            this.panel3.Controls.Add(this.rdCamara4);
            this.panel3.Controls.Add(this.rdCamara3);
            this.panel3.Controls.Add(this.rdCamara2);
            this.panel3.Controls.Add(this.rdCamara1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(274, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 46);
            this.panel3.TabIndex = 1;
            // 
            // rdCamara6
            // 
            this.rdCamara6.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdCamara6.AutoSize = true;
            this.rdCamara6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdCamara6.Location = new System.Drawing.Point(198, 10);
            this.rdCamara6.Margin = new System.Windows.Forms.Padding(4);
            this.rdCamara6.Name = "rdCamara6";
            this.rdCamara6.Size = new System.Drawing.Size(28, 29);
            this.rdCamara6.TabIndex = 5;
            this.rdCamara6.TabStop = true;
            this.rdCamara6.Tag = "5";
            this.rdCamara6.Text = "6";
            this.rdCamara6.UseVisualStyleBackColor = true;
            this.rdCamara6.Click += new System.EventHandler(this.rdCamara_Click);
            // 
            // rdCamara5
            // 
            this.rdCamara5.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdCamara5.AutoSize = true;
            this.rdCamara5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdCamara5.Location = new System.Drawing.Point(171, 10);
            this.rdCamara5.Margin = new System.Windows.Forms.Padding(4);
            this.rdCamara5.Name = "rdCamara5";
            this.rdCamara5.Size = new System.Drawing.Size(28, 29);
            this.rdCamara5.TabIndex = 4;
            this.rdCamara5.TabStop = true;
            this.rdCamara5.Tag = "4";
            this.rdCamara5.Text = "5";
            this.rdCamara5.UseVisualStyleBackColor = true;
            this.rdCamara5.Click += new System.EventHandler(this.rdCamara_Click);
            // 
            // rdCamara4
            // 
            this.rdCamara4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdCamara4.AutoSize = true;
            this.rdCamara4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdCamara4.Location = new System.Drawing.Point(144, 10);
            this.rdCamara4.Margin = new System.Windows.Forms.Padding(4);
            this.rdCamara4.Name = "rdCamara4";
            this.rdCamara4.Size = new System.Drawing.Size(28, 29);
            this.rdCamara4.TabIndex = 3;
            this.rdCamara4.TabStop = true;
            this.rdCamara4.Tag = "3";
            this.rdCamara4.Text = "4";
            this.rdCamara4.UseVisualStyleBackColor = true;
            this.rdCamara4.Click += new System.EventHandler(this.rdCamara_Click);
            // 
            // rdCamara3
            // 
            this.rdCamara3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdCamara3.AutoSize = true;
            this.rdCamara3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdCamara3.Location = new System.Drawing.Point(117, 10);
            this.rdCamara3.Margin = new System.Windows.Forms.Padding(4);
            this.rdCamara3.Name = "rdCamara3";
            this.rdCamara3.Size = new System.Drawing.Size(28, 29);
            this.rdCamara3.TabIndex = 2;
            this.rdCamara3.TabStop = true;
            this.rdCamara3.Tag = "2";
            this.rdCamara3.Text = "3";
            this.rdCamara3.UseVisualStyleBackColor = true;
            this.rdCamara3.Click += new System.EventHandler(this.rdCamara_Click);
            // 
            // rdCamara2
            // 
            this.rdCamara2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdCamara2.AutoSize = true;
            this.rdCamara2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdCamara2.Location = new System.Drawing.Point(90, 10);
            this.rdCamara2.Margin = new System.Windows.Forms.Padding(4);
            this.rdCamara2.Name = "rdCamara2";
            this.rdCamara2.Size = new System.Drawing.Size(28, 29);
            this.rdCamara2.TabIndex = 1;
            this.rdCamara2.TabStop = true;
            this.rdCamara2.Tag = "1";
            this.rdCamara2.Text = "2";
            this.rdCamara2.UseVisualStyleBackColor = true;
            this.rdCamara2.Click += new System.EventHandler(this.rdCamara_Click);
            // 
            // rdCamara1
            // 
            this.rdCamara1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdCamara1.AutoSize = true;
            this.rdCamara1.Checked = true;
            this.rdCamara1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdCamara1.Location = new System.Drawing.Point(63, 10);
            this.rdCamara1.Margin = new System.Windows.Forms.Padding(4);
            this.rdCamara1.Name = "rdCamara1";
            this.rdCamara1.Size = new System.Drawing.Size(28, 29);
            this.rdCamara1.TabIndex = 0;
            this.rdCamara1.TabStop = true;
            this.rdCamara1.Tag = "0";
            this.rdCamara1.Text = "1";
            this.rdCamara1.UseVisualStyleBackColor = true;
            this.rdCamara1.Click += new System.EventHandler(this.rdCamara_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cámara";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.rdLayout2);
            this.panel4.Controls.Add(this.rdLayout4);
            this.panel4.Controls.Add(this.rdLayout6);
            this.panel4.Controls.Add(this.rdLayout1);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 54);
            this.panel4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Layout";
            // 
            // rdLayout2
            // 
            this.rdLayout2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdLayout2.AutoSize = true;
            this.rdLayout2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdLayout2.Enabled = false;
            this.rdLayout2.FlatAppearance.BorderSize = 0;
            this.rdLayout2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdLayout2.Image = global::Kenos.Win.Properties.Resources.layout_2;
            this.rdLayout2.Location = new System.Drawing.Point(84, 2);
            this.rdLayout2.Margin = new System.Windows.Forms.Padding(4);
            this.rdLayout2.Name = "rdLayout2";
            this.rdLayout2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.rdLayout2.Size = new System.Drawing.Size(49, 48);
            this.rdLayout2.TabIndex = 2;
            this.rdLayout2.Tag = "2";
            this.rdLayout2.UseVisualStyleBackColor = true;
            this.rdLayout2.Visible = false;
            this.rdLayout2.CheckedChanged += new System.EventHandler(this.rdLayout_CheckedChanged);
            // 
            // rdLayout4
            // 
            this.rdLayout4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdLayout4.AutoSize = true;
            this.rdLayout4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdLayout4.Enabled = false;
            this.rdLayout4.FlatAppearance.BorderSize = 0;
            this.rdLayout4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdLayout4.Image = global::Kenos.Win.Properties.Resources.layout_4;
            this.rdLayout4.Location = new System.Drawing.Point(164, 2);
            this.rdLayout4.Margin = new System.Windows.Forms.Padding(4);
            this.rdLayout4.Name = "rdLayout4";
            this.rdLayout4.Padding = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.rdLayout4.Size = new System.Drawing.Size(49, 48);
            this.rdLayout4.TabIndex = 2;
            this.rdLayout4.Tag = "4";
            this.rdLayout4.UseVisualStyleBackColor = true;
            this.rdLayout4.CheckedChanged += new System.EventHandler(this.rdLayout_CheckedChanged);
            // 
            // rdLayout6
            // 
            this.rdLayout6.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdLayout6.AutoSize = true;
            this.rdLayout6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdLayout6.Enabled = false;
            this.rdLayout6.FlatAppearance.BorderSize = 0;
            this.rdLayout6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdLayout6.Image = global::Kenos.Win.Properties.Resources.layout_6;
            this.rdLayout6.Location = new System.Drawing.Point(218, 2);
            this.rdLayout6.Margin = new System.Windows.Forms.Padding(4);
            this.rdLayout6.Name = "rdLayout6";
            this.rdLayout6.Padding = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.rdLayout6.Size = new System.Drawing.Size(49, 48);
            this.rdLayout6.TabIndex = 3;
            this.rdLayout6.Tag = "6";
            this.rdLayout6.UseVisualStyleBackColor = true;
            this.rdLayout6.CheckedChanged += new System.EventHandler(this.rdLayout_CheckedChanged);
            // 
            // rdLayout1
            // 
            this.rdLayout1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdLayout1.AutoSize = true;
            this.rdLayout1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdLayout1.FlatAppearance.BorderSize = 0;
            this.rdLayout1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdLayout1.Image = global::Kenos.Win.Properties.Resources.layout_1;
            this.rdLayout1.Location = new System.Drawing.Point(111, 2);
            this.rdLayout1.Margin = new System.Windows.Forms.Padding(4);
            this.rdLayout1.Name = "rdLayout1";
            this.rdLayout1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.rdLayout1.Size = new System.Drawing.Size(49, 48);
            this.rdLayout1.TabIndex = 0;
            this.rdLayout1.Tag = "1";
            this.rdLayout1.UseVisualStyleBackColor = true;
            this.rdLayout1.CheckedChanged += new System.EventHandler(this.rdLayout_CheckedChanged);
            // 
            // pnlCamaraIp
            // 
            this.pnlCamaraIp.Controls.Add(this.label12);
            this.pnlCamaraIp.Controls.Add(this.panel1);
            this.pnlCamaraIp.Controls.Add(this.btnPreviewStop);
            this.pnlCamaraIp.Controls.Add(this.btnPreviewStart);
            this.pnlCamaraIp.Controls.Add(this.txtLogPreview);
            this.pnlCamaraIp.Controls.Add(this.label10);
            this.pnlCamaraIp.Controls.Add(this.lblUrl);
            this.pnlCamaraIp.Controls.Add(this.label11);
            this.pnlCamaraIp.Controls.Add(this.cboPerfiles);
            this.pnlCamaraIp.Controls.Add(this.label9);
            this.pnlCamaraIp.Controls.Add(this.cboPresetPosition);
            this.pnlCamaraIp.Controls.Add(this.label8);
            this.pnlCamaraIp.Controls.Add(this.vgPreview);
            this.pnlCamaraIp.Controls.Add(this.txtIpPassword);
            this.pnlCamaraIp.Controls.Add(this.txtIpUsuario);
            this.pnlCamaraIp.Controls.Add(this.txtIpPort);
            this.pnlCamaraIp.Controls.Add(this.txtIpHost);
            this.pnlCamaraIp.Controls.Add(this.label4);
            this.pnlCamaraIp.Controls.Add(this.label7);
            this.pnlCamaraIp.Controls.Add(this.label5);
            this.pnlCamaraIp.Controls.Add(this.LabelDispositivo);
            this.pnlCamaraIp.Location = new System.Drawing.Point(0, 170);
            this.pnlCamaraIp.Name = "pnlCamaraIp";
            this.pnlCamaraIp.Size = new System.Drawing.Size(520, 354);
            this.pnlCamaraIp.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(269, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 17);
            this.label12.TabIndex = 57;
            this.label12.Text = "Prueba de movimiento:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkMoveStartup);
            this.panel1.Controls.Add(this.lnkMoveDown);
            this.panel1.Controls.Add(this.lnkMoveUp);
            this.panel1.Controls.Add(this.lnkMoveRight);
            this.panel1.Controls.Add(this.lnkMoveLeft);
            this.panel1.Location = new System.Drawing.Point(465, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(52, 46);
            this.panel1.TabIndex = 56;
            // 
            // lnkMoveStartup
            // 
            this.lnkMoveStartup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkMoveStartup.Image = global::Kenos.Win.Properties.Resources.icon_moveStartup;
            this.lnkMoveStartup.Location = new System.Drawing.Point(17, 16);
            this.lnkMoveStartup.Name = "lnkMoveStartup";
            this.lnkMoveStartup.Size = new System.Drawing.Size(15, 15);
            this.lnkMoveStartup.TabIndex = 20;
            this.lnkMoveStartup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkMoveStartup_MouseClick);
            // 
            // lnkMoveDown
            // 
            this.lnkMoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkMoveDown.Image = global::Kenos.Win.Properties.Resources.icon_moveDown;
            this.lnkMoveDown.Location = new System.Drawing.Point(17, 32);
            this.lnkMoveDown.Name = "lnkMoveDown";
            this.lnkMoveDown.Size = new System.Drawing.Size(15, 15);
            this.lnkMoveDown.TabIndex = 20;
            this.lnkMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lnkMoveDown_MouseDown);
            this.lnkMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lnkMove_MouseUp);
            // 
            // lnkMoveUp
            // 
            this.lnkMoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkMoveUp.Image = global::Kenos.Win.Properties.Resources.icon_moveUp;
            this.lnkMoveUp.Location = new System.Drawing.Point(17, 0);
            this.lnkMoveUp.Name = "lnkMoveUp";
            this.lnkMoveUp.Size = new System.Drawing.Size(15, 15);
            this.lnkMoveUp.TabIndex = 20;
            this.lnkMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lnkMoveUp_MouseDown);
            this.lnkMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lnkMove_MouseUp);
            // 
            // lnkMoveRight
            // 
            this.lnkMoveRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkMoveRight.Image = global::Kenos.Win.Properties.Resources.icon_moveRight;
            this.lnkMoveRight.Location = new System.Drawing.Point(33, 16);
            this.lnkMoveRight.Name = "lnkMoveRight";
            this.lnkMoveRight.Size = new System.Drawing.Size(15, 15);
            this.lnkMoveRight.TabIndex = 20;
            this.lnkMoveRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lnkMoveRight_MouseDown);
            this.lnkMoveRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lnkMove_MouseUp);
            // 
            // lnkMoveLeft
            // 
            this.lnkMoveLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkMoveLeft.Image = global::Kenos.Win.Properties.Resources.icon_moveLeft;
            this.lnkMoveLeft.Location = new System.Drawing.Point(1, 16);
            this.lnkMoveLeft.Name = "lnkMoveLeft";
            this.lnkMoveLeft.Size = new System.Drawing.Size(15, 15);
            this.lnkMoveLeft.TabIndex = 20;
            this.lnkMoveLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lnkMoveLeft_MouseDown);
            this.lnkMoveLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lnkMove_MouseUp);
            // 
            // btnPreviewStop
            // 
            this.btnPreviewStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewStop.Location = new System.Drawing.Point(81, 323);
            this.btnPreviewStop.Name = "btnPreviewStop";
            this.btnPreviewStop.Size = new System.Drawing.Size(75, 28);
            this.btnPreviewStop.TabIndex = 7;
            this.btnPreviewStop.Text = "Cancelar";
            this.btnPreviewStop.UseVisualStyleBackColor = true;
            this.btnPreviewStop.Click += new System.EventHandler(this.btnPreviewStop_Click);
            // 
            // btnPreviewStart
            // 
            this.btnPreviewStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviewStart.Location = new System.Drawing.Point(0, 323);
            this.btnPreviewStart.Name = "btnPreviewStart";
            this.btnPreviewStart.Size = new System.Drawing.Size(75, 28);
            this.btnPreviewStart.TabIndex = 6;
            this.btnPreviewStart.Text = "Preview";
            this.btnPreviewStart.UseVisualStyleBackColor = true;
            this.btnPreviewStart.Click += new System.EventHandler(this.btnPreviewStart_Click);
            // 
            // txtLogPreview
            // 
            this.txtLogPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogPreview.Location = new System.Drawing.Point(269, 197);
            this.txtLogPreview.Multiline = true;
            this.txtLogPreview.Name = "txtLogPreview";
            this.txtLogPreview.Size = new System.Drawing.Size(251, 122);
            this.txtLogPreview.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(271, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 17);
            this.label10.TabIndex = 55;
            this.label10.Text = "Log";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrl.ForeColor = System.Drawing.Color.DarkRed;
            this.lblUrl.Location = new System.Drawing.Point(-3, 96);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(13, 17);
            this.lblUrl.TabIndex = 55;
            this.lblUrl.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 17);
            this.label11.TabIndex = 55;
            this.label11.Text = "Perfiles";
            // 
            // cboPerfiles
            // 
            this.cboPerfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPerfiles.FormattingEnabled = true;
            this.cboPerfiles.Location = new System.Drawing.Point(0, 69);
            this.cboPerfiles.Name = "cboPerfiles";
            this.cboPerfiles.Size = new System.Drawing.Size(250, 24);
            this.cboPerfiles.TabIndex = 4;
            this.cboPerfiles.SelectedIndexChanged += new System.EventHandler(this.cboPerfiles_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 55;
            this.label9.Text = "Posición Inicial";
            // 
            // cboPresetPosition
            // 
            this.cboPresetPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPresetPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPresetPosition.FormattingEnabled = true;
            this.cboPresetPosition.Location = new System.Drawing.Point(269, 69);
            this.cboPresetPosition.Name = "cboPresetPosition";
            this.cboPresetPosition.Size = new System.Drawing.Size(251, 24);
            this.cboPresetPosition.TabIndex = 5;
            this.cboPresetPosition.SelectedIndexChanged += new System.EventHandler(this.cboPresetPosition_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 53;
            this.label8.Text = "Preview";
            // 
            // vgPreview
            // 
            this.vgPreview.AdjustOverlayAspectRatio = true;
            this.vgPreview.AdjustPixelAspectRatio = true;
            this.vgPreview.Aero = VidGrab.TAero.ae_Default;
            this.vgPreview.AnalogVideoStandard = -1;
            this.vgPreview.ApplicationPriority = VidGrab.TApplicationPriority.ap_default;
            this.vgPreview.ASFAudioBitRate = -1;
            this.vgPreview.ASFAudioChannels = -1;
            this.vgPreview.ASFBufferWindow = -1;
            this.vgPreview.ASFDeinterlaceMode = VidGrab.TASFDeinterlaceMode.adm_NotInterlaced;
            this.vgPreview.ASFDirectStreamingKeepClientsConnected = false;
            this.vgPreview.ASFFixedFrameRate = true;
            this.vgPreview.ASFMediaServerPublishingPoint = "";
            this.vgPreview.ASFMediaServerRemovePublishingPointAfterDisconnect = false;
            this.vgPreview.ASFMediaServerTemplatePublishingPoint = "";
            this.vgPreview.ASFNetworkMaxUsers = 5;
            this.vgPreview.ASFNetworkPort = 0;
            this.vgPreview.ASFProfile = -1;
            this.vgPreview.ASFProfileFromCustomFile = "";
            this.vgPreview.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_8;
            this.vgPreview.ASFVideoBitRate = -1;
            this.vgPreview.ASFVideoFrameRate = 0D;
            this.vgPreview.ASFVideoHeight = -1;
            this.vgPreview.ASFVideoMaxKeyFrameSpacing = -1;
            this.vgPreview.ASFVideoQuality = -1;
            this.vgPreview.ASFVideoWidth = -1;
            this.vgPreview.AspectRatioToUse = -1D;
            this.vgPreview.AssociateAudioAndVideoDevices = false;
            this.vgPreview.AudioBalance = 0;
            this.vgPreview.AudioChannelRenderMode = VidGrab.TAudioChannelRenderMode.acrm_Normal;
            this.vgPreview.AudioCompressor = 0;
            this.vgPreview.AudioDevice = -1;
            this.vgPreview.AudioDeviceRendering = false;
            this.vgPreview.AudioFormat = VidGrab.TAudioFormat.af_default;
            this.vgPreview.AudioInput = -1;
            this.vgPreview.AudioInputBalance = 0;
            this.vgPreview.AudioInputLevel = 65535;
            this.vgPreview.AudioInputMono = false;
            this.vgPreview.AudioPeakEvent = false;
            this.vgPreview.AudioRecording = false;
            this.vgPreview.AudioRenderer = -1;
            this.vgPreview.AudioSource = VidGrab.TAudioSource.as_Default;
            this.vgPreview.AudioStreamNumber = -1;
            this.vgPreview.AudioSyncAdjustment = 0;
            this.vgPreview.AudioSyncAdjustmentEnabled = false;
            this.vgPreview.AudioVolume = 32767;
            this.vgPreview.AutoConnectRelatedPins = true;
            this.vgPreview.AutoFileName = VidGrab.TAutoFileName.fn_Sequential;
            this.vgPreview.AutoFileNameDateTimeFormat = "yymmdd_hhmmss_zzz";
            this.vgPreview.AutoFileNameMinDigits = 6;
            this.vgPreview.AutoFilePrefix = "vg";
            this.vgPreview.AutoFileSuffix = "";
            this.vgPreview.AutoRefreshPreview = false;
            this.vgPreview.AutoStartPlayer = true;
            this.vgPreview.AVIDurationUpdated = true;
            this.vgPreview.AVIFormatOpenDML = true;
            this.vgPreview.AVIFormatOpenDMLCompatibilityIndex = true;
            this.vgPreview.BackColor = System.Drawing.Color.DarkGray;
            this.vgPreview.BackgroundColor = 0;
            this.vgPreview.BufferCount = -1;
            this.vgPreview.BurstCount = 3;
            this.vgPreview.BurstInterval = 0;
            this.vgPreview.BurstMode = false;
            this.vgPreview.BurstType = VidGrab.TFrameCaptureDest.fc_TBitmap;
            this.vgPreview.BusyCursor = VidGrab.TCursors.cr_HourGlass;
            this.vgPreview.CameraControlSettings = true;
            this.vgPreview.CaptureFileExt = "";
            this.vgPreview.ColorKey = 1048592;
            this.vgPreview.ColorKeyEnabled = false;
            this.vgPreview.CompressionMode = VidGrab.TCompressionMode.cm_NoCompression;
            this.vgPreview.CompressionType = VidGrab.TCompressionType.ct_Video;
            this.vgPreview.Cropping_Enabled = false;
            this.vgPreview.Cropping_Height = 120;
            this.vgPreview.Cropping_Outbounds = true;
            this.vgPreview.Cropping_Width = 160;
            this.vgPreview.Cropping_X = 0;
            this.vgPreview.Cropping_Y = 0;
            this.vgPreview.Cropping_Zoom = 1D;
            this.vgPreview.Display_Active = true;
            this.vgPreview.Display_AlphaBlendEnabled = false;
            this.vgPreview.Display_AlphaBlendValue = 180;
            this.vgPreview.Display_AspectRatio = VidGrab.TAspectRatio.ar_Box;
            this.vgPreview.Display_AutoSize = false;
            this.vgPreview.Display_Embedded = true;
            this.vgPreview.Display_Embedded_FitParent = false;
            this.vgPreview.Display_FullScreen = false;
            this.vgPreview.Display_Height = 382;
            this.vgPreview.Display_Left = 10;
            this.vgPreview.Display_Monitor = 0;
            this.vgPreview.Display_MouseMovesWindow = true;
            this.vgPreview.Display_PanScanRatio = 50;
            this.vgPreview.Display_StayOnTop = false;
            this.vgPreview.Display_Top = 10;
            this.vgPreview.Display_TransparentColorEnabled = false;
            this.vgPreview.Display_TransparentColorValue = 255;
            this.vgPreview.Display_VideoPortEnabled = true;
            this.vgPreview.Display_Visible = true;
            this.vgPreview.Display_Width = 320;
            this.vgPreview.DoubleBuffered = false;
            this.vgPreview.DroppedFramesPollingInterval = -1;
            this.vgPreview.DualDisplay_Active = false;
            this.vgPreview.DualDisplay_AlphaBlendEnabled = false;
            this.vgPreview.DualDisplay_AlphaBlendValue = 180;
            this.vgPreview.DualDisplay_AspectRatio = VidGrab.TAspectRatio.ar_Box;
            this.vgPreview.DualDisplay_AutoSize = false;
            this.vgPreview.DualDisplay_Embedded = false;
            this.vgPreview.DualDisplay_Embedded_FitParent = false;
            this.vgPreview.DualDisplay_FullScreen = false;
            this.vgPreview.DualDisplay_Height = 382;
            this.vgPreview.DualDisplay_Left = 20;
            this.vgPreview.DualDisplay_Monitor = 0;
            this.vgPreview.DualDisplay_MouseMovesWindow = true;
            this.vgPreview.DualDisplay_PanScanRatio = 50;
            this.vgPreview.DualDisplay_StayOnTop = false;
            this.vgPreview.DualDisplay_Top = 400;
            this.vgPreview.DualDisplay_TransparentColorEnabled = false;
            this.vgPreview.DualDisplay_TransparentColorValue = 255;
            this.vgPreview.DualDisplay_VideoPortEnabled = false;
            this.vgPreview.DualDisplay_Visible = true;
            this.vgPreview.DualDisplay_Width = 320;
            this.vgPreview.DVDateTimeEnabled = true;
            this.vgPreview.DVDiscontinuityMinimumInterval = 3;
            this.vgPreview.DVDTitle = 0;
            this.vgPreview.DVEncoder_VideoFormat = VidGrab.TDVVideoFormat.dvf_DVSD;
            this.vgPreview.DVEncoder_VideoResolution = VidGrab.TDVSize.dv_Full;
            this.vgPreview.DVEncoder_VideoStandard = VidGrab.TDVVideoStandard.dvs_Default;
            this.vgPreview.DVRecordingInNativeFormatSeparatesStreams = false;
            this.vgPreview.DVReduceFrameRate = false;
            this.vgPreview.DVRgb219 = false;
            this.vgPreview.DVTimeCodeEnabled = false;
            this.vgPreview.EventNotificationSynchrone = true;
            this.vgPreview.ExtraDLLPath = "";
            this.vgPreview.FixFlickerOrBlackCapture = false;
            this.vgPreview.FrameCaptureHeight = -1;
            this.vgPreview.FrameCaptureWidth = -1;
            this.vgPreview.FrameCaptureWithoutOverlay = false;
            this.vgPreview.FrameCaptureZoomSize = 100;
            this.vgPreview.FrameGrabber = VidGrab.TFrameGrabber.fg_BothStreams;
            this.vgPreview.FrameGrabberRGBFormat = VidGrab.TFrameGrabberRGBFormat.fgf_Default;
            this.vgPreview.FrameNumberStartsFromZero = false;
            this.vgPreview.FrameRate = 0D;
            this.vgPreview.FrameRateDivider = 0;
            this.vgPreview.HoldRecording = false;
            this.vgPreview.ImageOverlay_AlphaBlend = false;
            this.vgPreview.ImageOverlay_AlphaBlendValue = 180;
            this.vgPreview.ImageOverlay_ChromaKey = false;
            this.vgPreview.ImageOverlay_ChromaKeyLeewayPercent = 25;
            this.vgPreview.ImageOverlay_ChromaKeyRGBColor = 0;
            this.vgPreview.ImageOverlay_Height = -1;
            this.vgPreview.ImageOverlay_LeftLocation = 10;
            this.vgPreview.ImageOverlay_RotationAngle = 0D;
            this.vgPreview.ImageOverlay_StretchToVideoSize = false;
            this.vgPreview.ImageOverlay_TargetDisplay = -1;
            this.vgPreview.ImageOverlay_TopLocation = 10;
            this.vgPreview.ImageOverlay_Transparent = false;
            this.vgPreview.ImageOverlay_TransparentColorValue = 0;
            this.vgPreview.ImageOverlay_UseTransparentColor = false;
            this.vgPreview.ImageOverlay_VideoAlignment = VidGrab.TVideoAlignment.oa_LeftTop;
            this.vgPreview.ImageOverlay_Width = -1;
            this.vgPreview.ImageOverlayEnabled = false;
            this.vgPreview.ImageOverlaySelector = 0;
            this.vgPreview.IPCameraURL = "";
            this.vgPreview.JPEGPerformance = VidGrab.TJPEGPerformance.jpBestQuality;
            this.vgPreview.JPEGProgressiveDisplay = false;
            this.vgPreview.JPEGQuality = 100;
            this.vgPreview.LicenseString = "N/A";
            this.vgPreview.Location = new System.Drawing.Point(0, 134);
            this.vgPreview.LogoDisplayed = false;
            this.vgPreview.LogoLayout = VidGrab.TLogoLayout.lg_Stretched;
            this.vgPreview.Margin = new System.Windows.Forms.Padding(4);
            this.vgPreview.MixAudioSamples_CurrentSourceLevel = 100;
            this.vgPreview.MixAudioSamples_ExternalSourceLevel = 100;
            this.vgPreview.Mixer_MosaicColumns = 1;
            this.vgPreview.Mixer_MosaicLines = 1;
            this.vgPreview.MotionDetector_CompareBlue = true;
            this.vgPreview.MotionDetector_CompareGreen = true;
            this.vgPreview.MotionDetector_CompareRed = true;
            this.vgPreview.MotionDetector_Enabled = false;
            this.vgPreview.MotionDetector_GreyScale = false;
            this.vgPreview.MotionDetector_Grid = "5555555555 5555555555 5555555555 5555555555 5555555555 5555555555 5555555555 5555" +
    "555555 5555555555 5555555555";
            this.vgPreview.MotionDetector_MaxDetectionsPerSecond = 0D;
            this.vgPreview.MotionDetector_ReduceCPULoad = 1;
            this.vgPreview.MotionDetector_ReduceVideoNoise = false;
            this.vgPreview.MotionDetector_Triggered = false;
            this.vgPreview.MouseWheelEventEnabled = true;
            this.vgPreview.MpegStreamType = VidGrab.TMpegStreamType.mpst_Default;
            this.vgPreview.MultiplexedInputEmulation = true;
            this.vgPreview.MultiplexedRole = VidGrab.TMultiplexedRole.mr_NotMultiplexed;
            this.vgPreview.MultiplexedStabilizationDelay = 100;
            this.vgPreview.MultiplexedSwitchDelay = 0;
            this.vgPreview.Multiplexer = -1;
            this.vgPreview.MuteAudioRendering = false;
            this.vgPreview.Name = "vgPreview";
            this.vgPreview.NetworkStreaming = VidGrab.TNetworkStreaming.ns_Disabled;
            this.vgPreview.NetworkStreamingType = VidGrab.TNetworkStreamingType.nst_AudioVideoStreaming;
            this.vgPreview.NormalCursor = VidGrab.TCursors.cr_Default;
            this.vgPreview.NotificationMethod = VidGrab.TNotificationMethod.nm_Thread;
            this.vgPreview.NotificationPriority = VidGrab.TThreadPriority.tpNormal;
            this.vgPreview.NotificationSleepTime = -1;
            this.vgPreview.OnFrameBitmapEventSynchrone = false;
            this.vgPreview.OpenURLAsync = true;
            this.vgPreview.OverlayAfterTransform = false;
            this.vgPreview.OwnerObject = null;
            this.vgPreview.PlayerAudioRendering = true;
            this.vgPreview.PlayerDuration = ((long)(1));
            this.vgPreview.PlayerDVSize = VidGrab.TDVSize.dv_Full;
            this.vgPreview.PlayerFastSeekSpeedRatio = 4;
            this.vgPreview.PlayerFileName = "";
            this.vgPreview.PlayerForcedCodec = "";
            this.vgPreview.PlayerFramePosition = ((long)(1));
            this.vgPreview.PlayerHwAccel = VidGrab.THwAccel.hw_None;
            this.vgPreview.PlayerRefreshPausedDisplay = false;
            this.vgPreview.PlayerRefreshPausedDisplayFrameRate = 0D;
            this.vgPreview.PlayerSpeedRatio = 1D;
            this.vgPreview.PlayerTimePosition = ((long)(0));
            this.vgPreview.PlayerTrackBarSynchrone = false;
            this.vgPreview.PlaylistIndex = 0;
            this.vgPreview.PreallocCapFileCopiedAfterRecording = true;
            this.vgPreview.PreallocCapFileEnabled = false;
            this.vgPreview.PreallocCapFileName = "";
            this.vgPreview.PreallocCapFileSizeInMB = 100;
            this.vgPreview.PreviewZoomSize = 100;
            this.vgPreview.QuickDeviceInitialization = false;
            this.vgPreview.RawAudioSampleCapture = false;
            this.vgPreview.RawCaptureAsyncEvent = true;
            this.vgPreview.RawSampleCaptureLocation = VidGrab.TRawSampleCaptureLocation.rl_SourceFormat;
            this.vgPreview.RawVideoSampleCapture = false;
            this.vgPreview.RecordingAudioBitRate = -1;
            this.vgPreview.RecordingBacktimedFramesCount = 0;
            this.vgPreview.RecordingCanPause = false;
            this.vgPreview.RecordingFileName = "";
            this.vgPreview.RecordingInNativeFormat = true;
            this.vgPreview.RecordingMethod = VidGrab.TRecordingMethod.rm_AVI;
            this.vgPreview.RecordingOnMotion_Enabled = false;
            this.vgPreview.RecordingOnMotion_MotionThreshold = 0D;
            this.vgPreview.RecordingOnMotion_NoMotionPauseDelayMs = 5000;
            this.vgPreview.RecordingPauseCreatesNewFile = false;
            this.vgPreview.RecordingSize = VidGrab.TRecordingSize.rs_Default;
            this.vgPreview.RecordingTimer = VidGrab.TRecordingTimer.rt_Disabled;
            this.vgPreview.RecordingTimerInterval = 0;
            this.vgPreview.RecordingVideoBitRate = -1;
            this.vgPreview.Reencoding_IncludeAudioStream = true;
            this.vgPreview.Reencoding_IncludeVideoStream = true;
            this.vgPreview.Reencoding_Method = VidGrab.TRecordingMethod.rm_ASF;
            this.vgPreview.Reencoding_NewVideoClip = "";
            this.vgPreview.Reencoding_SourceVideoClip = "";
            this.vgPreview.Reencoding_StartFrame = ((long)(-1));
            this.vgPreview.Reencoding_StartTime = ((long)(-1));
            this.vgPreview.Reencoding_StopFrame = ((long)(-1));
            this.vgPreview.Reencoding_StopTime = ((long)(-1));
            this.vgPreview.Reencoding_UseAudioCompressor = false;
            this.vgPreview.Reencoding_UseFrameGrabber = true;
            this.vgPreview.Reencoding_UseVideoCompressor = false;
            this.vgPreview.Reencoding_WMVOutput = false;
            this.vgPreview.ScreenRecordingLayeredWindows = false;
            this.vgPreview.ScreenRecordingMonitor = 0;
            this.vgPreview.ScreenRecordingNonVisibleWindows = false;
            this.vgPreview.ScreenRecordingThroughClipboard = false;
            this.vgPreview.ScreenRecordingWithCursor = true;
            this.vgPreview.SendToDV_DeviceIndex = -1;
            this.vgPreview.Size = new System.Drawing.Size(250, 185);
            this.vgPreview.SpeakerBalance = 0;
            this.vgPreview.SpeakerControl = false;
            this.vgPreview.SpeakerVolume = 65535;
            this.vgPreview.StoragePath = "C:\\Program Files (x86)\\Microsoft Visual Studio 11.0\\Common7\\IDE";
            this.vgPreview.StoreDeviceSettingsInRegistry = true;
            this.vgPreview.SyncCommands = true;
            this.vgPreview.SynchronizationRole = VidGrab.TSynchronizationRole.sr_Master;
            this.vgPreview.Synchronized = false;
            this.vgPreview.SyncPreview = VidGrab.TSyncPreview.sp_Auto;
            this.vgPreview.TabIndex = 52;
            this.vgPreview.TextOverlay_Align = VidGrab.TTextOverlayAlign.tf_Left;
            this.vgPreview.TextOverlay_AlphaBlend = false;
            this.vgPreview.TextOverlay_AlphaBlendValue = 180;
            this.vgPreview.TextOverlay_BkColor = 16777215;
            this.vgPreview.TextOverlay_Enabled = false;
// TODO: Error de generación de código de '' por la excepción 'Tipo primitivo no válido: System.IntPtr. Utilice CodeObjectCreateExpression.'.
            this.vgPreview.TextOverlay_FontColor = 16776960;
            this.vgPreview.TextOverlay_FontSize = 12;
            this.vgPreview.TextOverlay_GradientColor = 8388608;
            this.vgPreview.TextOverlay_GradientMode = VidGrab.TTextOverlayGradientMode.gm_Disabled;
            this.vgPreview.TextOverlay_HighResFont = true;
            this.vgPreview.TextOverlay_Left = 0;
            this.vgPreview.TextOverlay_Orientation = VidGrab.TTextOrientation.to_Horizontal;
            this.vgPreview.TextOverlay_Right = -1;
            this.vgPreview.TextOverlay_Scrolling = false;
            this.vgPreview.TextOverlay_ScrollingSpeed = 1;
            this.vgPreview.TextOverlay_Selector = 0;
            this.vgPreview.TextOverlay_Shadow = true;
            this.vgPreview.TextOverlay_ShadowColor = 0;
            this.vgPreview.TextOverlay_ShadowDirection = VidGrab.TCardinalDirection.cd_SouthEast;
            this.vgPreview.TextOverlay_String = resources.GetString("vgPreview.TextOverlay_String");
            this.vgPreview.TextOverlay_TargetDisplay = -1;
            this.vgPreview.TextOverlay_Top = 0;
            this.vgPreview.TextOverlay_Transparent = true;
            this.vgPreview.TextOverlay_VideoAlignment = VidGrab.TVideoAlignment.oa_LeftTop;
            this.vgPreview.ThirdPartyDeinterlacer = "";
            this.vgPreview.TranslateMouseCoordinates = true;
            this.vgPreview.TunerFrequency = -1;
            this.vgPreview.TunerMode = VidGrab.TTunerMode.tm_TVTuner;
            this.vgPreview.TVChannel = 0;
            this.vgPreview.TVCountryCode = 0;
            this.vgPreview.TVTunerInputType = VidGrab.TTunerInputType.TunerInputCable;
            this.vgPreview.TVUseFrequencyOverrides = false;
            this.vgPreview.UseClock = true;
            this.vgPreview.VCRHorizontalLocking = false;
            this.vgPreview.Version = "v10.8.4.6 (build 3406.181221) - Copyright (c)2018 Datastead";
            this.vgPreview.VideoCompression_DataRate = -1;
            this.vgPreview.VideoCompression_KeyFrameRate = 15;
            this.vgPreview.VideoCompression_PFramesPerKeyFrame = 0;
            this.vgPreview.VideoCompression_Quality = 1D;
            this.vgPreview.VideoCompression_WindowSize = -1;
            this.vgPreview.VideoCompressor = 0;
            this.vgPreview.VideoControlSettings = true;
            this.vgPreview.VideoCursor = VidGrab.TCursors.cr_Default;
            this.vgPreview.VideoDelay = ((long)(0));
            this.vgPreview.VideoDevice = -1;
            this.vgPreview.VideoFormat = -1;
            this.vgPreview.VideoFromImages_BitmapsSortedBy = VidGrab.TFileSort.fs_TimeAsc;
            this.vgPreview.VideoFromImages_RepeatIndefinitely = false;
            this.vgPreview.VideoFromImages_SourceDirectory = "C:\\Program Files (x86)\\Microsoft Visual Studio 11.0\\Common7\\IDE";
            this.vgPreview.VideoFromImages_TemporaryFile = "SetOfBitmaps01.dat";
            this.vgPreview.VideoInput = -1;
            this.vgPreview.VideoProcessing_Brightness = 0;
            this.vgPreview.VideoProcessing_Contrast = 0;
            this.vgPreview.VideoProcessing_Deinterlacing = VidGrab.TVideoDeinterlacing.di_Disabled;
            this.vgPreview.VideoProcessing_FlipHorizontal = false;
            this.vgPreview.VideoProcessing_FlipVertical = false;
            this.vgPreview.VideoProcessing_GrayScale = false;
            this.vgPreview.VideoProcessing_Hue = 0;
            this.vgPreview.VideoProcessing_InvertColors = false;
            this.vgPreview.VideoProcessing_Pixellization = 1;
            this.vgPreview.VideoProcessing_Rotation = VidGrab.TVideoRotation.rt_0_deg;
            this.vgPreview.VideoProcessing_RotationCustomAngle = 45.5D;
            this.vgPreview.VideoProcessing_Saturation = 0;
            this.vgPreview.VideoQualitySettings = true;
            this.vgPreview.VideoRenderer = VidGrab.TVideoRenderer.vr_AutoSelect;
            this.vgPreview.VideoRendererExternal = VidGrab.TVideoRendererExternal.vre_None;
            this.vgPreview.VideoRendererExternalIndex = -1;
            this.vgPreview.VideoRendererPriority = VidGrab.TVideoRendererPriority.vrp_Auto;
            this.vgPreview.VideoSize = -1;
            this.vgPreview.VideoSource = VidGrab.TVideoSource.vs_VideoCaptureDevice;
            this.vgPreview.VideoSource_FileOrURL = "";
            this.vgPreview.VideoSource_FileOrURL_StartTime = ((long)(-1));
            this.vgPreview.VideoSource_FileOrURL_StopTime = ((long)(-1));
            this.vgPreview.VideoStreamNumber = -1;
            this.vgPreview.VideoSubtype = -1;
            this.vgPreview.VideoVisibleWhenStopped = false;
            this.vgPreview.VirtualAudioStreamControl = -1;
            this.vgPreview.VirtualVideoStreamControl = -1;
            this.vgPreview.VuMeter = VidGrab.TVuMeter.vu_Disabled;
            this.vgPreview.WebcamStillCaptureButton = VidGrab.TWebcamStillCaptureButton.wb_Disabled;
            this.vgPreview.ZoomCoeff = 1000;
            this.vgPreview.ZoomXCenter = 0;
            this.vgPreview.ZoomYCenter = 0;
            this.vgPreview.OnLog += new VidGrab.OnLogEventHandler(this.vgPreview_OnLog);
            // 
            // txtIpPassword
            // 
            this.txtIpPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIpPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIpPassword.Location = new System.Drawing.Point(413, 20);
            this.txtIpPassword.Name = "txtIpPassword";
            this.txtIpPassword.PasswordChar = '*';
            this.txtIpPassword.Size = new System.Drawing.Size(105, 23);
            this.txtIpPassword.TabIndex = 3;
            this.txtIpPassword.TextChanged += new System.EventHandler(this.txtCamaraIp_TextChanged);
            // 
            // txtIpUsuario
            // 
            this.txtIpUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIpUsuario.Location = new System.Drawing.Point(269, 20);
            this.txtIpUsuario.Name = "txtIpUsuario";
            this.txtIpUsuario.Size = new System.Drawing.Size(104, 23);
            this.txtIpUsuario.TabIndex = 2;
            this.txtIpUsuario.TextChanged += new System.EventHandler(this.txtCamaraIp_TextChanged);
            // 
            // txtIpPort
            // 
            this.txtIpPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIpPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIpPort.Location = new System.Drawing.Point(138, 20);
            this.txtIpPort.Name = "txtIpPort";
            this.txtIpPort.Size = new System.Drawing.Size(112, 23);
            this.txtIpPort.TabIndex = 1;
            this.txtIpPort.TextChanged += new System.EventHandler(this.txtCamaraIp_TextChanged);
            // 
            // txtIpHost
            // 
            this.txtIpHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIpHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIpHost.Location = new System.Drawing.Point(0, 20);
            this.txtIpHost.Name = "txtIpHost";
            this.txtIpHost.Size = new System.Drawing.Size(112, 23);
            this.txtIpHost.TabIndex = 0;
            this.txtIpHost.TextChanged += new System.EventHandler(this.txtCamaraIp_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 17);
            this.label7.TabIndex = 46;
            this.label7.Text = "Puerto ONVIF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 45;
            this.label5.Text = "Usuario";
            // 
            // LabelDispositivo
            // 
            this.LabelDispositivo.AutoSize = true;
            this.LabelDispositivo.Location = new System.Drawing.Point(-3, 0);
            this.LabelDispositivo.Name = "LabelDispositivo";
            this.LabelDispositivo.Size = new System.Drawing.Size(20, 17);
            this.LabelDispositivo.TabIndex = 46;
            this.LabelDispositivo.Text = "IP";
            // 
            // pnlCamara
            // 
            this.pnlCamara.Controls.Add(this.label16);
            this.pnlCamara.Controls.Add(this.cbVideoInput);
            this.pnlCamara.Controls.Add(this.label15);
            this.pnlCamara.Controls.Add(this.cbVideoFormat);
            this.pnlCamara.Controls.Add(this.LabelNorma);
            this.pnlCamara.Controls.Add(this.cbNorma);
            this.pnlCamara.Controls.Add(this.LabelSubtipo);
            this.pnlCamara.Controls.Add(this.LabelTamanio);
            this.pnlCamara.Controls.Add(this.label6);
            this.pnlCamara.Controls.Add(this.cbVideoSize);
            this.pnlCamara.Controls.Add(this.cbVideoDevice);
            this.pnlCamara.Controls.Add(this.cbVideoSubtype);
            this.pnlCamara.Location = new System.Drawing.Point(445, 116);
            this.pnlCamara.Name = "pnlCamara";
            this.pnlCamara.Size = new System.Drawing.Size(507, 185);
            this.pnlCamara.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(147, 114);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 17);
            this.label16.TabIndex = 48;
            this.label16.Text = "Video Format";
            // 
            // cbVideoInput
            // 
            this.cbVideoInput.FormattingEnabled = true;
            this.cbVideoInput.Location = new System.Drawing.Point(0, 133);
            this.cbVideoInput.Name = "cbVideoInput";
            this.cbVideoInput.Size = new System.Drawing.Size(141, 24);
            this.cbVideoInput.TabIndex = 47;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(0, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 17);
            this.label15.TabIndex = 46;
            this.label15.Text = "Video Input";
            // 
            // cbVideoFormat
            // 
            this.cbVideoFormat.FormattingEnabled = true;
            this.cbVideoFormat.Location = new System.Drawing.Point(147, 133);
            this.cbVideoFormat.Name = "cbVideoFormat";
            this.cbVideoFormat.Size = new System.Drawing.Size(360, 24);
            this.cbVideoFormat.TabIndex = 45;
            // 
            // LabelNorma
            // 
            this.LabelNorma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelNorma.AutoSize = true;
            this.LabelNorma.Location = new System.Drawing.Point(429, 56);
            this.LabelNorma.Name = "LabelNorma";
            this.LabelNorma.Size = new System.Drawing.Size(50, 17);
            this.LabelNorma.TabIndex = 44;
            this.LabelNorma.Text = "Norma";
            // 
            // cbNorma
            // 
            this.cbNorma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNorma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNorma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbNorma.FormattingEnabled = true;
            this.cbNorma.Location = new System.Drawing.Point(435, 75);
            this.cbNorma.Name = "cbNorma";
            this.cbNorma.Size = new System.Drawing.Size(72, 24);
            this.cbNorma.TabIndex = 3;
            // 
            // LabelSubtipo
            // 
            this.LabelSubtipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelSubtipo.AutoSize = true;
            this.LabelSubtipo.Location = new System.Drawing.Point(351, 56);
            this.LabelSubtipo.Name = "LabelSubtipo";
            this.LabelSubtipo.Size = new System.Drawing.Size(60, 17);
            this.LabelSubtipo.TabIndex = 40;
            this.LabelSubtipo.Text = "Subtipo:";
            // 
            // LabelTamanio
            // 
            this.LabelTamanio.AutoSize = true;
            this.LabelTamanio.Location = new System.Drawing.Point(0, 56);
            this.LabelTamanio.Name = "LabelTamanio";
            this.LabelTamanio.Size = new System.Drawing.Size(64, 17);
            this.LabelTamanio.TabIndex = 41;
            this.LabelTamanio.Text = "Tamaño:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "Dispositivo:";
            // 
            // cbVideoSize
            // 
            this.cbVideoSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbVideoSize.FormattingEnabled = true;
            this.cbVideoSize.Location = new System.Drawing.Point(0, 75);
            this.cbVideoSize.Name = "cbVideoSize";
            this.cbVideoSize.Size = new System.Drawing.Size(348, 24);
            this.cbVideoSize.TabIndex = 1;
            // 
            // cbVideoDevice
            // 
            this.cbVideoDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbVideoDevice.FormattingEnabled = true;
            this.cbVideoDevice.Location = new System.Drawing.Point(0, 19);
            this.cbVideoDevice.Name = "cbVideoDevice";
            this.cbVideoDevice.Size = new System.Drawing.Size(507, 24);
            this.cbVideoDevice.TabIndex = 0;
            this.cbVideoDevice.SelectedIndexChanged += new System.EventHandler(this.cbVideoDevice_SelectedIndexChanged);
            // 
            // cbVideoSubtype
            // 
            this.cbVideoSubtype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoSubtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoSubtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbVideoSubtype.FormattingEnabled = true;
            this.cbVideoSubtype.Location = new System.Drawing.Point(354, 75);
            this.cbVideoSubtype.Name = "cbVideoSubtype";
            this.cbVideoSubtype.Size = new System.Drawing.Size(72, 24);
            this.cbVideoSubtype.TabIndex = 2;
            // 
            // chkHabilitada
            // 
            this.chkHabilitada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHabilitada.AutoSize = true;
            this.chkHabilitada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHabilitada.Checked = true;
            this.chkHabilitada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHabilitada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHabilitada.Location = new System.Drawing.Point(647, 82);
            this.chkHabilitada.Name = "chkHabilitada";
            this.chkHabilitada.Size = new System.Drawing.Size(87, 21);
            this.chkHabilitada.TabIndex = 1;
            this.chkHabilitada.Text = "Habilitada";
            this.chkHabilitada.UseVisualStyleBackColor = true;
            this.chkHabilitada.CheckedChanged += new System.EventHandler(this.chkHabilitada_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 17);
            this.label13.TabIndex = 27;
            this.label13.Text = "Formato";
            // 
            // cbFormat
            // 
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "mp4",
            "wmv"});
            this.cbFormat.Location = new System.Drawing.Point(0, 82);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(121, 24);
            this.cbFormat.TabIndex = 28;
            this.cbFormat.SelectedIndexChanged += new System.EventHandler(this.changeFormatOutput);
            // 
            // cbCodec
            // 
            this.cbCodec.FormattingEnabled = true;
            this.cbCodec.Location = new System.Drawing.Point(128, 82);
            this.cbCodec.Name = "cbCodec";
            this.cbCodec.Size = new System.Drawing.Size(264, 24);
            this.cbCodec.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(125, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 17);
            this.label14.TabIndex = 30;
            this.label14.Text = "Codec";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 25);
            this.button1.TabIndex = 31;
            this.button1.Text = "Device";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VideoConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 671);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbCodec);
            this.Controls.Add(this.cbFormat);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chkHabilitada);
            this.Controls.Add(this.pnlCamara);
            this.Controls.Add(this.pnlCamaraIp);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VideoConfig";
            this.Text = "VideoConfig";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlCamaraIp.ResumeLayout(false);
            this.pnlCamaraIp.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlCamara.ResumeLayout(false);
            this.pnlCamara.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdCamara6;
        private System.Windows.Forms.RadioButton rdCamara5;
        private System.Windows.Forms.RadioButton rdCamara4;
        private System.Windows.Forms.RadioButton rdCamara3;
        private System.Windows.Forms.RadioButton rdCamara2;
        private System.Windows.Forms.RadioButton rdCamara1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdLayout4;
        private System.Windows.Forms.RadioButton rdLayout6;
        private System.Windows.Forms.RadioButton rdLayout1;
        private System.Windows.Forms.Panel pnlCamaraIp;
        private System.Windows.Forms.TextBox txtIpPassword;
        private System.Windows.Forms.TextBox txtIpUsuario;
        private System.Windows.Forms.TextBox txtIpHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LabelDispositivo;
        private System.Windows.Forms.Panel pnlCamara;
        private System.Windows.Forms.Label LabelNorma;
        private System.Windows.Forms.ComboBox cbNorma;
        private System.Windows.Forms.Label LabelSubtipo;
        private System.Windows.Forms.Label LabelTamanio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbVideoSize;
        private System.Windows.Forms.ComboBox cbVideoDevice;
        private System.Windows.Forms.ComboBox cbVideoSubtype;
        private System.Windows.Forms.CheckBox chkHabilitada;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboPresetPosition;
        private System.Windows.Forms.Label label8;
        private VidGrab.VideoGrabber vgPreview;
        private System.Windows.Forms.TextBox txtLogPreview;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPreviewStop;
        private System.Windows.Forms.Button btnPreviewStart;
        private System.Windows.Forms.TextBox txtIpPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboPerfiles;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.RadioButton rdLayout2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnkMoveStartup;
        private System.Windows.Forms.LinkLabel lnkMoveDown;
        private System.Windows.Forms.LinkLabel lnkMoveUp;
        private System.Windows.Forms.LinkLabel lnkMoveRight;
        private System.Windows.Forms.LinkLabel lnkMoveLeft;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.ComboBox cbCodec;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbVideoInput;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbVideoFormat;
        private System.Windows.Forms.Button button1;
    }
}