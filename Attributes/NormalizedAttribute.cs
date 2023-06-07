using System;
using UnityEngine;

namespace Tools.Attributes
{
	/// <summary>
	/// Attribute that enables a little warning and button above the field in the editor.
	/// For vectors that aren't yet normalized.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class NormalizedAttribute : PropertyAttribute { }
}