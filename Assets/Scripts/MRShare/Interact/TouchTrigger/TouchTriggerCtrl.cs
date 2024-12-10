using HoloEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloShare
{
    public class TouchTriggerCtrl : SingletonMono<TouchTriggerCtrl>
    {
        private IStopInteract mStopInteract;

        public IStopInteract stopInteract
        {
            get => mStopInteract;
            set
            {
                if (mStopInteract == value) return;

                mStopInteract?.StopCurr();

                mStopInteract = value;
            }
        }
    }

}