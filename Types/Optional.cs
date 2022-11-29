using System;
using UnityEngine;

namespace Tools.Types
{
	/// <summary>
	/// "Optional" type. Has a generic value, and an "enabled" state, which is false by default.
	/// It has a custom drawer in the inspector, and works fine as serialized field.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
    public struct Optional<T>
    {
	    [SerializeField] private T value;
	    [SerializeField] private bool enabled;

	    public T Value => value;
	    public bool Enabled => enabled;

	    // GET VALUE FROM STRUCT
	    public static implicit operator T(Optional<T> optionalSource) => optionalSource.Value; // value from optional
	    // public static implicit operator bool(Optional<T> optionalSource) => optionalSource.Enabled; // state from optional

	    // ASSIGN STRUCT FROM VALUE
	    public static implicit operator Optional<T>(bool enableSource) => new Optional<T>(default, enableSource); // optional from state
	    public static implicit operator Optional<T>(T valueSource) => new Optional<T>(valueSource); // optional from value

	    public Optional(T setValue, bool setEnable = false) // always disabled by default
	    {
		    enabled = setEnable;
		    value = setValue;
	    }
    }
}