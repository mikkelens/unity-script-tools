using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools.Attributes.Editor
{
	[CustomPropertyDrawer(typeof(AskToFindComponentAttribute))]
	public class AskToFindComponentAttributeDrawer : PropertyDrawer
	{
		private bool _missing;

		private static readonly float WarningHeight = 1.5f * EditorGUIUtility.singleLineHeight;

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if (_missing) return base.GetPropertyHeight(property, label) + WarningHeight;
			return base.GetPropertyHeight(property, label);
		}

		public override void OnGUI(Rect propertyRect, SerializedProperty property, GUIContent label)
		{
			_missing = false;
			if (property.objectReferenceValue == null)
			{
				_missing = true;

				Rect topRect = propertyRect;
				propertyRect.yMin += WarningHeight;
				topRect.height = WarningHeight;
				BasicAttributeDrawerUtils.DrawMessageWithFixAboveField
				(
					topRect,
					"This field expects a reference.",
					MessageType.Warning,
					"Search for one",
					property, TryAssignComponent
				);
			}

			EditorGUI.PropertyField(propertyRect, property, label);
		}

		private void TryAssignComponent(SerializedProperty property)
		{
			property.objectReferenceValue = TryFindComponent(property);
		}

		private Component TryFindComponent(SerializedProperty property)
		{
			SerializedObject so = property.serializedObject;
			foreach (Object targetObject in so.targetObjects)
			{
				if (targetObject is not Component component) continue;

				Component target = component.GetComponentInChildren(fieldInfo.FieldType);
				if (target != null) return target;
			}

			return null;
		}
	}
}