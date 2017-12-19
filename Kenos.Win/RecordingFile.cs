﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VidGrab;

namespace Kenos.Win
{
    public class RecordingFile
    {
        #region Miembros privados
        private List<FileInfo> _files;
        private long _fileSize;
        private string _baseFileName;
        private VidGrab.VideoGrabber _videoGrabber;
        private bool _videoReencoding = false;
        #endregion 

        #region Propiedades
        public List<FileInfo> Files { get { return _files; } }

        public string CurrentFileName { get; set; }

        public string BaseFileName { get { return _baseFileName; } }

        public long TotalFileSize
        {
            get { return _fileSize + new FileInfo(this.CurrentFileName).Length; }
        }
        #endregion 
         


        public RecordingFile(string baseFileName, VidGrab.VideoGrabber videoGrabber)
        {
            _baseFileName = baseFileName;
            _files = new List<FileInfo>();
            _fileSize = 0;
            _videoGrabber = videoGrabber;

            this.CurrentFileName = baseFileName;
        }

        public string CreateNew()
        {
            FileInfo fi = new FileInfo(this.CurrentFileName);

            _files.Add(new FileInfo(this.CurrentFileName));

            _fileSize += fi.Length;

            fi = new FileInfo(this.BaseFileName);

            string name = string.Format("{0}\\{1}_{2}{3}", fi.Directory.FullName, Path.GetFileNameWithoutExtension(fi.Name), _files.Count + 1, fi.Extension);

            this.CurrentFileName = name;
            
            return this.CurrentFileName;
        }

        public string Merge()
        {
            Log("Combinando archivos");

            string outputFileName = "";

            if (_files.Count > 0)
            {
                if (_files.Last().FullName != this.CurrentFileName)
                {
                    _files.Add(new FileInfo(this.CurrentFileName));
                }
            }
            else 
            {
                Log("...... Combinacion cancelada por existir un solo archivo");

                return this.CurrentFileName;
            }

            try
            {
                foreach (FileInfo file in _files)
                    Log(string.Format("...... {0}", file.Name));

                FileInfo fi = new FileInfo(this.BaseFileName);

                outputFileName = string.Format("{0}\\{1}_total{2}", fi.Directory.FullName, Path.GetFileNameWithoutExtension(fi.Name), fi.Extension);

                Log("Archivo resultante {0}", outputFileName);

                if (fi.Extension.ToLower() == ".mp3")
                    UnirMP3(outputFileName);
                else if (fi.Extension.ToLower() == ".wmv")
                    UnirWMV(outputFileName);
                else
                    throw new ApplicationException("No se reconoce el tipo de archivo para unir");
                
            }
            catch (Exception ex)
            {
                Log(ex.Message);

                throw new ApplicationException("Se produjo un error grave cuando se estaba intentando combinar los archivos. Llame al administrador del sistema", ex);
            }

            return outputFileName;
        }


        private void UnirMP3(string outputFileName)
        {
            Log("... Union MP3");

            try
            {
                using (FileStream output = File.Create(outputFileName))
                {
                    Log("... Archivo creado");

                    foreach (FileInfo file in _files)
                    {
                        Log("... Leyendo archivo {0}", file);

                        if (file.Exists)
                        {
                            if (file.Length > 0)
                            {
                                Mp3FileReader reader = new Mp3FileReader(file.FullName);
                                if ((output.Position == 0) && (reader.Id3v2Tag != null))
                                {
                                    Log("... Escribiendo header");

                                    output.Write(reader.Id3v2Tag.RawData, 0, reader.Id3v2Tag.RawData.Length);
                                }

                                Log("... Escribiendo fames");

                                NAudio.Wave.Mp3Frame frame;
                                while ((frame = reader.ReadNextFrame()) != null)
                                {
                                    output.Write(frame.RawData, 0, frame.RawData.Length);
                                }

                                Log("... fin archivo {0}", file);

                                reader.Close();
                            }
                            else
                            {
                                Log("... El archivo {0} no tiene datos.", file);
                            }
                        }
                        else
                        {
                            Log("... El archivo no existe. {0}", file);
                        }
                    }
                }

                Log("Union MP3 satisfactoria");
            }
            catch (Exception ex)
            {
                Log("Error grave mientras se unian los archivos mp3. Archivo base: {0}. Error:{1}", outputFileName, ex.Message);

                throw new ApplicationException("Se produjo un error grave cuando se estaba intentando combinar los archivos MP3. Llame al administrador del sistema");
            }
        }

        private void UnirWMV(string outputFileName)
        {
            _videoGrabber.Playlist(TPlaylist.pl_Clear, "");

            foreach (FileInfo fi in _files)
            {
                _videoGrabber.Playlist(TPlaylist.pl_Add, fi.FullName);
            }

            _videoGrabber.Reencoding_SourceVideoClip = "PLAYLIST";
            _videoGrabber.Reencoding_NewVideoClip = outputFileName;
            _videoGrabber.Reencoding_Method = TRecordingMethod.rm_ASF;
            _videoGrabber.Reencoding_WMVOutput = true;
            _videoGrabber.Reencoding_UseFrameGrabber = false;

            _videoReencoding = false;

            TVuMeter vuMeter = _videoGrabber.VuMeter;

            _videoGrabber.VuMeter = VidGrab.TVuMeter.vu_Disabled;

      
            _videoGrabber.StartReencoding();

            do
            {
                Application.DoEvents();

                Thread.Sleep(100);

            } while (!_videoReencoding);


            _videoGrabber.VuMeter = vuMeter;
        }

        public void OnReencodingCompleted(object sender, TOnSourceFileToDestFileCompletedEventArgs arg)
        {
            _videoReencoding = true;
        }

        private void Log(string template, params object[] param)
        {
            Log(string.Format(template, param));
        }

        private void Log(string log)
        {
            Logger.Log.Info(log);
        }
    }
}
