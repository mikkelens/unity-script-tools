using UnityEngine;

namespace Scripts.Tools.Types
{
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
			Debug.LogWarning($"There was multiple {nameof(T)} instances. Removing {nameof(T)} called '{name}'");
			Destroy(gameObject);
		}
	}
}