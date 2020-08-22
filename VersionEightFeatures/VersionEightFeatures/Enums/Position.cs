using System;

namespace VersionEightFeatures.Enums
{
	[Flags]
	public enum Position
	{
		#region Offense

		Quarterback = 1 << 0,
		Halfback = 1 << 1,
		Fullback = 1 << 2,
		WideReceiver = 1 << 3,
		TightEnd = 1 << 4,
		Center = 1 << 5,
		Guard = 1 << 6,
		Tackle = 1 << 7,

		#endregion

		#region Defense

		End = 1 << 8,
		Nose = 1 << 9,
		Linebacker = 1 << 10,
		Cornerback = 1 << 11,
		Safety = 1 << 12

		#endregion
	}
}