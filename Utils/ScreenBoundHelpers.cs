using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Tools.Utils
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class ScreenBoundHelpers
	{
		public static bool PointOutsideViewArea2D(this Camera cam, Vector2 pos, float clearance = 0f)
		{
			float height = cam.orthographicSize;
			float width = height * cam.aspect;
			float verticalClearance = height + clearance;
			float horizontalClearance = width + clearance;
			return pos.x.Abs() > verticalClearance || pos.y.Abs() > horizontalClearance;
		}
	}
}