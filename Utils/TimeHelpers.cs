using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Tools.Utils
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class TimeHelpers
	{
		public static float TimeSince(this float time) => Time.time - time;
		public static float TimeUntill(this float time) => time - Time.time;
		public static float TimeSinceUnscaled(this float unscaledTime) => Time.unscaledTime - unscaledTime;
		public static float TimeUntillUnscaled(this float unscaledTime) => unscaledTime - Time.unscaledTime;

		public static float DifferenceTo(this float a, float b) => Difference(a, b);
		public static float Difference(float a, float b) => Mathf.Abs(a - b);
	}
}