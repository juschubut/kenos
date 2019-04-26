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
    public partial class AudioConfig : ConfigFormBase
    {
        public AudioConfig(VidGrab.VideoGrabber videoGrabber)
            : base(videoGrabber)
        {
            InitializeComponent();

            LoadConfig();
        }

        private void cbAudioDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAudioDevice.SelectedIndex != -1)
            {
                this.VideoGrabber.AudioDevice = cbAudioDevice.SelectedIndex;

                WinHelper.LoadComboBoxFromDelimitedText(cbAudioFormat, this.VideoGrabber.AudioFormats);
                WinHelper.LoadComboBoxFromDelimitedText(cbAudioLine, this.VideoGrabber.AudioInputs);

                if (cbAudioFormat.Items.Count > 0)
                    cbAudioFormat.SelectedIndex = 0;

                if (cbAudioLine.Items.Count > 0)
                    cbAudioLine.SelectedIndex = 0;
            }
        }

        private void LoadConfig()
        {
            AudioSetting c = Config.Current.AudioSetting;

            cbAudioDevice.Items.Clear();
        
            WinHelper.LoadComboBoxFromDelimitedText(cbAudioDevice, this.VideoGrabber.AudioDevices);
            WinHelper.LoadComboBoxFromDelimitedText(cbAudioOutput, this.VideoGrabber.AudioRenderers);
  
            WinHelper.ComboBoxSelectByText(cbAudioDevice, c.AudioDevice);
            WinHelper.ComboBoxSelectByText(cbAudioFormat, c.AudioFormat);
            WinHelper.ComboBoxSelectByText(cbAudioLine, c.AudioDeviceLine);
            WinHelper.ComboBoxSelectByText(cbAudioOutput, c.AudioOutputDevice);

            chkAudioDeviceRendering.Checked = c.AudioDeviceRendering;
        }

        public override void SaveConfig(Config config)
        {
            AudioSetting c = config.AudioSetting;

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

            c.AudioDeviceRendering = chkAudioDeviceRendering.Checked;
        }
    }
}
