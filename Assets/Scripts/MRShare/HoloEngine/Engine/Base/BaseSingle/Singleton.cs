/****************************************************************************
* ScriptType: 主框架 - 单例模块
* 核心功能:   游戏的单例功能
* 请勿修改!!!
* 
* 修改人:     袁楠
* 修改时间:   2021/6/9
****************************************************************************/

using System;

namespace HoloEngine
{
    /// <summary>
    /// 单例类
    /// </summary>
    /// <typeparam name="T">需要单例的类型</typeparam>
    public class Singleton<T> : IDisposable where T : class
    {
        private static T m_instance;
        public static T Inst
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = Activator.CreateInstance<T>();
                }
                return m_instance;
            }
        }

        public Singleton()
        {
            Init();
        }

        public virtual void Init() { }

        public virtual void Dispose()
        {
            m_instance = null;
        }
    }
}
