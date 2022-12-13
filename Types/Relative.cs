using System;
using UnityEngine;

namespace Tools.Types
{
	[Serializable]
	public struct Relative<T>
	{
		[SerializeField] private T value;
		[SerializeField] private float relativity;

		public T Value => value;
		public float Relativity => relativity;

		// GET VALUE FROM STRUCT
		public static implicit operator T(Relative<T> relativeSource) => relativeSource.Value;

		// ASSIGN STRUCT FROM VALUE
		public static implicit operator Relative<T>(float relativeSource) => new Relative<T>(default, relativeSource);
		public static implicit operator Relative<T>(T valueSource) => new Relative<T>(valueSource);

		public Relative(T setValue, float setRelativity = 1f)
		{
			value = setValue;
			relativity = setRelativity;
		}
	}
}