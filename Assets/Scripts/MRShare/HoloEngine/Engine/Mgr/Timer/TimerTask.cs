/****************************************************************************
* ScriptType: 主框架工具 - 标准定时器
* 核心功能:   基于Unity Monobehaver的标准计时器
* 
* 修改人:     袁楠
* 修改时间:   2021/6/15
****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace HoloEngine
{
    public class TimerTask : IDisposable
    {
        public GeneralTimer timer;
        public int repeatCount;
        public float interval;
        public Action<TimerTask> onCallBack;
        public object[] args;
        public float time;
        public bool isActive = true;

        public TimerTask(float interval, Action<TimerTask> onCallBack, params object[] args)
        {
            repeatCount = 1;
            this.interval = interval;
            this.onCallBack = onCallBack;
            this.args = args;
            time = GeneralTimer.GetTriggerTime(interval);
        }

        public TimerTask(int repeatCount, float interval, Action<TimerTask> onCallBack, params object[] args)
        {
            this.repeatCount = repeatCount;
            this.interval = interval;
            this.onCallBack = onCallBack;
            this.args = args;
            time = GeneralTimer.GetTriggerTime(interval);
        }

        public void SetActive(bool isActive)
        {
            if (this.isActive == isActive) return;

            this.isActive = isActive;
            if (this.isActive)
            {
                time = GeneralTimer.GetTriggerTime(interval);
            }
        }

        public void Dispose()
        {
            timer.RemoveTimer(this);
        }
    }
}