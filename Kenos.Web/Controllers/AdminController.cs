
using Kenos.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Kenos.Web.Controllers
{
    [AllowCrossSiteJson]
    public class AdminController : Controller
    {
        private SimpleImpersonation.LogonType _logonType = SimpleImpersonation.LogonType.Interactive;

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View( );
        }

        public PartialViewResult ListInstancias()
        {
            Models.InstanciaListModel list = GetListInstancias();

            IEnumerable<IGrouping<string, Models.InstanciaModel>> model = list.GroupBy(x => x.Version).OrderBy(x => x.Key);

            return PartialView(model);
        }

        public JsonResult InstanciasListar()
        {
            JsonResponse json = new JsonResponse();

            try
            {
                Models.InstanciaListModel model = GetListInstancias();

                json.Data = model;

                json.IsSuccess = true;
            }
            catch (Exception ex)
            {
                json.Message = ex.Message;
                json.IsFail = true;
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private Models.InstanciaListModel GetListInstancias()
        {
            List<string> instancias = Instancia.GetInstancias();

            Models.InstanciaListModel list = new Models.InstanciaListModel();

            foreach (string nombreInstancia in instancias)
            {
                Instancia instancia = new Instancia(nombreInstancia);

                Registro actual = instancia.RegistroActual;

                list.Add(new Models.InstanciaModel()
                {
                    MachineName = nombreInstancia,
                    Ip = actual.Ip,
                    Fecha = actual.Fecha,
                    Version = actual.Version
                });
            }

            return list;
        }

        public JsonResult Ver(string nombreInstancia)
        {
            JsonResponse json = new JsonResponse();

            try
            {
                Instancia instancia = new Instancia(nombreInstancia);

                Registro actual = instancia.RegistroActual;

                json.Data = new {
                        machineName = instancia.MachineName, 
                        version = actual.Version, 
                        path = actual.Path, 
                        ip = actual.Ip, 
                        assemblyName = actual.AssemblyName, 
                        fecha = actual.Fecha.ToString("dd/MM/yyyy HH:mm")
                    };

                json.IsSuccess = true;
            }
            catch(Exception ex)
            {
                json.Message = ex.Message;
                json.IsFail = true;
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }


        public PartialViewResult TabUpdate(TabUpdateRequestModel request)
        {
            TabUpdateResponseModel response = new TabUpdateResponseModel();

            response.ReleasePath = Properties.Settings.Default.ReleasesPath;

            using (SimpleImpersonation.Impersonation.LogonUser(request.Dominio, request.Usuario, request.Password, _logonType))
            {
                //Releases
                List<string> list = new List<string>();

                System.IO.DirectoryInfo dirInfo = new DirectoryInfo(response.ReleasePath);

                foreach (System.IO.DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    list.Add(dir.Name);
                }

                string selected = "";

                if (list.Count > 0)
                    selected = list[list.Count - 1];

                response.Releases = new SelectList(list, selected);

                // Versiones
                list = new List<string>();

                if (selected != "")
                {
                    dirInfo = new DirectoryInfo(string.Format("{0}\\{1}", response.ReleasePath, selected));

                    foreach (System.IO.DirectoryInfo dir in dirInfo.GetDirectories())
                    {
                        list.Add(dir.Name);
                    }
                }

                response.Versiones = new SelectList(list);
            }           

            return PartialView(response);
        }

        public JsonResult UpdateInfo(TabUpdateRequestModel request)
        {
            JsonResponse json = new JsonResponse();

            try
            {
                TabUpdateResponseModel response = new TabUpdateResponseModel();

                response.ReleasePath = Properties.Settings.Default.ReleasesPath;

                using (SimpleImpersonation.Impersonation.LogonUser(request.Dominio, request.Usuario, request.Password, _logonType))
                {
                    //Releases
                    List<string> list = new List<string>();

                    System.IO.DirectoryInfo dirInfo = new DirectoryInfo(response.ReleasePath);

                    foreach (System.IO.DirectoryInfo dir in dirInfo.GetDirectories())
                    {
                        list.Add(dir.Name);
                    }

                    string selected = "";

                    if (list.Count > 0)
                        selected = list[list.Count - 1];

                    response.Releases = new SelectList(list, selected);

                    // Versiones
                    list = new List<string>();

                    if (selected != "")
                    {
                        dirInfo = new DirectoryInfo(string.Format("{0}\\{1}", response.ReleasePath, selected));

                        foreach (System.IO.DirectoryInfo dir in dirInfo.GetDirectories())
                        {
                            list.Add(dir.Name);
                        }
                    }

                    response.Versiones = new SelectList(list);
                }

                json.IsSuccess = true;
                json.Data = response;
            }
            catch (Exception ex)
            {
                json.IsFail = true;
                json.Message = ex.Message;
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarArchivosDestino(TabUpdateRequestModel request)
        {
            JsonResponse response = new JsonResponse();

            response.IsSuccess = true;

            try
            {
                Instancia actual = new Instancia(request.NombreInstancia);

                string path = string.Format("\\\\{0}\\{1}", request.NombreInstancia, actual.RegistroActual.Path);

                path = path.Replace(":", "$");

                List<string> list = GetArchivos(request, path);

                response.Data = list;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarArchivos(ListarArchivosRequest request)
        {
            JsonResponse response = new JsonResponse();

            response.IsSuccess = true;

            try
            {
                string path = string.Format("{0}\\{1}\\{2}", Properties.Settings.Default.ReleasesPath, request.Release, request.Version);

                List<string> list = GetArchivos(request, path);

                response.Data = list;
            }
            catch (Exception ex)
            {
                response.IsFail = true;
                response.Message = ex.Message;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        private List<string> GetArchivos(AutenticacionModel autenticacion, string path)
        {
            List<string> list = new List<string>();

            using (SimpleImpersonation.Impersonation.LogonUser(autenticacion.Dominio, autenticacion.Usuario, autenticacion.Password, SimpleImpersonation.LogonType.NetworkCleartext))
            {

                System.IO.DirectoryInfo dirInfo = new DirectoryInfo(path);

                foreach (System.IO.FileInfo file in dirInfo.GetFiles())
                {
                    list.Add(file.Name);
                }
            }

            return list;
        }

        public JsonResult Actualizar(ActualizarRequest request)
        {
            JsonResponse response = new JsonResponse();

            response.IsSuccess = true;

            try
            {
                //Archivos Actuales
                Instancia instancia = new Instancia(request.NombreInstancia);
                Registro actual = instancia.RegistroActual;

                string destino = string.Format("\\\\{0}\\{1}", request.NombreInstancia, actual.Path);

                destino = destino.Replace(":", "$");

                string origen = string.Format("{0}\\{1}\\{2}\\", Properties.Settings.Default.ReleasesPath, request.Release, request.Version);

                object isRunningResult = IsKenosRunning(request, request.NombreInstancia);

                if (isRunningResult is bool)
                {
                    bool isRunning = (bool)isRunningResult;

                    if (isRunning)
                    {
                        response.Message = "No puede actualizar el sistema porque se encuentra en uso.";
                        response.IsFail = true;

                        return Json(response);
                    }
                }

                using (SimpleImpersonation.Impersonation.LogonUser(request.Dominio, request.Usuario, request.Password, _logonType))
                {
                    foreach (string fileName in request.Archivos)
                    {
                        System.IO.File.Copy(
                            string.Format("{0}{1}", origen, fileName),
                            string.Format("{0}{1}", destino, fileName), 
                            true);
                    }
                }

                if (request.Archivos.Exists(x => x.Equals("kenos.win.exe", StringComparison.InvariantCultureIgnoreCase)))
                {
                    Instancia.Registrar(
                        request.NombreInstancia,
                        actual.AssemblyName,
                        request.Release.Replace("v.", ""),
                        actual.Path,
                        actual.Ip);
                }

                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.IsFail = true;
                response.Message = ex.Message;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Ping(string nombreInstancia)
        {
            JsonResponse json = new JsonResponse();

            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

                System.Net.NetworkInformation.PingReply result = ping.Send(nombreInstancia);

                if (result.Status.ToString().ToLower() == "success")
                    json.Data = "Prendido";
                else
                    json.Data = "Apagado";

                json.IsSuccess = true;
            }
            catch (Exception ex)
            {
                json.Message = ex.Message;
                json.IsFail = true;
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsRunning(PingRequest request)
        {
            JsonResponse json = new JsonResponse();

            try
            {
                object result = IsKenosRunning(request, request.NombreInstancia);

                if (result is bool)
                {
                    if ((bool)result)
                        json.Data = "Corriendo";
                    else
                        json.Data = "No";
                }
                else
                    json.Data = result;

                json.IsSuccess = true;
            }
            catch (Exception ex)
            {
                json.Message = ex.Message;
                json.IsFail = true;
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private object IsKenosRunning(AutenticacionModel autenticacion, string nombreInstancia)
        {
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                options.Authentication = AuthenticationLevel.Packet;
                options.Username = string.Format("{0}\\{1}", autenticacion.Dominio, autenticacion.Usuario);
                options.Password = autenticacion.Password;

                ManagementPath mp = new ManagementPath();
                mp.NamespacePath = @"\root\cimv2";
                mp.Server = nombreInstancia;               

                ManagementScope scope = new ManagementScope(mp, options);
                scope.Connect();

                string query = "SELECT * FROM Win32_Process WHERE Name='Kenos.Win.exe'";
                var searcher = new ManagementObjectSearcher(query);
 
                searcher.Scope = scope;


                return searcher.Get().Count > 0;                

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public JsonResult LeerConfig(LeerConfigRequest request)
        {
            JsonResponse json = new JsonResponse();
            json.IsSuccess = true;
            try
            {
                Instancia instancia = new Instancia(request.NombreInstancia);

                Registro actual = instancia.RegistroActual;

                string path = string.Format("\\\\{0}\\{1}\\Kenos.Win.exe.config", request.NombreInstancia, actual.Path);

                path = path.Replace(":", "$");

                using (SimpleImpersonation.Impersonation.LogonUser(request.Dominio, request.Usuario, request.Password, _logonType))
                {
                    json.Data = System.IO.File.ReadAllText(path);
                }
            }
            catch (Exception ex)
            {
                json.IsSuccess = false;
                json.Message = ex.Message;
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public FileResult VerXml(string nombreInstancia)
        {
            return File(string.Format("{0}{1}.xml", Instancia.BasePath, nombreInstancia), "text/xml");
        }
	}
}