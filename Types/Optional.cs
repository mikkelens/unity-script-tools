using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Types
{
	/// <summary>
	/// "Optional" type. Has a generic value, and an "enabled" state, which is false by default.
	/// It has a custom drawer in the inspector, and works fine as a serialized field.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	public struct Optional<T> : IEquatable<Optional<T>>
	{
		[SerializeField] private T value;
		[SerializeField] private bool enabled;

		public T Value => value;
		public bool Enabled => enabled;

	#region Conversion and construction
		// GET VALUE FROM STRUCT
		public static implicit operator T(Optional<T> optionalSource) => optionalSource.Value; // value from optional
		// ASSIGN STRUCT FROM VALUE
		public static implicit operator Optional<T>(bool enableSource) => new Optional<T>(default, enableSource); // optional from state
		public static implicit operator Optional<T>(T valueSource) => new Optional<T>(valueSource); // optional from value
		public Optional(T setValue, bool setEnable = false) // always disabled by default
		{
			enabled = setEnable;
			value = setValue;
		}
	#endregion

	#region Equal comparison
		public override bool Equals(object obj)
		{
			return obj is Optional<T> other && Equals(other);
		}
		public bool Equals(Optional<T> other)
		{
			return EqualityComparer<T>.Default.Equals(value, other.value) && enabled == other.enabled;
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(value, enabled);
		}
		public static bool operator ==(Optional<T> o1, Optional<T> o2)
		{
			return o1.Equals(o2);
		}
		public static bool operator !=(Optional<T> o1, Optional<T> o2)
		{
			return !o1.Equals(o2);
		}
	#endregion
	}
}