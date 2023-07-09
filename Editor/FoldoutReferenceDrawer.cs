using Sirenix.OdinInspector.Editor.Drawers;
using Tools.Attributes;
using Tools.Types;
using UnityEditor;
using UnityEngine;

namespace Tools.Editor
{
	/// <summary>
	/// Editor for drawing Scriptable Objects using foldouts so you can edit their values when they are drawn as a
	/// field in a different editor.
	/// </summary>
	/// <source href="https://forum.unity.com/threads/editor-tool-better-scriptableobject-inspector-editing.484393/"></source>
	// [CustomPropertyDrawer(typeof(FoldoutReferenceAttribute), true)]
	[CustomPropertyDrawer(typeof(FoldoutScriptableObject), true)]
	public class FoldoutReferenceDrawer : PropertyDrawer
	{
		private UnityEditor.Editor _editor;

		public override void OnGUI(Rect fullPropertyRect, SerializedProperty property, GUIContent label)
		{
			GUIContent thisLabel = label.text == ""
				? new GUIContent(label) { text = "Unknown" }
				: label;

			Object propertyObject = property.objectReferenceValue;
			if (propertyObject == null)
			{
				EditorGUI.PropertyField(fullPropertyRect, property, label, false); // draw content with label
				return;
			}
			if (thisLabel.text == "Unknown")
			{
				thisLabel = new GUIContent(propertyObject.name);
			}

			Rect labelRect = fullPropertyRect;
			Rect valueRect = fullPropertyRect;
			labelRect.width = EditorGUIUtility.labelWidth - EditorGUIUtility.standardVerticalSpacing;
			valueRect.xMin += EditorGUIUtility.labelWidth;

			property.isExpanded = GUI.Toggle(labelRect, property.isExpanded, thisLabel, EditorStyles.foldoutHeader);

			EditorGUI.PropertyField(valueRect, property, GUIContent.none, false); // draw content without label

			if (property.isExpanded)
			{
				EditorGUI.indentLevel++;
				if (!_editor)
				{
					UnityEditor.Editor.CreateCachedEditor(propertyObject, null, ref _editor);
				}
				_editor.OnInspectorGUI();
				EditorGUI.indentLevel--;
			}
		}
	}
}