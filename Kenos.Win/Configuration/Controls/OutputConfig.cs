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

            if (Properties.Settings.Default.Mp4Habilitado)
                cboVideoFormat.Items.Add("mp4");

            chkModoNativo.Checked = c.Video.UseNativeFormat;

            cboVideoFormat.SelectedIndex = 0;

            for (int i = 0; i <= 30; i++)
                cbFrames.Items.Add(i);

            if (c.Video.WMV.VideoBitRate >= tbBitRates.Minimum && c.Video.WMV.VideoBitRate <= tbBitRates.Maximum)
            {
                tbBitRates.Value = c.Video.WMV.VideoBitRate;
                tbBitRates_Scroll(null, null);
            }

            if (c.Video.WMV.VideoQuality >= tbVideoQuality.Minimum && c.Video.WMV.VideoQuality <= tbVideoQuality.Maximum)
            {
                tbVideoQuality.Value = c.Video.WMV.VideoQuality;
                tbVideoQuality_Scroll(null, null);
            }

            WinHelper.LoadComboBoxFromDelimitedText(cbAudioCompressor, this.VideoGrabber.AudioCompressors);
            WinHelper.LoadComboBoxFromDelimitedText(cboVideoCompressor, this.VideoGrabber.VideoCompressors);
            WinHelper.LoadComboBoxFromDelimitedText(cboCompressorAudioMP4, this.VideoGrabber.AudioCompressors);

            WinHelper.ComboBoxSelectByText(cbAudioCompressor, c.AudioCompressor);
            WinHelper.ComboBoxSelectByText(cbFrames, c.Video.WMV.FramesRate.ToString());
            WinHelper.ComboBoxSelectByText(cboVideoFormat, c.Video.Format);
            WinHelper.ComboBoxSelectByText(cboVideoCompressor, c.Video.Mp4.VideoCompressor);
            WinHelper.ComboBoxSelectByText(cboCompressorAudioMP4, c.Video.Mp4.AudioCompressor);
             
            cbVideoFormat_SelectedIndexChanged(null, null);
            chkModoNativo_CheckedChanged(null, null);
        }

        public override void SaveConfig(Config config)
        {
            OutputSetting c = config.OutputSetting;

            double frames = 0;
            if (cbFrames.SelectedItem != null)
                double.TryParse(cbFrames.SelectedItem.ToString(), out frames);

            c.Video.WMV.FramesRate = frames;

            c.Video.WMV.VideoBitRate = tbBitRates.Value;
            c.Video.WMV.VideoQuality = tbVideoQuality.Value;

            if (cbAudioCompressor.SelectedItem != null)
                c.AudioCompressor = cbAudioCompressor.SelectedItem.ToString();

            c.Video.Format = cboVideoFormat.SelectedItem.ToString();

            if (cboVideoCompressor.SelectedItem != null)
                c.Video.Mp4.VideoCompressor = cboVideoCompressor.SelectedItem.ToString();

            c.Video.UseNativeFormat = false;
            if (c.Video.Format == "mp4")
            {
                c.Video.UseNativeFormat = chkModoNativo.Checked;

                if (cboCompressorAudioMP4.SelectedItem != null)
                    c.Video.Mp4.AudioCompressor = cboCompressorAudioMP4.SelectedItem.ToString();
            }   
        }

        private void cbVideoFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVideoFormat.SelectedItem != null && cboVideoFormat.SelectedItem.ToString() == "mp4")
                pnlMP4.Visible = true;
            else 
                pnlMP4.Visible = false;
        }

        private void btnVideoCompressorConfig_Click(object sender, EventArgs e)
        {
            if (cboVideoCompressor.SelectedItem == null)
            {
                MessageBox.Show(this, "Debe seleccionar el compresor de MP4", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            this.VideoGrabber.VideoCompressor = this.VideoGrabber.VideoCompressorIndex(cboVideoCompressor.SelectedItem.ToString());
            this.VideoGrabber.ShowDialog(VidGrab.TDialog.dlg_VideoCompressor);
        }

        private void chkModoNativo_CheckedChanged(object sender, EventArgs e)
        {
            lblModoNativo.Enabled = chkModoNativo.Checked;

            cboVideoCompressor.Enabled = !chkModoNativo.Checked;
            cboCompressorAudioMP4.Enabled = !chkModoNativo.Checked;
            lblCompressorAudioMP4.Enabled = !chkModoNativo.Checked;
            lblVideoCompressor.Enabled = !chkModoNativo.Checked;
        }
    }
}
