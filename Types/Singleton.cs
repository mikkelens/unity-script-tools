using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Tools.Types
{
	[SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
	[DefaultExecutionOrder(-100)]
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		// ReSharper disable MemberCanBePrivate.Global
		// ReSharper disable UnusedMember.Global
		public static T Instance { get; private set; }
		public static bool Exists => Instance != null;
		// ReSharper restore MemberCanBePrivate.Global
		// ReSharper restore UnusedMember.Global

		protected virtual void Awake()
		{
			if (Instance == null)
			{
				DeclareThisInstance();
			}
			else if (Instance != this)
			{
				DeleteThisDuplicate();
			}
		}

		private protected virtual void DeclareThisInstance()
		{
			Instance = this as T;
		}

		private protected virtual void DeleteThisDuplicate()
		{
			Debug.Log($"{typeof(Singleton<T>).Name} ({typeof(T).Name}) '{name}' found an already existing instance. Removing {name}'s GameObject.");
			Destroy(gameObject);
		}
	}
}