using System;
using UnityEditor;
using UnityEngine;

namespace Tools.Attributes.Editor
{
	public static class BasicAttributeDrawerUtils
	{
		private const float ButtonInsetDiameterRelative = 0.15f;

		public static void DrawMessageWithFixAboveField
		(
			Rect topRect,
			string message,
			MessageType messageType,
			string buttonText,
			SerializedProperty property,
			Action<SerializedProperty> fix,
			string newValueText = null
		)
		{
			// define field property
			Rect helpBoxRect = topRect;
			Rect buttonRect = topRect;
			helpBoxRect.width = EditorGUIUtility.labelWidth;
			buttonRect.xMin += EditorGUIUtility.labelWidth;

			// define box
			Vector2 buttonCenter = buttonRect.center;
			float inset = buttonRect.height * ButtonInsetDiameterRelative;
			buttonRect.height -= inset;
			buttonRect.width -= inset;
			buttonRect.center = buttonCenter; // reassign after size changes position

			EditorGUI.HelpBox(helpBoxRect, message, messageType);

			if (newValueText != null) buttonText += $" (New value: {newValueText})";
			if (GUI.Button(buttonRect, buttonText))
			{
				fix(property);
			}
		}
	}
}