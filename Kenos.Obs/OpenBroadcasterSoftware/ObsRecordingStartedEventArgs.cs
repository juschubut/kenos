using System;

namespace Kenos.Win.OpenBroadcasterSoftware
{
	public class ObsRecordingStartedEventArgs : EventArgs
	{
		public string OutputFileName { get; set; }
	}
}
