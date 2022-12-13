using UnityEditor;
using UnityEngine;

namespace Tools.Types.Editor
{
	[CustomPropertyDrawer(typeof(Relative<>))]
	public class RelativePropertyDrawer : PropertyDrawer
	{
		private const string ValueSerializedRef = "value";
		private const string RelativitySerializedRef = "relativity";

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			SerializedProperty startProperty = property.FindPropertyRelative(ValueSerializedRef);
			return EditorGUI.GetPropertyHeight(startProperty);
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
			SerializedProperty relativityProperty = fullProperty.FindPropertyRelative(RelativitySerializedRef);

			Rect relativityRect = fullRect;
			Rect labelAndValueRect = fullRect;

			relativityRect.width = (fullRect.width - EditorGUIUtility.labelWidth) / 2f;
			labelAndValueRect.width -= relativityRect.width;

			relativityRect.width -= spacing / 2f;
			labelAndValueRect.width -= spacing / 2f;

			relativityRect.x += labelAndValueRect.width + spacing;

			// BEGIN DRAWING //
			int originalIndent = EditorGUI.indentLevel;
			EditorGUI.BeginProperty(fullRect, label, fullProperty);
			EditorGUI.PropertyField(labelAndValueRect, valueProperty, label, false);

			EditorGUI.indentLevel = 0;
			EditorGUI.PropertyField(relativityRect, relativityProperty, GUIContent.none, false);
			EditorGUI.EndProperty();
			EditorGUI.indentLevel = originalIndent;
			// END DRAWING //
		}
	}
}