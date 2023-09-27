using System;

namespace Kenos.OpenBroadcasterSoftware
{
	public class ObsRecordingStatusEventArgs : EventArgs
	{
		public bool IsRecording { set; get; }

		public bool IsRecordingPaused { set; get; }

		public long RecordingDuration { set; get; }

		public long RecordingBytes { set; get; }
	}
}
