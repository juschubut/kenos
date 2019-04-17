using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Win
{
    public class FileMonitor
    {
        public string FileName { get; set;}
        public long FileSize { get; set; }
        public DateTime Time { get; set; }

        public FileMonitor(string fileName)
        {
            this.FileName = fileName;
            this.Time = DateTime.Now;
        }

        public bool Verify(long fileSize)
        {
            TimeSpan ts = this.Time - DateTime.Now;

            if (ts.TotalSeconds > 10)
            {
                this.Time = DateTime.Now;

                if (fileSize <= this.FileSize)
                    return false;
                else
                    return true;
            }
            else
            {
                return true;
            }
        }
    }
}
