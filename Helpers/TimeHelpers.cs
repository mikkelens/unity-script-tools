using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Tools.Helpers
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public static class TimeHelpers
	{
		public static float TimeSince(this float time) => Time.time - time;
		public static float TimeUntill(this float time) => time - Time.time;
		public static float DifferenceTo(this float a, float b) => Difference(a, b);
		public static float Difference(float a, float b) => Mathf.Abs(a - b);
	}
}