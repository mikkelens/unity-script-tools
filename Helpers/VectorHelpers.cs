using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;

namespace Tools.Helpers
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class VectorHelpers
	{
		// size conversion extensions
		public static Vector2 V2FromV3(this Vector3 vector3) => new Vector2(vector3.x, vector3.y);
		public static Vector3 V3FromV2(this Vector2 vector2, float zValue = 0f) => new Vector3(vector2.x, vector2.y, zValue);

		// int/float conversion extensions
		public static Vector2 V2FromV2Int(this Vector2Int intVector2) => intVector2;
		public static Vector3 V3FromV3Int(this Vector3Int intVector3) => intVector3;
		public static Vector2Int V2IntFromV2(this Vector2 vector2) => Vector2Int.RoundToInt(vector2);
		public static Vector3Int V3IntFromV3(this Vector3 vector3) => Vector3Int.RoundToInt(vector3);

		// float/vector conversion extension
		public static Vector2 ToSquareV2(this float number) => Vector2.one * number;
		public static Vector3 ToCubeV3(this float number) => Vector3.one * number;
		public static float SquareSizeAverage(this Vector2 vector2) => vector2.magnitude;
		public static float CubeSizeAverage(this Vector3 vector3) => vector3.magnitude;

		// absolute value
		public static Vector2 Abs(this Vector2 vector2) => new Vector2(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y));
		public static Vector3 Abs(this Vector3 vector3) => new Vector3(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y), Mathf.Abs(vector3.z));

		// min/max
		public static float MinFromV2(this Vector2 vector2) => Mathf.Min(vector2.x, vector2.y);
		public static float MinFromV3(this Vector3 vector3) => Mathf.Min(vector3.x, Mathf.Min(vector3.y, vector3.z));
		public static float MaxFromV2(this Vector2 vector2) => Mathf.Max(vector2.x, vector2.y);
		public static float MaxFromV3(this Vector3 vector3) => Mathf.Max(vector3.x, Mathf.Max(vector3.y, vector3.z));
		public static Vector2 MinSquareV2(this Vector2 vector2) => vector2.MinFromV2().ToSquareV2();
		public static Vector2 MaxSquareV2(this Vector2 vector2) => vector2.MaxFromV2().ToSquareV2();
		public static Vector3 MinCubeV3(this Vector3 vector3) => vector3.MinFromV3().ToCubeV3();
		public static Vector3 MaxCubeV3(this Vector3 vector3) => vector3.MaxFromV3().ToCubeV3();

		// normalization / circle
		public static Vector2 WithinUnitCircle(this Vector2 vector2)
		{
			if (vector2.magnitude <= 1f) return vector2; // within bounds of circle
			return vector2.normalized;
		}
		public static Vector3 WithinUnitSphere(this Vector3 vector3)
		{
			if (vector3.magnitude <= 1f) return vector3; // within bounds of sphere
			return vector3.normalized;
		}

		// with components
		public static Vector2 WithX(this Vector2 vector2, float x) => new Vector2(x, vector2.y);
		public static Vector2 WithY(this Vector2 vector2, float y) => new Vector2(vector2.x, y);
		public static Vector3 WithX(this Vector3 vector3, float x) => new Vector3(x, vector3.y, vector3.z);
		public static Vector3 WithY(this Vector3 vector3, float y) => new Vector3(vector3.x, y, vector3.z);
		public static Vector3 WithZ(this Vector3 vector3, float z) => new Vector3(vector3.x, vector3.y, z);

		// list selection
		public static Vector2? ClosestV2(this Vector2 position, List<Vector2> otherPositions)
		{
			Vector2? closestPosition = null;
			float closestDistance = float.PositiveInfinity;
			foreach (Vector2 otherPosition in otherPositions)
			{
				float newDistance = Vector2.Distance(position, otherPosition);
				if (!(newDistance < closestDistance)) continue;
				closestDistance = newDistance;
				closestPosition = otherPosition;
			}
			return closestPosition;
		}
		public static Vector3? ClosestV3(this Vector3 position, List<Vector3> otherPositions)
		{
			Vector3? closestPosition = null;
			float closestDistance = float.PositiveInfinity;
			foreach (Vector3 newPoosition in otherPositions)
			{
				float newDistance = Vector3.Distance(position, newPoosition);
				if (closestDistance <= newDistance) continue;
				closestDistance = newDistance;
				closestPosition = newPoosition;
			}
			return closestPosition;
		}
	}
}