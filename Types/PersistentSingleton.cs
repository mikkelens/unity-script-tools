using Sirenix.Utilities;
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
			#if UNITY_EDITOR
			Debug.Log($"{GetType().BaseType.GetNiceName()} on GameObject '{gameObject.name}' found an existing {GetType().GetNiceName()}. Deleting self (newest duplicate).");
			#endif
			Destroy(gameObject);
		}
	}
}