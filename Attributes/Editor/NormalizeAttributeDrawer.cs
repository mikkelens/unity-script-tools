using UnityEditor;
using UnityEngine;

namespace Tools.Attributes.Editor
{
	[CustomPropertyDrawer(typeof(NormalizedAttribute))]
	public class NormalizeAttributeDrawer : PropertyDrawer
	{
		private const float MinDifference = 0.000001f;

		private bool _warning;
		private bool _vec2Not3; // either Vector2 or Vector3, we assume

		// display proportions with warning
		private static readonly float WarningHeight = 1.5f * EditorGUIUtility.singleLineHeight;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if (_warning) return base.GetPropertyHeight(property, label) + WarningHeight;
			return base.GetPropertyHeight(property, label);
		}

		public override void OnGUI(Rect propertyRect, SerializedProperty property, GUIContent label)
		{
			_warning = false;
			if (property.propertyType == SerializedPropertyType.Vector2)
			{
				_vec2Not3 = true;
				Vector2 value = property.vector2Value;
				if (Vector2.Distance(value, value.normalized) >= MinDifference)
				{
					_warning = true;
				}
			}
			else if (property.propertyType == SerializedPropertyType.Vector3)
			{
				_vec2Not3 = false;
			}

			if (_warning)
			{
				string newValueDisplay = _vec2Not3
					? property.vector2Value.normalized.ToString("0.000")
					: property.vector3Value.normalized.ToString("0.000");

				propertyRect.height -= WarningHeight;
				Rect topRect = propertyRect;
				topRect.height = WarningHeight;
				BasicAttributeDrawerUtils.DrawMessageWithFixAboveField
				(
					topRect,
					"This value expects to be normalized.",
					MessageType.Warning,
					"Normalize!",
					property,
					NormalizeProperty,
					newValueDisplay
				);
			}

			// draw as normal
			EditorGUI.PropertyField(propertyRect, property, label);
		}

		private void NormalizeProperty(SerializedProperty property)
		{
			if (_vec2Not3)
				property.vector2Value = property.vector2Value.normalized;
			else
				property.vector3Value = property.vector3Value.normalized;
			property.serializedObject.ApplyModifiedProperties();
		}
	}
}