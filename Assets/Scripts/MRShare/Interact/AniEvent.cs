using UnityEngine;

namespace HoloShare
{
    public class AniEvent : MonoBehaviour
    {
        public ICanPlay iCanPlay;

        public Animator ani;

        private void OnAnimatorDefaltStateStart()
        {
            if (iCanPlay != null)
            {
                iCanPlay.CanPlay = true;
            }
        }

        public void AddEventToAnimation(Animator animator)
        {
            ani = animator;

            if (ani != null)
            {
                if (ani.runtimeAnimatorController == null) return;

                AnimationClip animationClip;

                var stateInfo = ani.GetCurrentAnimatorStateInfo(0);
                if (stateInfo.length > 0)
                {
                    if (ani.GetCurrentAnimatorClipInfo(0).Length > 0)
                    {
                        animationClip = ani.GetCurrentAnimatorClipInfo(0)[0].clip;

                        AnimationEvent aniEvent = new AnimationEvent();
                        aniEvent.functionName = nameof(OnAnimatorDefaltStateStart);
                        aniEvent.time = 0;
                        animationClip.AddEvent(aniEvent);
                    }

                }

            }
        }
    }
}