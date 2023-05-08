using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace Tools.Utils
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class MeshUtils
	{
		/// <summary>
		/// Based on Unity Question https://answers.unity.com/questions/855827/problems-with-creating-a-disk-shaped-mesh-c.html
		/// </summary>
		/// <param name="radius"></param>
		/// <param name="radiusTiles"></param>
		/// <param name="tilesAround"></param>
		/// <returns>Newly generated disc mesh</returns>
		public static Mesh Disc(float radius, int radiusTiles, int tilesAround, bool bothSides = true)
		{
			int construct = radiusTiles * tilesAround * 6;

			Vector3[] vertices = new Vector3[construct];
			int[] triangles = new int[construct];
			Vector2[] uv = new Vector2[construct];
			int currentVertex = 0;

			float tileLength = radius / radiusTiles; // the length of a tile parallel to the radius
			float radPerTile = 2 * Mathf.PI  / tilesAround; // the radians the tile takes

			for(int angleNum = 0; angleNum < tilesAround; angleNum++) // loop around
			{
				float angle = radPerTile * angleNum; // the current angle in radians

				for(int offset = 0; offset < radiusTiles; offset++) // loop from the center outwards
				{
					vertices[currentVertex]        =    new Vector3(Mathf.Cos(angle)              *offset       *tileLength                 , Mathf.Sin(angle) *offset       *tileLength                ,0);
					vertices[currentVertex + 1]    =    new Vector3(Mathf.Cos(angle + radPerTile) *offset       *tileLength , Mathf.Sin(angle + radPerTile)    *offset       *tileLength    ,0);
					vertices[currentVertex + 2]    =    new Vector3(Mathf.Cos(angle)              *(offset + 1) *tileLength         , Mathf.Sin(angle)         *(offset + 1) *tileLength            ,0);

					vertices[currentVertex + 3]    =    new Vector3(Mathf.Cos(angle + radPerTile) *offset       *tileLength         , Mathf.Sin(angle + radPerTile) *offset       *tileLength        ,0);
					vertices[currentVertex + 4]    =    new Vector3(Mathf.Cos(angle + radPerTile) *(offset + 1) *tileLength     , Mathf.Sin(angle     + radPerTile) *(offset + 1) *tileLength    ,0);
					vertices[currentVertex + 5]    =    new Vector3(Mathf.Cos(angle)              *(offset + 1) *tileLength                 , Mathf.Sin(angle)      *(offset + 1) *tileLength                ,0);

					currentVertex += 6;
				}
			}
			for(int j = 0; j < triangles.Length; j++) // set the triangles (works bc of how we created the triangles?)
			{
				triangles[j] = j;
			}
			if (bothSides) // addition: backface generation
			{
				triangles = triangles.Concat(triangles.Reverse()).ToArray();
			}

			// create the mesh and apply vertices/triangles/UV
			Mesh disc = new Mesh
			{
				vertices = vertices,
				triangles = triangles,
				uv = uv // the UV doesnt need to be set (?)
			};
			disc.RecalculateNormals(); // idk if needed tbh
			return disc;
		}
	}
}