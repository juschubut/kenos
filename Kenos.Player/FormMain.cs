using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Windows.Forms;

namespace Kenos.Player
{
    public partial class FormMain : Form
    {
        private string _allowedExtensions = "|.mp3|.wmv|.wav|";


        private string _fileName = "";
        private List<Kenos.TagsLib.Tag> _tags;
        private int _interval = 2;
        private bool _changed = false;
        private bool _autoPaused = false;

        public FormMain()
        {
            InitializeComponent();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //wmpPlayer.uiMode = "mini";
            wmpPlayer.stretchToFit = true;
            splitContainer.SplitterDistance = Convert.ToInt32(splitContainer.Width * 0.7);

            Changed(false);

            string fileName = "";

            if (AppDomain.CurrentDomain?.SetupInformation?.ActivationArguments?.ActivationData != null)
            {
                foreach (string arg in AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData)
                {
                    if (IsMultimediaFile(arg))
                    {
                        fileName = arg;
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(fileName))
            {
                for (int i = Environment.GetCommandLineArgs().Length - 1; i >= 0; i--)
                {
                    if (IsMultimediaFile(Environment.GetCommandLineArgs()[i]))
                    {
                        fileName = Environment.GetCommandLineArgs()[i];
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(fileName))
                OpenFile(fileName);
        }

        private bool IsMultimediaFile(string fileName)
        {
            FileInfo info = new FileInfo(fileName);

            if (info.Exists)
            {
                if (_allowedExtensions.Contains("|" + info.Extension + "|"))
                {
                    return true;
                }
            }

            return false;
        }

        private DialogResult ConfirmChanges()
        {
            return MessageBox.Show(this, "Realizó cambios en las marcas de tiempo. ¿Desea guardarlas?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {

            DialogResult result;

            if (_changed)
            {
                result = ConfirmChanges();

                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                else if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveTags();
                }
            }

            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Todos|*.mp3;*.wmv;*.wav|Mp3|*.mp3|Wav|*.wav|Windows Media Video|*.wmv|MPEG-4|*.mp4";
            result = dialog.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo info = new FileInfo(dialog.FileName);

                if (!info.Exists)
                {
                    MessageBox.Show(this, "El archivo que selecciono no existe o no se puede leer", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OpenFile(info.FullName);
            }
        }

        private void OpenFile(string fullName)
        {
            _fileName = fullName;

            wmpPlayer.URL = _fileName;
            lblArchivo.Text = fullName;

            LoadTags();

            wmpPlayer.Ctlcontrols.play();

            Changed(false);
        }

        private void LoadTags()
        {
            Kenos.TagsLib.KenosFile file = Kenos.TagsLib.KenosFile.Load(_fileName);

            lblDescripcion.Text = "Reproducción de audiencia";

            if (!string.IsNullOrEmpty(file.Description))
                lblDescripcion.Text = file.Description;

            _tags = new List<TagsLib.Tag>();

            _tags.Add(new TagsLib.Tag() { Description = "Inicio" });

            if (file.Tags != null && file.Tags.Count > 0)
            {
                foreach (Kenos.TagsLib.Tag tag in file.Tags)
                {
                    if (tag != null)
                    {
                        if (tag.TimeSpan.TotalSeconds == 0 && _tags.Count == 1)
                            _tags.Clear();

                        _tags.Add(tag);


                    }
                }
            }

            gvMarcas.AutoGenerateColumns = false;
            BindTags();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down ||
                keyData == Keys.Left || keyData == Keys.Right)
            {
                object sender = Control.FromHandle(msg.HWnd);

                if (sender is DataGridViewTextBoxEditingControl)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                KeyEventArgs e = new KeyEventArgs(keyData);
                FormMain_KeyDown(sender, e);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void gvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvMarcas.SelectedRows.Count > 0)
            {
                Kenos.TagsLib.Tag tag = (Kenos.TagsLib.Tag)gvMarcas.SelectedRows[0].DataBoundItem;

                wmpPlayer.Ctlcontrols.currentPosition = tag.TimeSpan.TotalSeconds;

                if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPaused || wmpPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    wmpPlayer.Ctlcontrols.play();
                }
            }

        }
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (wmpPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying)
                {
                    wmpPlayer.Ctlcontrols.play();
                    Log("Play");
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    wmpPlayer.Ctlcontrols.pause();
                    Log("Pausa");
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
                {
                    wmpPlayer.Ctlcontrols.play();
                    Log("Play");
                }
                else if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    wmpPlayer.Ctlcontrols.currentPosition += _interval;
                    Log("Adelantar");
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying || wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
                {
                    if (wmpPlayer.Ctlcontrols.currentPosition > _interval)
                    {
                        wmpPlayer.Ctlcontrols.currentPosition -= _interval;
                        Log("Retroceder");
                    }
                    else
                    {
                        wmpPlayer.Ctlcontrols.currentPosition = 0;
                    }

                }
            }
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            AddTag(txtMarca.Text);

            txtMarca.Text = "";
            txtMarca.Focus();
        }


        private void AddTag(string texto)
        {
            if (_tags == null)
                return;

            Kenos.TagsLib.Tag tag = new Kenos.TagsLib.Tag();

            try
            {
                tag.TimeSpan = new TimeSpan(0, 0, Convert.ToInt32(wmpPlayer.Ctlcontrols.currentPosition));
                tag.Description = texto;

                _tags.Add(tag);

                Changed(true);

                BindTags();

                Log("Marca agregada");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void BindTags()
        {

            _tags.Sort(delegate (Kenos.TagsLib.Tag t1, Kenos.TagsLib.Tag t2)
                {
                    return t1.TimeSpan.CompareTo(t2.TimeSpan);
                });

            gvMarcas.DataSource = null;
            gvMarcas.DataSource = _tags;

        }

        private void Log(string log)
        {
            lblLog.Text = log;
        }

        private void gvMarcas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gvMarcas.IsCurrentCellInEditMode)
            {

                if (e.ColumnIndex == 0)
                {
                    TimeSpan ts;

                    if (!TimeSpan.TryParse(e.FormattedValue.ToString(), out ts))
                    {
                        MessageBox.Show(this, "El formato de tiempo ingresado no es válido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        e.Cancel = true;

                        return;
                    }
                }

                //Valida si se cambio algo
                Kenos.TagsLib.Tag tag = _tags[e.RowIndex];
                string val = tag.Description;

                if (e.ColumnIndex == 0)
                    val = tag.Time;

                if (!e.FormattedValue.ToString().Equals(val, StringComparison.CurrentCultureIgnoreCase))
                    Changed(true);

            }
        }

        private void gvMarcas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                RefreshTags();
            }
        }

        private void RefreshTags()
        {
            _tags.Sort(delegate (Kenos.TagsLib.Tag t1, Kenos.TagsLib.Tag t2)
            {
                return t1.TimeSpan.CompareTo(t2.TimeSpan);
            });

            gvMarcas.Refresh();
        }

        private void SaveTags()
        {
            if (string.IsNullOrEmpty(_fileName))
                return;

            if (!_changed)
                return;

            wmpPlayer.URL = "";

            try
            {
                FileInfo info = new FileInfo(_fileName);

                if (info.Exists)
                {
                    Kenos.TagsLib.KenosFile file = Kenos.TagsLib.KenosFile.Load(_fileName);

                    file.Tags = _tags;

                    file.Save();

                    Changed(false);
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_changed)
            {
                DialogResult result = ConfirmChanges();

                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveTags();
                }

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveTags();
        }


        private void Changed(bool val)
        {
            _changed = val;
            btnGuardar.Visible = val;
        }

        private void txtMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAgregarMarca_Click(null, null);
        }

        private void lnkActualizaciones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.Hand;

            try
            {
                ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;

                UpdateCheckInfo updateCheckInfo = updateCheck.CheckForDetailedUpdate();

                if (updateCheckInfo.UpdateAvailable)
                {

                    DialogResult result = MessageBox.Show(this, "Se encontró una nueva versión. ¿Desea actualizar la aplicación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            updateCheck.Update();

                            MessageBox.Show(this, "La aplicación ha sido actualizada. se reiniciara para poder aplicar los cambios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                        }
                        catch (System.Deployment.Application.TrustNotGrantedException)
                        {
                            MessageBox.Show(this, "No tiene permisos para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (System.Deployment.Application.DeploymentException ex)
                        {
                            MessageBox.Show(this, "Se produjo un error al intentar actualizar la aplicación. Error: " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "No existen actualizaciones disponibles.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Se produjo un error intentando comprobar las actualizaciones. Error: " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            if (chkModoDesgrabacion.Checked)
            {
                try
                {
                    if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPaused && _autoPaused)
                    {

                        if (wmpPlayer.Ctlcontrols.currentPosition > 0)
                            wmpPlayer.Ctlcontrols.currentPosition = wmpPlayer.Ctlcontrols.currentPosition - 1;

                        wmpPlayer.Ctlcontrols.play();
                        _autoPaused = false;
                    }
                }
                catch { }
            }
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            if (chkModoDesgrabacion.Checked)
            {
                try
                {
                    if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    {
                        wmpPlayer.Ctlcontrols.pause();
                        _autoPaused = true;
                    }
                    else
                    {
                        _autoPaused = false;
                    }
                }
                catch { }
            }
        }

    }
}
