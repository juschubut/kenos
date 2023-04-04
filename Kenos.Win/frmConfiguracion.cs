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

        public frmConfiguracion(VidGrab.VideoGrabber videoGrabber) : this()
        {
            _capture = videoGrabber;

            LoadConfiguration();
        }

        public frmConfiguracion()
        {
            InitializeComponent();
        }
        
        private void LoadConfiguration()
        {
            Config c = Config.Current;

            cbVideoDevice.Items.Clear();
            cbAudioDevice.Items.Clear();
        
            WinHelper.LoadComboBoxFromDelimitedText(cbVideoDevice, _capture.VideoDevices);
            WinHelper.LoadComboBoxFromDelimitedText(cbAudioCompressor, _capture.AudioCompressors);
            WinHelper.LoadComboBoxFromDelimitedText(cbAudioDevice, _capture.AudioDevices);
            WinHelper.LoadComboBoxFromDelimitedText(cbAudioOutput, _capture.AudioRenderers);
            WinHelper.LoadComboBoxFromDelimitedText(cbAudioCompressor, _capture.AudioCompressors);
            
            for (int i = 0; i <= 30; i++)
                cbFrames.Items.Add(i);

            if (cbFrames.Items.Count > 0)
                cbFrames.SelectedIndex = Properties.Settings.Default.FrameRatePredeterminado;


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

            //string[] files = System.IO.Directory.GetFiles(Properties.Settings.Default.WmvProfiles, "*.prx");

            //_capture.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_8;

            //if (Properties.Settings.Default.WmvProfileVersion == 8)
            //{
            //    WinHelper.LoadComboBoxFromDelimitedText(cbWmvProfile, _capture.ASFProfiles);
            //}
            //else
            //{
            //    foreach (string file in files)
            //    {
            //        System.IO.FileInfo fi = new System.IO.FileInfo(file);

            //        cbWmvProfile.Items.Add(fi.Name);
            //    }
            //}

            WinHelper.ComboBoxSelectByText(cbVideoDevice, c.VideoDevice);
            WinHelper.ComboBoxSelectByText(cbVideoSize, c.VideoSize);
            WinHelper.ComboBoxSelectByText(cbVideoSubtype, c.VideoFormatSubType);
            WinHelper.ComboBoxSelectByText(cbNorma, c.VideoNorma);
            WinHelper.ComboBoxSelectByText(cbFrames, c.FramesRate.ToString());
            


            WinHelper.ComboBoxSelectByText(cbAudioCompressor, c.AudioCompressor);
            WinHelper.ComboBoxSelectByText(cbAudioDevice, c.AudioDevice);
            WinHelper.ComboBoxSelectByText(cbAudioFormat, c.AudioFormat);
            WinHelper.ComboBoxSelectByText(cbAudioLine, c.AudioDeviceLine);
            WinHelper.ComboBoxSelectByText(cbAudioOutput, c.AudioOutputDevice);
            WinHelper.ComboBoxSelectByText(cbAudioCompressor, c.AudioCompressor);

            chkAudioDeviceRendering.Checked = c.AudioDeviceRendering;

            //WinHelper.ComboBoxSelectByText(cbWmvProfile, c.WmvProfile);
        }
        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Config c = Config.Current;


            if (cbVideoDevice.SelectedItem != null)
                c.VideoDevice = cbVideoDevice.SelectedItem.ToString();
            else
                c.VideoDevice = "";

            if (cbVideoSize.SelectedItem != null)
                c.VideoSize = cbVideoSize.SelectedItem.ToString();

            if (cbVideoSubtype.SelectedItem != null)
                c.VideoFormatSubType = cbVideoSubtype.SelectedItem.ToString();
            else
                c.VideoFormatSubType = "";

            if (cbNorma.SelectedItem != null)
                c.VideoNorma = cbNorma.SelectedItem.ToString();
            else
                c.VideoNorma = "";

            double frames = 0;
            if (cbFrames.SelectedItem != null)
                double.TryParse(cbFrames.SelectedItem.ToString(), out frames);

            c.FramesRate = frames;

            c.VideoBitRate = tbBitRates.Value;
            c.VideoQuality = tbVideoQuality.Value;

            if (cbAudioDevice.SelectedItem != null)
            {
                c.AudioDevice = cbAudioDevice.SelectedItem.ToString();

                if (cbAudioFormat.SelectedItem != null)
                    c.AudioFormat = cbAudioFormat.SelectedItem.ToString();
            }
            else
                c.AudioDevice = "";


            if (cbAudioLine.SelectedItem != null)
                c.AudioDeviceLine = cbAudioLine.SelectedItem.ToString();
            else
                c.AudioDeviceLine = "";

            if (cbAudioOutput.SelectedItem != null)
                c.AudioOutputDevice = cbAudioOutput.SelectedItem.ToString();
            else
                c.AudioOutputDevice = "";

            if (cbAudioCompressor.SelectedItem != null)
                c.AudioCompressor = cbAudioCompressor.SelectedItem.ToString();

            c.AudioDeviceRendering = chkAudioDeviceRendering.Checked;

            //if (cbWmvProfile.SelectedItem != null)
            //    c.WmvProfile = cbWmvProfile.SelectedItem.ToString();
            //else
            //    c.WmvProfile = "";

            c.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void cbVideoDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO ver opciones
            //VideoGrabber1.AnalogVideoStandards
            //VideoGrabber1.VideoInputs --> Switch entre distintos sources


            if (cbVideoDevice.SelectedIndex != -1)
            {
                _capture.VideoDevice = cbVideoDevice.SelectedIndex;

                WinHelper.LoadComboBoxFromDelimitedText(cbVideoSize, _capture.VideoSizes);
                WinHelper.LoadComboBoxFromDelimitedText(cbVideoSubtype, _capture.VideoSubtypes);

                WinHelper.LoadComboBoxFromDelimitedText(cbNorma, _capture.AnalogVideoStandards);
            }
        }

        private void cbAudioDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAudioDevice.SelectedIndex != -1)
            {
                _capture.AudioDevice = cbAudioDevice.SelectedIndex;

                WinHelper.LoadComboBoxFromDelimitedText(cbAudioFormat, _capture.AudioFormats);
                WinHelper.LoadComboBoxFromDelimitedText(cbAudioLine, _capture.AudioInputs);


                if (cbAudioFormat.Items.Count > 0)
                    cbAudioFormat.SelectedIndex = 0;

                if (cbAudioLine.Items.Count > 0)
                    cbAudioLine.SelectedIndex = 0;

            }
        }
        
        private void cmdAudioCompressorConfig_Click(object sender, EventArgs e)
        {
            _capture.AudioCompressor = _capture.AudioCompressorIndex(cbAudioCompressor.SelectedItem.ToString());
            _capture.ShowDialog(VidGrab.TDialog.dlg_AudioCompressor);
        }

        private void tbBitRates_Scroll(object sender, EventArgs e)
        {
            lblBitRates.Text = tbBitRates.Value.ToString();
        }

        private void tbVideoQuality_Scroll(object sender, EventArgs e)
        {
            lblVideoQuality.Text = tbVideoQuality.Value.ToString();
        }
    }
}
