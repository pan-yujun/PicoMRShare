using HoloEngine;
using HoloShare;
using UnityEngine;

public class NonSingleShowCtrl : Singleton<NonSingleShowCtrl>
{
    private Animator lastAnimator;

    public void SetLastAnimator(Animator animator)
    {
        lastAnimator = animator;
    }

    public void PlayAni()
    {
        if (lastAnimator != null)
        {
            if (lastAnimator.GetCurrentAnimatorStateInfo(0).length > 0 && lastAnimator.GetCurrentAnimatorStateInfo(0).IsName("chuxian"))
            {
                lastAnimator.ResetTrigger(AnimatorStr.TOUCH);
                lastAnimator.SetTrigger("BackIdle");
            }


        }
    }
}
