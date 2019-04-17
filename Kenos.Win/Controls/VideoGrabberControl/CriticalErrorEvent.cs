using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Win.Controls.VideoGrabberControl
{

    public delegate void CriticalErrorEventHandler(object sender, CriticalErrorEventArgs evt);

    public class CriticalErrorEventArgs : EventArgs
    {
        public string ControlName { get; set; }
        public VidGrab.TOnLogEventArgs Log { get; set; }

        public CriticalErrorEventArgs(string controlName, VidGrab.TOnLogEventArgs log)
        {
            this.Log = log;
            this.ControlName = controlName;


            if (log.logType == VidGrab.TLogType.e_failed_to_start_preview || log.logType == VidGrab.TLogType.e_failed_to_start_recording)
                log.infoMsg = "No se pudo iniciar la grabación. Por favor verifique la configuración";
        }
    }

}
