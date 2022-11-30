using UnityEditor;
using UnityEngine;

namespace Tools.Types.Editor
{
	[CustomPropertyDrawer(typeof(TimedState))]
	public class TimedStatePropertyDrawer : PropertyDrawer
	{
		private const string StateSerializedRef = "state";
		private const string TrueSerializedRef = "latestTimeTrue";
		private const string FalseSerializedRef = "startTimeFalse";

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			SerializedProperty stateProperty = property.FindPropertyRelative(StateSerializedRef);
			return EditorGUI.GetPropertyHeight(stateProperty);
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
			SerializedProperty stateProperty = fullProperty.FindPropertyRelative(StateSerializedRef);
			SerializedProperty trueProperty = fullProperty.FindPropertyRelative(TrueSerializedRef);
			SerializedProperty falseProperty = fullProperty.FindPropertyRelative(FalseSerializedRef);

			Rect labelAndTime = fullRect;
			Rect stateRect = fullRect;

			stateRect.width = stateRect.height;
			labelAndTime.width -= stateRect.width;

			stateRect.x += labelAndTime.width + spacing;

			// BEGIN DRAWING //
			int originalIndent = EditorGUI.indentLevel;
			EditorGUI.BeginProperty(fullRect, label, fullProperty);
			bool state = stateProperty.boolValue;
			EditorGUI.BeginDisabledGroup(!state);
			SerializedProperty relevantTimeProperty = state ? trueProperty : falseProperty;
			EditorGUI.PropertyField(labelAndTime, relevantTimeProperty, label, false);
			EditorGUI.EndDisabledGroup();

			EditorGUI.indentLevel = 0;
			EditorGUI.PropertyField(stateRect, stateProperty, GUIContent.none, false);
			EditorGUI.EndProperty();
			EditorGUI.indentLevel = originalIndent;
			// END DRAWING //
		}
	}
}