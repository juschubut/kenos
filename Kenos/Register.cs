using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Kenos
{
    public class Register
    {
        public static void RegistrarInstalacion()
        {
            try
            {
                Logger.Log.Info("Iniciando registración de instalacion");

                // Metodo para largar el proceso de registración y no esperar una respuesta
                ThreadPool.QueueUserWorkItem(new WaitCallback(RegistrarAsync));

            }
            catch (Exception ex)
            {
                Logger.Log.Error(new ApplicationException("Error al iniciar registracion de instalacion", ex));
            }
        }

        private static void RegistrarAsync(object state)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                       { "Path", AppDomain.CurrentDomain.BaseDirectory },
                       { "Version", WinHelper.Version },
                       { "MachineName", System.Environment.MachineName},
                       { "AssemblyName", Assembly.GetExecutingAssembly().ManifestModule.Name}

                    };

                    FormUrlEncodedContent content = new FormUrlEncodedContent(values);

                    Task<HttpResponseMessage> task = client.PostAsync(Properties.Settings.Default.RegistracionUrl, content);

                    var ok = task.Result.Content.ReadAsStringAsync();


                    if (task.Result.StatusCode == System.Net.HttpStatusCode.OK)
                        Logger.Log.Info("........... Registración de instalacion satisfactoria");
                    else
                        Logger.Log.Error(new ApplicationException(
                            string.Format("Error al intentar registrar la instalacion de kenos. Url: {0}. StatusCode: {1}",
                            Properties.Settings.Default.RegistracionUrl,
                            task.Result.StatusCode)));

                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(new ApplicationException(
                    string.Format("Error inesperado al intentar registrar la instalacion de kenos. Url: {0}", Properties.Settings.Default.RegistracionUrl),
                    ex));
            }
        }
    }
}
