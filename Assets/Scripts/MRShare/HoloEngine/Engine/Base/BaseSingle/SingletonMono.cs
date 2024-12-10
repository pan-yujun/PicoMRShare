/****************************************************************************
* ScriptType: 主框架 - Monobehavior单例模块
* 核心功能:   游戏的Monobehavior单例功能
* 请勿修改!!!
* 
* 修改人:     袁楠
* 修改时间:   2021/6/9
****************************************************************************/

using System;
using UnityEngine;

namespace HoloEngine
{
    /// <summary>
    /// 单例类
    /// </summary>
    /// <typeparam name="T">需要单例的类型</typeparam>
    public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
    {
        protected static bool IsAppQuit = false;

        private static T m_instance;
        public static T Inst
        {
            get
            {
                if (m_instance == null && !IsAppQuit)
                {
                    CreateInstance();
                }
                return m_instance;
            }
        }
        public void Release()
        {
            if (m_instance != null && !IsAppQuit)
            {
                Destroy(m_instance);
            }
        }
        private static void CreateInstance()
        {
            GameObject instanceGO = new GameObject(typeof(T).Name);
            m_instance = instanceGO.AddComponent<T>();
        }

        protected virtual void Awake()
        {
            if (m_instance == null)
                m_instance = (T)this;
        }

        private void OnApplicationQuit()
        {
            IsAppQuit = true;
        }

        protected virtual void OnDestroy()
        {
            m_instance = null;
        }
    }
}
