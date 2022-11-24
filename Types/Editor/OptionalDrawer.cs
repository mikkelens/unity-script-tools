using Tools.Types;
using UnityEditor;
using UnityEngine;

namespace Tools.Editor
{
	[CustomPropertyDrawer(typeof(Optional<>))]
	public class OptionalPropertyDrawer : PropertyDrawer
	{
		private const string ValueSerializedRef = "value";
		private const string EnabledSerializedRef = "enabled";

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			SerializedProperty valueProperty = property.FindPropertyRelative(ValueSerializedRef);
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
			SerializedProperty valueProperty = fullProperty.FindPropertyRelative(ValueSerializedRef);
			SerializedProperty enabledProperty = fullProperty.FindPropertyRelative(EnabledSerializedRef);

			Rect labelAndValue = fullRect;
			Rect enabledRect = fullRect;

			enabledRect.width = enabledRect.height;
			labelAndValue.width -= enabledRect.width;

			enabledRect.x += labelAndValue.width + spacing;

			// BEGIN DRAWING //
			EditorGUI.BeginProperty(fullRect, label, fullProperty);

			EditorGUI.BeginDisabledGroup(enabledProperty.boolValue == false);
			EditorGUI.PropertyField(labelAndValue, valueProperty, label, false);
			EditorGUI.EndDisabledGroup();

			EditorGUI.PropertyField(enabledRect, enabledProperty, GUIContent.none, false);
			EditorGUI.EndProperty();
			// END DRAWING //
		}
	}
}