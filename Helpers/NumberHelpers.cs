using System.Diagnostics.CodeAnalysis;
using Tools.Types;
using UnityEngine;

namespace Tools.Helpers
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class NumberHelpers
	{
		public static int AsIntSign(this float value) => value >= 0f ? 1 : -1;
		public static int AsSignedIntOrZero(this float value, float deadZone = 0f) => value.Abs() > deadZone ? value.AsIntSign() : 0;
		public static float Abs(this float value) => Mathf.Abs(value);
		public static float SignedMax(this float original, float modifier) => modifier.AsIntSign() * Mathf.Max(original.Abs(), modifier.Abs());

		public static float RandomValueInRange(this Range<float> range) => Random.Range(range.Min, range.Max);
		public static float MappedToRange(this Range<float> range, float value01) => Mathf.LerpUnclamped(range.Min, range.Max, value01);
	}
}