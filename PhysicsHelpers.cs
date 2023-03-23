using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Scripts.Tools
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class PhysicsHelpers
	{
		// contacts
		public static ContactPoint? ClosestContactPoint(this List<ContactPoint> contactPoints, Vector3 position)
		{
			ContactPoint? closestContactPoint = null;
			float closestDistance = float.PositiveInfinity;
			foreach (ContactPoint newContactPoint in contactPoints)
			{
				float newDistance = Vector3.Distance(position, newContactPoint.point);
				if (closestDistance <= newDistance) continue;
				closestDistance = newDistance;
				closestContactPoint = newContactPoint;
			}
			return closestContactPoint;
		}
	}
}