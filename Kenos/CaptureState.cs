using System;

namespace Kenos
{
	[Flags]
	public enum CaptureState
	{
		NoSet = 0,
		Initialized = 1,
		Recording = 2,
		Paused = 4,
		Testing = 5,
		PlayingTest = 6,
		Completed = 8
	}
}
