using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Logger
{
    public interface ILog
    {
        void Log(LogLevel level, string text);

        void Error(Exception ex);

        void Error(string text);

        void Info(string text);

        void Debug(string text);

        int LogIndentation { get; set; }
    }
}
