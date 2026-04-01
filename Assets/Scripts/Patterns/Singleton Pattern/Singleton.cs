using UnityEngine;

namespace Assets.Scripts.Patterns.Singleton_Pattern
{
    /// <summary>
    /// Generic base class for MonoBehaviour singletons.
    /// Any manager that should only have one instance can inherit from this class.
    /// </summary>
    /// <typeparam name="T">The concrete MonoBehaviour type that becomes the singleton.</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// Global instance of the singleton.
        /// </summary>
        public static T Instance { get; private set; }

        [Header("Singleton Settings")]
        [Tooltip("If true, this singleton will not be destroyed when loading a new scene.")]
        [SerializeField]
        private bool _dontDestroyOnLoad = true;

        /// <summary>
        /// Unity Awake callback.
        /// Ensures only one instance of this singleton exists.
        /// </summary>
        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning($"Duplicate singleton of type {typeof(T).Name} found on GameObject '{gameObject.name}'. Destroying duplicate.");

                Destroy(gameObject);
                return;
            }

            Instance = this as T;

            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// Clears the static instance when this object is destroyed.
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}
