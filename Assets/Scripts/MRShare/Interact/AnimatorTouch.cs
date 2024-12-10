//using HoloSupExp;
//using Microsoft.MixedReality.Toolkit.Input;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TouchBase = Assets.PICOSDKWrapper.TouchBase;

namespace HoloShare
{
    public interface ICanPlay
    {
        bool CanPlay { get; set; }
    }

    public class AnimatorTouch : TouchBase, ICanPlay, IReset
    {
        [SerializeField]
        private Animator ani;
        [SerializeField]
        private string m_AnimTrigger;

        [Header("只是按钮点击")]
        [SerializeField]
        private bool m_OnlyClick;

        public Animator Ani { get => ani; set => ani = value; }

        public List<Animator> notSingleShowAnis;
        public UnityEvent AnimationOnTouch = new UnityEvent();
        public UnityEvent TriggerTouch = new UnityEvent();
        public UnityEvent TriggerIdle = new UnityEvent();



        private bool canPlay;

        //private bool isPreview;

        private AudioSource aud;

        //public bool IsPreview
        //{
        //    set
        //    {
        //        isPreview = value;
        //    }
        //}

        public bool CanPlay
        {
            get => canPlay; set
            {
                canPlay = value;
            }
        }

        private void Awake()
        {
            if (Ani == null)
            {
                Ani = GetComponentInChildren<Animator>();
            }

            if (Ani != null)
            {
                var temp = Ani.gameObject.AddComponent<AniEvent>();

                temp.iCanPlay = this;
                temp.ani = Ani;
                temp.AddEventToAnimation(Ani);
            }

            aud = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            CanPlay = true;
        }

        public override void TouchInteraction()
        {
            PlayInteraction();
            AnimationOnTouch?.Invoke();
        }

        public void PlayInteraction()
        {
            Debug.Log("--------------可能会影响到局域网的功能");
            //限制LLPFS模式下的触发条件
            //if (!_isTouch)
            //    return;

            //if (isPreview == false) return;
            //Debug.Log("canplay:" + CanPlay);
            if (CanPlay == false)
            {
                if (gameObject.tag.Equals(Tag.SINGLE_SHOW))
                {
                    if (Ani != null)
                        Ani.Play(AnimatorStr.IDLE);
                    TriggerIdle?.Invoke();
                    if (notSingleShowAnis != null && notSingleShowAnis.Count != 0)
                    {
                        foreach (var item in notSingleShowAnis)
                        {
                            item.Play(AnimatorStr.IDLE);
                        }
                    }
                    CanPlay = true;
                }
                return;
            }

            string trigger = string.IsNullOrEmpty(m_AnimTrigger) ? AnimatorStr.TOUCH : m_AnimTrigger;
            if (Ani != null)
                Ani.SetTrigger(trigger);
            TriggerTouch?.Invoke();
            if (notSingleShowAnis != null && notSingleShowAnis.Count != 0)
            {
                foreach (var item in notSingleShowAnis)
                {
                    item.SetTrigger(AnimatorStr.TOUCH);
                }
            }

            if (aud != null)
                aud.Play();

            if (gameObject.tag.Equals(Tag.SINGLE_SHOW))
            {
                InteractiveCtrl.Inst.AnimatorTouch = this;
                TouchTriggerCtrl.Inst.stopInteract = null;
                interactiveCtrlNoSingleShow.Inst.AnimatorTouchSingleShow = null;
                interactiveCtrlNoSingleShowFix.Inst.AnimatorTouchSingleShow = null;
            }
            if (!m_OnlyClick)
            {
                CanPlay = false;
            }
        }

        #region Override

        public override void OnTouchStarted()
        {
            base.OnTouchStarted();

            PlayInteraction();
            AnimationOnTouch?.Invoke();
        }

        public override void OnPointerClicked()
        {
            base.OnPointerClicked();

            PlayInteraction();
            AnimationOnTouch?.Invoke();
        }

        //public void OnEditModeToggle(bool toggle)
        //{
        //    IsPreview = !toggle;
        //}

        #endregion Override



        //private bool _isTouch = true;

        //public void OnLLPFSModeToggle(bool toggle)
        //{
        //    _isTouch = toggle;
        //}

        public void ResetData()
        {
            if (Ani != null)
                Ani.Play(AnimatorStr.IDLE);
            TriggerIdle?.Invoke();
            if (notSingleShowAnis != null && notSingleShowAnis.Count != 0)
            {
                foreach (var item in notSingleShowAnis)
                {
                    item.Play(AnimatorStr.IDLE);
                }
            }
            CanPlay = true;
            if (aud != null)
                aud.Stop();

            if (gameObject.tag.Equals(Tag.SINGLE_SHOW))
            {
                InteractiveCtrl.Inst.AnimatorTouch = null;
                TouchTriggerCtrl.Inst.stopInteract = null;
                interactiveCtrlNoSingleShow.Inst.AnimatorTouchSingleShow = null;
                interactiveCtrlNoSingleShowFix.Inst.AnimatorTouchSingleShow = null;

            }

        }
    }
}