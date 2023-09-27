using System;

namespace Kenos.OpenBroadcasterSoftware
{
	public class ObsLogEventArgs : EventArgs
	{
		public string Message { get; set; }
		public bool IsError { get; set; }
		public Exception Exception { get; set; }
	}
}
