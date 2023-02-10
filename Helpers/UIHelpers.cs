using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Tools.Helpers
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class UIHelpers
	{
		// got this from https://answers.unity.com/questions/1100493/convert-recttransformrect-to-rect-world.html
		public static Rect AsWorldRect(this RectTransform rectTransform)
		{
			Vector3[] corners = new Vector3[4];
			rectTransform.GetWorldCorners(corners);
			return new Rect(corners[0], corners[2] - corners[0]);
		}

		public static Vector3 ScaleVector3(this RectTransform rectTransform, Vector3 size) => rectTransform.localToWorldMatrix.MultiplyVector(size);
		public static Vector2 ScaleVector2(this RectTransform rectTransform, Vector2 size) => rectTransform.localToWorldMatrix.MultiplyVector(size.AsV3FromV2()).AsV2FromV3();
	}
}