using UnityEngine;

namespace Tools.Helpers
{
	public static class UIHelpers
	{
		// got this from https://answers.unity.com/questions/1100493/convert-recttransformrect-to-rect-world.html
		public static Rect AsWorldRect(this RectTransform rectTransform)
		{
			Vector3[] corners = new Vector3[4];
			rectTransform.GetWorldCorners(corners);
			return new Rect(corners[0], corners[2] - corners[0]);
		}
	}
}