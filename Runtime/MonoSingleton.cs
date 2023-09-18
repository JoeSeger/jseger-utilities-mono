using UnityEngine;

namespace JSeger.Utilities.Mono.Runtime
{
    public sealed class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public sealed class SingletonPersistent<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static void CreateInstance()
        {
            var newInstance = new GameObject(typeof(T).Name);
            newInstance.AddComponent<T>();
        }
    }
    
}