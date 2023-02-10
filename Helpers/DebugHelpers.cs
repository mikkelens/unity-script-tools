using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Tools.Helpers
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class DebugHelpers
	{
		public static void LogIfNull<T>(this T nullableItem, string message)
		{
			if (nullableItem != null) return;
			Debug.Log(message);
		}
		public static void LogWarningIfNull<T>(this T nullableItem, string message)
		{
			if (nullableItem != null) return;
			Debug.LogWarning(message);
		}
		public static void LogErrorIfNull<T>(this T nullableItem, string message)
		{
			if (nullableItem != null) return;
			Debug.LogError(message);
		}
	}
}