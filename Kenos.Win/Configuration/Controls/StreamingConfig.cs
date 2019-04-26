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
    public partial class StreamingConfig : ConfigFormBase
    {
        public StreamingConfig(VidGrab.VideoGrabber videoGrabber) : base(videoGrabber)
        {
            InitializeComponent();

            LoadConfig();
        }

        public void LoadConfig()
        {
            StreamingSetting c = Config.Current.StreamingSetting;

            txtPuerto.Text = c.Port == 0 ? "" : c.Port.ToString();

            WinHelper.ComboBoxSelectByText(cboUsuarios, c.MaxUsers.ToString());

            if (c.Type == StreamingTypes.Audio)
                rdAudio.Checked = true;
            else if (c.Type == StreamingTypes.Video)
                rdVideo.Checked = true;
            else if (c.Type == StreamingTypes.AudioVideo)
                rdAudioVideo.Checked = true;
        }

        public override void SaveConfig(Config config)
        {
            StreamingSetting c = config.StreamingSetting;

            int port = 0;

            if (int.TryParse(txtPuerto.Text, out port))
            {
                c.Port = port;
            }

            if (cboUsuarios.SelectedItem != null && !string.IsNullOrEmpty(cboUsuarios.SelectedItem.ToString()))
            {
                c.MaxUsers = int.Parse(cboUsuarios.SelectedItem.ToString());
            }

            if (rdAudio.Checked)
                c.Type = StreamingTypes.Audio;
            else if (rdVideo.Checked)
                c.Type = StreamingTypes.Video;
            else 
                c.Type = StreamingTypes.AudioVideo;
        }

        private void txtPuerto_TextChanged(object sender, EventArgs e)
        {
            RefreshUrl();
        }

        private void RefreshUrl()
        {
            txtUrl.Text = string.Format("mms://{0}:{1}", System.Environment.MachineName, txtPuerto.Text);
        }
    }
}
