using UnityEngine;

namespace JSeger.Utilities.MonoTools.Runtime
{
    public  abstract class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        public virtual void Awake()
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

    public  abstract class MonoSingletonPersistent<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        public virtual void Awake()
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