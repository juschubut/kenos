using System;

namespace Kenos.OpenBroadcasterSoftware
{
	public class ObsStateChangeEventArgs : EventArgs
	{
		public ObsStates State { get; set; }
	}
}
