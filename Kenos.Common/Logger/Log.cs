using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Kenos.Common.Properties;

namespace Kenos.Logger
{
    public class Log
    {

        private static ILog _log = Initialize();

        private static ILog Initialize()
        {
            return new SimpleLogger();
        }

        public static ILog Logger { get { return _log; } }


        public static void Error(Exception ex)
        {
            _log.Error(ex);
        }

        public static void Error(string message)
        {
            _log.Log(LogLevel.Error, message);
        }

        public static void Info(string message)
        {
            _log.Log(LogLevel.Informacion, message);
        }

        public static void Debug(string message)
        {
            if (Settings.Default.Debug)
                _log.Log(LogLevel.Debug, message);
        }

        internal static void SendMail(string text)
        {
            SendMail(text, Settings.Default.EmailSubject);
        }

        public static void IncreaseLogIndentation()
        {
            _log.LogIndentation++;
        }

        public static void DecreaseLogIndentation()
        {
            _log.LogIndentation--;
        }

        internal static void SendMail(string text, string subject)
        {
            try
            {
                MailMessage msg = new MailMessage();

                if (string.IsNullOrEmpty(Settings.Default.EmailFrom))
                    return;

                msg.From = new MailAddress(Settings.Default.EmailFrom);
                msg.Subject = Settings.Default.EmailSubject;
                msg.Body = string.Format("MachineName: {0}\n\n\n{1}", System.Environment.MachineName, text);
                msg.To.Add(new MailAddress(Settings.Default.EmailTo));
                msg.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient(Settings.Default.EmailSmtpServer);

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(msg);
            }
            catch { }
        }

    }
}
