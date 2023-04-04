using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kenos.Win.Test
{
    public class PruebaGrabacion
    {
        private List<CasoPrueba> _casosPrueba;
        private int _index = 0;
        private Timer _timer = new Timer();
        private bool _forzarCancelacion = false;

        public event PasoPruebaGrabacionEventHandler PasoPrueba;
        public event EventHandler Iniciando;
        public event EventHandler Finalizado;
        public event EventHandler Cancelado;

        public PruebaGrabacion()
        {
            _timer.Interval = Properties.Settings.Default.PruebaGrabacionIntervalo * 1000;
            _timer.Tick += _timer_Tick;

            _casosPrueba = new List<CasoPrueba>();

            Logger.Log.Info("Cargando Pruebas de Grabación");

            try
            {
                Logger.Log.IncreaseLogIndentation();

                Logger.Log.Info(string.Format("Intervalo: {0}seg.", _timer.Interval / 1000));

                foreach (string item in Properties.Settings.Default.CasosPrueba)
                {
                    string[] aux = item.Split(',');

                    if (aux.Length > 1)
                    {
                        CasoPrueba cp = new CasoPrueba();

                        cp.Nombre = aux[0];
                        cp.BeepPath = aux[1].Trim();

                        if (!File.Exists(cp.BeepPath))
                        {
                            string path = AppDomain.CurrentDomain.BaseDirectory + cp.BeepPath;

                            if (File.Exists(path))
                                cp.BeepPath = path;
                        }


                        Logger.Log.Info(string.Format("{0}: {1}", cp.Nombre, cp.BeepPath));

                        _casosPrueba.Add(cp);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error cargando prueba de grabación");
                Logger.Log.Error(ex);
            }
            finally
            { 
                Logger.Log.DecreaseLogIndentation();
            }
        }

        public void Comenzar()
        {
            _forzarCancelacion = false;
            _index = -1;

            if (this.Iniciando != null)
            {
                this.Iniciando(this, new EventArgs());
            }

            if (!_forzarCancelacion)
                _timer.Start();
        }

        private CasoPrueba Current
        {
            get { return _casosPrueba[_index]; }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (!Proximo())
            {
                _timer.Stop();
                Finalizar();
                return;
            }

            CasoPrueba cp = this.Current;

            if (this.PasoPrueba != null)
            {
                PasoPruebaGrabacionEventArgs ea = new PasoPruebaGrabacionEventArgs(cp);

                this.PasoPrueba(this, ea);
            }

            PlayBeep(cp.BeepPath);
        }

        public void Cancelar()
        {
            _forzarCancelacion = true;
            _timer.Stop();

            if (this.Cancelado != null)
            {
                this.Cancelado(this, new EventArgs());
            }
        }


        public void Finalizar()
        {
            if (this.Finalizado != null)
            {
                this.Finalizado(this, new EventArgs());
            }
        }

        public bool Proximo()
        {
            _index++;

            if (_index >= _casosPrueba.Count)
                return false;

            return true;
        }

        private void PlayBeep(string path)
        {
            try
            {
                SoundPlayer simpleSound = new SoundPlayer(path);

                simpleSound.Play();
            }
            catch
            {
                Logger.Log.Error("Beep not found");
            }
        }
    }
}
