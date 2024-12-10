using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HoloShare
{
    public enum AudioOrAnimator
    {
        Audio,
        Animator,
        AnimationClip
    }

    public class TouchToActivite : TouchTrigger
    {
        [SerializeField]
        private GameObject[] m_TargetArr;
        [SerializeField]
        private AudioSource[] m_AudioSourceArr;
        [SerializeField]
        private Animator[] m_AnimatorArr;
        [SerializeField]
        private AnimationClip[] m_AnimationClipArr;
        [SerializeField]
        private AudioOrAnimator m_AudioOrAnimator;
        [SerializeField]
        private GameObject[] m_disabledObjArr;

        [SerializeField]
        private float m_DelayTime = 0;
        [SerializeField]
        private bool m_StopAnim = false;

        public UnityEvent appearEvent;
        private int mClickNum = 0;

        private float mActiviteTime = 0;
        private Coroutine mWaitCor;

        protected override void OnAwake()
        {
            base.OnAwake();
            mActiviteTime = 0;
            SetTargetState(false);
        }

        protected override void TriggerInteraction()
        {
            base.TriggerInteraction();
            mClickNum++;

            int num = mClickNum % 2;
            if (m_StopAnim)
            {
                if (num == 0)
                {
                    OnStopAnima();
                }
            }

            if (CanPlay)
            {
                if (m_StopAnim && num == 0) return;
                SetTargetState(true);
                appearEvent?.Invoke();
                SetOthersState(false);
                CanPlay = false;
                mActiviteTime = GetPlayTime();
                if (mWaitCor != null) StopCoroutine(mWaitCor);
                mWaitCor = StartCoroutine(CorWaitToHide(mActiviteTime, () =>
                {
                    mClickNum = 0;
                    CanPlay = true;
                    mActiviteTime = 0;
                    if (mWaitCor != null) StopCoroutine(mWaitCor);
                }));
            }
        }

        private float GetPlayTime()
        {
            float back = 0;

            switch (m_AudioOrAnimator)
            {
                case AudioOrAnimator.Audio:
                    for (int i = 0; i < m_AudioSourceArr.Length; i++)
                    {
                        back += m_AudioSourceArr[i].clip.length;
                    }
                    break;
                case AudioOrAnimator.Animator:
                    for (int i = 0; i < m_AnimatorArr.Length; i++)
                    {
                        back += m_AnimatorArr[i].runtimeAnimatorController.animationClips[0].length;
                    }
                    break;
                case AudioOrAnimator.AnimationClip:
                    for (int i = 0; i < m_AnimationClipArr.Length; i++)
                    {
                        back += m_AnimationClipArr[i].length;
                    }
                    break;
                default:
                    break;
            }

            return back;
        }

        private void SetTargetState(bool state)
        {
            for (int i = 0; i < m_TargetArr.Length; i++)
            {
                m_TargetArr[i].SetActive(state);
            }
        }

        private IEnumerator CorWaitToHide(float time, System.Action action)
        {
            yield return new WaitForSeconds(time + m_DelayTime);
            SetTargetState(false);
            action?.Invoke();
        }

        protected override void OnStopAnima()
        {
            base.OnStopAnima();
            if (mWaitCor != null) StopCoroutine(mWaitCor);
            SetTargetState(false);
            CanPlay = true;
            mClickNum = 0;
        }

        private void SetOthersState(bool active)
        {
            if (m_disabledObjArr != null && m_disabledObjArr.Length > 0)
            {
                for (int i = 0; i < m_disabledObjArr.Length; i++)
                {
                    if (m_disabledObjArr[i] != null)
                        m_disabledObjArr[i].SetActive(active);
                }
            }
        }

        public void SetPlayState(bool active)
        {
            CanPlay = active;
            if (active)
                mClickNum = 0;
            else
                mClickNum = 1;



        }

        public void InitData()
        {
            mClickNum = 0;
        }
    }
}