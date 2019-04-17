using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace Kenos.Win
{
    [Serializable]
    public class Config
    {

        [NonSerialized]
        private static Config _instance = Load();
        [NonSerialized]
        private static string _configFileName;


        public static string ConfigFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_configFileName))
                {
                    _configFileName = AppDomain.CurrentDomain.BaseDirectory + "Kenos.data";
                }

                return _configFileName;
            }
            set { _configFileName = value; }
        }

        private VideoSetting[] _videoSettings = null;
        private AudioSetting _audioSettings = null;
        private StreamingSetting _streamingSetting = null;
        private OutputSetting _outputSetting = null;


        //Video
        public int VideoSourceCount { get; set; }
        public VideoSetting[] VideoSettings
        {
            get
            {
                if (_videoSettings == null)
                    InitVideoSettings();

                return _videoSettings;
            }
            set
            {
                _videoSettings = value;

                InitVideoSettings();
            }
        }

        //Audio
        public AudioSetting AudioSetting
        {
            get
            {
                if (_audioSettings == null)
                    _audioSettings = new AudioSetting();

                return _audioSettings;
            }
            set
            {
                _audioSettings = value;

                if (value == null)
                    _audioSettings = new AudioSetting();
            }
        }

        //Streaming 
        public StreamingSetting StreamingSetting
        {
            get
            {
                if (_streamingSetting == null)
                    _streamingSetting = new StreamingSetting();

                return _streamingSetting;
            }
            set
            {
                _streamingSetting = value;

                if (value == null)
                    _streamingSetting = new StreamingSetting();
            }
        }

        //Output
        public OutputSetting OutputSetting
        {
            get
            {
                if (_outputSetting == null)
                    _outputSetting = new OutputSetting();

                return _outputSetting;
            }
            set
            {
                _outputSetting = value;

                if (value == null)
                    _outputSetting = new OutputSetting();
            }
        }

        private Config()
        {
        }

        public static Config Current { get { return _instance; } }

        public bool IsValid()
        {
            if (!this.AudioSetting.IsValid())
                return false;

            //if (string.IsNullOrEmpty(this.WmvProfile))
            //    return false;

            return true;
        }

        public bool IsValidToVideo()
        {
            return this.IsValid();
        }

        public bool IsValidToAudio()
        {
            return this.IsValid();
        }
        
        public void Save()
        {
            try
            {
                Logger.Log.Info("Grabando configuración");

                using (FileStream fs = new FileStream(ConfigFileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(fs, this);
                }
            }
            catch (Exception ex)
            {
                Kenos.Logger.Log.Error("No se pudo guardar la configuración");
                Kenos.Logger.Log.Error(ex);
            }

        }

        private static Config Load()
        {
            try
            {
                Logger.Log.Info("Iniciando carga de configuración");

                Config c = null;

                if (File.Exists(ConfigFileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(ConfigFileName, FileMode.Open))
                    {
                        c = (Config)formatter.Deserialize(fs);
                    }
                }
                else
                {
                    c = new Config();
                }

                return c;
            }
            catch (Exception ex)
            {
                Kenos.Logger.Log.Error("No se pudo cargar la configuración");
                Kenos.Logger.Log.Error(ex);

                return new Config();
            }
        }

        private void InitVideoSettings()
        {
            if (_videoSettings == null)
            {
                VideoSetting[] settings = new VideoSetting[6];

                for (int i = 0; i < settings.Length; i++)
                    settings[i] = new VideoSetting();

                _videoSettings = settings;
            }

            if (_videoSettings.Length < 6)
            {
                List<VideoSetting> list = new List<VideoSetting>(_videoSettings);

                for (int i = 0; i < _videoSettings.Length - 6; i++)
                {
                    list.Add(new VideoSetting());
                }

                _videoSettings = list.ToArray();
            }
        }

    }


}
