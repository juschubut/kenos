using Kenos.OpenBroadcasterSoftware;
using Kenos.Win.Test;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

/**
 * 
 * 
 * 
 * */
namespace Kenos
{
    public partial class frmMain : Form
    {
        private ObsWrapper _obs = new ObsWrapper();

        private Common.IConnector _connector;
        private Common.Metadata _metadata;
        private FileMonitor _fileMonitor = null;
        private CaptureState _estado = CaptureState.Initializing;
        private RecordingFile _output = null;
        private bool _closing = false;
        private PruebaGrabacion _pruebaGrabacion = null;
        private TimeSpan _marcaTiempoActual;    // Mantiene el tiempo actual de grabación
        private TimeSpan _marcaTiempoInicial;   // Mantiene el tiempo total de la grabacion hasta la última pausa
        private DataTable _dtMarcaTiempo;

        private bool IsPaused
        {
            get { return lnkResume.Visible; }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmMain_Load(object sender, EventArgs e)
        {
            AplicarStyles();

            ConfigurarForm();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            InicializarKenos();
        }

        private void OnReady(object sender, EventArgs args)
        {
            Invoke(new MethodInvoker(() =>
            {
                lblStatus.Text = "Cargando modos de grabación...";
                Application.DoEvents();
                CargarModosGrabacion();

                _estado = CaptureState.NotSet;

                ConfigurarForm();
            }));
        }

        private void CargarModosGrabacion()
        {
            var modos = _obs.GetRecordingModes();

            cboModo.Items.Clear();
            cboModo.Items.AddRange(modos.ToArray<object>());

            if (!string.IsNullOrEmpty(Properties.Settings.Default.ModoGrabacionPredeterminado))
            {
                var modo = modos.FirstOrDefault(x => x.Equals(Properties.Settings.Default.ModoGrabacionPredeterminado, StringComparison.InvariantCultureIgnoreCase));

                cboModo.SelectedItem = modo;
            }
            else if (modos.Count > 0)
            {
                cboModo.SelectedIndex = 0;
            }
        }

        private void OnLog(object sender, ObsLogEventArgs args)
        {
            if (args.IsError)
            {
                Logger.Log.Error(new ApplicationException(args.Message, args.Exception));
                MostrarAlerta(true, args.Message);
            }
            else
                Logger.Log.Info(args.Message);
        }

        #region Pruebas de grabación
        private void PruebaGrabacion_Cancelado(object sender, EventArgs e)
        {
            Probando(false);
        }

        private void PruebaGrabacion_Finalizado(object sender, EventArgs e)
        {
            lblProbando.Text = "Finalizando pruebas de grabación";
            Parar();

            MessageBox.Show(this, "Verifique el sonido en las marcas de tiempo correspondientes.", "Prueba de grabación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblProbando.Font = new Font(lblProbando.Font.FontFamily, 10);
            lblProbando.Text = "Pruebe que el sonido de cada micrófono se escuche correctamente. Luego presione el botón \"Confirmar\" para finalizar la prueba de grabación";

            _estado = CaptureState.PlayingTest;

            ConfigurarForm();
        }

        private void PruebaGrabacion_Iniciando(object sender, EventArgs e)
        {
            Probando(true);

            _pruebaGrabacion.Verificada = false;

            if (!IniciarGrabacion())
            {
                _pruebaGrabacion.Cancelar();
            }
        }

        private void PruebaGrabacion_PasoPrueba(object sender, PasoPruebaGrabacionEventArgs e)
        {
            lblProbando.Text = string.Format("Probando {0}...", e.CasoPrueba.Nombre);

            AgregarMarca(string.Format("Prueba de grabación {0}", e.CasoPrueba.Nombre));
        }
        #endregion

        private void menuConnnectorItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            _connector = (Common.IConnector)menuItem.Tag;

            NuevaGrabacion();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_obs.State == ObsStates.Recording)
            {
                MessageBox.Show(this, "Actualmente se encuentra grabando. Termine correctamente el proceso antes de salir.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            if (_estado == CaptureState.Testing || _estado == CaptureState.Recording)
            {
                MessageBox.Show(this, "Inicio una grabación y no se termino correctamente. Debe presionar el boton \"Confirmar\" o \"Cancelar\" para completar el proceso de grabación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            _closing = true;

            _obs.Dispose();

            Log("******************* Kenos Finalizado *******************");
        }

        private void gvMarcas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show(this, string.Format("¿Está seguro que desea borrar la marca de tiempo de {0}?", e.Row.Cells[0].FormattedValue), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void timerRecording_Tick(object sender, EventArgs e)
        {
            if (_obs.State != ObsStates.Recording)
                return;

            if (this.IsPaused)
                return;

            try
            {

                lblGrabando.Text = "Grabando...";

                if (pnlBotonera.BackColor == Kenos.Common.Styles.ColorFondoTerciario)
                {
                    pnlBotonera.BackColor = Color.Red;
                    lblGrabando.ForeColor = Color.White;
                }
                else
                {
                    pnlBotonera.BackColor = Kenos.Common.Styles.ColorFondoTerciario;
                    lblGrabando.ForeColor = Color.Red;
                }

                FileInfo fi = new FileInfo(_output.CurrentFileName);

                if (fi == null || !fi.Exists)
                    return;


                long size = fi.Length;
                bool fileOk = _fileMonitor.Verify(size);

                if (!fileOk)
                {
                    MostrarAlerta(true, "Alerta: Existen problemas con la grabación de la audiencia");
                }

                long totalSize = _output.TotalFileSize;

                lblTamanio.Text = string.Format("{0:N2}Mb", totalSize / 1024.00 / 1024.00);

                int count = 0;

                if (timerRecording.Tag != null)
                    count = (int)timerRecording.Tag;

                count++;

                // Cada 10 pasadas, guarda las marcas de tiempo
                if (count > 10)
                {
                    count = 0;
                    GuardarMarcas();
                }

                timerRecording.Tag = count;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                timerRecording.Stop();
            }
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (_obs.State != ObsStates.Recording)
                return;

            AgregarMarca(txtDescripcion.Text, false);

            txtDescripcion.Text = "";
            txtDescripcion.Focus();
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAgregarMarca_Click(null, null);
        }

        private void lblAlerta_DoubleClick(object sender, EventArgs e)
        {
            pnlAlerta_DoubleClick(sender, e);
        }

        private void pnlAlerta_DoubleClick(object sender, EventArgs e)
        {
            MostrarAlerta(false);
        }

        private void rdTipoGrabacion_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurarForm();
        }
        #endregion

        #region Metodos
        private void InicializarKenos()
        {
            lblStatus.Text = "Inicializando...";
            Application.DoEvents();

            Log("******************* Kenos Iniciado *******************");
            LogKenosInformation();

            ResetGrabacion();

            Probando(false);

            _dtMarcaTiempo = CreateDataSourceMarcaTiempo();

            lblStatus.Text = "Cargando conectores...";
            Application.DoEvents();

            Log("Cargando conectores");

            bool connectorOk = false;

            Logger.Log.IncreaseLogIndentation();

            foreach (string connectorClassName in Properties.Settings.Default.Connectors)
            {
                if (!string.IsNullOrEmpty(connectorClassName))
                {
                    Log("Cargando " + connectorClassName);

                    try
                    {
                        Common.IConnector connector = (Common.IConnector)Activator.CreateInstance(Type.GetType(connectorClassName, true));

                        _connector = connector;

                        AddConnectorMenuItem(connector);
                        connectorOk = true;
                    }
                    catch (Exception ex)
                    {
                        Log("Error al cargar connector " + connectorClassName);
                        Logger.Log.Error(ex);
                    }
                }
            }

            Logger.Log.DecreaseLogIndentation();

            if (!connectorOk)
            {
                _connector = null;

                MessageBox.Show(this, "No se puede cargar el connector, llame al administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _pruebaGrabacion = new PruebaGrabacion();
            _pruebaGrabacion.PasoPrueba += PruebaGrabacion_PasoPrueba;
            _pruebaGrabacion.Iniciando += PruebaGrabacion_Iniciando;
            _pruebaGrabacion.Finalizado += PruebaGrabacion_Finalizado;
            _pruebaGrabacion.Cancelado += PruebaGrabacion_Cancelado;
            _pruebaGrabacion.Verificada = true;

            lblStatus.Text = "Validando espacio en disco...";
            Application.DoEvents();

            AlertaEspacioDisco();

            lblStatus.Text = "Iniciando OBS...";
            Application.DoEvents();

            _obs.Initialize(pnlObs);

            _obs.OnRecordingStarted += OnRecordingStarted;
            _obs.OnRecordingStatus += OnRecordingStatus;
            _obs.OnReady += OnReady;
            _obs.OnLog += OnLog;

            ConfigurarForm();
        }


        private bool IniciarGrabacion()
        {
            bool isOk = true;

            Log("Iniciando grabación");

            Logger.Log.IncreaseLogIndentation();

            try
            {
                _marcaTiempoActual = new TimeSpan();
                _marcaTiempoInicial = new TimeSpan();

                if (!_obs.ValidateConfig())
                {
                    Log("Grabación suspendida por configuracion inválida");

                    isOk = false;
                }

                if (isOk)
                {
                    if (_metadata != null)
                    {
                        Log("Metadata:");
                        Log(_metadata.ToString());
                    }

                    _dtMarcaTiempo.Clear();

                    isOk = _obs.Configure();
                }

                if (isOk)
                {

                    lblArchivo.Text = _obs.RecordingFileName;

                    gvMarcas.AutoGenerateColumns = false;
                    gvMarcas.DataSource = _dtMarcaTiempo;

                    if (_metadata != null)
                        _metadata.FullFileName = _obs.RecordingFileName;

                    _obs.StartRecording();
                    Log("Grabación Iniciada");
                }
            }
            catch (Exception ex)
            {
                isOk = false;

                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }

            ConfigurarForm();

            return isOk;
        }

        private void NuevaGrabacion()
        {
            Log("Click en boton Nuevo");

            Logger.Log.IncreaseLogIndentation();

            Common.Metadata metadata = null;

            try
            {

                try
                {
                    Log("Llamando operación \"Nueva\" de connector");

                    Logger.Log.IncreaseLogIndentation();

                    metadata = _connector.Nueva();
                }
                catch (Exception ex)
                {
                    Log("Se produjo un error al intentar crear una grabación nueva.");
                    Logger.Log.Error(ex);

                    MessageBox.Show(this, "Se produjo un error al intentar crear una grabación nueva.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    throw ex;
                }
                finally
                {
                    Logger.Log.DecreaseLogIndentation();
                }

                if (metadata == null)
                {
                    Log("Click en boton Nuevo - Sin efecto por ser cancelada");
                    return;
                }

                lnkTest.Enabled = true;

                Log("Path donde se realiza grabación {0}", Properties.Settings.Default.PathGrabacion);

                ResetGrabacion();

                _metadata = metadata;
                _estado = CaptureState.Initialized;

                lblDescripcion.Text = _metadata.Descripcion;
                lblArchivo.Text = _metadata.FullFileName;

                if (!string.IsNullOrEmpty(_metadata.Descripcion) && !string.IsNullOrEmpty(_metadata.Etiqueta))
                    lblDescripcion.Text = string.Format("{0} - {1}", _metadata.Etiqueta, _metadata.Descripcion);

                if (string.IsNullOrEmpty(_metadata.Descripcion) && !string.IsNullOrEmpty(_metadata.Etiqueta))
                    lblDescripcion.Text = _metadata.Etiqueta;

                if (!string.IsNullOrEmpty(_metadata.Descripcion) && string.IsNullOrEmpty(_metadata.Etiqueta))
                    lblDescripcion.Text = _metadata.Descripcion;


                Log("Nueva grabación");
                Log("...... Archivo: " + _metadata.FullFileName);
                Log("...... Descripción: " + _metadata.Descripcion);

                ConfigurarForm();

                if (!_pruebaGrabacion.Realizada)
                {
                    MessageBox.Show(this, "Debe realizar la prueba de grabación antes de comenzar a grabar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log("Se produjo un error en operación de NuevaGrabación.");
                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }
        }

        private void CancelarGrabacion()
        {
            Parar();

            if (_connector != null && _metadata != null)
            {
                try
                {
                    _connector.Cancelar(_metadata);

                    Log("Grabación cancelada");
                }
                catch (Exception ex)
                {
                    Log("Se produjo un error al intentar cancelar la grabación.");
                    Logger.Log.Error(ex);

                    MessageBox.Show(this, "Se produjo un error al intentar cancelar la grabación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ResetGrabacion();
        }

        private void Parar()
        {
            Log("Parando grabación");

            Logger.Log.IncreaseLogIndentation();
            try
            {
                if (_obs.State == ObsStates.Recording || _obs.State == ObsStates.Paused)
                {
                    _obs.Stop();

                    MostrarAlerta(false);
                    timerRecording.Stop();

                    Log(string.Format("Grabación parada [{0}]", lblDuracion.Text));

                    UnirArchivos();

                    ConfigurarForm();
                }
                else if (_obs.State == ObsStates.Playing)
                {
                    _obs.Stop();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }
        }

        private void Pausar()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.TextoEnPausa))
                AgregarMarca(string.Format(Properties.Settings.Default.TextoEnPausa, DateTime.Now));

            _estado = CaptureState.Paused;

            _obs.Pause();

            _marcaTiempoInicial = _marcaTiempoActual;

            //CrearNuevoArchivo();

            lnkPausar.Visible = false;
            lnkResume.Visible = true;
            lnkResume.BringToFront();

            pnlBotonera.BackColor = Kenos.Common.Styles.ColorFondoTerciario;
            lblGrabando.ForeColor = Color.Red;
            lblGrabando.Text = "Pausado...";


            Log(string.Format("Grabación pausada [{0}]", lblDuracion.Text));
        }

        private void Reproducir()
        {
            Log("Reproduciendo.");

            if (!_pruebaGrabacion.Verificada)
                Log("Verificación de Prueba de grabación iniciada.");

            _pruebaGrabacion.Verificada = true;

            wmpPlayer.URL = _obs.RecordingFileName;
            wmpPlayer.Ctlcontrols.play();

            ConfigurarForm();
        }

        private void ContinuarGrabacion()
        {
            Log("Continuando Grabación...");

            _obs.Resume();

            _estado = CaptureState.Recording;
            lnkResume.Visible = false;
            lnkPausar.Visible = true;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.TextEnReanudar))
                AgregarMarca(string.Format(Properties.Settings.Default.TextEnReanudar, DateTime.Now));

            Log("Grabación continuada");
        }

        private void ConfirmarPruebaGrabacion()
        {
            if (_pruebaGrabacion.Verificada)
            {
                Log("Finalizando pruebas de grabación");

                _pruebaGrabacion.Confirmada = true;
                _estado = CaptureState.Initialized;

                wmpPlayer.Ctlcontrols.stop();

                GuardarMarcas();

                GuardarPrueba();

                ResetGrabacion(false);
            }
            else
            {
                Log("Informando al usuario que debe reproducir la grabación para poder confirmarla");

                MessageBox.Show(this, "Debe reproducir la grabación y verificar el correcto funcionamiento antes de poder confirmar la prueba de grabación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Finalizar()
        {
            Log("Iniciando proceso de finalización");

            Logger.Log.IncreaseLogIndentation();

            try
            {
                if (_metadata != null)
                {
                    Log("Finalizando grabación de audiencia");

                    try
                    {
                        if (!string.IsNullOrEmpty(Properties.Settings.Default.TextoEnFin))
                            AgregarMarca(string.Format(Properties.Settings.Default.TextoEnFin, DateTime.Now));

                        _metadata.MarcasTiempo = GetMarcasTiempo();

                        //Agrega metadata al archivo resultante.
                        AgregarMarcas();

                        Log("Generando hash...");
                        string hashSHA1 = WinHelper.GenerarHashSHA1(_metadata.FullFileName);

                        Log(string.Format("Archivo resultante: {0}", _metadata.FullFileName));
                        Log(string.Format("----- HASH SHA1: {0}", hashSHA1));

                        _metadata.HashFile = hashSHA1;

                        Log("Comenzando proceso de finalización de conector");

                        try
                        {
                            Logger.Log.IncreaseLogIndentation();

                            _connector.Finalizar(_metadata);
                        }
                        catch (Exception ex)
                        {
                            Logger.Log.Error("Error dentro del finalizar del connector");
                            Logger.Log.Error(ex);
                        }
                        finally
                        {
                            Logger.Log.DecreaseLogIndentation();
                        }

                        Log("Grabación finalizada");

                        ResetGrabacion();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log.Error("Error al confirmar grabación");
                        Logger.Log.Error(ex);

                        MessageBox.Show(this, "Error al confirmar grabación. " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error al finalizar grabación");
                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }

            ConfigurarForm();
        }

        private List<Common.MarcaTiempo> GetMarcasTiempo()
        {
            Log("Obteniendo marcas de tiempo");

            List<Common.MarcaTiempo> marcas = new List<Common.MarcaTiempo>();

            foreach (DataRow r in _dtMarcaTiempo.Rows)
            {
                Common.MarcaTiempo marca = new Common.MarcaTiempo();

                marca.Tiempo = new TimeSpan(0, 0, Convert.ToInt32(r["Posicion"]));
                marca.Descripcion = r["Descripcion"].ToString();

                marcas.Add(marca);
            }

            return marcas;
        }

        private void AddConnectorMenuItem(Common.IConnector connector)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(connector.Nombre);

            menuItem.BackColor = Kenos.Common.Styles.ColorFondoSecundario;
            menuItem.Image = Kenos.Properties.Resources.item_connector;
            menuItem.ForeColor = Kenos.Common.Styles.ColorFuenteSecundario;
            menuItem.Click += menuConnnectorItem_Click;
            menuItem.Tag = connector;

            mnuNueva.Items.Add(menuItem);
        }

        private void ResetGrabacion()
        {
            ResetGrabacion(true);
        }

        private void ResetGrabacion(bool resetMetadata)
        {
            Log("Inicializando datos de grabación");

            if (_estado != CaptureState.Initializing)
                _estado = CaptureState.NotSet;

            if (resetMetadata)
            {
                _metadata = null;
                lblArchivo.Text = "-";
                lblDescripcion.Text = "";
            }
            else
            {
                if (_metadata != null)
                {
                    _estado = CaptureState.Initialized;
                }
            }

            ConfigurarForm();

            lblDuracion.Text = "00:00:00";
            lblTamanio.Text = "0MB";

            if (_dtMarcaTiempo != null)
                _dtMarcaTiempo.Clear();

            if (_pruebaGrabacion != null)
                _pruebaGrabacion.Cancelar();

            Log("Datos de grabación inicializados");
        }

        private void AgregarMarcas()
        {
            if (_metadata != null)
            {
                try
                {
                    Log("Agregando marcas de tiempo al archivo resultante");

                    Kenos.TagsLib.KenosFile file = Kenos.TagsLib.KenosFile.Load(_metadata.FullFileName);

                    file.Description = _metadata.Descripcion;
                    file.Label = _metadata.Etiqueta;
                    file.KenosVersion = WinHelper.Version;

                    foreach (var r in _metadata.MarcasTiempo)
                    {
                        file.Tags.Add(new TagsLib.Tag()
                        {
                            Time = string.Format("{0:hh\\:mm\\:ss}", r.Tiempo),
                            Description = r.Descripcion
                        });
                    }

                    file.Save();

                    Log("... marcas guardadas satisfactoriamente");
                }
                catch (Exception ex)
                {
                    Logger.Log.Error(ex);
                }
            }
        }

        private void GuardarMarcas()
        {

            if (_dtMarcaTiempo != null && _metadata != null)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(_metadata.FullFileName + ".xml", false))
                    {
                        _dtMarcaTiempo.DataSet.WriteXml(sw);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log.Error(ex);
                }
            }
        }

        private void MostrarAlerta(bool value, string mensaje = null)
        {
            if (value)
            {
                if (mensaje != null)
                    lblAlerta.Text = mensaje;

                Log("Mostrando Alerta. Mensaje: " + lblAlerta.Text);
                pnlAlerta.BringToFront();
                pnlAlerta.Visible = true;


                if (_estado == CaptureState.Recording)
                {
                    Log("Pausando grabación por aleta. " + lblAlerta.Text);
                    Pausar();
                }
            }
            else
            {
                if (pnlAlerta.Visible)
                {
                    pnlAlerta.Visible = false;
                    Log("Ocultando Alerta. Mensaje: " + lblAlerta.Text);
                }
            }
        }

        private void ConfigurarForm()
        {
            if (_estado == CaptureState.Initializing)
            {
                pnlBotonera.Enabled = false;
                lnkNueva.Enabled = false;
                lnkGrabar.Enabled = false;
                lnkPausar.Enabled = false;
                lnkParar.Enabled = false;
                lnkPlay.Enabled = false;
                lnkFinalizar.Enabled = false;
                lnkCancelar.Enabled = false;
                lnkTest.Enabled = false;
                wmpPlayer.Visible = false;

                return;
            }

            pnlIniciando.Visible = false;
            pnlBotonera.Enabled = true;
            lnkNueva.Enabled = _estado == CaptureState.Initialized || _estado == CaptureState.NotSet;
            lnkGrabar.Enabled = _estado == CaptureState.Initialized && _pruebaGrabacion.Realizada;
            lnkPausar.Enabled = _estado == CaptureState.Recording && _obs.State == ObsStates.Recording;
            lnkParar.Enabled = _estado == CaptureState.Recording || _estado == CaptureState.Testing || _estado == CaptureState.PlayingTest;
            lnkPlay.Enabled = _estado == CaptureState.PlayingTest;
            lnkFinalizar.Enabled = _estado == CaptureState.Completed || _estado == CaptureState.PlayingTest;
            lnkCancelar.Enabled = (_estado != CaptureState.NotSet);
            lnkTest.Enabled = _estado == CaptureState.Initialized || _estado == CaptureState.NotSet;

            if (lnkCancelar.Enabled && Properties.Settings.Default.ConfirmacionAutomatica)
                lnkCancelar.Enabled = _estado != CaptureState.Completed;

            btnAgregarMarca.Enabled = _estado == CaptureState.Initialized;

            cboModo.Enabled = !(_estado == CaptureState.Recording || _estado == CaptureState.Testing);
            lblDuracion.Enabled = _estado == CaptureState.Recording || _estado == CaptureState.Testing;
            lblTamanio.Enabled = _estado == CaptureState.Recording || _estado == CaptureState.Testing;

            lnkResume.Visible = _estado == CaptureState.Paused;
            lnkPausar.Visible = _estado != CaptureState.Paused;

            if (lnkParar.Enabled)
            {
                if (_estado == CaptureState.PlayingTest)
                    toolTip.SetToolTip(lnkParar, "Para la reproducción actual");
                else
                    toolTip.SetToolTip(lnkParar, "Para la grabación actual");
            }

            pnlBotonera.BackColor = Kenos.Common.Styles.ColorFondoTerciario;
            lblGrabando.Visible = _estado == CaptureState.Recording || _estado == CaptureState.Testing;
            lblGrabando.ForeColor = Color.Red;


            if (_estado == CaptureState.PlayingTest)
            {
                lnkResume.Visible = false;
                lnkParar.Visible = false;
                lnkPlay.Visible = true;
                wmpPlayer.Visible = true;
                pnlObs.Visible = false;
            }
            else
            {
                lnkParar.Visible = true;
                lnkPlay.Visible = false;
                wmpPlayer.Visible = false;
                pnlObs.Visible = true;
            }
        }

        private void Probando(bool probando)
        {
            if (probando)
            {
                lblProbando.Font = new Font(lblProbando.Font.FontFamily, 14);

                lblProbando.Text = "Iniciando pruebas";
                _estado = CaptureState.Testing;
            }

            pnlProbando.Visible = probando;
        }

        private DataTable CreateDataSourceMarcaTiempo()
        {
            DataTable dt = new DataTable("Marcas");

            dt.Columns.Add("Posicion", typeof(long));
            dt.Columns.Add("Tiempo", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));

            DataSet ds = new DataSet();

            ds.DataSetName = "Root";
            ds.Tables.Add(dt);

            return dt;
        }

        private string PositionToTime(TimeSpan ts)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        }

        private string PositionToTime(int position, out int hours, out int minutes, out int seconds)
        {
            seconds = position / 1000;
            minutes = seconds / 60;
            hours = minutes / 60;

            return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes % 60, seconds % 60);
        }

        private void Log(string template, params object[] param)
        {
            Log(string.Format(template, param));
        }

        private void Log(string log)
        {
            if (_estado == CaptureState.Testing || _estado == CaptureState.PlayingTest)
                log += " [Testing]";

            Logger.Log.Info(log);
        }

        private void AgregarMarca(string texto, bool log = true)
        {
            DataRow row = _dtMarcaTiempo.NewRow();

            try
            {
                string tiempo = PositionToTime(_marcaTiempoActual);
                row["Posicion"] = _marcaTiempoActual.TotalSeconds;
                row["Tiempo"] = tiempo;
                row["Descripcion"] = texto;

                _dtMarcaTiempo.Rows.Add(row);

                if (log)
                    Log(string.Format("Marca de tiempo [{0}] - {1}", tiempo, texto));
                else
                    Log(string.Format("Marca de tiempo [{0}]", tiempo));
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }
        }
        #endregion



        private void OnRecordingStatus(object sender, OpenBroadcasterSoftware.ObsRecordingStatusEventArgs args)
        {
            if (!_closing)
            {
                Invoke(new MethodInvoker(() =>
                {
                    if (!_closing)
                    {

                        if (args.IsRecordingPaused)
                            lblGrabando.Text = "Pausado...";
                        else if (args.IsRecording)
                            lblGrabando.Text = "Grabando...";
                        else
                            lblGrabando.Text = "-";

                        var ts = TimeSpan.FromMilliseconds(args.RecordingDuration);

                        if (ts.TotalMilliseconds > 0)
                            lblDuracion.Text = String.Format("{0:hh}:{0:mm}:{0:ss}", ts);
                    }
                }));
            }
        }

        private void OnRecordingStarted(object sender, EventArgs args)
        {
            Invoke(new MethodInvoker(() =>
            {
                lblGrabando.Text = "Grabando...";

                _output = new RecordingFile(_obs.RecordingFileName);
                lblArchivo.Text = _obs.RecordingFileName;

                if (_estado != CaptureState.Testing)
                    _estado = CaptureState.Recording;

                _fileMonitor = new FileMonitor(_obs.RecordingFileName);

                ConfigurarForm();

                if (!string.IsNullOrEmpty(Properties.Settings.Default.TextoEnInicio))
                    AgregarMarca(string.Format(Properties.Settings.Default.TextoEnInicio, DateTime.Now));

                MostrarAlerta(false);
                timerRecording.Start();
            }));
        }

        private void gvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (_obs.State == ObsStates.Playing)
            {
                if (gvMarcas.CurrentRow != null)
                {
                    long seconds = (long)_dtMarcaTiempo.Rows[gvMarcas.CurrentRow.Index]["Posicion"];

                    //  TODO VER SI VALE LA PENA
                    // Reproducir(seconds);
                }
            }
        }

        private bool AlertaEspacioDisco()
        {
            Log("Comprobando espacio en disco");
            Logger.Log.IncreaseLogIndentation();

            double espacio = WinHelper.GetEspacioLibreDisco();

            espacio = espacio / 1024 / 1024 / 1024;

            Log(string.Format("Espacio libre {0:N2}GB", espacio));

            Logger.Log.DecreaseLogIndentation();

            if (espacio < Properties.Settings.Default.AlertaEspacioLibre)
            {
                MostrarAlerta(true, string.Format("El disco donde se graba la audiencia tiene poco espacio libre {0:N2}GB. Comuniquese con el responsable de informática", espacio));

                return false;
            }

            return true;
        }

        private void CrearNuevoArchivo()
        {
            //TODO ver
            _obs.RecordingFileName = _output.CreateNew();
        }

        private void UnirArchivos()
        {
            if (_metadata != null)
                _metadata.FullFileName = _output.Merge();
        }

        private void lnkNueva_MouseClick(object sender, MouseEventArgs e)
        {
            if (mnuNueva.Items.Count > 1)
            {
                Point location = new Point(lnkNueva.Location.X - 3, lnkNueva.Location.Y + 20);

                lnkNueva.ContextMenuStrip.Show(lnkNueva, location);
            }
            else if (_connector != null)
            {
                NuevaGrabacion();
            }
        }

        private void lnkPlay_MouseClick(object sender, MouseEventArgs e)
        {
            Reproducir();
        }

        private void lnkGrabar_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Grabar");

            if (this.IsPaused)
            {
                MessageBox.Show(this, "No puede iniciar una nueva grabación porque el proceso se encuentra pausado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Log("Click en boton Grabar - Sin efecto por estar pausado");

                return;
            }

            IniciarGrabacion();
        }

        private void lnkPausar_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Pausar");

            if (_obs.State == ObsStates.Recording)
                Pausar();
            else
                Log("Click en boton Pausar - Sin efecto por estar grabando");
        }

        private void lnkResume_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Resume");

            if (_estado == CaptureState.Paused)
                ContinuarGrabacion();
            else
                Log("Click en boton Resume - Sin efecto por no estar grabando");
        }

        private void lnkParar_MouseClick(object sender, MouseEventArgs e)
        {
            if (_obs.State == ObsStates.Recording || _estado == CaptureState.Paused)
            {
                DialogResult result = MessageBox.Show(this, "¿Está seguro que desea parar la grabación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    Parar();

                    if (Properties.Settings.Default.ConfirmacionAutomatica)
                    {
                        Finalizar();
                    }
                }
            }
            else
            {
                Parar();
            }
        }

        private void lnkCancelar_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Cancelar");

            DialogResult result = DialogResult.No;

            if (_estado == CaptureState.NotSet || _estado == CaptureState.Initialized)
                result = DialogResult.Yes;
            else
                result = MessageBox.Show(this, "Si cancela la grabación se perderán todos los datos (audio/video/eventos) registrados hasta el momento \n¿Está seguro que desea cancelar la grabación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                CancelarGrabacion();
            }
            else
                Log("Click en boton Cancelar - Sin efecto");

        }

        private void lnkFinalizar_MouseClick(object sender, MouseEventArgs e)
        {
            Log("Click en boton Confirmar");

            if (_estado == CaptureState.Recording || _estado == CaptureState.Testing)
                Finalizar();
            else if (_estado == CaptureState.PlayingTest)
                ConfirmarPruebaGrabacion();
            else
                MessageBox.Show(this, "No existe ninguna grabación iniciada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void lnkTest_MouseClick(object sender, MouseEventArgs e)
        {
            _pruebaGrabacion.Comenzar();
        }

        public void AplicarStyles()
        {
            this.BackColor = Common.Styles.ColorFondoPrimario;

            //pnlInfo.BackColor = Common.Styles.ColorFondoSecundario;
            LabelTamanio.ForeColor = Color.White;
            LabelArchivo.ForeColor = Color.White;
            LabelTiempo.ForeColor = Color.White;
            pnlObs.BackColor = Common.Styles.ColorFondoPrimario;

            LabelDescripcion.ForeColor = Common.Styles.ColorFuentePrimario;

            gvMarcas.BackgroundColor = Common.Styles.ColorFondoSecundario;
            cboModo.BackColor = Common.Styles.ColorFondoPrimario;

        }

        private void LogKenosInformation()
        {
            Log("Kenos info:");

            Logger.Log.IncreaseLogIndentation();

            try
            {
                Log(string.Format("Path: {0}", AppDomain.CurrentDomain.BaseDirectory));
                Log(string.Format("Version: {0}", WinHelper.Version));
                Log(string.Format("MachineName: {0}", System.Environment.MachineName));
                Log(string.Format("AssemblyName: {0}", System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name));
            }
            catch (Exception ex)
            {
                Log("Error al loguear informacion de la aplicacion");
                Logger.Log.Error(ex);
            }
            finally
            {
                Logger.Log.DecreaseLogIndentation();
            }
        }

        private void GuardarPrueba()
        {
            //TODO: ver donde esta el archivo de grabacion 
            //string origen = videoGrabber.RecordingFileName;
            string origen = $"{Guid.NewGuid()}.dat";
            string ext = Path.GetExtension(origen);

            FileInfo fi = new FileInfo(origen);

            if (!fi.Exists)
                return;

            string destinoTemplate = fi.Directory.FullName + "\\Prueba.{0:yyyMMdd}.{1}" + ext;
            int i = 0;
            string destino = "";


            do
            {
                i++;
                destino = string.Format(destinoTemplate, DateTime.Now, i);
            }
            while (File.Exists(destino));


            try
            {
                File.Move(origen, destino);
                Logger.Log.Info(string.Format("Prueba de grabación guardada: {0}", destino));
            }
            catch (Exception ex)
            {
                Logger.Log.Error(new Exception("Error guardando archivo de prueba de grabación", ex));
            }
        }

        private void splitContainer_Panel1_SizeChanged(object sender, EventArgs e)
        {
            var h = splitContainer.Panel1.Height;
            var w = splitContainer.Panel1.Width;
            var top = 23;

            wmpPlayer.Height = h - top;
            wmpPlayer.Width = w;
            wmpPlayer.Left = 0;
            wmpPlayer.Top = top;
        }

        private void cboModo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var modo = cboModo.SelectedItem.ToString();

            _obs.SetRecordingMode(modo);
            Log($"Seleccion de modo de grabación -> {modo}");

            gvMarcas.Focus();
        }
    }
}
