using System;

namespace Kenos.Win.OpenBroadcasterSoftware
{
	public class ObsLogEventArgs : EventArgs
	{
		public string Message { get; set; }
		public bool IsError { get; set; }
		public Exception Exception { get; set; }
	}
}
