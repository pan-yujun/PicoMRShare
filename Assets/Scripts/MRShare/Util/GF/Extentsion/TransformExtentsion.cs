using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GF
{
    public static class TransformExtentsion
    {
        public static void SetPosX(this Transform tran, float x)
        {
            Vector3 pos = tran.position;
            pos.x = x;
            tran.position = pos;
        }

        public static void SetPosY(this Transform tran, float y)
        {
            Vector3 pos = tran.position;
            pos.y = y;
            tran.position = pos;
        }

        public static void SetLocalPosY(this Transform tran, float y)
        {
            Vector3 pos = tran.localPosition;
            pos.y = y;
            tran.localPosition = pos;
        }

        public static void SetPosZ(this Transform tran, float z)
        {
            Vector3 pos = tran.position;
            pos.z = z;
            tran.position = pos;
        }

        public static Transform TryFind(this Transform parent, string searchPath)
        {
            Transform target = parent.Find(searchPath);

            if (target == null)
            {
#if UNITY_EDITOR
                // Debug.Log($"<color=red>[{parent.name}] can not find child:{searchPath}</color>");
#endif          
            }
            return target;
        }

        //public static void ChangeLayerIncludeChild(this Transform t, int layer)
        //{
        //    t.gameObject.layer = layer;
        //    foreach (Transform tran in t.GetComponentsInChildren<Transform>())
        //    {//遍历当前物体及其所有子物体
        //        tran.gameObject.layer = layer;//更改物体的Layer层
        //    }
        //}
        public static void ChangeLayerIncludeChild(this Transform t, int layer)
        {
            if (t.GetComponent<DontChangeLayer>() != null) return;

            t.gameObject.layer = layer;
            for (int i = 0; i < t.childCount; i++)
            {
                t.GetChild(i).ChangeLayerIncludeChild(layer);
            }
        }
    }
}