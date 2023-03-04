using System.Diagnostics.CodeAnalysis;
using Sirenix.Utilities;
using UnityEngine;

namespace Tools.Types
{
	[SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
	[DefaultExecutionOrder(-100)]
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		// ReSharper disable MemberCanBePrivate.Global
		// ReSharper disable UnusedMember.Global
		private static T _instance;
		public static T Instance
		{
			get
			{
				#if UNITY_EDITOR
				if (_instance == null) Debug.LogError($"Tried accessing instance of {typeof(T).BaseType.GetNiceName()} when it did not exist!");
				#endif
				return _instance;
			}
		}

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
			_instance = this as T;
		}

		private  void DeleteThisDuplicate()
		{
			#if UNITY_EDITOR
			Debug.Log($"{GetType().BaseType.GetNiceName()} on GameObject '{gameObject.name}' found an existing {GetType().GetNiceName()}. Deleting GameObject of self (newest duplicate).");
			#endif
			Destroy(gameObject);
		}
	}
}