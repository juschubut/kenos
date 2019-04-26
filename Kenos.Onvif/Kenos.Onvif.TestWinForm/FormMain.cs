using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenos.Onvif.TestWinForm
{
    public partial class FormMain : Form
    {
        /*
        string rtspUrl = "rtsp://admin:pistol745@10.1.2.35:554/videoMain";
        string onvifHost = "10.1.2.35";
        int onvifPort = 888;
        string onvifUser = "admin";
        string onvifPass = "pistol745";*/

        string rtspUrl = "rtsp://admin:pistol745@10.1.2.17:554/videoMain";
        string onvifHost = "10.4.10.130";
        int onvifPort = 80;
        string onvifUser = "onvifkenos";
        string onvifPass = "kenos";

        private Onvif.OnvifDevice _device;

        public FormMain()
        {
            InitializeComponent();

            videoGrabber.LicenseString = "3262443125200627035110-27abijuschugovar";
            videoGrabber.LicenseString = "DTSTDRTSP:4814446211562164240574-75abijuschugovar";

            _device = new Onvif.OnvifDevice(onvifHost, onvifPort, onvifUser, onvifPass);

            var rs = _device.GetPresets();

            if (rs.IsSuccess)
            {
                foreach (string preset in rs.Presets)
                {
                    cboPresets.Items.Add(preset);
                }
            }
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";

            videoGrabber.VideoSource = VidGrab.TVideoSource.vs_IPCamera;
            videoGrabber.IPCameraURL = rtspUrl;

            videoGrabber.StartPreview();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            videoGrabber.Stop();
        }

        private void videoGrabber_OnLog(object sender, VidGrab.TOnLogEventArgs e)
        {
            txtLog.Text += string.Format("{0}\n", e.infoMsg);
        }

        private void btnIzquierda_MouseDown(object sender, MouseEventArgs e)
        {
            _device.MoveLeft();
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            _device.MoveLeft();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            btnConnect_Click(null, null);
        }

        private void cboPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            _device.GoToPreset(cboPresets.SelectedItem.ToString());
        }

        private void btnArriba_MouseDown(object sender, MouseEventArgs e)
        {
            _device.MoveDown();
        }

        private void btnMove_MouseUp(object sender, MouseEventArgs e)
        {
            _device.MoveStop();
        }

        private void btnAbajo_MouseDown(object sender, MouseEventArgs e)
        {
            _device.MoveDown();
        }

        private void btnDerecha_MouseDown(object sender, MouseEventArgs e)
        {
            _device.MoveRight();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";

            txtLog.Text += string.Format("IsPTZSupported: {0}", _device.IsPTZSupported);
            txtLog.Text += string.Format("{0}IsAbsoluteMoveSupported: {1}", System.Environment.NewLine, _device.IsAbsoluteMoveSupported);
            txtLog.Text += string.Format("{0}IsRelativeMoveSupported: {1}", System.Environment.NewLine, _device.IsRelativeMoveSupported);
            txtLog.Text += string.Format("{0}IsContinuousMoveSupported: {1}", System.Environment.NewLine, _device.IsContinuousMoveSupported);
            txtLog.Text += string.Format("{0}IsZoomSupported: {1}", System.Environment.NewLine, _device.IsZoomSupported);
        }

        private void btnAux_Click(object sender, EventArgs e)
        {
            _device.AbsoluteMove(0.6f, 0.6f);
        }

        private void tbY_ValueChanged(object sender, EventArgs e)
        {
            lblY.Text = tbY.Value.ToString();
        }

        private void tbX_ValueChanged(object sender, EventArgs e)
        {
            lblX.Text = tbX.Value.ToString();
        }

        private void btnAbsoluteMove_Click(object sender, EventArgs e)
        {
            AbsoluteMove();
        }

        private void tbPosition_MouseUp(object sender, MouseEventArgs e)
        {
            AbsoluteMove();
        }

        private void btnCentro_Click(object sender, EventArgs e)
        {
            tbY.Value = 0;
            tbX.Value = 0;

            AbsoluteMove();
        }

        private void AbsoluteMove()
        {
            float x = tbX.Value / 100f;
            float y = tbY.Value / 100f;

            _device.AbsoluteMove(x, -y);
        }

        private void btnInfo_Click_(object sender, EventArgs e)
        {
            cboProfiles.Items.Clear();

            var rs = _device.GetProfiles();

            if (rs.IsSuccess)
            {
                foreach (Kenos.Onvif.ProfileInfo profile in rs.Profiles)
                {
                    cboProfiles.Items.Add(new ComboboxItem
                    {
                        Text = profile.Description,
                        Value = profile.Token
                    });
                }
            }         


            txtLog.Text = "";

            if (_device.IsRtspSupported)
            {
                txtLog.Text += string.Format("Rtsp: {0}{1}", _device.RtspProtocol.Port[0], System.Environment.NewLine);
            }


            txtLog.Text += string.Format("Rtsp URL: {0}{1}", _device.GetRTSPStreamUri().Uri, Environment.NewLine);

           
            
        }

        private void cboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem item = cboProfiles.SelectedItem as ComboboxItem;

            txtLog.Text = "";

            txtLog.Text += string.Format("Rtsp: {0}{1}", _device.GetRTSPStreamUri(), System.Environment.NewLine);
        }

        private void btnDiscovery_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_device.AbsoluteMove(1, 1);

           // _device.RelativeMove(1, 1);
            _device.MoveUp();


            OnvifServices.v20.PTZ.PTZNode node = _device.PTZ.GetNodes()[0];


            //var response = _device.Managment.GetServices(true);
        }

    }
}
