using UnityEditor;
using UnityEngine;

namespace Tools.Types.Editor
{
	[CustomPropertyDrawer(typeof(Range<>))]
	public class RangePropertyDrawer : PropertyDrawer
	{
		private const string MinSerializedRef = "min";
		private const string MaxSerializedRef = "max";

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			SerializedProperty startProperty = property.FindPropertyRelative(MinSerializedRef);
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
			SerializedProperty minProperty = fullProperty.FindPropertyRelative(MinSerializedRef);
			SerializedProperty maxProperty = fullProperty.FindPropertyRelative(MaxSerializedRef);

			Rect maxRect = fullRect;
			Rect labelAndMinRect = fullRect;

			maxRect.width = (fullRect.width - EditorGUIUtility.labelWidth) / 2f;
			labelAndMinRect.width -= maxRect.width;

			maxRect.width -= spacing / 2f;
			labelAndMinRect.width -= spacing / 2f;

			maxRect.x += labelAndMinRect.width + spacing;

			// BEGIN DRAWING //
			int originalIndent = EditorGUI.indentLevel;
			EditorGUI.BeginProperty(fullRect, label, fullProperty);
			EditorGUI.PropertyField(labelAndMinRect, minProperty, label, false);

			EditorGUI.indentLevel = 0;
			EditorGUI.PropertyField(maxRect, maxProperty, GUIContent.none, false);
			EditorGUI.EndProperty();
			EditorGUI.indentLevel = originalIndent;
			// END DRAWING //
		}
	}
}