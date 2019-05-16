using Kenos.Common;
using Kenos.Win.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenos.Win.ConfigControls
{
    public partial class VideoConfig : ConfigFormBase
    {
        private Color _colorOn = Color.Green;
        private Color _colorOff = Color.Red;

        private VideoSetting[] _settings = new VideoSetting[6];
        private int _camaraActual = 0;
        private Onvif.OnvifDevice _onvifDevice;

        private VidGrab.TVideoSource VideoSource
        {
            get
            {
                return cboTipo.SelectedIndex == 0 ? VidGrab.TVideoSource.vs_VideoCaptureDevice : VidGrab.TVideoSource.vs_IPCamera;
            }
            set
            {



                if (value == VidGrab.TVideoSource.vs_IPCamera)
                    cboTipo.SelectedIndex = 1;
                else
                    cboTipo.SelectedIndex = 0;
            }
        }

        private Onvif.OnvifDevice OnvifDevice
        {
            get
            {
                if (_onvifDevice == null)
                    LoadOnvif();

                return _onvifDevice;
            }
        }

        public VideoConfig(VidGrab.VideoGrabber videoGrabber)
            : base(videoGrabber)
        {
            InitializeComponent();

            vgPreview.LicenseString = Properties.Settings.Default.DatasteadLicenseKey;
            vgPreview.LicenseString = Properties.Settings.Default.DatasteadLicenseKeyRTSP;

            pnlCamara.Location = pnlCamaraIp.Location;

            cboTipo.SelectedIndex = 0;
            chkHabilitada_CheckedChanged(null, null);

            LoadConfig();
        }

        private void cbVideoDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVideoDevice.SelectedIndex != -1)
            {
                this.VideoGrabber.VideoDevice = cbVideoDevice.SelectedIndex;

                WinHelper.LoadComboBoxFromDelimitedText(cbVideoSize, this.VideoGrabber.VideoSizes);
                WinHelper.LoadComboBoxFromDelimitedText(cbVideoSubtype, this.VideoGrabber.VideoSubtypes);

                WinHelper.LoadComboBoxFromDelimitedText(cbNorma, this.VideoGrabber.AnalogVideoStandards);

                WinHelper.LoadComboBoxFromDelimitedText(cbVideoFormat, this.VideoGrabber.VideoFormats);
                WinHelper.LoadComboBoxFromDelimitedText(cbVideoInput, this.VideoGrabber.VideoInputs);
                
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlCamara.Visible = this.VideoSource == VidGrab.TVideoSource.vs_VideoCaptureDevice;
            pnlCamaraIp.Visible = this.VideoSource == VidGrab.TVideoSource.vs_IPCamera;
        }

        private void rdLayout_CheckedChanged(object sender, EventArgs e)
        {
            int camaras = int.Parse((sender as Control).Tag.ToString());

            rdCamara2.Visible = camaras >= 2;
            rdCamara3.Visible = camaras >= 4;
            rdCamara4.Visible = camaras >= 4;
            rdCamara5.Visible = camaras >= 6;
            rdCamara6.Visible = camaras >= 6;
        }

        private void rdCamara_Click(object sender, EventArgs e)
        {
            int camara = int.Parse((sender as Control).Tag.ToString());

            LoadCamara(camara);
        }

        private void LoadCamara(int camara)
        {
            VideoSetting setting;

            if (_camaraActual >= 0)
            {
                setting = _settings[_camaraActual];

                SaveCamara(setting);
            }

            _camaraActual = camara;
            setting = _settings[camara];
            bool habilitada = false;

            txtIpHost.Text = "";
            txtIpUsuario.Text = "";
            txtIpPassword.Text = "";
            txtIpPort.Text = "";
            txtLogPreview.Text = "";
            lblUrl.Text = "";
            cboPerfiles.Items.Clear();
            cboPresetPosition.Items.Clear();

            cbVideoDevice.SelectedIndex = -1;
            cbVideoSize.SelectedIndex = -1;
            cbVideoSubtype.SelectedIndex = -1;
            cbNorma.SelectedIndex = -1;

            btnPreviewStop_Click(null, null);


            habilitada = !string.IsNullOrEmpty(setting.VideoDevice);

            if (setting.VideoSource == VideoSources.IpCamera)
                this.VideoSource = VidGrab.TVideoSource.vs_IPCamera;
            else
                this.VideoSource = VidGrab.TVideoSource.vs_VideoCaptureDevice;

            if (this.VideoSource == VidGrab.TVideoSource.vs_IPCamera)
            {
                txtIpHost.Text = setting.Host;
                txtIpUsuario.Text = setting.Username;
                txtIpPassword.Text = setting.Password;
                if (setting.Port > 0)
                    txtIpPort.Text = setting.Port.ToString();
                else
                    txtIpPort.Text = "";

                lblUrl.Text = setting.StreamUrl;

                
                bool result = true;

                
                if (!string.IsNullOrEmpty(setting.Profile))
                {
                    txtLogPreview.Text = "Buscando perfiles....";

                    Application.DoEvents();

                    result = LoadPerfiles();

                    txtLogPreview.Text = "";

                    Application.DoEvents();

                    WinHelper.ComboBoxSelectByValue(cboPerfiles, setting.Profile);
                }

                if (result)
                {
                    if (!string.IsNullOrEmpty(setting.PresetStartupPosition))
                    {
                        txtLogPreview.Text = "Buscando presets....";

                        Application.DoEvents();

                        LoadPresets();

                        txtLogPreview.Text = "";

                        Application.DoEvents();

                        WinHelper.ComboBoxSelectByValue(cboPresetPosition, setting.PresetStartupPosition);
                    }
                }

                habilitada = !string.IsNullOrEmpty(setting.StreamUrl);
            }
            else
            {
                WinHelper.ComboBoxSelectByText(cbVideoDevice, setting.VideoDevice);
                WinHelper.ComboBoxSelectByText(cbVideoSize, setting.VideoSize);
                WinHelper.ComboBoxSelectByText(cbVideoSubtype, setting.VideoFormatSubType);
                WinHelper.ComboBoxSelectByText(cbNorma, setting.VideoNorma);
                WinHelper.ComboBoxSelectByText(cbFormat, setting.FormatOutput);
                WinHelper.ComboBoxSelectByText(cbCodec, setting.VideoCompressors);
                WinHelper.ComboBoxSelectByText(cbVideoFormat, setting.VideoFormat);
                WinHelper.ComboBoxSelectByText(cbVideoInput, setting.VideoInput);


                habilitada = !string.IsNullOrEmpty(setting.VideoDevice);
            }

            chkHabilitada.Checked = habilitada;
        }

        private void SaveCamara(VideoSetting setting)
        {
            setting.Clean();

            setting.IsEnabled = chkHabilitada.Checked;

            if (chkHabilitada.Checked)
            {
                if (this.VideoSource == VidGrab.TVideoSource.vs_IPCamera)
                    setting.VideoSource = VideoSources.IpCamera;
                else
                    setting.VideoSource = VideoSources.VideoCapture;

                if (this.cbFormat.SelectedItem != null) {
                    setting.FormatOutput = this.cbFormat.SelectedItem.ToString();
                }

                if (this.cbCodec.SelectedItem != null)
                {
                    setting.VideoCompressors = this.cbCodec.SelectedItem.ToString();
                }

                if (VideoSource == VidGrab.TVideoSource.vs_IPCamera)
                {
                    setting.Host = txtIpHost.Text;

                    int port = 0;
                    setting.Port = 0;

                    if (int.TryParse(txtIpPort.Text, out port))
                        setting.Port = port;

                    ComboBoxItem item = cboPresetPosition.SelectedItem as ComboBoxItem;

                    if (item != null)
                        setting.PresetStartupPosition = item.Value;
                    else
                        setting.PresetStartupPosition = "";

                    item = cboPerfiles.SelectedItem as ComboBoxItem;

                    if (item != null)
                        setting.Profile = item.Value;
                    else
                        setting.Profile = "";

                    setting.Username = txtIpUsuario.Text;
                    setting.Password = txtIpPassword.Text;
                    setting.StreamUrl = lblUrl.Text;
                }
                else
                {
                    if (cbVideoInput.SelectedItem != null)
                        setting.VideoInput = cbVideoInput.SelectedItem.ToString();

                    if (cbVideoFormat.SelectedItem != null)
                        setting.VideoFormat = cbVideoFormat.SelectedItem.ToString();

                    if (cbVideoDevice.SelectedItem != null)
                        setting.VideoDevice = cbVideoDevice.SelectedItem.ToString();

                    if (cbVideoDevice.SelectedItem != null)
                        setting.VideoDevice = cbVideoDevice.SelectedItem.ToString();

                    if (cbVideoSize.SelectedItem != null)
                        setting.VideoSize = cbVideoSize.SelectedItem.ToString();

                    if (cbVideoSubtype.SelectedItem != null)
                        setting.VideoFormatSubType = cbVideoSubtype.SelectedItem.ToString();

                    if (cbNorma.SelectedItem != null)
                        setting.VideoNorma = cbNorma.SelectedItem.ToString();
                }
            }
        }

        private void LoadConfig()
        {
            Config c = Config.Current;

            _settings = c.VideoSettings;

            cbVideoDevice.Items.Clear();

            WinHelper.LoadComboBoxFromDelimitedText(cbVideoDevice, this.VideoGrabber.VideoDevices);

            RadioButton rd = rdLayout1;

            if (c.VideoSourceCount > 1)
                rd = rdLayout4;
            if (c.VideoSourceCount > 4)
                rd = rdLayout6;

            _camaraActual = -1;

            rd.Checked = true;
            rdLayout_CheckedChanged(rd, null);

            rdCamara1.Checked = true;
            rdCamara_Click(rdCamara1, null);
        }

        public override void SaveConfig(Config config)
        {
            VideoSetting setting = _settings[_camaraActual];

            SaveCamara(setting);

            config.VideoSourceCount = 1;

            if (rdLayout2.Checked)
                config.VideoSourceCount = 2;
            if (rdLayout4.Checked)
                config.VideoSourceCount = 4;
            if (rdLayout6.Checked)
                config.VideoSourceCount = 6;

            config.VideoSettings = _settings;
        }

        private void chkHabilitada_CheckedChanged(object sender, EventArgs e)
        {
            pnlCamara.Enabled = chkHabilitada.Checked;
            pnlCamaraIp.Enabled = chkHabilitada.Checked;

            if (chkHabilitada.Checked)
            {
                chkHabilitada.ForeColor = _colorOn;
                chkHabilitada.Text = "Habilitada";
            }
            else
            {
                chkHabilitada.ForeColor = _colorOff;
                chkHabilitada.Text = "Deshabilitada";
            }
        }

        private void btnPreviewStart_Click(object sender, EventArgs e)
        {
            vgPreview.Stop();

            VideoSetting setting = _settings[_camaraActual];

            SaveCamara(setting);

            txtLogPreview.Text = "";

            if (setting.Apply(vgPreview))
            {
                vgPreview.StartPreview();
            }
        }

        private void btnPreviewStop_Click(object sender, EventArgs e)
        {
            vgPreview.Stop();
        }

        private void vgPreview_OnLog(object sender, VidGrab.TOnLogEventArgs e)
        {
            txtLogPreview.Text += string.Format("{0} - {1}{2}", e.severity, e.infoMsg, System.Environment.NewLine);
        }

        private void Reset(ComboBox cbo)
        {
            cbo.Items.Clear();
            cbo.Items.Add("Buscar...");
        }

        private void txtCamaraIp_TextChanged(object sender, EventArgs e)
        {
            Reset(cboPerfiles);
            Reset(cboPresetPosition);

            _onvifDevice = null;
        }

        private void cboPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = cboPerfiles.SelectedItem as ComboBoxItem;

            if (item == null)
            {
                if (!LoadPerfiles())
                {
                    Reset(cboPerfiles);
                }
            }
            else
            {
                this.OnvifDevice.SetCurrentProfile(item.Value);

                var rs = this.OnvifDevice.GetRTSPStreamUri();

                if (rs.IsSuccess)
                    lblUrl.Text = rs.Uri;
                else
                    lblUrl.Text = "";

                vgPreview.Stop();
            }
        }

        private void cboPresetPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = cboPresetPosition.SelectedItem as ComboBoxItem;

            if (item == null)
            {
                LoadPresets();
            }
            else
            {
                this.OnvifDevice.GoToPreset(item.Value);
            }
        }


        private void LoadPresets()
        {
            txtLogPreview.Text = "Buscando presets...";
            Application.DoEvents();

            cboPresetPosition.Items.Clear();

            var rs = this.OnvifDevice.GetPresets();

            if (rs.IsSuccess)
            {
                foreach (var p in rs.Presets)
                {
                    cboPresetPosition.Items.Add(new ComboBoxItem
                    {
                        Text = p,
                        Value = p
                    });
                }
            }

            txtLogPreview.Text = "";             
        }

        private bool LoadPerfiles()
        {

            txtLogPreview.Text = "Buscando perfiles...";
            Application.DoEvents();

            cboPerfiles.Items.Clear();

            var rs = this.OnvifDevice.GetProfiles();

            if (rs.IsSuccess)
            {
                foreach (var p in rs.Profiles)
                {
                    cboPerfiles.Items.Add(new ComboBoxItem
                    {
                        Text = p.Description,
                        Value = p.Token
                    });
                }
            }

            if (rs.IsSuccess)
                txtLogPreview.Text = "";

            return rs.IsSuccess;

        }

        private void LoadOnvif()
        {
            int port = 0;

            if (!int.TryParse(txtIpPort.Text, out port))
            {
                txtLogPreview.Text = "Puerto inválido.";
            }

            _onvifDevice = new Onvif.OnvifDevice(txtIpHost.Text, port, txtIpUsuario.Text, txtIpPassword.Text);
            _onvifDevice.OnLog += _onvifDevice_OnLog;
        }

        void _onvifDevice_OnLog(object sender, Onvif.Events.OnLogEventArgs e)
        {
            txtLogPreview.Text += string.Format("{0}{1}", e.Message, Environment.NewLine);

            if (e.Exception != null)
                txtLogPreview.Text += string.Format("{0}{1}", e.Exception.Message, Environment.NewLine);
        }

        private void lnkMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnvifDevice.MoveDown();
        }

        private void lnkMove_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnvifDevice.MoveStop();
        }

        private void lnkMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnvifDevice.MoveUp();
        }

        private void lnkMoveRight_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnvifDevice.MoveRight();
        }

        private void lnkMoveLeft_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnvifDevice.MoveLeft();
        }

        private void lnkMoveStartup_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnvifDevice.AbsoluteMove(0, 0);
        }

        private void changeFormatOutput(object sender, EventArgs e)
        {
            if (cbFormat.SelectedItem.ToString() == "mp4")
            {
                WinHelper.LoadComboBoxFromDelimitedText(cbCodec, this.VideoGrabber.VideoCompressors);
                cbCodec.Enabled = true;
            }
            else {
                cbCodec.Enabled = false;
                cbCodec.SelectedIndex = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.VideoGrabber.ShowDialog(VidGrab.TDialog.dlg_VideoDevice);
        }        
    }
}
