using System.Diagnostics.CodeAnalysis;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Tools.Utils
{
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	[SuppressMessage("ReSharper", "UnusedType.Global")]
	public static class ScriptableObjectUtils
	{
		#if UNITY_EDITOR
		public static T[] GetAllInstancesInAssets<T>()
			where T : ScriptableObject
		{
			// Find assets using tags ("t:[...]")
			string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
			T[] allInstances = new T[guids.Length];
			for (int i = 0; i < guids.Length; i++)
			{
				string path = AssetDatabase.GUIDToAssetPath(guids[i]);
				allInstances[i] = AssetDatabase.LoadAssetAtPath<T>(path);
			}
			return allInstances;
		}
		#endif
	}
}