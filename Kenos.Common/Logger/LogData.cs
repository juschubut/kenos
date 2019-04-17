using System;

namespace Kenos.Logger
{
    public class LogData
    {
        public LogData()
        {
            this.LogToEmail = true;
            this.LogToFile = true;
        }

        public bool LogToEmail
        {
            get;
            set;
        }

        public bool LogToFile
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public bool IsEmpty
        {
            get { return string.IsNullOrEmpty(this.Text); }
        }
    }
}
