using UnityEditor;
using UnityEngine;

namespace Tools.Types.Editor
{
	[CustomPropertyDrawer(typeof(Optional<>))]
	public class OptionalPropertyDrawer : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			SerializedProperty valueProperty = property.FindPropertyRelative(Optional<bool>.ValueName);
			return EditorGUI.GetPropertyHeight(valueProperty);
		}

		public override void OnGUI
		(
			Rect fullRect,
			SerializedProperty fullProperty,
			GUIContent label
		)
		{
			// define constant ish variables
			float spacing = EditorGUIUtility.standardVerticalSpacing;

			// find sub-properties
			SerializedProperty valueProperty = fullProperty.FindPropertyRelative(Optional<bool>.ValueName);
			SerializedProperty enabledProperty = fullProperty.FindPropertyRelative(Optional<bool>.EnabledName);

			Rect labelAndValue = fullRect;
			Rect enabledRect = fullRect;

			enabledRect.width = enabledRect.height;
			labelAndValue.width -= enabledRect.width + spacing;

			enabledRect.x += labelAndValue.width + spacing;

			// BEGIN DRAWING //
			int originalIndent = EditorGUI.indentLevel;
			EditorGUI.BeginProperty(fullRect, label, fullProperty);
			EditorGUI.BeginDisabledGroup(enabledProperty.boolValue == false);
			EditorGUI.PropertyField(labelAndValue, valueProperty, label, true);
			EditorGUI.EndDisabledGroup();

			// EditorGUI.indentLevel = 0; // not sure why I need this but honestly dont change it
			EditorGUI.PropertyField(enabledRect, enabledProperty, GUIContent.none, true);
			EditorGUI.EndProperty();
			EditorGUI.indentLevel = originalIndent;
			// END DRAWING //
		}
	}
}