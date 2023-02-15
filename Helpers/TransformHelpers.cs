using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Tools.Helpers
{
	public static class TransformHelpers
	{
		[CanBeNull]
		public static T ClosestScript<T>(this Transform transform, IEnumerable<T> scriptsOfRightType)
		where T : MonoBehaviour
		{
			T closestScript = null; // return null if empty list
			float closestDistance = Mathf.Infinity;
			Vector2 ourPos = transform.position.AsV2FromV3();
			foreach (T scriptOfRightType in scriptsOfRightType)
			{
				Vector2 otherPos = scriptOfRightType.transform.position.AsV2FromV3();
				float distance = Vector2.Distance(ourPos, otherPos);
				if (distance >= closestDistance) continue;

				closestScript = scriptOfRightType;
				closestDistance = distance;
			}
			return closestScript;
		}
	}
}