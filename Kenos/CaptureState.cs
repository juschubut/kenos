using System;

namespace Kenos
{
	[Flags]
	public enum CaptureState
	{
		Initializing,
		NotSet,
		Initialized,
		Recording,
		Paused,
		Testing,
		PlayingTest,
		Completed
	}
}
