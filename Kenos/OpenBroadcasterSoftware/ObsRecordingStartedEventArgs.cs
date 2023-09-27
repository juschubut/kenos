using System;

namespace Kenos.OpenBroadcasterSoftware
{
	public class ObsRecordingStartedEventArgs : EventArgs
	{
		public string OutputFileName { get; set; }
	}
}
