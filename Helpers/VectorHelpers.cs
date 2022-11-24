using UnityEngine;

namespace Tools.Helpers
{
	public static class VectorHelpers
	{
		// extensions
		public static Vector2 AsV2(this Vector3 vector) => new Vector2(vector.x, vector.y);
		public static Vector3 AsV3(this Vector2 vector) => new Vector3(vector.x, vector.y);
	}
}