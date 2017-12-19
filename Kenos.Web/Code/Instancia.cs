using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace Kenos.Web
{
    public class Instancia
    {
        private static string _basePath = "~/instancias/";
        private string _machineName = "";

        private List<Registro> _registros;

        private XmlDocument _doc = null;

        public Instancia(string machinename)
        {
            _machineName = machinename;
        }

        #region Propiedades
        public static string BasePath { get { return _basePath; } }

        public string MachineName { get { return _machineName; } }

        public List<Registro> Registros
        {
            get 
            {
                if (_registros == null)
                {
                    _registros = new List<Registro>();

                    LoadRegistros();
                }

                return _registros;

            }
        }

        public Registro RegistroActual
        {
            get 
            {
                Registro registro = this.Registros.LastOrDefault();

                if (registro != null)
                    return registro;
                else 
                    return new Registro();
            }
        }

        private XmlDocument XmlDoc
        {
            get 
            {
                if (_doc == null)
                {
                    LoadXml();
                }

                return _doc;
            }
        }
        #endregion

        private void LoadXml()
        {
            _doc = new XmlDocument();

            string fileName = this.XmlFileName;

            if (File.Exists(fileName))
            {
                try
                {
                    _doc.Load(fileName);
                }
                catch { }
            }
        }

        private void LoadRegistros()
        {
            XmlNodeList list = this.XmlDoc.SelectNodes("//instancia/registro");

            foreach (XmlNode node in list)
            {
                Registro registro = new Registro();

                registro.AssemblyName = node.Attributes["assembly-name"].InnerText;
                registro.Path = node.Attributes["path"].InnerText;
                registro.Ip = node.Attributes["ip"].InnerText;
                registro.Version = node.Attributes["version"].InnerText;
                
                string fecha = node.Attributes["fecha"].InnerText;
                DateTime f = new DateTime();

                DateTime.TryParse(fecha, out f);

                registro.Fecha = f;

                _registros.Add(registro);
            }

            _registros.Sort((r1, r2) => r1.Fecha.CompareTo(r2.Fecha));
        }

        private string XmlFileName
        {
            get { return HttpContext.Current.Server.MapPath(string.Format("{0}{1}.xml",_basePath, _machineName)); }
        }

        private void AddAttribute(XmlNode node, string attrName, string attrValue)
        {
            XmlAttribute att = this.XmlDoc.CreateAttribute(attrName);

            att.Value = attrValue;

            node.Attributes.Append(att);
        }

        private void SaveXml()
        { 
            _doc.Save(XmlFileName);
        }

        public static List<string> GetInstancias()
        {
            List<string> instancias = new List<string>();

            DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(_basePath));

            if (dir.Exists)
            {
                FileInfo[] files = dir.GetFiles("*.xml");

                foreach (FileInfo file in files)
                {
                    string machineName = System.IO.Path.GetFileNameWithoutExtension(file.FullName);

                    instancias.Add(machineName);
                }
            }

            return instancias;
        }

        public static void Registrar(string machineName, string assemblyName, string version, string path, string ip)
        {
            Instancia instancia = new Instancia(machineName);

            instancia.Registrar(assemblyName, version, path, ip);
        }

        private void Registrar(string assemblyName, string version, string path, string ip)
        {
            XmlNode instancia = this.XmlDoc.SelectSingleNode(string.Format("//instancia[@machine-name='{0}']", _machineName));

            if (instancia == null)
            {
                instancia = this.XmlDoc.CreateNode(XmlNodeType.Element, "instancia", "");

                this.XmlDoc.AppendChild(instancia);

                AddAttribute(instancia, "machine-name", _machineName);
            }


            XmlNode xmlRegistro = this.XmlDoc.CreateNode(XmlNodeType.Element, "registro", "");

            instancia.AppendChild(xmlRegistro);

            AddAttribute(xmlRegistro, "path", path);

            AddAttribute(xmlRegistro, "ip", ip);
            AddAttribute(xmlRegistro, "assembly-name", assemblyName);
            AddAttribute(xmlRegistro, "version", version);
            AddAttribute(xmlRegistro, "fecha", DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));

            SaveXml();
        }
    }
}