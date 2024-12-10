/****************************************************************************
* ScriptType: 主框架工具 - 标准定时器
* 核心功能:   基于Unity Monobehaver的标准计时器
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
    public class GeneralTimer : MonoBehaviour
    {
        public const int INFINITE_LOOP = -1;

        private List<TimerTask> timerInfos = new List<TimerTask>();

        private void Awake()
        {
            StartCoroutine(UpdateTimer());
        }

        IEnumerator UpdateTimer()
        {
            while (true)
            {
                if (timerInfos.Count > 0)
                {
                    for (int i = timerInfos.Count - 1; i >= 0; i--)
                    {
                        TimerTask timerInfo = timerInfos[i];
                        if (!timerInfo.isActive) continue;
                        if (timerInfo.time <= Time.time) 
                        {
                            if (timerInfo.repeatCount != INFINITE_LOOP)
                            {
                                timerInfo.repeatCount--;
                            }
                            if (timerInfo.repeatCount == 0)
                            {
                                timerInfo.Dispose();
                            }
                            else
                            {
                                timerInfo.time = GetTriggerTime(timerInfo.interval);
                            }
                            timerInfo.onCallBack?.Invoke(timerInfo);
                        }
                    }
                }
                yield return 1;
            }
        }

        /// <summary>
        /// 添加一个定时任务
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="onCallBack"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public TimerTask AddTimer(float interval, Action<TimerTask> onCallBack, params object[] args)
        {
            TimerTask timeInfo = new TimerTask(interval, onCallBack, args);
            timeInfo.timer = this;
            AddTimer(timeInfo);
            return timeInfo;
        }

        /// <summary>
        /// 添加一个重复触发repeatCount次的定时任务
        /// </summary>
        /// <param name="repeatCount"></param>
        /// <param name="interval"></param>
        /// <param name="onCallBack"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public TimerTask AddRepeatTimer(int repeatCount, float interval, Action<TimerTask> onCallBack, params object[] args)
        {
            TimerTask timeInfo = new TimerTask(repeatCount, interval, onCallBack, args);
            timeInfo.timer = this;
            AddTimer(timeInfo);
            return timeInfo;
        }

        /// <summary>
        /// 添加一个循环的定时任务
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="onCallBack"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public TimerTask AddLoopTimer(float interval, Action<TimerTask> onCallBack, params object[] args)
        {
            TimerTask timeInfo = new TimerTask(INFINITE_LOOP, interval, onCallBack, args);
            timeInfo.timer = this;
            AddTimer(timeInfo);
            return timeInfo;
        }

        public void AddTimer(TimerTask timerInfo)
        {
            if (null != timerInfo)
            {
                if (timerInfo.interval <= 0)
                {
                    timerInfo.onCallBack(timerInfo);
                    return;
                }
                timerInfos.Add(timerInfo);
            }
        }

        public void RemoveTimer(TimerTask timerInfo)
        {
            if (null != timerInfo)
            {
                if (timerInfos.Contains(timerInfo))
                {
                    timerInfos.Remove(timerInfo);
                }
            }
        }

        public void ClearAll()
        {
            timerInfos.Clear();
        }

        public void Destroy()
        {
            Destroy(this);
        }

        public static float GetTriggerTime(float interval)
        {
            return Time.time + interval;
        }

        void OnDestroy()
        {
            ClearAll();
            timerInfos = null;

            StopAllCoroutines();
        }
    }
}