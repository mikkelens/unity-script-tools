using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;

namespace Tools.Utils
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class TransformHelpers
	{
		[CanBeNull] public static T ClosestScript<T>(this Transform transform, IEnumerable<T> scriptsOfRightType)
			where T : MonoBehaviour
		{
			T closestScript = null; // return null if empty list
			float closestDistance = Mathf.Infinity;
			Vector2 ourPos = transform.position.V2FromV3();
			foreach (T scriptOfRightType in scriptsOfRightType)
			{
				Vector2 otherPos = scriptOfRightType.transform.position.V2FromV3();
				float distance = Vector2.Distance(ourPos, otherPos);
				if (distance >= closestDistance) continue;

				closestScript = scriptOfRightType;
				closestDistance = distance;
			}
			return closestScript;
		}

		public static Transform ClosestTransform(this Transform transform, IEnumerable<Transform> otherTransforms)
		{
			Transform closestTransform = null;
			float closestDistance = Mathf.Infinity;
			Vector2 ourPos = transform.position.V2FromV3();
			foreach (Transform otherTransform in otherTransforms)
			{
				Vector2 otherPos = otherTransform.position.V2FromV3();
				float distance = Vector2.Distance(ourPos, otherPos);
				if (distance >= closestDistance) continue;

				closestTransform = otherTransform;
				closestDistance = distance;
			}
			return closestTransform;
		}
	}
}