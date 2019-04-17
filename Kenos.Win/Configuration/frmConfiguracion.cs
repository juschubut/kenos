using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Xml;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kenos.Common;

namespace Kenos.Win
{
    public partial class frmConfiguracion : FormularioBase
    {
        VidGrab.VideoGrabber _capture;

        private Control[] tabControls;
        private ConfigControls.AudioConfig _audioConfig;
        private ConfigControls.VideoConfig _videoConfig;
        private ConfigControls.OutputConfig _outputConfig;
        private ConfigControls.StreamingConfig _streamingConfig;


        public frmConfiguracion(VidGrab.VideoGrabber videoGrabber)
            : this()
        {

            _capture = videoGrabber;
            tabControls = new Control[] { pnlVideo, pnlAudio, pnlStreaming, pnlOutput };

            tabAudio.Tag = pnlAudio;
            tabVideo.Tag = pnlVideo;
            tabStreaming.Tag = pnlStreaming;
            tabOutput.Tag = pnlOutput;

            // Video
            _videoConfig = new ConfigControls.VideoConfig(videoGrabber);
            _videoConfig.TopLevel = false;
            _videoConfig.Parent = pnlVideo;
            _videoConfig.Show();

            // Audio
            _audioConfig = new ConfigControls.AudioConfig(videoGrabber);
            _audioConfig.TopLevel = false;
            _audioConfig.Parent = pnlAudio;
            _audioConfig.Show();

            // Streaming
            _streamingConfig = new ConfigControls.StreamingConfig(videoGrabber);
            _streamingConfig.TopLevel = false;
            _streamingConfig.Parent = pnlStreaming;
            _streamingConfig.Show();

            // Output
            _outputConfig = new ConfigControls.OutputConfig(videoGrabber);
            _outputConfig.TopLevel = false;
            _outputConfig.Parent = pnlOutput;
            _outputConfig.Show();


            int x = pnlTabs.Location.X + 10;
            int y = pnlVideo.Location.Y;
            int w = pnlTabs.Width - 20;

            pnlVideo.Location = new System.Drawing.Point(x, y);
            pnlVideo.Width = w;

            pnlAudio.Location = new System.Drawing.Point(x, y);
            pnlAudio.Width = w;

            pnlStreaming.Location = new System.Drawing.Point(x, y);
            pnlStreaming.Width = w;

            pnlOutput.Location = new System.Drawing.Point(x, y);
            pnlOutput.Width = w;

            tab_Click(tabVideo, null);
        }

        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            AplicarEstiloTabs();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Config c = Config.Current;

            _audioConfig.SaveConfig(c);
            _videoConfig.SaveConfig(c);
            _streamingConfig.SaveConfig(c);
            _outputConfig.SaveConfig(c);

            c.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void AplicarEstiloTabsButtons()
        {
            tabVideo.ForeColor = tabVideo.Checked ? Styles.ColorFuenteSecundario : Styles.ColorFuentePrimario;
            tabAudio.ForeColor = tabAudio.Checked ? Styles.ColorFuenteSecundario : Styles.ColorFuentePrimario;
            tabStreaming.ForeColor = tabStreaming.Checked ? Styles.ColorFuenteSecundario : Styles.ColorFuentePrimario;
            tabOutput.ForeColor = tabOutput.Checked ? Styles.ColorFuenteSecundario : Styles.ColorFuentePrimario;
        }

        private void AplicarEstiloTabs()
        {
            pnlTabs.BackColor = Styles.ColorFondoTerciario;

            tabVideo.BackColor = Styles.ColorFondoTerciario;
            tabAudio.BackColor = Styles.ColorFondoTerciario;
            tabStreaming.BackColor = Styles.ColorFondoTerciario;
            tabOutput.BackColor = Styles.ColorFondoTerciario;

            tabVideo.FlatAppearance.CheckedBackColor = Styles.ColorFondoSecundario;
            tabAudio.FlatAppearance.CheckedBackColor = Styles.ColorFondoSecundario;
            tabStreaming.FlatAppearance.CheckedBackColor = Styles.ColorFondoSecundario;
            tabOutput.FlatAppearance.CheckedBackColor = Styles.ColorFondoSecundario;

            AplicarEstiloTabsButtons();
        }

        private void tab_Click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            if (c != null)
            {
                Control selectedTab = c.Tag as Control;

                if (selectedTab != null)
                {
                    foreach (Control tab in tabControls)
                    {
                        tab.Visible = (selectedTab == tab);
                    }
                }
            }

            AplicarEstiloTabsButtons();
        }

    }
}
