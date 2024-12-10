using UnityEngine;

namespace GF
{
    public static class ComponentExtentsion
    {
        public static T TryGetComp<T>(this Component com)
        {
            T target = com.GetComponent<T>();

            if (target == null)
            {
#if UNITY_EDITOR
                // Debug.Log($"<color=red>[{com.gameObject.name}] can not Get component:{typeof(T).Name}</color>");
#endif           
            }

            return target;
        }
    }
}