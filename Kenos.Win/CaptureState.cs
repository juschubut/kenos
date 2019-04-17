using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kenos.Win
{
    [Flags]
    public enum CaptureState
    {
        NoSet = 0, 
        Initialized = 1,
        Started = 2,
        Paused = 4,
        Completed = 8
 
    }
}
