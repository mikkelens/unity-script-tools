using System;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace Tools.Types
{
	#if ODIN_INSPECTOR
	[InlineProperty]
	#endif
	[Serializable]
	public struct OptionalSecondary<T>
	{
		#if ODIN_INSPECTOR
		[HideLabel, HorizontalGroup("range")]
		#endif
		[SerializeField] private T primary;
		#if ODIN_INSPECTOR
		[HideLabel, HorizontalGroup("range")]
		#endif
		[SerializeField] private Optional<T> secondary;

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