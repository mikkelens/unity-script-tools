using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;

namespace Tools.Utils
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class PathUtiils
	{
		public static string ToAssetsFromGlobalPath(this string globalPath)
		{
			int index = globalPath.IndexOf("Assets/", StringComparison.CurrentCulture);
			return globalPath.Remove(0, index);
		}
		public static string ToGlobalFromAssetsPath(this string assetsPath)
		{
			string globalPathToAssets = Application.dataPath;

			int assetsTrimIndex = assetsPath.IndexOf("Assets/", StringComparison.CurrentCulture);
			string appendage = globalPathToAssets;
			if (assetsTrimIndex != -1) // path had "Assets/" in it
			{
				appendage.Remove(assetsTrimIndex);
			}
			else // path did *not* have "Assets/" in it
			{
				Debug.LogWarning($"'Assets/' was not found in path: '{assetsPath}'. It is assumed that the provided path is local to/exists within directory 'Assets'.");
			}
			return appendage + "/" + assetsPath;
		}
		public static string DirectoryFromFilePath(this string filePath)
		{
			int directoryTrimIndex = filePath.LastIndexOf('/');
			return filePath.Remove(directoryTrimIndex);
		}
	}
}