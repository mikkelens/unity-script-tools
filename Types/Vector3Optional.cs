using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Tools.Types
{
	/// <summary>
	/// 3-component wrapper for the Optional float type, used similar to a standard Vector3.
	/// </summary>
	[Serializable]
	public struct Vector3Optional
	{
		[SerializeField] public Optional<float> x;
		[SerializeField] public Optional<float> y;
		[SerializeField] public Optional<float> z;

		public Vector3 V3FromEnabledComponents => new Vector3(x.Enabled ? x.Value : 0f, y.Enabled ? y.Value : 0f, z.Enabled ? z.Value : 0f);
		public bool AllEnabled => x.Enabled && y.Enabled && z.Enabled;
		public bool AnyEnabled => x.Enabled || y.Enabled || z.Enabled;
		public Vector3 AsV3RawValues => new Vector3(x.Value, y.Value, z.Value);

	#region Conversion and construction
		// GET VALUE FROM STRUCT
		public static implicit operator Vector3(Vector3Optional optionalSource) => optionalSource.AsV3RawValues; // value from optional
		// ASSIGN STRUCT FROM VALUE
		public static implicit operator Vector3Optional(bool enableSource) => new Vector3Optional(default, enableSource); // optional from state
		public static implicit operator Vector3Optional(Vector3 valueSource) => new Vector3Optional(valueSource); // optional from value
		public Vector3Optional(Vector3 defaultValues, bool enabled = false)
		{
			x = new Optional<float>(defaultValues.x, enabled);
			y = new Optional<float>(defaultValues.y, enabled);
			z = new Optional<float>(defaultValues.z, enabled);
		}
	#endregion
	}
}