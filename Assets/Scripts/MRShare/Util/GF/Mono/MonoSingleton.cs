using UnityEngine;

namespace GF
{
    public class MonoSingleton<T> : GMono where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                        Debug.Log($"Can find the instance of {typeof(T).Name} in scene!");
                }
                return instance;
            }
        }

        protected override void OnBeforeDestroy()
        {

        }
    }
}
