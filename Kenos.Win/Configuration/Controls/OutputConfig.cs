using Kenos.Common;
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
    public partial class OutputConfig : ConfigFormBase
    {
        public OutputConfig(VidGrab.VideoGrabber videoGrabber)
            : base(videoGrabber)
        {            
            InitializeComponent();

            LoadConfig();
        }

        private void tbBitRates_Scroll(object sender, EventArgs e)
        {
            lblBitRates.Text = tbBitRates.Value.ToString();
        }

        private void tbVideoQuality_Scroll(object sender, EventArgs e)
        {
            lblVideoQuality.Text = tbVideoQuality.Value.ToString();
        }

        private void LoadConfig()
        {
            OutputSetting c = Config.Current.OutputSetting;
             
            for (int i = 0; i <= 30; i++)
                cbFrames.Items.Add(i);
             
            if (c.VideoBitRate >= tbBitRates.Minimum && c.VideoBitRate <= tbBitRates.Maximum)
            {
                tbBitRates.Value = c.VideoBitRate;
                tbBitRates_Scroll(null, null);
            }

            if (c.VideoQuality >= tbVideoQuality.Minimum && c.VideoQuality <= tbVideoQuality.Maximum)
            {
                tbVideoQuality.Value = c.VideoQuality;
                tbVideoQuality_Scroll(null, null);
            }

            WinHelper.LoadComboBoxFromDelimitedText(cbAudioCompressor, this.VideoGrabber.AudioCompressors);

            WinHelper.ComboBoxSelectByText(cbAudioCompressor, c.AudioCompressor);
            WinHelper.ComboBoxSelectByText(cbFrames, c.FramesRate.ToString());
        }

        public override void SaveConfig(Config config)
        {
            OutputSetting c = config.OutputSetting;

            double frames = 0;
            if (cbFrames.SelectedItem != null)
                double.TryParse(cbFrames.SelectedItem.ToString(), out frames);

            c.FramesRate = frames;

            c.VideoBitRate = tbBitRates.Value;
            c.VideoQuality = tbVideoQuality.Value;

            if (cbAudioCompressor.SelectedItem != null)
                c.AudioCompressor = cbAudioCompressor.SelectedItem.ToString();
        }
    }
}
