using System;
using System.Collections.Generic;
using System.Text;

namespace Kenos.TagsLib
{
    public class KenosFile
    {
        private string _fileFormatVersion = "";

        public string Description { get; set; }
        public string Label { get; set; }
        public string KenosVersion { get; set; }
        public string FileFormatVersion { get { return _fileFormatVersion; } }
        public List<Tag> Tags { get; set; }

        private TagLib.File _file = null;

        private KenosFile(string fullFileName)
        {
            _file = TagLib.File.Create(fullFileName);

            this.Description = "";
            this.Label = "";
            this.Tags = new List<Tag>();
            this.KenosVersion = "";
            _fileFormatVersion = "";

            this.Tags.Add(Tag.Parse("[00:00:00] Inicio"));

            if (!string.IsNullOrEmpty(_file.Tag.Title))
                this.Description = _file.Tag.Title;

            if (!string.IsNullOrEmpty(_file.Tag.TitleSort))
                this.Label = _file.Tag.TitleSort;

            if (!string.IsNullOrEmpty(_file.Tag.Lyrics))
            {

                string[] aux = _file.Tag.Lyrics.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in aux)
                {
                    if (string.IsNullOrEmpty(item))
                        continue;

                    if (item.Trim().StartsWith("{meta-"))
                    {
                        string val = GetMetaValue(item, "meta-kenos-version");

                        if (!string.IsNullOrEmpty(val))
                        {
                            this.KenosVersion = val;
                            continue;
                        }

                        val = GetMetaValue(item, "meta-file-format");

                        if (!string.IsNullOrEmpty(val))
                        {
                            _fileFormatVersion = val;
                            continue;
                        }
                    }

                    Tag timeStamp = Tag.Parse(item);

                    if (timeStamp != null)
                    {
                        if (timeStamp.TimeSpan.TotalSeconds == 0 && this.Tags.Count == 1)
                            this.Tags.Clear();

                        this.Tags.Add(timeStamp);
                    }
                }
            }
        }

        private string GetMetaValue(string item, string meta)
        {
            meta = "{" + meta + ":";

            if (item.StartsWith(meta))
            {
                return item.Substring(meta.Length, item.Length - meta.Length - 1);
            }
            else
            {
                return "";
            }

        }

        public static KenosFile Load(string fullFileName)
        {
            KenosFile file = new KenosFile(fullFileName);

            return file;
        }

        public void Save()
        {
            if (_file != null)
            {
                _file.Tag.Title = this.Description;
                _file.Tag.TitleSort = this.Label;


                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("{{meta-kenos-version:{0}}}", this.KenosVersion);
                sb.AppendLine("");

                sb.AppendFormat("{{meta-file-format:{0}}}", AssemblyFileVersion());
                sb.AppendLine("");

                foreach (var r in this.Tags)
                {
                    sb.AppendFormat("[{0:hh\\:mm\\:ss}] {1}", r.Time, r.Description);
                    sb.AppendLine("");
                }

                _file.Tag.Lyrics = sb.ToString();
                _file.Save();
            }

        }

        private string AssemblyFileVersion()
        {
         
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(this.GetType().Assembly.Location);

            return fvi.FileVersion;
        }
    }
}
