using UnityEngine;

namespace Tools.Types
{
	public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
	{
		// Instance property exists in base class

		private protected override void DeclareThisInstance()
		{
			base.DeclareThisInstance();
			DontDestroyOnLoad(gameObject);
		}

		private protected override void DeleteThisDuplicate()
		{
			Debug.Log($"{GetType().Name} of type ({GetType().BaseType?.Name}) found an existing Persistent Singleton. Deleting self ('{name}').");
			Destroy(gameObject);
		}
	}
}