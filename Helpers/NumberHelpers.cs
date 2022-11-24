using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Tools.Helpers
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public static class NumberHelpers
	{
		public static int AsSignedInt(this float value) => value > 0f ? 1 : -1;
		public static int AsWeightedInt(this float value, float minValue) =>
			value.Abs() >= minValue ? value.AsSignedInt() : 0;
		public static float Abs(this float value) => Mathf.Abs(value);
	}
}