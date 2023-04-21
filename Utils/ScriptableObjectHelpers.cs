using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Tools.Utils
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class ScriptableObjectHelpers
	{
		#if UNITY_EDITOR
		// for trying to help user with navigating to right directory, caches last directory path (value) with type (key)
		private static readonly Dictionary<string, string> NameLookupTable = new Dictionary<string, string>(); // todo: make this import data after recompilation
		private static readonly Dictionary<string, string> DirectoryLookupTable = new Dictionary<string, string>(); // todo: make this import data after recompilation
		private static string RememberedNameOrDefault(string typeName)
		{
			// Debug.Log($"Trying to get directory from lookup table '{NameLookupTable.GetType().GetNiceName()}' with keys [{string.Join(',', NameLookupTable.Keys)}]");
			if (!NameLookupTable.TryGetValue(typeName, out string fileName))
			{
				fileName = "New " + typeName; // fall back value
			}
			return fileName;
		}
		private static string RememberedDirectoryOrDefault(string typeName)
		{
			// Debug.Log($"Trying to get directory from lookup table '{DirectoryLookupTable.GetType().GetNiceName()}' with keys [{string.Join(',', DirectoryLookupTable.Keys)}]");
			if (!DirectoryLookupTable.TryGetValue(typeName, out string directoryPath))
			{
				directoryPath = Application.dataPath; // fall back value
			}
			return directoryPath;
		}

		[CanBeNull] public static T TrySaveAssetWithFileWindow<T>(this T asset, string title)
			where T : ScriptableObject
		{
			string directoryPath = RememberedDirectoryOrDefault(typeof(T).Name);
			return asset.TrySaveAssetWithFileWindow(title, ref directoryPath);
		}
		[CanBeNull] public static T TrySaveAssetWithFileWindow<T>(this T asset, string title, ref string directoryPath)
			where T : ScriptableObject
		{
			string fileName = RememberedNameOrDefault(typeof(T).Name);
			return asset.TrySaveAssetWithFileWindow(title, ref directoryPath, fileName);
		}
		[CanBeNull] public static T TrySaveAssetWithFileWindow<T>(this T asset, string title, ref string directoryPath, string fileName)
			where T : ScriptableObject
		{
			// get path for saving and loading asset from user using editor prompt/window
			string rawPath = EditorUtility.SaveFilePanel(title, directoryPath, fileName, "asset");
			if (rawPath.Length == 0) return null; // save-file panel was closed/canceled

			string assetsFilePath = rawPath.ToAssetsFromGlobalPath(); // global file -> local file

			// remember name for next time
			NameLookupTable[typeof(T).Name] = fileName;

			// remember directory for next time
			string selectedDirectory = assetsFilePath.ToDirectoryFromFilePath(); // local file -> local folder
			DirectoryLookupTable[typeof(T).Name] = selectedDirectory; // apparantly also creates new key/value pairs if the key does not exist

			return TrySaveWithAssetPath(asset, assetsFilePath);
		}

		[CanBeNull] public static T TrySaveWithAssetPath<T>(this T asset, string assetsFilePath) where T : ScriptableObject
		{
			// save and load asset
			AssetDatabase.CreateAsset(asset, assetsFilePath);
			T loadedAsset = AssetDatabase.LoadAssetAtPath<T>(assetsFilePath);
			if (loadedAsset != null) return loadedAsset;

			Debug.LogError($"Could not load '{assetsFilePath}' after trying to create it?");
			return null;
		}
		#endif
	}
}