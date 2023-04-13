using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Tools.Types
{
	[Serializable, InlineProperty]
	public struct OptionalSecondary<T>
	{
		[SerializeField, HideLabel, HorizontalGroup("range")] private T primary;
		[SerializeField, HideLabel, HorizontalGroup("range")] private Optional<T> secondary;

		public OptionalSecondary(T firstValue)
		{
			primary = firstValue;
			secondary = new Optional<T>();
		}
		public OptionalSecondary(T firstValue, T secondValue, bool enableSecond = true)
		{
			primary = firstValue;
			secondary = new Optional<T>(secondValue, enableSecond);
		}

		public T Primary => primary;
		public Optional<T> Secondary => secondary; // it's ok to pass along a class bc all the members are get-only outside serializedfield
	}
}