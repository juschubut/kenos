using System;

namespace Kenos
{
	[Flags]
	public enum CaptureState
	{
		Disabled,
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
