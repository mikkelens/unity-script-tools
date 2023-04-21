using Tools.Utils;
using UnityEditor;
using UnityEngine;

namespace Tools.Editor
{
	// ReSharper disable CommentTypo
	/// <summary>
	/// Script based on CreateEditorScriptMenu.cs
	/// </summary>
	// ReSharper restore CommentTypo
    public static class CreateMeshMenu
	{
        [MenuItem("Assets/Create/Meshes/Disc", priority = 5)]
        public static void CreateDiscMesh()
        {
	        const string defaultName = "New Disc Mesh";
	        const string extension = ".asset";

            Mesh discMesh = MeshUtils.Disc(1f, 32, 32);
            MeshUtility.Optimize(discMesh);
            ProjectWindowUtil.CreateAsset(discMesh, defaultName + extension); // creates asset from selected folder, lets us edit its name
        }
	}
}