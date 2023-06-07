using System;
using UnityEngine;

namespace Tools.Types
{
	/// <summary>
	/// Range between two number
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	public struct Range<T> : IEquatable<Range<T>> where T : IEquatable<T>, new()
	{
		[SerializeField] private T min;
		[SerializeField] private T max;

		public T Min => min;
		public T Max => max;

		// GET STRUCT FROM VALUE (single max, or both by tuple)
		public static implicit operator Range<T>(T maxSource) => new Range<T>(default, maxSource);
		public static implicit operator Range<T>((T min, T max) source) => new Range<T>(source.min, source.max);

		public Range(T setMin, T setMax)
		{
			min = setMin;
			max = setMax;
		}

		public bool Equals(Range<T> other)
		{
			return min.Equals(other.min) && max.Equals(other.max);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(min, max);
		}
	}
}