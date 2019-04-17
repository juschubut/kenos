namespace Kenos.Win
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkStreaming = new System.Windows.Forms.CheckBox();
            this.rdVideo = new System.Windows.Forms.RadioButton();
            this.rdAudio = new System.Windows.Forms.RadioButton();
            this.lnkConfigurar = new System.Windows.Forms.LinkLabel();
            this.lnkTest = new System.Windows.Forms.LinkLabel();
            this.lnkCancelar = new System.Windows.Forms.LinkLabel();
            this.lnkFinalizar = new System.Windows.Forms.LinkLabel();
            this.lnkNueva = new System.Windows.Forms.LinkLabel();
            this.mnuNueva = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.LabelDescripcion = new System.Windows.Forms.Label();
            this.timerRecording = new System.Windows.Forms.Timer(this.components);
            this.gvMarcas = new System.Windows.Forms.DataGridView();
            this.Tiemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAlerta = new System.Windows.Forms.Panel();
            this.btnCerrarAlerta = new System.Windows.Forms.Button();
            this.lblAlerta = new System.Windows.Forms.Label();
            this.pnlVUMeter = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAgregarMarca = new System.Windows.Forms.Button();
            this.lnkGrabar = new System.Windows.Forms.LinkLabel();
            this.lnkPlay = new System.Windows.Forms.LinkLabel();
            this.lnkPausar = new System.Windows.Forms.LinkLabel();
            this.lnkParar = new System.Windows.Forms.LinkLabel();
            this.lnkResume = new System.Windows.Forms.LinkLabel();
            this.pnlProbando = new System.Windows.Forms.Panel();
            this.lblProbando = new System.Windows.Forms.Label();
            this.pnlSoloAudio = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlBotonera = new System.Windows.Forms.Panel();
            this.pnlOnvifMove = new System.Windows.Forms.Panel();
            this.lnkSeleccionCamara = new System.Windows.Forms.LinkLabel();
            this.lnkMoveStartup = new System.Windows.Forms.LinkLabel();
            this.lnkMoveDown = new System.Windows.Forms.LinkLabel();
            this.lnkMoveUp = new System.Windows.Forms.LinkLabel();
            this.lnkMoveRight = new System.Windows.Forms.LinkLabel();
            this.lnkMoveLeft = new System.Windows.Forms.LinkLabel();
            this.lblGrabando = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.LabelArchivo = new System.Windows.Forms.Label();
            this.LabelTamanio = new System.Windows.Forms.Label();
            this.lblTamanio = new System.Windows.Forms.Label();
            this.LabelTiempo = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.videoGrabber = new Kenos.Win.Controls.VideoGrabberControl.VideoGrabberWrapper();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcas)).BeginInit();
            this.pnlAlerta.SuspendLayout();
            this.pnlProbando.SuspendLayout();
            this.pnlSoloAudio.SuspendLayout();
            this.pnlBotonera.SuspendLayout();
            this.pnlOnvifMove.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::Kenos.Win.Properties.Resources.fonto_header;
            this.panel1.Controls.Add(this.chkStreaming);
            this.panel1.Controls.Add(this.rdVideo);
            this.panel1.Controls.Add(this.rdAudio);
            this.panel1.Controls.Add(this.lnkConfigurar);
            this.panel1.Controls.Add(this.lnkTest);
            this.panel1.Controls.Add(this.lnkCancelar);
            this.panel1.Controls.Add(this.lnkFinalizar);
            this.panel1.Controls.Add(this.lnkNueva);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 75);
            this.panel1.TabIndex = 0;
            // 
            // chkStreaming
            // 
            this.chkStreaming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkStreaming.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStreaming.FlatAppearance.BorderSize = 0;
            this.chkStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkStreaming.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStreaming.ForeColor = System.Drawing.Color.White;
            this.chkStreaming.Image = global::Kenos.Win.Properties.Resources.streaming;
            this.chkStreaming.Location = new System.Drawing.Point(563, 0);
            this.chkStreaming.Name = "chkStreaming";
            this.chkStreaming.Size = new System.Drawing.Size(73, 72);
            this.chkStreaming.TabIndex = 24;
            this.chkStreaming.Text = "Streaming";
            this.chkStreaming.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkStreaming.UseVisualStyleBackColor = true;
            this.chkStreaming.CheckedChanged += new System.EventHandler(this.chkStreaming_CheckedChanged);
            // 
            // rdVideo
            // 
            this.rdVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdVideo.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdVideo.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdVideo.FlatAppearance.BorderSize = 0;
            this.rdVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdVideo.ForeColor = System.Drawing.Color.White;
            this.rdVideo.Image = global::Kenos.Win.Properties.Resources.icon_video;
            this.rdVideo.Location = new System.Drawing.Point(700, 0);
            this.rdVideo.Name = "rdVideo";
            this.rdVideo.Size = new System.Drawing.Size(64, 72);
            this.rdVideo.TabIndex = 23;
            this.rdVideo.TabStop = true;
            this.rdVideo.Text = "Video";
            this.rdVideo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.rdVideo, "Grabación de Audio y Video");
            this.rdVideo.UseVisualStyleBackColor = true;
            this.rdVideo.CheckedChanged += new System.EventHandler(this.rdTipoGrabacion_CheckedChanged);
            this.rdVideo.Click += new System.EventHandler(this.rdVideo_Click);
            // 
            // rdAudio
            // 
            this.rdAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdAudio.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdAudio.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdAudio.FlatAppearance.BorderSize = 0;
            this.rdAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAudio.ForeColor = System.Drawing.Color.White;
            this.rdAudio.Image = global::Kenos.Win.Properties.Resources.icon_audio;
            this.rdAudio.Location = new System.Drawing.Point(636, 0);
            this.rdAudio.Name = "rdAudio";
            this.rdAudio.Size = new System.Drawing.Size(64, 72);
            this.rdAudio.TabIndex = 23;
            this.rdAudio.TabStop = true;
            this.rdAudio.Text = "Audio";
            this.rdAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.rdAudio, "Grabación solo de Audio");
            this.rdAudio.UseVisualStyleBackColor = true;
            this.rdAudio.CheckedChanged += new System.EventHandler(this.rdTipoGrabacion_CheckedChanged);
            this.rdAudio.Click += new System.EventHandler(this.rdAudio_Click);
            // 
            // lnkConfigurar
            // 
            this.lnkConfigurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkConfigurar.BackColor = System.Drawing.Color.Transparent;
            this.lnkConfigurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkConfigurar.Image = global::Kenos.Win.Properties.Resources.icon_config;
            this.lnkConfigurar.Location = new System.Drawing.Point(831, 12);
            this.lnkConfigurar.Name = "lnkConfigurar";
            this.lnkConfigurar.Size = new System.Drawing.Size(51, 51);
            this.lnkConfigurar.TabIndex = 6;
            this.toolTip.SetToolTip(this.lnkConfigurar, "Configurar el sistema");
            this.lnkConfigurar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkConfigurar_MouseClick);
            // 
            // lnkTest
            // 
            this.lnkTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkTest.BackColor = System.Drawing.Color.Transparent;
            this.lnkTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkTest.Image = global::Kenos.Win.Properties.Resources.icon_prueba;
            this.lnkTest.Location = new System.Drawing.Point(769, 12);
            this.lnkTest.Name = "lnkTest";
            this.lnkTest.Size = new System.Drawing.Size(51, 51);
            this.lnkTest.TabIndex = 6;
            this.toolTip.SetToolTip(this.lnkTest, "Inicia una prueba de grabación para verificar el correcto funcionamiento de todos" +
        " los componentes.");
            this.lnkTest.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkTest_MouseClick);
            // 
            // lnkCancelar
            // 
            this.lnkCancelar.BackColor = System.Drawing.Color.Transparent;
            this.lnkCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkCancelar.Image = global::Kenos.Win.Properties.Resources.icon_cancelar;
            this.lnkCancelar.Location = new System.Drawing.Point(136, 12);
            this.lnkCancelar.Name = "lnkCancelar";
            this.lnkCancelar.Size = new System.Drawing.Size(51, 51);
            this.lnkCancelar.TabIndex = 6;
            this.toolTip.SetToolTip(this.lnkCancelar, "Presione el boton Cancelar para descartar todos los datos capturados (Viedo/Audio" +
        "/Marcas de timpo).");
            this.lnkCancelar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkCancelar_MouseClick);
            // 
            // lnkFinalizar
            // 
            this.lnkFinalizar.BackColor = System.Drawing.Color.Transparent;
            this.lnkFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkFinalizar.Image = global::Kenos.Win.Properties.Resources.icon_confirmar;
            this.lnkFinalizar.Location = new System.Drawing.Point(74, 12);
            this.lnkFinalizar.Name = "lnkFinalizar";
            this.lnkFinalizar.Size = new System.Drawing.Size(51, 51);
            this.lnkFinalizar.TabIndex = 6;
            this.toolTip.SetToolTip(this.lnkFinalizar, "Luego de finalizada la audiencia, presiones este boton para confirmar los datos y" +
        " marcas de tiempo.");
            this.lnkFinalizar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkFinalizar_MouseClick);
            // 
            // lnkNueva
            // 
            this.lnkNueva.BackColor = System.Drawing.Color.Transparent;
            this.lnkNueva.ContextMenuStrip = this.mnuNueva;
            this.lnkNueva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkNueva.Image = global::Kenos.Win.Properties.Resources.icon_nuevo;
            this.lnkNueva.Location = new System.Drawing.Point(12, 12);
            this.lnkNueva.Name = "lnkNueva";
            this.lnkNueva.Size = new System.Drawing.Size(51, 51);
            this.lnkNueva.TabIndex = 6;
            this.lnkNueva.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkNueva_MouseClick);
            // 
            // mnuNueva
            // 
            this.mnuNueva.Name = "mnuNueva";
            this.mnuNueva.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuNueva.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Kenos.Win.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(193, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(193, 38);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(364, 31);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "-";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(498, 104);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(350, 26);
            this.txtDescripcion.TabIndex = 5;
            this.toolTip.SetToolTip(this.txtDescripcion, resources.GetString("txtDescripcion.ToolTip"));
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // LabelDescripcion
            // 
            this.LabelDescripcion.AutoSize = true;
            this.LabelDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDescripcion.ForeColor = System.Drawing.Color.Black;
            this.LabelDescripcion.Location = new System.Drawing.Point(496, 81);
            this.LabelDescripcion.Name = "LabelDescripcion";
            this.LabelDescripcion.Size = new System.Drawing.Size(220, 20);
            this.LabelDescripcion.TabIndex = 4;
            this.LabelDescripcion.Text = "Descripción del evento actual:";
            // 
            // timerRecording
            // 
            this.timerRecording.Interval = 2000;
            this.timerRecording.Tick += new System.EventHandler(this.timerRecording_Tick);
            // 
            // gvMarcas
            // 
            this.gvMarcas.AllowUserToAddRows = false;
            this.gvMarcas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvMarcas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMarcas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tiemp,
            this.Descripcion});
            this.gvMarcas.Location = new System.Drawing.Point(498, 136);
            this.gvMarcas.Name = "gvMarcas";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMarcas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvMarcas.Size = new System.Drawing.Size(384, 568);
            this.gvMarcas.TabIndex = 8;
            this.gvMarcas.SelectionChanged += new System.EventHandler(this.gvMarcas_SelectionChanged);
            this.gvMarcas.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gvMarcas_UserDeletingRow);
            // 
            // Tiemp
            // 
            this.Tiemp.DataPropertyName = "Tiempo";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tiemp.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tiemp.Frozen = true;
            this.Tiemp.HeaderText = "Tiempo";
            this.Tiemp.Name = "Tiemp";
            this.Tiemp.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            // 
            // pnlAlerta
            // 
            this.pnlAlerta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAlerta.BackColor = System.Drawing.Color.Red;
            this.pnlAlerta.Controls.Add(this.btnCerrarAlerta);
            this.pnlAlerta.Controls.Add(this.lblAlerta);
            this.pnlAlerta.Location = new System.Drawing.Point(63, 295);
            this.pnlAlerta.Name = "pnlAlerta";
            this.pnlAlerta.Size = new System.Drawing.Size(776, 96);
            this.pnlAlerta.TabIndex = 9;
            this.pnlAlerta.Visible = false;
            // 
            // btnCerrarAlerta
            // 
            this.btnCerrarAlerta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarAlerta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarAlerta.ForeColor = System.Drawing.Color.White;
            this.btnCerrarAlerta.Location = new System.Drawing.Point(684, 69);
            this.btnCerrarAlerta.Name = "btnCerrarAlerta";
            this.btnCerrarAlerta.Size = new System.Drawing.Size(87, 23);
            this.btnCerrarAlerta.TabIndex = 22;
            this.btnCerrarAlerta.Text = "Cerrar";
            this.btnCerrarAlerta.UseVisualStyleBackColor = true;
            this.btnCerrarAlerta.Click += new System.EventHandler(this.btnCerrarAlerta_Click);
            // 
            // lblAlerta
            // 
            this.lblAlerta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlerta.ForeColor = System.Drawing.Color.White;
            this.lblAlerta.Location = new System.Drawing.Point(19, 0);
            this.lblAlerta.Name = "lblAlerta";
            this.lblAlerta.Size = new System.Drawing.Size(740, 92);
            this.lblAlerta.TabIndex = 0;
            this.lblAlerta.Text = "Alerta: Existen problemas con la grabación de la audiencia";
            this.lblAlerta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlVUMeter
            // 
            this.pnlVUMeter.BackColor = System.Drawing.Color.Black;
            this.pnlVUMeter.Location = new System.Drawing.Point(458, 81);
            this.pnlVUMeter.Name = "pnlVUMeter";
            this.pnlVUMeter.Size = new System.Drawing.Size(9, 394);
            this.pnlVUMeter.TabIndex = 11;
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // btnAgregarMarca
            // 
            this.btnAgregarMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarMarca.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(102)))), ((int)(((byte)(107)))));
            this.btnAgregarMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMarca.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMarca.Image = global::Kenos.Win.Properties.Resources.agregar1;
            this.btnAgregarMarca.Location = new System.Drawing.Point(850, 104);
            this.btnAgregarMarca.Name = "btnAgregarMarca";
            this.btnAgregarMarca.Size = new System.Drawing.Size(30, 26);
            this.btnAgregarMarca.TabIndex = 0;
            this.btnAgregarMarca.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarMarca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnAgregarMarca, resources.GetString("btnAgregarMarca.ToolTip"));
            this.btnAgregarMarca.UseVisualStyleBackColor = false;
            this.btnAgregarMarca.Click += new System.EventHandler(this.btnAgregarMarca_Click);
            // 
            // lnkGrabar
            // 
            this.lnkGrabar.BackColor = System.Drawing.Color.Transparent;
            this.lnkGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkGrabar.Image = global::Kenos.Win.Properties.Resources.icon_grabar;
            this.lnkGrabar.Location = new System.Drawing.Point(164, 13);
            this.lnkGrabar.Name = "lnkGrabar";
            this.lnkGrabar.Size = new System.Drawing.Size(41, 41);
            this.lnkGrabar.TabIndex = 17;
            this.toolTip.SetToolTip(this.lnkGrabar, "Inicia una grabación de audio o video");
            this.lnkGrabar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkGrabar_MouseClick);
            // 
            // lnkPlay
            // 
            this.lnkPlay.BackColor = System.Drawing.Color.Transparent;
            this.lnkPlay.ContextMenuStrip = this.mnuNueva;
            this.lnkPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkPlay.Image = global::Kenos.Win.Properties.Resources.icon_play;
            this.lnkPlay.Location = new System.Drawing.Point(110, 13);
            this.lnkPlay.Name = "lnkPlay";
            this.lnkPlay.Size = new System.Drawing.Size(41, 41);
            this.lnkPlay.TabIndex = 17;
            this.toolTip.SetToolTip(this.lnkPlay, "Haga click para iniciar la reproducción");
            this.lnkPlay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkPlay_MouseClick);
            // 
            // lnkPausar
            // 
            this.lnkPausar.BackColor = System.Drawing.Color.Transparent;
            this.lnkPausar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkPausar.Image = global::Kenos.Win.Properties.Resources.icon_pausa;
            this.lnkPausar.Location = new System.Drawing.Point(218, 13);
            this.lnkPausar.Name = "lnkPausar";
            this.lnkPausar.Size = new System.Drawing.Size(41, 41);
            this.lnkPausar.TabIndex = 17;
            this.toolTip.SetToolTip(this.lnkPausar, "Pausa la grabación actual. Luego puede continuar grabando sobre el mismo archivo." +
        "");
            this.lnkPausar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkPausar_MouseClick);
            // 
            // lnkParar
            // 
            this.lnkParar.BackColor = System.Drawing.Color.Transparent;
            this.lnkParar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkParar.Image = global::Kenos.Win.Properties.Resources.icon_stop;
            this.lnkParar.Location = new System.Drawing.Point(272, 13);
            this.lnkParar.Name = "lnkParar";
            this.lnkParar.Size = new System.Drawing.Size(41, 41);
            this.lnkParar.TabIndex = 17;
            this.toolTip.SetToolTip(this.lnkParar, "Para la grabación actual");
            this.lnkParar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkParar_MouseClick);
            // 
            // lnkResume
            // 
            this.lnkResume.BackColor = System.Drawing.Color.Transparent;
            this.lnkResume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkResume.Image = global::Kenos.Win.Properties.Resources.icon_grabar;
            this.lnkResume.Location = new System.Drawing.Point(218, 13);
            this.lnkResume.Name = "lnkResume";
            this.lnkResume.Size = new System.Drawing.Size(41, 41);
            this.lnkResume.TabIndex = 17;
            this.toolTip.SetToolTip(this.lnkResume, "Haga click para continuar con la grabación");
            this.lnkResume.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkResume_MouseClick);
            // 
            // pnlProbando
            // 
            this.pnlProbando.BackColor = System.Drawing.Color.YellowGreen;
            this.pnlProbando.Controls.Add(this.lblProbando);
            this.pnlProbando.Location = new System.Drawing.Point(7, 82);
            this.pnlProbando.Name = "pnlProbando";
            this.pnlProbando.Size = new System.Drawing.Size(448, 60);
            this.pnlProbando.TabIndex = 16;
            this.pnlProbando.Visible = false;
            // 
            // lblProbando
            // 
            this.lblProbando.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProbando.Location = new System.Drawing.Point(3, 4);
            this.lblProbando.Name = "lblProbando";
            this.lblProbando.Size = new System.Drawing.Size(442, 52);
            this.lblProbando.TabIndex = 0;
            this.lblProbando.Text = "Pruebe que el sonido de cada micrófono se escuche correctamente. Luego presione e" +
    "l botón \"Confirmar\" para finalizar la prueba de grabación.";
            this.lblProbando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSoloAudio
            // 
            this.pnlSoloAudio.BackColor = System.Drawing.Color.Black;
            this.pnlSoloAudio.BackgroundImage = global::Kenos.Win.Properties.Resources.icon_audio;
            this.pnlSoloAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlSoloAudio.Controls.Add(this.label6);
            this.pnlSoloAudio.Location = new System.Drawing.Point(6, 187);
            this.pnlSoloAudio.Name = "pnlSoloAudio";
            this.pnlSoloAudio.Size = new System.Drawing.Size(368, 287);
            this.pnlSoloAudio.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(359, 52);
            this.label6.TabIndex = 0;
            this.label6.Text = "Grabación solo de audio";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlBotonera
            // 
            this.pnlBotonera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(68)))), ((int)(((byte)(80)))));
            this.pnlBotonera.Controls.Add(this.pnlOnvifMove);
            this.pnlBotonera.Controls.Add(this.lnkParar);
            this.pnlBotonera.Controls.Add(this.lnkPausar);
            this.pnlBotonera.Controls.Add(this.lnkGrabar);
            this.pnlBotonera.Controls.Add(this.lnkResume);
            this.pnlBotonera.Controls.Add(this.lnkPlay);
            this.pnlBotonera.Controls.Add(this.lblGrabando);
            this.pnlBotonera.Location = new System.Drawing.Point(7, 6);
            this.pnlBotonera.Name = "pnlBotonera";
            this.pnlBotonera.Size = new System.Drawing.Size(448, 66);
            this.pnlBotonera.TabIndex = 18;
            // 
            // pnlOnvifMove
            // 
            this.pnlOnvifMove.Controls.Add(this.lnkSeleccionCamara);
            this.pnlOnvifMove.Controls.Add(this.lnkMoveStartup);
            this.pnlOnvifMove.Controls.Add(this.lnkMoveDown);
            this.pnlOnvifMove.Controls.Add(this.lnkMoveUp);
            this.pnlOnvifMove.Controls.Add(this.lnkMoveRight);
            this.pnlOnvifMove.Controls.Add(this.lnkMoveLeft);
            this.pnlOnvifMove.Location = new System.Drawing.Point(4, 10);
            this.pnlOnvifMove.Name = "pnlOnvifMove";
            this.pnlOnvifMove.Size = new System.Drawing.Size(100, 48);
            this.pnlOnvifMove.TabIndex = 22;
            // 
            // lnkSeleccionCamara
            // 
            this.lnkSeleccionCamara.AutoSize = true;
            this.lnkSeleccionCamara.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkSeleccionCamara.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(220)))));
            this.lnkSeleccionCamara.Location = new System.Drawing.Point(42, 35);
            this.lnkSeleccionCamara.Name = "lnkSeleccionCamara";
            this.lnkSeleccionCamara.Size = new System.Drawing.Size(37, 13);
            this.lnkSeleccionCamara.TabIndex = 23;
            this.lnkSeleccionCamara.TabStop = true;
            this.lnkSeleccionCamara.Text = "Cam.1";
            this.lnkSeleccionCamara.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(220)))));
            this.lnkSeleccionCamara.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSeleccionCamara_LinkClicked);
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
            // lblGrabando
            // 
            this.lblGrabando.AutoSize = true;
            this.lblGrabando.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrabando.ForeColor = System.Drawing.Color.Red;
            this.lblGrabando.Location = new System.Drawing.Point(324, 22);
            this.lblGrabando.Name = "lblGrabando";
            this.lblGrabando.Size = new System.Drawing.Size(120, 24);
            this.lblGrabando.TabIndex = 16;
            this.lblGrabando.Text = "Grabando...";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlInfo.Controls.Add(this.lblArchivo);
            this.pnlInfo.Controls.Add(this.LabelArchivo);
            this.pnlInfo.Controls.Add(this.LabelTamanio);
            this.pnlInfo.Controls.Add(this.lblTamanio);
            this.pnlInfo.Controls.Add(this.LabelTiempo);
            this.pnlInfo.Controls.Add(this.lblDuracion);
            this.pnlInfo.Location = new System.Drawing.Point(6, 559);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(462, 145);
            this.pnlInfo.TabIndex = 21;
            // 
            // lblArchivo
            // 
            this.lblArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchivo.ForeColor = System.Drawing.Color.Black;
            this.lblArchivo.Location = new System.Drawing.Point(101, 91);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(359, 51);
            this.lblArchivo.TabIndex = 5;
            this.lblArchivo.Text = "-";
            // 
            // LabelArchivo
            // 
            this.LabelArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelArchivo.AutoSize = true;
            this.LabelArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelArchivo.ForeColor = System.Drawing.Color.Black;
            this.LabelArchivo.Location = new System.Drawing.Point(8, 91);
            this.LabelArchivo.Name = "LabelArchivo";
            this.LabelArchivo.Size = new System.Drawing.Size(54, 13);
            this.LabelArchivo.TabIndex = 6;
            this.LabelArchivo.Text = "Archivo:";
            this.LabelArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelTamanio
            // 
            this.LabelTamanio.AutoSize = true;
            this.LabelTamanio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTamanio.ForeColor = System.Drawing.Color.Black;
            this.LabelTamanio.Location = new System.Drawing.Point(3, 44);
            this.LabelTamanio.Name = "LabelTamanio";
            this.LabelTamanio.Size = new System.Drawing.Size(96, 25);
            this.LabelTamanio.TabIndex = 7;
            this.LabelTamanio.Text = "Tamaño:";
            // 
            // lblTamanio
            // 
            this.lblTamanio.AutoSize = true;
            this.lblTamanio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamanio.ForeColor = System.Drawing.Color.Red;
            this.lblTamanio.Location = new System.Drawing.Point(98, 38);
            this.lblTamanio.Name = "lblTamanio";
            this.lblTamanio.Size = new System.Drawing.Size(72, 31);
            this.lblTamanio.TabIndex = 8;
            this.lblTamanio.Text = "0MB";
            // 
            // LabelTiempo
            // 
            this.LabelTiempo.AutoSize = true;
            this.LabelTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTiempo.ForeColor = System.Drawing.Color.Black;
            this.LabelTiempo.Location = new System.Drawing.Point(3, 13);
            this.LabelTiempo.Name = "LabelTiempo";
            this.LabelTiempo.Size = new System.Drawing.Size(89, 25);
            this.LabelTiempo.TabIndex = 9;
            this.LabelTiempo.Text = "Tiempo:";
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuracion.ForeColor = System.Drawing.Color.Red;
            this.lblDuracion.Location = new System.Drawing.Point(98, 7);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(128, 31);
            this.lblDuracion.TabIndex = 10;
            this.lblDuracion.Text = "00:00:00";
            this.lblDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.pnlBotonera);
            this.panel2.Location = new System.Drawing.Point(6, 475);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 78);
            this.panel2.TabIndex = 18;
            // 
            // videoGrabber
            // 
            this.videoGrabber.AdjustOverlayAspectRatio = true;
            this.videoGrabber.AdjustPixelAspectRatio = true;
            this.videoGrabber.Aero = VidGrab.TAero.ae_Default;
            this.videoGrabber.AnalogVideoStandard = -1;
            this.videoGrabber.ApplicationPriority = VidGrab.TApplicationPriority.ap_default;
            this.videoGrabber.ASFAudioBitRate = -1;
            this.videoGrabber.ASFAudioChannels = -1;
            this.videoGrabber.ASFBufferWindow = -1;
            this.videoGrabber.ASFDeinterlaceMode = VidGrab.TASFDeinterlaceMode.adm_NotInterlaced;
            this.videoGrabber.ASFDirectStreamingKeepClientsConnected = false;
            this.videoGrabber.ASFFixedFrameRate = true;
            this.videoGrabber.ASFMediaServerPublishingPoint = "";
            this.videoGrabber.ASFMediaServerRemovePublishingPointAfterDisconnect = false;
            this.videoGrabber.ASFMediaServerTemplatePublishingPoint = "";
            this.videoGrabber.ASFNetworkMaxUsers = 5;
            this.videoGrabber.ASFNetworkPort = 0;
            this.videoGrabber.ASFProfile = -1;
            this.videoGrabber.ASFProfileFromCustomFile = "";
            this.videoGrabber.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_8;
            this.videoGrabber.ASFVideoBitRate = -1;
            this.videoGrabber.ASFVideoFrameRate = 0D;
            this.videoGrabber.ASFVideoHeight = -1;
            this.videoGrabber.ASFVideoMaxKeyFrameSpacing = -1;
            this.videoGrabber.ASFVideoQuality = -1;
            this.videoGrabber.ASFVideoWidth = -1;
            this.videoGrabber.AspectRatioToUse = -1D;
            this.videoGrabber.AssociateAudioAndVideoDevices = false;
            this.videoGrabber.AudioBalance = 0;
            this.videoGrabber.AudioChannelRenderMode = VidGrab.TAudioChannelRenderMode.acrm_Normal;
            this.videoGrabber.AudioCompressor = 0;
            this.videoGrabber.AudioDevice = -1;
            this.videoGrabber.AudioDeviceRendering = false;
            this.videoGrabber.AudioFormat = VidGrab.TAudioFormat.af_default;
            this.videoGrabber.AudioInput = -1;
            this.videoGrabber.AudioInputBalance = 0;
            this.videoGrabber.AudioInputLevel = 65535;
            this.videoGrabber.AudioInputMono = false;
            this.videoGrabber.AudioPeakEvent = false;
            this.videoGrabber.AudioRecording = false;
            this.videoGrabber.AudioRenderer = -1;
            this.videoGrabber.AudioSource = VidGrab.TAudioSource.as_Default;
            this.videoGrabber.AudioStreamNumber = -1;
            this.videoGrabber.AudioSyncAdjustment = 0;
            this.videoGrabber.AudioSyncAdjustmentEnabled = false;
            this.videoGrabber.AudioVolume = 32767;
            this.videoGrabber.AutoConnectRelatedPins = true;
            this.videoGrabber.AutoFileName = VidGrab.TAutoFileName.fn_Sequential;
            this.videoGrabber.AutoFileNameDateTimeFormat = "yymmdd_hhmmss_zzz";
            this.videoGrabber.AutoFileNameMinDigits = 6;
            this.videoGrabber.AutoFilePrefix = "vg";
            this.videoGrabber.AutoFileSuffix = "";
            this.videoGrabber.AutoRefreshPreview = false;
            this.videoGrabber.AutoStartPlayer = true;
            this.videoGrabber.AVIDurationUpdated = true;
            this.videoGrabber.AVIFormatOpenDML = true;
            this.videoGrabber.AVIFormatOpenDMLCompatibilityIndex = true;
            this.videoGrabber.BackColor = System.Drawing.Color.DarkGray;
            this.videoGrabber.BackgroundColor = 0;
            this.videoGrabber.BufferCount = -1;
            this.videoGrabber.BurstCount = 3;
            this.videoGrabber.BurstInterval = 0;
            this.videoGrabber.BurstMode = false;
            this.videoGrabber.BurstType = VidGrab.TFrameCaptureDest.fc_TBitmap;
            this.videoGrabber.BusyCursor = VidGrab.TCursors.cr_HourGlass;
            this.videoGrabber.CameraControlSettings = true;
            this.videoGrabber.CaptureFileExt = "";
            this.videoGrabber.ColorKey = 1048592;
            this.videoGrabber.ColorKeyEnabled = false;
            this.videoGrabber.CompressionMode = VidGrab.TCompressionMode.cm_NoCompression;
            this.videoGrabber.CompressionType = VidGrab.TCompressionType.ct_AudioVideo;
            this.videoGrabber.Cropping_Enabled = false;
            this.videoGrabber.Cropping_Height = 120;
            this.videoGrabber.Cropping_Outbounds = true;
            this.videoGrabber.Cropping_Width = 160;
            this.videoGrabber.Cropping_X = 0;
            this.videoGrabber.Cropping_Y = 0;
            this.videoGrabber.Cropping_Zoom = 1D;
            this.videoGrabber.CurrentOnvifIndex = 0;
            this.videoGrabber.Display_Active = true;
            this.videoGrabber.Display_AlphaBlendEnabled = false;
            this.videoGrabber.Display_AlphaBlendValue = 180;
            this.videoGrabber.Display_AspectRatio = VidGrab.TAspectRatio.ar_Box;
            this.videoGrabber.Display_AutoSize = false;
            this.videoGrabber.Display_Embedded = true;
            this.videoGrabber.Display_Embedded_FitParent = false;
            this.videoGrabber.Display_FullScreen = false;
            this.videoGrabber.Display_Height = 240;
            this.videoGrabber.Display_Left = 10;
            this.videoGrabber.Display_Monitor = 0;
            this.videoGrabber.Display_MouseMovesWindow = true;
            this.videoGrabber.Display_PanScanRatio = 50;
            this.videoGrabber.Display_StayOnTop = false;
            this.videoGrabber.Display_Top = 10;
            this.videoGrabber.Display_TransparentColorEnabled = false;
            this.videoGrabber.Display_TransparentColorValue = 255;
            this.videoGrabber.Display_VideoPortEnabled = true;
            this.videoGrabber.Display_Visible = true;
            this.videoGrabber.Display_Width = 320;
            this.videoGrabber.DoubleBuffered = false;
            this.videoGrabber.DroppedFramesPollingInterval = -1;
            this.videoGrabber.DualDisplay_Active = false;
            this.videoGrabber.DualDisplay_AlphaBlendEnabled = false;
            this.videoGrabber.DualDisplay_AlphaBlendValue = 180;
            this.videoGrabber.DualDisplay_AspectRatio = VidGrab.TAspectRatio.ar_Stretch;
            this.videoGrabber.DualDisplay_AutoSize = false;
            this.videoGrabber.DualDisplay_Embedded = false;
            this.videoGrabber.DualDisplay_Embedded_FitParent = false;
            this.videoGrabber.DualDisplay_FullScreen = false;
            this.videoGrabber.DualDisplay_Height = 240;
            this.videoGrabber.DualDisplay_Left = 20;
            this.videoGrabber.DualDisplay_Monitor = 0;
            this.videoGrabber.DualDisplay_MouseMovesWindow = true;
            this.videoGrabber.DualDisplay_PanScanRatio = 50;
            this.videoGrabber.DualDisplay_StayOnTop = false;
            this.videoGrabber.DualDisplay_Top = 400;
            this.videoGrabber.DualDisplay_TransparentColorEnabled = false;
            this.videoGrabber.DualDisplay_TransparentColorValue = 255;
            this.videoGrabber.DualDisplay_VideoPortEnabled = false;
            this.videoGrabber.DualDisplay_Visible = true;
            this.videoGrabber.DualDisplay_Width = 320;
            this.videoGrabber.DVDateTimeEnabled = true;
            this.videoGrabber.DVDiscontinuityMinimumInterval = 3;
            this.videoGrabber.DVDTitle = 0;
            this.videoGrabber.DVEncoder_VideoFormat = VidGrab.TDVVideoFormat.dvf_DVSD;
            this.videoGrabber.DVEncoder_VideoResolution = VidGrab.TDVSize.dv_Full;
            this.videoGrabber.DVEncoder_VideoStandard = VidGrab.TDVVideoStandard.dvs_Default;
            this.videoGrabber.DVRecordingInNativeFormatSeparatesStreams = false;
            this.videoGrabber.DVReduceFrameRate = false;
            this.videoGrabber.DVRgb219 = false;
            this.videoGrabber.DVTimeCodeEnabled = true;
            this.videoGrabber.EnableStreaming = false;
            this.videoGrabber.EventNotificationSynchrone = true;
            this.videoGrabber.ExtraDLLPath = "";
            this.videoGrabber.FixFlickerOrBlackCapture = false;
            this.videoGrabber.FrameCaptureHeight = -1;
            this.videoGrabber.FrameCaptureWidth = -1;
            this.videoGrabber.FrameCaptureWithoutOverlay = false;
            this.videoGrabber.FrameCaptureZoomSize = 100;
            this.videoGrabber.FrameGrabber = VidGrab.TFrameGrabber.fg_Disabled;
            this.videoGrabber.FrameGrabberRGBFormat = VidGrab.TFrameGrabberRGBFormat.fgf_Default;
            this.videoGrabber.FrameNumberStartsFromZero = false;
            this.videoGrabber.FrameRate = 0D;
            this.videoGrabber.FrameRateDivider = 0;
            this.videoGrabber.HoldRecording = false;
            this.videoGrabber.ImageOverlay_AlphaBlend = false;
            this.videoGrabber.ImageOverlay_AlphaBlendValue = 180;
            this.videoGrabber.ImageOverlay_ChromaKey = false;
            this.videoGrabber.ImageOverlay_ChromaKeyLeewayPercent = 25;
            this.videoGrabber.ImageOverlay_ChromaKeyRGBColor = 0;
            this.videoGrabber.ImageOverlay_Height = -1;
            this.videoGrabber.ImageOverlay_LeftLocation = 10;
            this.videoGrabber.ImageOverlay_RotationAngle = 0D;
            this.videoGrabber.ImageOverlay_StretchToVideoSize = false;
            this.videoGrabber.ImageOverlay_TargetDisplay = -1;
            this.videoGrabber.ImageOverlay_TopLocation = 10;
            this.videoGrabber.ImageOverlay_Transparent = false;
            this.videoGrabber.ImageOverlay_TransparentColorValue = 0;
            this.videoGrabber.ImageOverlay_UseTransparentColor = false;
            this.videoGrabber.ImageOverlay_VideoAlignment = VidGrab.TVideoAlignment.oa_LeftTop;
            this.videoGrabber.ImageOverlay_Width = -1;
            this.videoGrabber.ImageOverlayEnabled = false;
            this.videoGrabber.ImageOverlaySelector = 0;
            this.videoGrabber.IPCameraURL = "";
            this.videoGrabber.JPEGPerformance = VidGrab.TJPEGPerformance.jpBestQuality;
            this.videoGrabber.JPEGProgressiveDisplay = false;
            this.videoGrabber.JPEGQuality = 100;
            this.videoGrabber.LicenseString = "N/A";
            this.videoGrabber.Location = new System.Drawing.Point(6, 81);
            this.videoGrabber.LogoDisplayed = false;
            this.videoGrabber.LogoLayout = VidGrab.TLogoLayout.lg_Stretched;
            this.videoGrabber.MixAudioSamples_CurrentSourceLevel = 100;
            this.videoGrabber.MixAudioSamples_ExternalSourceLevel = 100;
            this.videoGrabber.Mixer_MosaicColumns = 1;
            this.videoGrabber.Mixer_MosaicLines = 1;
            this.videoGrabber.MotionDetector_CompareBlue = true;
            this.videoGrabber.MotionDetector_CompareGreen = true;
            this.videoGrabber.MotionDetector_CompareRed = true;
            this.videoGrabber.MotionDetector_Enabled = false;
            this.videoGrabber.MotionDetector_GreyScale = false;
            this.videoGrabber.MotionDetector_Grid = "5555555555 5555555555 5555555555 5555555555 5555555555 5555555555 5555555555 5555" +
    "555555 5555555555 5555555555";
            this.videoGrabber.MotionDetector_MaxDetectionsPerSecond = 0D;
            this.videoGrabber.MotionDetector_ReduceCPULoad = 1;
            this.videoGrabber.MotionDetector_ReduceVideoNoise = false;
            this.videoGrabber.MotionDetector_Triggered = false;
            this.videoGrabber.MouseWheelEventEnabled = true;
            this.videoGrabber.MpegStreamType = VidGrab.TMpegStreamType.mpst_Default;
            this.videoGrabber.MultiplexedInputEmulation = true;
            this.videoGrabber.MultiplexedRole = VidGrab.TMultiplexedRole.mr_NotMultiplexed;
            this.videoGrabber.MultiplexedStabilizationDelay = 100;
            this.videoGrabber.MultiplexedSwitchDelay = 0;
            this.videoGrabber.Multiplexer = -1;
            this.videoGrabber.MuteAudioRendering = false;
            this.videoGrabber.Name = "videoGrabber";
            this.videoGrabber.NetworkStreaming = VidGrab.TNetworkStreaming.ns_Disabled;
            this.videoGrabber.NetworkStreamingType = VidGrab.TNetworkStreamingType.nst_AudioVideoStreaming;
            this.videoGrabber.NormalCursor = VidGrab.TCursors.cr_Default;
            this.videoGrabber.NotificationMethod = VidGrab.TNotificationMethod.nm_Thread;
            this.videoGrabber.NotificationPriority = VidGrab.TThreadPriority.tpNormal;
            this.videoGrabber.NotificationSleepTime = -1;
            this.videoGrabber.OnFrameBitmapEventSynchrone = false;
            this.videoGrabber.OpenURLAsync = true;
            this.videoGrabber.OverlayAfterTransform = false;
            this.videoGrabber.OwnerObject = null;
            this.videoGrabber.PlayerAudioRendering = true;
            this.videoGrabber.PlayerDuration = ((long)(1));
            this.videoGrabber.PlayerDVSize = VidGrab.TDVSize.dv_Full;
            this.videoGrabber.PlayerFastSeekSpeedRatio = 4;
            this.videoGrabber.PlayerFileName = "";
            this.videoGrabber.PlayerForcedCodec = "";
            this.videoGrabber.PlayerFramePosition = ((long)(1));
            this.videoGrabber.PlayerRefreshPausedDisplay = false;
            this.videoGrabber.PlayerRefreshPausedDisplayFrameRate = 0D;
            this.videoGrabber.PlayerSpeedRatio = 1D;
            this.videoGrabber.PlayerTimePosition = ((long)(0));
            this.videoGrabber.PlayerTrackBarSynchrone = false;
            this.videoGrabber.PlaylistIndex = 0;
            this.videoGrabber.PreallocCapFileCopiedAfterRecording = true;
            this.videoGrabber.PreallocCapFileEnabled = false;
            this.videoGrabber.PreallocCapFileName = "";
            this.videoGrabber.PreallocCapFileSizeInMB = 100;
            this.videoGrabber.PreviewZoomSize = 100;
            this.videoGrabber.QuickDeviceInitialization = false;
            this.videoGrabber.RawAudioSampleCapture = false;
            this.videoGrabber.RawCaptureAsyncEvent = true;
            this.videoGrabber.RawSampleCaptureLocation = VidGrab.TRawSampleCaptureLocation.rl_SourceFormat;
            this.videoGrabber.RawVideoSampleCapture = false;
            this.videoGrabber.RecordingAudioBitRate = -1;
            this.videoGrabber.RecordingBacktimedFramesCount = 0;
            this.videoGrabber.RecordingCanPause = false;
            this.videoGrabber.RecordingFileName = "";
            this.videoGrabber.RecordingInNativeFormat = true;
            this.videoGrabber.RecordingMethod = VidGrab.TRecordingMethod.rm_AVI;
            this.videoGrabber.RecordingMode = Kenos.Win.Controls.VideoGrabberControl.RecordingModes.Standard;
            this.videoGrabber.RecordingOnMotion_Enabled = false;
            this.videoGrabber.RecordingOnMotion_MotionThreshold = 0D;
            this.videoGrabber.RecordingOnMotion_NoMotionPauseDelayMs = 5000;
            this.videoGrabber.RecordingPauseCreatesNewFile = false;
            this.videoGrabber.RecordingSize = VidGrab.TRecordingSize.rs_Default;
            this.videoGrabber.RecordingTimer = VidGrab.TRecordingTimer.rt_Disabled;
            this.videoGrabber.RecordingTimerInterval = 0;
            this.videoGrabber.RecordingVideoBitRate = -1;
            this.videoGrabber.Reencoding_IncludeAudioStream = true;
            this.videoGrabber.Reencoding_IncludeVideoStream = true;
            this.videoGrabber.Reencoding_Method = VidGrab.TRecordingMethod.rm_ASF;
            this.videoGrabber.Reencoding_NewVideoClip = "";
            this.videoGrabber.Reencoding_SourceVideoClip = "";
            this.videoGrabber.Reencoding_StartFrame = ((long)(-1));
            this.videoGrabber.Reencoding_StartTime = ((long)(-1));
            this.videoGrabber.Reencoding_StopFrame = ((long)(-1));
            this.videoGrabber.Reencoding_StopTime = ((long)(-1));
            this.videoGrabber.Reencoding_UseAudioCompressor = false;
            this.videoGrabber.Reencoding_UseFrameGrabber = true;
            this.videoGrabber.Reencoding_UseVideoCompressor = false;
            this.videoGrabber.Reencoding_WMVOutput = false;
            this.videoGrabber.ScreenRecordingLayeredWindows = false;
            this.videoGrabber.ScreenRecordingMonitor = 0;
            this.videoGrabber.ScreenRecordingNonVisibleWindows = false;
            this.videoGrabber.ScreenRecordingThroughClipboard = false;
            this.videoGrabber.ScreenRecordingWithCursor = true;
            this.videoGrabber.SendToDV_DeviceIndex = -1;
            this.videoGrabber.Size = new System.Drawing.Size(452, 394);
            this.videoGrabber.SpeakerBalance = 0;
            this.videoGrabber.SpeakerControl = false;
            this.videoGrabber.SpeakerVolume = 65535;
            this.videoGrabber.StoragePath = "";
            this.videoGrabber.StoreDeviceSettingsInRegistry = true;
            this.videoGrabber.SyncCommands = true;
            this.videoGrabber.SynchronizationRole = VidGrab.TSynchronizationRole.sr_Master;
            this.videoGrabber.Synchronized = false;
            this.videoGrabber.SyncPreview = VidGrab.TSyncPreview.sp_Auto;
            this.videoGrabber.TabIndex = 10;
            this.videoGrabber.TextOverlay_Align = VidGrab.TTextOverlayAlign.tf_Left;
            this.videoGrabber.TextOverlay_AlphaBlend = false;
            this.videoGrabber.TextOverlay_AlphaBlendValue = 180;
            this.videoGrabber.TextOverlay_BkColor = 16777215;
            this.videoGrabber.TextOverlay_Enabled = false;
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.videoGrabber.TextOverlay_FontColor = 16776960;
            this.videoGrabber.TextOverlay_FontSize = 12;
            this.videoGrabber.TextOverlay_GradientColor = 8388608;
            this.videoGrabber.TextOverlay_GradientMode = VidGrab.TTextOverlayGradientMode.gm_Disabled;
            this.videoGrabber.TextOverlay_HighResFont = true;
            this.videoGrabber.TextOverlay_Left = 0;
            this.videoGrabber.TextOverlay_Orientation = VidGrab.TTextOrientation.to_Horizontal;
            this.videoGrabber.TextOverlay_Right = -1;
            this.videoGrabber.TextOverlay_Scrolling = false;
            this.videoGrabber.TextOverlay_ScrollingSpeed = 1;
            this.videoGrabber.TextOverlay_Selector = 0;
            this.videoGrabber.TextOverlay_Shadow = true;
            this.videoGrabber.TextOverlay_ShadowColor = 0;
            this.videoGrabber.TextOverlay_ShadowDirection = VidGrab.TCardinalDirection.cd_Center;
            this.videoGrabber.TextOverlay_String = resources.GetString("videoGrabber.TextOverlay_String");
            this.videoGrabber.TextOverlay_TargetDisplay = -1;
            this.videoGrabber.TextOverlay_Top = 0;
            this.videoGrabber.TextOverlay_Transparent = true;
            this.videoGrabber.TextOverlay_VideoAlignment = VidGrab.TVideoAlignment.oa_LeftTop;
            this.videoGrabber.ThirdPartyDeinterlacer = "";
            this.videoGrabber.TranslateMouseCoordinates = true;
            this.videoGrabber.TunerFrequency = -1;
            this.videoGrabber.TunerMode = VidGrab.TTunerMode.tm_TVTuner;
            this.videoGrabber.TVChannel = 0;
            this.videoGrabber.TVCountryCode = 0;
            this.videoGrabber.TVTunerInputType = VidGrab.TTunerInputType.TunerInputCable;
            this.videoGrabber.TVUseFrequencyOverrides = false;
            this.videoGrabber.UseClock = true;
            this.videoGrabber.VCRHorizontalLocking = false;
            this.videoGrabber.Version = "v10.8.2.4 (build 3174.180524) - Copyright ©2018 Datastead";
            this.videoGrabber.VideoCompression_DataRate = -1;
            this.videoGrabber.VideoCompression_KeyFrameRate = 15;
            this.videoGrabber.VideoCompression_PFramesPerKeyFrame = 0;
            this.videoGrabber.VideoCompression_Quality = 1D;
            this.videoGrabber.VideoCompression_WindowSize = -1;
            this.videoGrabber.VideoCompressor = 0;
            this.videoGrabber.VideoControlSettings = true;
            this.videoGrabber.VideoCursor = VidGrab.TCursors.cr_Default;
            this.videoGrabber.VideoDelay = ((long)(0));
            this.videoGrabber.VideoDevice = -1;
            this.videoGrabber.VideoFormat = -1;
            this.videoGrabber.VideoFromImages_BitmapsSortedBy = VidGrab.TFileSort.fs_TimeAsc;
            this.videoGrabber.VideoFromImages_RepeatIndefinitely = false;
            this.videoGrabber.VideoFromImages_SourceDirectory = "";
            this.videoGrabber.VideoFromImages_TemporaryFile = "SetOfBitmaps01.dat";
            this.videoGrabber.VideoInput = -1;
            this.videoGrabber.VideoProcessing_Brightness = 0;
            this.videoGrabber.VideoProcessing_Contrast = 0;
            this.videoGrabber.VideoProcessing_Deinterlacing = VidGrab.TVideoDeinterlacing.di_Disabled;
            this.videoGrabber.VideoProcessing_FlipHorizontal = false;
            this.videoGrabber.VideoProcessing_FlipVertical = false;
            this.videoGrabber.VideoProcessing_GrayScale = false;
            this.videoGrabber.VideoProcessing_Hue = 0;
            this.videoGrabber.VideoProcessing_InvertColors = false;
            this.videoGrabber.VideoProcessing_Pixellization = 1;
            this.videoGrabber.VideoProcessing_Rotation = VidGrab.TVideoRotation.rt_0_deg;
            this.videoGrabber.VideoProcessing_RotationCustomAngle = 45.5D;
            this.videoGrabber.VideoProcessing_Saturation = 0;
            this.videoGrabber.VideoQualitySettings = true;
            this.videoGrabber.VideoRenderer = VidGrab.TVideoRenderer.vr_AutoSelect;
            this.videoGrabber.VideoRendererExternal = VidGrab.TVideoRendererExternal.vre_None;
            this.videoGrabber.VideoRendererExternalIndex = -1;
            this.videoGrabber.VideoRendererPriority = VidGrab.TVideoRendererPriority.vrp_Auto;
            this.videoGrabber.VideoSize = -1;
            this.videoGrabber.VideoSource = VidGrab.TVideoSource.vs_VideoCaptureDevice;
            this.videoGrabber.VideoSource_FileOrURL = "";
            this.videoGrabber.VideoSource_FileOrURL_StartTime = ((long)(-1));
            this.videoGrabber.VideoSource_FileOrURL_StopTime = ((long)(-1));
            this.videoGrabber.VideoStreamNumber = -1;
            this.videoGrabber.VideoSubtype = -1;
            this.videoGrabber.VideoVisibleWhenStopped = false;
            this.videoGrabber.VirtualAudioStreamControl = -1;
            this.videoGrabber.VirtualVideoStreamControl = -1;
            this.videoGrabber.VuMeter = VidGrab.TVuMeter.vu_Disabled;
            this.videoGrabber.WebcamStillCaptureButton = VidGrab.TWebcamStillCaptureButton.wb_Disabled;
            this.videoGrabber.ZoomCoeff = 1000;
            this.videoGrabber.ZoomXCenter = 0;
            this.videoGrabber.ZoomYCenter = 0;
            this.videoGrabber.CurrentOnvifDeviceIndexChange += new Kenos.Win.Controls.VideoGrabberControl.CurrentOnvifDeviceIndexChangeEventHandler(this.videoGrabber_CurrentOnvifDeviceIndexChange);
            this.videoGrabber.CriticalError += new Kenos.Win.Controls.VideoGrabberControl.CriticalErrorEventHandler(this.videoGrabber_CriticalError);
            this.videoGrabber.OnDeviceLost += new System.EventHandler(this.videoGrabber_OnDeviceLost);
            this.videoGrabber.OnDiskFull += new System.EventHandler(this.videoGrabber_OnDiskFull);
            this.videoGrabber.OnFrameProgress2 += new VidGrab.OnFrameProgress2EventHandler(this.videoGrabber_OnFrameProgress2);
            this.videoGrabber.OnRecordingStarted += new VidGrab.OnRecordingStartedEventHandler(this.videoGrabber_OnRecordingStarted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 716);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlProbando);
            this.Controls.Add(this.pnlSoloAudio);
            this.Controls.Add(this.pnlVUMeter);
            this.Controls.Add(this.gvMarcas);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.LabelDescripcion);
            this.Controls.Add(this.btnAgregarMarca);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.videoGrabber);
            this.Controls.Add(this.pnlAlerta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kenos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcas)).EndInit();
            this.pnlAlerta.ResumeLayout(false);
            this.pnlProbando.ResumeLayout(false);
            this.pnlSoloAudio.ResumeLayout(false);
            this.pnlBotonera.ResumeLayout(false);
            this.pnlBotonera.PerformLayout();
            this.pnlOnvifMove.ResumeLayout(false);
            this.pnlOnvifMove.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label LabelDescripcion;
        private System.Windows.Forms.Button btnAgregarMarca;
        private System.Windows.Forms.Timer timerRecording;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel pnlAlerta;
        private System.Windows.Forms.Label lblAlerta;
        private System.Windows.Forms.DataGridView gvMarcas;
        private Kenos.Win.Controls.VideoGrabberControl.VideoGrabberWrapper videoGrabber;
        private System.Windows.Forms.Panel pnlVUMeter;
        private System.Windows.Forms.Panel pnlSoloAudio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.ContextMenuStrip mnuNueva;
        private System.Windows.Forms.Panel pnlProbando;
        private System.Windows.Forms.Label lblProbando;
        private System.Windows.Forms.Panel pnlBotonera;
        private System.Windows.Forms.Label lblGrabando;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkNueva;
        private System.Windows.Forms.LinkLabel lnkConfigurar;
        private System.Windows.Forms.LinkLabel lnkTest;
        private System.Windows.Forms.LinkLabel lnkCancelar;
        private System.Windows.Forms.LinkLabel lnkFinalizar;
        private System.Windows.Forms.LinkLabel lnkPlay;
        private System.Windows.Forms.LinkLabel lnkParar;
        private System.Windows.Forms.LinkLabel lnkPausar;
        private System.Windows.Forms.LinkLabel lnkGrabar;
        private System.Windows.Forms.LinkLabel lnkResume;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Label LabelArchivo;
        private System.Windows.Forms.Label LabelTamanio;
        private System.Windows.Forms.Label lblTamanio;
        private System.Windows.Forms.Label LabelTiempo;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdAudio;
        private System.Windows.Forms.RadioButton rdVideo;
        private System.Windows.Forms.CheckBox chkStreaming;
        private System.Windows.Forms.Panel pnlOnvifMove;
        private System.Windows.Forms.LinkLabel lnkMoveStartup;
        private System.Windows.Forms.LinkLabel lnkMoveDown;
        private System.Windows.Forms.LinkLabel lnkMoveUp;
        private System.Windows.Forms.LinkLabel lnkMoveRight;
        private System.Windows.Forms.LinkLabel lnkMoveLeft;
        private System.Windows.Forms.LinkLabel lnkSeleccionCamara;
        private System.Windows.Forms.Button btnCerrarAlerta;
    }
}

