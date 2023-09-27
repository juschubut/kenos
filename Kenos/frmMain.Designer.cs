namespace Kenos
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lnkTest = new System.Windows.Forms.LinkLabel();
			this.lnkCancelar = new System.Windows.Forms.LinkLabel();
			this.lnkFinalizar = new System.Windows.Forms.LinkLabel();
			this.lnkNueva = new System.Windows.Forms.LinkLabel();
			this.mnuNueva = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.rdVideo = new System.Windows.Forms.RadioButton();
			this.rdAudio = new System.Windows.Forms.RadioButton();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.LabelDescripcion = new System.Windows.Forms.Label();
			this.timerRecording = new System.Windows.Forms.Timer(this.components);
			this.gvMarcas = new System.Windows.Forms.DataGridView();
			this.Tiemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pnlAlerta = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.lblAlerta = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.btnAgregarMarca = new System.Windows.Forms.Button();
			this.lnkGrabar = new System.Windows.Forms.LinkLabel();
			this.lnkPlay = new System.Windows.Forms.LinkLabel();
			this.lnkPausar = new System.Windows.Forms.LinkLabel();
			this.lnkParar = new System.Windows.Forms.LinkLabel();
			this.lnkResume = new System.Windows.Forms.LinkLabel();
			this.pnlProbando = new System.Windows.Forms.Panel();
			this.lblProbando = new System.Windows.Forms.Label();
			this.lblGrabando = new System.Windows.Forms.Label();
			this.prgReencoding = new System.Windows.Forms.ProgressBar();
			this.pnlReencodingProgress = new System.Windows.Forms.Panel();
			this.lblReencodingProgress = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlInfo = new System.Windows.Forms.Panel();
			this.lblArchivo = new System.Windows.Forms.Label();
			this.LabelArchivo = new System.Windows.Forms.Label();
			this.LabelTamanio = new System.Windows.Forms.Label();
			this.lblTamanio = new System.Windows.Forms.Label();
			this.LabelTiempo = new System.Windows.Forms.Label();
			this.lblDuracion = new System.Windows.Forms.Label();
			this.pnlBotonera = new System.Windows.Forms.Panel();
			this.pnlObs = new System.Windows.Forms.Panel();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.wmpPlayer = new AxWMPLib.AxWindowsMediaPlayer();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvMarcas)).BeginInit();
			this.pnlAlerta.SuspendLayout();
			this.pnlProbando.SuspendLayout();
			this.pnlReencodingProgress.SuspendLayout();
			this.pnlInfo.SuspendLayout();
			this.pnlBotonera.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.lnkTest);
			this.panel1.Controls.Add(this.lnkCancelar);
			this.panel1.Controls.Add(this.lnkFinalizar);
			this.panel1.Controls.Add(this.lnkNueva);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.lblDescripcion);
			this.panel1.Controls.Add(this.rdVideo);
			this.panel1.Controls.Add(this.rdAudio);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1503, 115);
			this.panel1.TabIndex = 0;
			// 
			// lnkTest
			// 
			this.lnkTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lnkTest.BackColor = System.Drawing.Color.Transparent;
			this.lnkTest.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkTest.Image = global::Kenos.Properties.Resources.icon_prueba;
			this.lnkTest.Location = new System.Drawing.Point(1411, 18);
			this.lnkTest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lnkTest.Name = "lnkTest";
			this.lnkTest.Size = new System.Drawing.Size(76, 78);
			this.lnkTest.TabIndex = 6;
			this.toolTip.SetToolTip(this.lnkTest, "Inicia una prueba de grabación para verificar el correcto funcionamiento de todos" +
        " los componentes.");
			this.lnkTest.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkTest_MouseClick);
			// 
			// lnkCancelar
			// 
			this.lnkCancelar.BackColor = System.Drawing.Color.Transparent;
			this.lnkCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkCancelar.Image = global::Kenos.Properties.Resources.icon_cancelar;
			this.lnkCancelar.Location = new System.Drawing.Point(204, 18);
			this.lnkCancelar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lnkCancelar.Name = "lnkCancelar";
			this.lnkCancelar.Size = new System.Drawing.Size(76, 78);
			this.lnkCancelar.TabIndex = 6;
			this.toolTip.SetToolTip(this.lnkCancelar, "Presione el boton Cancelar para descartar todos los datos capturados (Viedo/Audio" +
        "/Marcas de timpo).");
			this.lnkCancelar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkCancelar_MouseClick);
			// 
			// lnkFinalizar
			// 
			this.lnkFinalizar.BackColor = System.Drawing.Color.Transparent;
			this.lnkFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkFinalizar.Image = global::Kenos.Properties.Resources.icon_confirmar;
			this.lnkFinalizar.Location = new System.Drawing.Point(111, 18);
			this.lnkFinalizar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lnkFinalizar.Name = "lnkFinalizar";
			this.lnkFinalizar.Size = new System.Drawing.Size(76, 78);
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
			this.lnkNueva.Image = global::Kenos.Properties.Resources.icon_nuevo;
			this.lnkNueva.Location = new System.Drawing.Point(18, 18);
			this.lnkNueva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lnkNueva.Name = "lnkNueva";
			this.lnkNueva.Size = new System.Drawing.Size(76, 78);
			this.lnkNueva.TabIndex = 6;
			this.lnkNueva.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkNueva_MouseClick);
			// 
			// mnuNueva
			// 
			this.mnuNueva.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.mnuNueva.Name = "mnuNueva";
			this.mnuNueva.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.mnuNueva.Size = new System.Drawing.Size(61, 4);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::Kenos.Properties.Resources.logo;
			this.pictureBox1.Location = new System.Drawing.Point(290, 14);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(956, 40);
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
			this.lblDescripcion.Location = new System.Drawing.Point(290, 58);
			this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(956, 48);
			this.lblDescripcion.TabIndex = 2;
			this.lblDescripcion.Text = "-";
			this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rdVideo
			// 
			this.rdVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rdVideo.AutoSize = true;
			this.rdVideo.BackColor = System.Drawing.Color.Transparent;
			this.rdVideo.Checked = true;
			this.rdVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rdVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdVideo.ForeColor = System.Drawing.Color.DimGray;
			this.rdVideo.Image = global::Kenos.Properties.Resources.icon_video;
			this.rdVideo.Location = new System.Drawing.Point(1344, 26);
			this.rdVideo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdVideo.Name = "rdVideo";
			this.rdVideo.Size = new System.Drawing.Size(60, 40);
			this.rdVideo.TabIndex = 1;
			this.rdVideo.TabStop = true;
			this.rdVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolTip.SetToolTip(this.rdVideo, "Grabación de Audio y Video");
			this.rdVideo.UseVisualStyleBackColor = false;
			this.rdVideo.CheckedChanged += new System.EventHandler(this.rdTipoGrabacion_CheckedChanged);
			this.rdVideo.Click += new System.EventHandler(this.rdVideo_Click);
			// 
			// rdAudio
			// 
			this.rdAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rdAudio.AutoSize = true;
			this.rdAudio.BackColor = System.Drawing.Color.Transparent;
			this.rdAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.rdAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rdAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdAudio.ForeColor = System.Drawing.Color.DimGray;
			this.rdAudio.Image = global::Kenos.Properties.Resources.icon_audio;
			this.rdAudio.Location = new System.Drawing.Point(1258, 26);
			this.rdAudio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdAudio.Name = "rdAudio";
			this.rdAudio.Size = new System.Drawing.Size(51, 40);
			this.rdAudio.TabIndex = 1;
			this.rdAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.rdAudio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolTip.SetToolTip(this.rdAudio, "Grabación solo de Audio");
			this.rdAudio.UseVisualStyleBackColor = false;
			this.rdAudio.CheckedChanged += new System.EventHandler(this.rdTipoGrabacion_CheckedChanged);
			this.rdAudio.Click += new System.EventHandler(this.rdAudio_Click);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDescripcion.Location = new System.Drawing.Point(11, 267);
			this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(719, 35);
			this.txtDescripcion.TabIndex = 5;
			this.toolTip.SetToolTip(this.txtDescripcion, resources.GetString("txtDescripcion.ToolTip"));
			this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
			// 
			// LabelDescripcion
			// 
			this.LabelDescripcion.AutoSize = true;
			this.LabelDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelDescripcion.ForeColor = System.Drawing.Color.Black;
			this.LabelDescripcion.Location = new System.Drawing.Point(6, 233);
			this.LabelDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabelDescripcion.Name = "LabelDescripcion";
			this.LabelDescripcion.Size = new System.Drawing.Size(334, 29);
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
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gvMarcas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.gvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tiemp,
            this.Descripcion});
			this.gvMarcas.Location = new System.Drawing.Point(11, 308);
			this.gvMarcas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvMarcas.Name = "gvMarcas";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSlateGray;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gvMarcas.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.gvMarcas.RowHeadersWidth = 62;
			this.gvMarcas.Size = new System.Drawing.Size(767, 656);
			this.gvMarcas.TabIndex = 8;
			this.gvMarcas.SelectionChanged += new System.EventHandler(this.gvMarcas_SelectionChanged);
			this.gvMarcas.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gvMarcas_UserDeletingRow);
			// 
			// Tiemp
			// 
			this.Tiemp.DataPropertyName = "Tiempo";
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Tiemp.DefaultCellStyle = dataGridViewCellStyle6;
			this.Tiemp.Frozen = true;
			this.Tiemp.HeaderText = "Tiempo";
			this.Tiemp.MinimumWidth = 8;
			this.Tiemp.Name = "Tiemp";
			this.Tiemp.ReadOnly = true;
			this.Tiemp.Width = 150;
			// 
			// Descripcion
			// 
			this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Descripcion.DataPropertyName = "Descripcion";
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Descripcion.DefaultCellStyle = dataGridViewCellStyle7;
			this.Descripcion.HeaderText = "Descripción";
			this.Descripcion.MinimumWidth = 8;
			this.Descripcion.Name = "Descripcion";
			// 
			// pnlAlerta
			// 
			this.pnlAlerta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlAlerta.BackColor = System.Drawing.Color.Red;
			this.pnlAlerta.Controls.Add(this.label2);
			this.pnlAlerta.Controls.Add(this.lblAlerta);
			this.pnlAlerta.Location = new System.Drawing.Point(94, 454);
			this.pnlAlerta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlAlerta.Name = "pnlAlerta";
			this.pnlAlerta.Size = new System.Drawing.Size(1329, 148);
			this.pnlAlerta.TabIndex = 9;
			this.pnlAlerta.Visible = false;
			this.pnlAlerta.DoubleClick += new System.EventHandler(this.pnlAlerta_DoubleClick);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(1023, 123);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(295, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Doble click para quitar mensaje de alerta";
			this.label2.DoubleClick += new System.EventHandler(this.pnlAlerta_DoubleClick);
			// 
			// lblAlerta
			// 
			this.lblAlerta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAlerta.ForeColor = System.Drawing.Color.White;
			this.lblAlerta.Location = new System.Drawing.Point(28, 0);
			this.lblAlerta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblAlerta.Name = "lblAlerta";
			this.lblAlerta.Size = new System.Drawing.Size(1275, 145);
			this.lblAlerta.TabIndex = 0;
			this.lblAlerta.Text = "Alerta: Existen problemas con la grabación de la audiencia";
			this.lblAlerta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblAlerta.DoubleClick += new System.EventHandler(this.lblAlerta_DoubleClick);
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
			this.btnAgregarMarca.Image = global::Kenos.Properties.Resources.agregar;
			this.btnAgregarMarca.Location = new System.Drawing.Point(732, 265);
			this.btnAgregarMarca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnAgregarMarca.Name = "btnAgregarMarca";
			this.btnAgregarMarca.Size = new System.Drawing.Size(45, 40);
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
			this.lnkGrabar.Image = global::Kenos.Properties.Resources.icon_grabar;
			this.lnkGrabar.Location = new System.Drawing.Point(104, 4);
			this.lnkGrabar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lnkGrabar.Name = "lnkGrabar";
			this.lnkGrabar.Size = new System.Drawing.Size(62, 63);
			this.lnkGrabar.TabIndex = 17;
			this.toolTip.SetToolTip(this.lnkGrabar, "Inicia una grabación de audio o video");
			this.lnkGrabar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkGrabar_MouseClick);
			// 
			// lnkPlay
			// 
			this.lnkPlay.BackColor = System.Drawing.Color.Transparent;
			this.lnkPlay.ContextMenuStrip = this.mnuNueva;
			this.lnkPlay.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkPlay.Image = global::Kenos.Properties.Resources.icon_play;
			this.lnkPlay.Location = new System.Drawing.Point(23, 4);
			this.lnkPlay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lnkPlay.Name = "lnkPlay";
			this.lnkPlay.Size = new System.Drawing.Size(62, 63);
			this.lnkPlay.TabIndex = 17;
			this.toolTip.SetToolTip(this.lnkPlay, "Haga click para iniciar la reproducción");
			this.lnkPlay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkPlay_MouseClick);
			// 
			// lnkPausar
			// 
			this.lnkPausar.BackColor = System.Drawing.Color.Transparent;
			this.lnkPausar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkPausar.Image = global::Kenos.Properties.Resources.icon_pausa;
			this.lnkPausar.Location = new System.Drawing.Point(185, 4);
			this.lnkPausar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lnkPausar.Name = "lnkPausar";
			this.lnkPausar.Size = new System.Drawing.Size(62, 63);
			this.lnkPausar.TabIndex = 17;
			this.toolTip.SetToolTip(this.lnkPausar, "Pausa la grabación actual. Luego puede continuar grabando sobre el mismo archivo." +
        "");
			this.lnkPausar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkPausar_MouseClick);
			// 
			// lnkParar
			// 
			this.lnkParar.BackColor = System.Drawing.Color.Transparent;
			this.lnkParar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkParar.Image = global::Kenos.Properties.Resources.icon_stop;
			this.lnkParar.Location = new System.Drawing.Point(266, 4);
			this.lnkParar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lnkParar.Name = "lnkParar";
			this.lnkParar.Size = new System.Drawing.Size(62, 63);
			this.lnkParar.TabIndex = 17;
			this.toolTip.SetToolTip(this.lnkParar, "Para la grabación actual");
			this.lnkParar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkParar_MouseClick);
			// 
			// lnkResume
			// 
			this.lnkResume.BackColor = System.Drawing.Color.Transparent;
			this.lnkResume.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lnkResume.Image = global::Kenos.Properties.Resources.icon_grabar;
			this.lnkResume.Location = new System.Drawing.Point(104, 4);
			this.lnkResume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lnkResume.Name = "lnkResume";
			this.lnkResume.Size = new System.Drawing.Size(62, 63);
			this.lnkResume.TabIndex = 17;
			this.toolTip.SetToolTip(this.lnkResume, "Haga click para continuar con la grabación");
			this.lnkResume.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lnkResume_MouseClick);
			// 
			// pnlProbando
			// 
			this.pnlProbando.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlProbando.BackColor = System.Drawing.Color.YellowGreen;
			this.pnlProbando.Controls.Add(this.lblProbando);
			this.pnlProbando.Location = new System.Drawing.Point(0, 897);
			this.pnlProbando.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlProbando.Name = "pnlProbando";
			this.pnlProbando.Size = new System.Drawing.Size(704, 67);
			this.pnlProbando.TabIndex = 16;
			this.pnlProbando.Visible = false;
			// 
			// lblProbando
			// 
			this.lblProbando.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblProbando.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProbando.Location = new System.Drawing.Point(4, 4);
			this.lblProbando.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblProbando.Name = "lblProbando";
			this.lblProbando.Size = new System.Drawing.Size(695, 60);
			this.lblProbando.TabIndex = 0;
			this.lblProbando.Text = "Pruebe que el sonido de cada micrófono se escuche correctamente. Luego presione e" +
    "l botón \"Confirmar\" para finalizar la prueba de grabación.";
			this.lblProbando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblGrabando
			// 
			this.lblGrabando.AutoSize = true;
			this.lblGrabando.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGrabando.ForeColor = System.Drawing.Color.Red;
			this.lblGrabando.Location = new System.Drawing.Point(344, 18);
			this.lblGrabando.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblGrabando.Name = "lblGrabando";
			this.lblGrabando.Size = new System.Drawing.Size(176, 32);
			this.lblGrabando.TabIndex = 16;
			this.lblGrabando.Text = "Grabando...";
			// 
			// prgReencoding
			// 
			this.prgReencoding.ForeColor = System.Drawing.Color.White;
			this.prgReencoding.Location = new System.Drawing.Point(6, 72);
			this.prgReencoding.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.prgReencoding.Name = "prgReencoding";
			this.prgReencoding.Size = new System.Drawing.Size(646, 35);
			this.prgReencoding.TabIndex = 19;
			this.prgReencoding.Value = 50;
			// 
			// pnlReencodingProgress
			// 
			this.pnlReencodingProgress.BackColor = System.Drawing.Color.Black;
			this.pnlReencodingProgress.Controls.Add(this.lblReencodingProgress);
			this.pnlReencodingProgress.Controls.Add(this.label1);
			this.pnlReencodingProgress.Controls.Add(this.prgReencoding);
			this.pnlReencodingProgress.Location = new System.Drawing.Point(11, 132);
			this.pnlReencodingProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlReencodingProgress.Name = "pnlReencodingProgress";
			this.pnlReencodingProgress.Size = new System.Drawing.Size(662, 154);
			this.pnlReencodingProgress.TabIndex = 20;
			this.pnlReencodingProgress.Visible = false;
			// 
			// lblReencodingProgress
			// 
			this.lblReencodingProgress.AutoSize = true;
			this.lblReencodingProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblReencodingProgress.ForeColor = System.Drawing.Color.White;
			this.lblReencodingProgress.Location = new System.Drawing.Point(606, 48);
			this.lblReencodingProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblReencodingProgress.Name = "lblReencodingProgress";
			this.lblReencodingProgress.Size = new System.Drawing.Size(35, 20);
			this.lblReencodingProgress.TabIndex = 21;
			this.lblReencodingProgress.Text = "0%";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(4, 48);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(591, 20);
			this.label1.TabIndex = 20;
			this.label1.Text = "Finalizando la grabación. Esta tarea puede demorar algunos minutos.";
			// 
			// pnlInfo
			// 
			this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlInfo.Controls.Add(this.lblArchivo);
			this.pnlInfo.Controls.Add(this.LabelArchivo);
			this.pnlInfo.Controls.Add(this.LabelTamanio);
			this.pnlInfo.Controls.Add(this.lblTamanio);
			this.pnlInfo.Controls.Add(this.LabelTiempo);
			this.pnlInfo.Controls.Add(this.lblDuracion);
			this.pnlInfo.Location = new System.Drawing.Point(11, 121);
			this.pnlInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlInfo.Name = "pnlInfo";
			this.pnlInfo.Size = new System.Drawing.Size(1234, 96);
			this.pnlInfo.TabIndex = 21;
			// 
			// lblArchivo
			// 
			this.lblArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lblArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblArchivo.ForeColor = System.Drawing.Color.Black;
			this.lblArchivo.Location = new System.Drawing.Point(147, 57);
			this.lblArchivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblArchivo.Name = "lblArchivo";
			this.lblArchivo.Size = new System.Drawing.Size(629, 39);
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
			this.LabelArchivo.Location = new System.Drawing.Point(7, 57);
			this.LabelArchivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabelArchivo.Name = "LabelArchivo";
			this.LabelArchivo.Size = new System.Drawing.Size(73, 20);
			this.LabelArchivo.TabIndex = 6;
			this.LabelArchivo.Text = "Archivo:";
			this.LabelArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LabelTamanio
			// 
			this.LabelTamanio.AutoSize = true;
			this.LabelTamanio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelTamanio.ForeColor = System.Drawing.Color.Black;
			this.LabelTamanio.Location = new System.Drawing.Point(429, 21);
			this.LabelTamanio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabelTamanio.Name = "LabelTamanio";
			this.LabelTamanio.Size = new System.Drawing.Size(145, 37);
			this.LabelTamanio.TabIndex = 7;
			this.LabelTamanio.Text = "Tamaño:";
			// 
			// lblTamanio
			// 
			this.lblTamanio.AutoSize = true;
			this.lblTamanio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTamanio.ForeColor = System.Drawing.Color.Red;
			this.lblTamanio.Location = new System.Drawing.Point(572, 11);
			this.lblTamanio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTamanio.Name = "lblTamanio";
			this.lblTamanio.Size = new System.Drawing.Size(107, 47);
			this.lblTamanio.TabIndex = 8;
			this.lblTamanio.Text = "0MB";
			// 
			// LabelTiempo
			// 
			this.LabelTiempo.AutoSize = true;
			this.LabelTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelTiempo.ForeColor = System.Drawing.Color.Black;
			this.LabelTiempo.Location = new System.Drawing.Point(4, 20);
			this.LabelTiempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LabelTiempo.Name = "LabelTiempo";
			this.LabelTiempo.Size = new System.Drawing.Size(133, 37);
			this.LabelTiempo.TabIndex = 9;
			this.LabelTiempo.Text = "Tiempo:";
			// 
			// lblDuracion
			// 
			this.lblDuracion.AutoSize = true;
			this.lblDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDuracion.ForeColor = System.Drawing.Color.Red;
			this.lblDuracion.Location = new System.Drawing.Point(147, 11);
			this.lblDuracion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDuracion.Name = "lblDuracion";
			this.lblDuracion.Size = new System.Drawing.Size(188, 47);
			this.lblDuracion.TabIndex = 10;
			this.lblDuracion.Text = "00:00:00";
			this.lblDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlBotonera
			// 
			this.pnlBotonera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlBotonera.BackColor = System.Drawing.Color.Black;
			this.pnlBotonera.Controls.Add(this.lnkResume);
			this.pnlBotonera.Controls.Add(this.lnkParar);
			this.pnlBotonera.Controls.Add(this.lnkPausar);
			this.pnlBotonera.Controls.Add(this.lnkPlay);
			this.pnlBotonera.Controls.Add(this.lnkGrabar);
			this.pnlBotonera.Controls.Add(this.lblGrabando);
			this.pnlBotonera.Location = new System.Drawing.Point(-1, 35);
			this.pnlBotonera.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlBotonera.Name = "pnlBotonera";
			this.pnlBotonera.Size = new System.Drawing.Size(784, 72);
			this.pnlBotonera.TabIndex = 18;
			// 
			// pnlObs
			// 
			this.pnlObs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlObs.BackColor = System.Drawing.Color.Black;
			this.pnlObs.CausesValidation = false;
			this.pnlObs.Enabled = false;
			this.pnlObs.Location = new System.Drawing.Point(0, 2);
			this.pnlObs.Name = "pnlObs";
			this.pnlObs.Size = new System.Drawing.Size(704, 962);
			this.pnlObs.TabIndex = 22;
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point(4, 80);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.pnlProbando);
			this.splitContainer.Panel1.Controls.Add(this.wmpPlayer);
			this.splitContainer.Panel1.Controls.Add(this.pnlObs);
			this.splitContainer.Panel1.Controls.Add(this.pnlReencodingProgress);
			this.splitContainer.Panel1.SizeChanged += new System.EventHandler(this.splitContainer_Panel1_SizeChanged);
			this.splitContainer.Panel1MinSize = 470;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.pnlBotonera);
			this.splitContainer.Panel2.Controls.Add(this.LabelDescripcion);
			this.splitContainer.Panel2.Controls.Add(this.btnAgregarMarca);
			this.splitContainer.Panel2.Controls.Add(this.pnlInfo);
			this.splitContainer.Panel2.Controls.Add(this.txtDescripcion);
			this.splitContainer.Panel2.Controls.Add(this.gvMarcas);
			this.splitContainer.Size = new System.Drawing.Size(1492, 965);
			this.splitContainer.SplitterDistance = 704;
			this.splitContainer.TabIndex = 23;
			// 
			// wmpPlayer
			// 
			this.wmpPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.wmpPlayer.Enabled = true;
			this.wmpPlayer.Location = new System.Drawing.Point(462, 35);
			this.wmpPlayer.Name = "wmpPlayer";
			this.wmpPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpPlayer.OcxState")));
			this.wmpPlayer.Size = new System.Drawing.Size(201, 289);
			this.wmpPlayer.TabIndex = 23;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1503, 1050);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.pnlAlerta);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kenos";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvMarcas)).EndInit();
			this.pnlAlerta.ResumeLayout(false);
			this.pnlAlerta.PerformLayout();
			this.pnlProbando.ResumeLayout(false);
			this.pnlReencodingProgress.ResumeLayout(false);
			this.pnlReencodingProgress.PerformLayout();
			this.pnlInfo.ResumeLayout(false);
			this.pnlInfo.PerformLayout();
			this.pnlBotonera.ResumeLayout(false);
			this.pnlBotonera.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdVideo;
        private System.Windows.Forms.RadioButton rdAudio;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label LabelDescripcion;
        private System.Windows.Forms.Button btnAgregarMarca;
        private System.Windows.Forms.Timer timerRecording;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel pnlAlerta;
        private System.Windows.Forms.Label lblAlerta;
        private System.Windows.Forms.DataGridView gvMarcas;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.ContextMenuStrip mnuNueva;
        private System.Windows.Forms.Panel pnlProbando;
        private System.Windows.Forms.Label lblProbando;
        private System.Windows.Forms.Label lblGrabando;
        private System.Windows.Forms.ProgressBar prgReencoding;
        private System.Windows.Forms.Panel pnlReencodingProgress;
        private System.Windows.Forms.Label lblReencodingProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkNueva;
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
        private System.Windows.Forms.Panel pnlBotonera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlObs;
		private System.Windows.Forms.SplitContainer splitContainer;
		private AxWMPLib.AxWindowsMediaPlayer wmpPlayer;
	}
}

