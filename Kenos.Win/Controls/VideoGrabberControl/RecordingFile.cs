using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kenos.Win.Controls.VideoGrabberControl
{
    public class RecordingFile
    {
        #region Miembros privados
        private List<FileInfo> _files;
        private long _fileSize;
        private string _baseFileName;
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



        public RecordingFile(string baseFileName)
        {
            _baseFileName = baseFileName;
            _files = new List<FileInfo>();
            _fileSize = 0;

            this.CurrentFileName = baseFileName;
        }

        public string CreateNew()
        {
            FileInfo fi = new FileInfo(this.CurrentFileName);

            if (fi.Exists)
            {
                _files.Add(fi);

                _fileSize += fi.Length;

                fi = new FileInfo(this.BaseFileName);

                string name = string.Format("{0}\\{1}_{2}{3}", fi.Directory.FullName, Path.GetFileNameWithoutExtension(fi.Name), _files.Count + 1, fi.Extension);

                this.CurrentFileName = name;
            }

            return this.CurrentFileName;
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
