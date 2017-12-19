using Kenos.Common.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kenos.Logger
{
    public class SimpleLogger : ILog
    {
        private int _logIndentation = 0;
        private string _indentation = "";

        public int LogIndentation { 
            get { return _logIndentation; } 
            set { 
                _logIndentation = value;

                if (_logIndentation < 0)
                    _logIndentation = 0;

                CreateIndentation();
            } 
        }

        public SimpleLogger()
        {
            this.LogIndentation = 0;
        }

        public void Log(LogLevel level, string text)
        {
            LogData data = Create(level, text);

            Log(level, data);
        }

        public void Error(Exception ex)
        {
            LogData data = Create(ex);

            Log(LogLevel.Error, data);
        }

        public void Error(string text)
        {
            Log(LogLevel.Error, text);
        }

        public void Info(string text)
        {
            Log(LogLevel.Informacion, text);
        }

        public void Debug(string text)
        {
            Log(LogLevel.Debug, text);
        }

        private void Log(LogLevel level, LogData data)
        {
            if (data.LogToEmail)
            {
                LogToEmail(level, data.Text);
            }

            if (data.LogToFile)
            {
                LogToFile(level, data.Text);
            }

        }

        private void LogToEmail(LogLevel level, string text)
        {
            try
            {
                Logger.Log.SendMail(text);
            }
            catch (Exception ex)
            {
                LogToFile(LogLevel.Debug, "Error al enviar e-mail. " + ex.Message);
            }
        }

        private void LogToFile(LogLevel level, string text)
        {
            try
            {
                string path = Settings.Default.LogFileName;
                string referencia = string.Format("[{0}] {1:yyy-MM-dd HH:mm:ss} |", level, DateTime.Now);

                path += DateTime.Now.ToString("yyyyMM") + ".log";

                using (StreamWriter w = new StreamWriter(path, true))
                {
                    text = referencia + "|" + _indentation + text;

                    w.WriteLine(text);
                }
            }
            catch
            { }
        }

        public LogData Create(Exception ex)
        {
            LogData data = new LogData();
            Exception ex2 = ex;
            StringBuilder sb = new StringBuilder();

            sb.Append("Fecha: ");
            sb.Append(DateTime.Now.ToString());
            sb.Append(System.Environment.NewLine);

            try
            {
                System.Security.Principal.IPrincipal user = null;

                if (user != null)
                {
                    sb.Append(System.Environment.NewLine);
                    sb.Append("USER (S.O.): ");
                    if (user.Identity != null)
                        sb.Append(user.Identity.Name);

                    sb.Append(System.Environment.NewLine);
                }


                // ERROR 
                sb.Append(System.Environment.NewLine);
                sb.Append("ERROR: ");

                do
                {
                    sb.Append(ex2.Message);
                    sb.Append(" - ");

                } while ((ex2 = ex2.InnerException) != null);
                sb.Append(System.Environment.NewLine);


                // STACK TRACE
                sb.Append(Environment.NewLine);
                sb.Append("StackTrace: ");
                sb.Append(Environment.NewLine);
                sb.Append(ex.StackTrace);
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
            }
            catch
            {
                sb.Append(Environment.NewLine);
                sb.Append("******* ERROR EN CAPTURA DE INFORMACION ADICIONAL DE ERROR *******");
                sb.Append(Environment.NewLine);
            }

            data.Text = sb.ToString();
            data.LogToEmail = true;

            return data;
        }

        public LogData Create(LogLevel level, string text)
        {
            LogData data = new LogData();

            data.Text = text;
            data.LogToEmail = level == LogLevel.Error;

            return data;
        }

        private void CreateIndentation()
        {
            _indentation = "";

            for (int i = 0; i < _logIndentation; i++)
            {
                _indentation += "...";
            }
        }
    }
}
