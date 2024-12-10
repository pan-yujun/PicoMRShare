/****************************************************************************
* ScriptType: 主框架 - TimeMgr
* 核心功能：  游戏定时器管理类
* 请勿修改!!!
* 
* 修改人:     袁楠
* 修改时间:   2021/7/28
****************************************************************************/

using System;
using UnityEngine;

namespace HoloEngine
{
    public class TimerMgr : SingletonMono<TimerMgr>
    {
        public SimpleTimer SimpleTimer { get; private set; }
        public GeneralTimer Timer { get; private set; }

        #region Life
        protected override void Awake()
        {
            base.Awake();
            gameObject.hideFlags = HideFlags.HideAndDontSave;
            DontDestroyOnLoad(this);
            SimpleTimer = CreateTimer<SimpleTimer>();
            Timer = CreateTimer<GeneralTimer>();
            OnInit();
        }

        private void OnInit()
        {
            if (SimpleTimer != null)
                SimpleTimer.ClearAll();
            if (Timer != null)
                Timer.ClearAll();
        }

        private T CreateTimer<T>() where T : MonoBehaviour
        {
            GameObject timer = new GameObject(typeof(T).ToString());
            timer.transform.SetParent(transform);
            return timer.AddComponent<T>();
        }
        #endregion
    }
}
