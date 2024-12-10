using UnityEngine;
using HoloEngine;

namespace HoloShare
{
    /// <summary>
    /// 互动控制器
    /// 用于处理同一时刻只能有一个音频或动画在执行的情况
    /// </summary>
    public class InteractiveCtrl : SingletonMono<InteractiveCtrl>
    {
        private AnimatorTouch animatorTouch;

        public AnimatorTouch AnimatorTouch
        {
            get => animatorTouch;
            set
            {
                //Debug.Log("InteractiveCtrl: reset  " + currentAni.gameObject.name);
                if (animatorTouch == value)
                {
                    return;
                }

                if (animatorTouch != null)
                {
                    var currentAni = animatorTouch.Ani;

                    // 把之前的状态机重置回默认状态
                    //if (currentAni.GetCurrentAnimatorStateInfo(0).IsName(AnimatorStr.IDLE) == false)
                    {
                        if (currentAni != null)
                        {
                            currentAni.ResetTrigger(AnimatorStr.TOUCH);
                            // 注意：在状态机中要确保默认状态的名字为"idle"，否则如下代码不生效
                            currentAni.Play(AnimatorStr.IDLE);
                        }
                        //Debug.Log("InteractiveCtrl: reset " + currentAni.gameObject.name);
                        animatorTouch.CanPlay = true;

                    }
                }
                animatorTouch = value;
            }
        }
    }
}