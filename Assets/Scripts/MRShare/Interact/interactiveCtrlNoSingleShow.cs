using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloEngine;
namespace HoloShare
{
    public class interactiveCtrlNoSingleShow : SingletonMono<interactiveCtrlNoSingleShow>
    {
        private AnimotionTouchNoSingleShow animatorTouchSingleShow;

        public AnimotionTouchNoSingleShow AnimatorTouchSingleShow
        {
            get => animatorTouchSingleShow;
            set
            {
                //Debug.Log("InteractiveCtrl: reset  " + currentAni.gameObject.name);
                if (animatorTouchSingleShow == value)
                {
                    return;
                }

                if (animatorTouchSingleShow != null)
                {
                    var currentAni = animatorTouchSingleShow.Ani;

                    // 把之前的状态机重置回默认状态
                    //if (currentAni.GetCurrentAnimatorStateInfo(0).IsName(AnimatorStr.IDLE) == false)
                    {
                        currentAni.ResetTrigger(AnimatorStr.TOUCH);
                        // 注意：在状态机中要确保默认状态的名字为"idle"，否则如下代码不生效
                        currentAni.Play(AnimatorStr.IDLE);
                        //Debug.Log("InteractiveCtrl: reset " + currentAni.gameObject.name);
                        animatorTouchSingleShow.CanPlay = true;
                    }
                }
                animatorTouchSingleShow = value;
            }
        }
    }
}