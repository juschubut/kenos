using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Kenos.PlayerLauncher
{
    class Program
    {
        private static string _applicationReferencePath = "KenosPlayer.appref-ms";

        static void Main(string[] args)
        {
            LogInformation("Iniciando Kenos.Player");

            var localApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string referencePath = string.Format("{0}\\KenosPlayer\\{1}", localApplicationData, _applicationReferencePath);

            try
            {
                CreateAppRef(Properties.Settings.Default.KenosPlayerUrl, referencePath);

                LogInformation(string.Format("Iniciando Kenos.Player args.length: {0}", args.Length));

                string fileName = "";
                string arguments = "";

                if (args.Length > 0)
                {
                    FileInfo info = new FileInfo(args[0]);

                    if (info.Exists)
                    {
                        LogInformation(string.Format("Archivo {0}", info.FullName));

                        fileName = info.FullName;

                        arguments = string.Format("\"{0}\"", fileName);
                    }
                    else 
                    {
                        LogInformation("El archivo no existe");
                    }
                }

                // Launch the .appref-ms file.
                Process.Start(referencePath, arguments);
            }
            catch (Exception ex)
            {
                string source = "Kenos Player Launcher";
                string log = "Application";

                if (!EventLog.SourceExists(source))
                    EventLog.CreateEventSource(source, log);

                EventLog.WriteEntry(source, ex.Message, EventLogEntryType.Error);
            }
        }
         

        private static void CreateAppRef(string url, string referencePath)
        { 

            // Only bother generating the .appref-ms file if we haven't done it before.
            if (!File.Exists(referencePath))
            {
                byte[] applicationManifest = null;
                string applicationReference = null;

                // Download the application manifest.
                using (WebClient wc = new WebClient())
                {
                    applicationManifest = wc.DownloadData(url);
                }

                // Build the .appref-ms contents.
                using (MemoryStream stream = new MemoryStream(applicationManifest))
                {
                    //XNamespace asmv1 = "urn:schemas-microsoft-com:asm.v1";
                    //XNamespace asmv2 = "urn:schemas-microsoft-com:asm.v2";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(stream);

                    XmlNamespaceManager asmv1 = new XmlNamespaceManager(doc.NameTable);


                    XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                    ns.AddNamespace("asmv1", "urn:schemas-microsoft-com:asm.v1");
                    ns.AddNamespace("asmv2", "urn:schemas-microsoft-com:asm.v2");

                    string xPath = "/asmv1:assembly/asmv1:assemblyIdentity/@name";
                    XmlNode name = doc.SelectSingleNode(xPath, ns);


                    xPath = "/asmv1:assembly/asmv2:deployment/asmv2:deploymentProvider/@codebase";
                    XmlNode codebase = doc.SelectSingleNode(xPath, ns);

                    xPath = "/asmv1:assembly/asmv1:assemblyIdentity/@language";
                    XmlNode language = doc.SelectSingleNode(xPath, ns);

                    xPath = "/asmv1:assembly/asmv1:assemblyIdentity/@publicKeyToken";
                    XmlNode publicKeyToken = doc.SelectSingleNode(xPath, ns);

                    xPath = "/asmv1:assembly/asmv1:assemblyIdentity/@processorArchitecture";
                    XmlNode architecture = doc.SelectSingleNode(xPath, ns);
                     
                    applicationReference = String.Format(
                      "{0}#{1}, Culture={2}, PublicKeyToken={3}, processorArchitecture={4}",
                      codebase.Value,
                      name.Value,
                      language.Value,
                      publicKeyToken.Value,
                      architecture.Value);
                }

                string path = Path.GetDirectoryName(referencePath);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Write the .appref-ms file (ensure that it's Unicode encoded).
                using (FileStream stream = File.OpenWrite(referencePath))
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
                    {
                        writer.Write(applicationReference);
                    }
                }
            }

        }


        private static void LogInformation(string message)
        {
            Log(message, EventLogEntryType.Information);
        }

        private static void LogError(string message)
        {
            Log(message, EventLogEntryType.Error);
        }

        private static void Log(string message, EventLogEntryType type)
        {/*
            string source = "KenosPlayer";
            string logName = "Application";

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, logName);
            }

            using (EventLog eventLog = new EventLog(logName))
            {
                eventLog.Log = "";
                eventLog.Source = source;
                
                eventLog.WriteEntry(message, type, 101, 1);
            }
          * */
        }
    }
}
