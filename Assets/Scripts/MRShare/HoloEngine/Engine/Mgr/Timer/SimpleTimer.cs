/****************************************************************************
* ScriptType: 主框架工具 - 简单定时器
* 核心功能:   基于Unity Monobehaver的简单计时器
* 
* 修改人:     袁楠
* 修改时间:   2021/6/15
****************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloEngine
{
    public class SimpleTimer : MonoBehaviour
    {
        private Dictionary<Action, float> mIntervalDic = new Dictionary<Action, float>();
        private List<Action> triggers = new List<Action>();

        private void Awake()
        {
            StartCoroutine(UpdateTimer());
        }

        IEnumerator UpdateTimer()
        {
            while (true)
            {
                if (mIntervalDic.Count > 0)
                {
                    triggers.Clear();
                    foreach (KeyValuePair<Action, float> KeyValue in mIntervalDic)
                    {
                        if (KeyValue.Value <= Time.time)
                        {
                            triggers.Add(KeyValue.Key);
                        }
                    }
                    for (int i = 0; i < triggers.Count; i++)
                    {
                        Action func = triggers[i];
                        mIntervalDic.Remove(func);

                        func();
                    }
                }
                yield return 1;
            }
        }

        public void AddTimer(float interval, Action func)
        {
            if (null != func)
            {
                if (interval <= 0)
                {
                    func();
                    return;
                }
                mIntervalDic[func] = Time.time + interval;
            }
        }

        public void RemoveTimer(Action func)
        {
            if (null != func)
            {
                if (mIntervalDic.ContainsKey(func))
                {
                    mIntervalDic.Remove(func);
                }
            }
        }

        public void ClearAll()
        {
            mIntervalDic.Clear();
            triggers.Clear();
        }

        public void Destroy()
        {
            Destroy(this);
        }

        void OnDestroy()
        {
            ClearAll();
            mIntervalDic = null;
            triggers = null;
            StopAllCoroutines();
        }
    }
}