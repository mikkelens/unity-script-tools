using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools.Editor
{
	public static class CreateTexture2DArrayMenu
	{
		[MenuItem("Assets/Create/Texture2D Array", isValidateFunction: true)]
		public static bool CanCreateTexture2DArray() => Selection.activeObject != null
		                                                && AssetDatabase.Contains(Selection.activeObject)
		                                                && Selection.activeObject is Texture2D;

		[MenuItem("Assets/Create/Texture2D Array", priority = 1)]
		public static void CreateTexture2DArrayFromSelection()
		{
			// Find selected textures
			Object[] selection = Selection.objects;
			List<Texture2D> textureList = new List<Texture2D>();
			foreach (Object selectedObject in selection)
			{
				if (selectedObject is not Texture2D texture2D) continue; // ignore all selected objects that are not Texture2Ds
				textureList.Add(texture2D);
			}
			Texture2D[] allTextures = textureList.ToArray();

			// Create array
			int mapHeight = allTextures.Max(x => x.height);
			int mapWidth = allTextures.Max(x => x.width);
			Texture2DArray tex2DArray = new Texture2DArray(mapWidth, mapHeight, allTextures.Length, allTextures[0].format, false, false, true);
			int requiredPixels = mapWidth * mapHeight;
			for (int i = 0; i < allTextures.Length; i++)
			{
				Texture2D newTexture2D = DuplicateTexture(allTextures[i]);
				Color[] pixels = newTexture2D.GetPixels();
				Color[] empty = new Color[requiredPixels - pixels.Length];
				Array.Fill(empty, new Color(0, 0, 0, 0));
				Color[] pixelsWithEmpty = pixels.Concat(empty).ToArray();
				tex2DArray.SetPixels(pixelsWithEmpty, i);
			}
			tex2DArray.Apply();

			// Save array
			const string defaultName = "New Texture2D Array";
			string newFilePath = $"{AssetDatabase.GetAssetPath(Selection.activeObject)}/{defaultName}.png";
			AssetDatabase.CreateAsset(tex2DArray, newFilePath);
			// AssetDatabase.Refresh(); // unneeded?
		}

		private static Texture2D DuplicateTexture(Texture2D source)
		{
			RenderTexture renderTex = RenderTexture.GetTemporary(
				source.width,
				source.height,
				0,
				RenderTextureFormat.Default,
				RenderTextureReadWrite.Linear);

			Graphics.Blit(source, renderTex);
			RenderTexture previous = RenderTexture.active;
			RenderTexture.active = renderTex;
			Texture2D readableText = new Texture2D(source.width, source.height);
			readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
			readableText.Apply();
			RenderTexture.active = previous;
			RenderTexture.ReleaseTemporary(renderTex);
			return readableText;
		}
	}
}