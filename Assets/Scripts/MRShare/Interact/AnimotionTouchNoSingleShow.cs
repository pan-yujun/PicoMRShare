//using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
//using HoloSupExp;
using System.Collections.Generic;
using UnityEngine.Events;
using TouchBase = Assets.PICOSDKWrapper.TouchBase;

namespace HoloShare
{

    public class AnimotionTouchNoSingleShow : TouchBase, ICanPlay, IStopInteract, IReset
    {
        [SerializeField]
        private Animator ani;
        public Animator Ani { get => ani; set => ani = value; }

        public List<Animator> notSingleShowAnis;

        private bool canPlay;

        private bool isPreview;

        private AudioSource aud;
        public UnityEvent AnimotionOnTouch = new UnityEvent();
        public UnityEvent TriggerTouch = new UnityEvent();
        public UnityEvent TriggerIdle = new UnityEvent();
        public bool IsPreview
        {
            set
            {
                isPreview = value;
            }
        }

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

            //AnimotionTouchNoSingleShowFix animotionTouchNoSingleShowFix = this.gameObject.AddComponent<AnimotionTouchNoSingleShowFix>();
            //animotionTouchNoSingleShowFix.Ani = Ani;
            //if (animotionTouchNoSingleShowFix.Ani == null)
            //{
            //    animotionTouchNoSingleShowFix.Ani = GetComponentInChildren<Animator>();
            //}

            //if (animotionTouchNoSingleShowFix.Ani != null)
            //{
            //    var temp = animotionTouchNoSingleShowFix.Ani.gameObject.AddComponent<AniEvent>();

            //    temp.iCanPlay = this;
            //    temp.ani = animotionTouchNoSingleShowFix.Ani;
            //    temp.AddEventToAnimation(animotionTouchNoSingleShowFix.Ani);
            //}
            //animotionTouchNoSingleShowFix.notSingleShowAnis = notSingleShowAnis;
            //animotionTouchNoSingleShowFix.AnimotionOnTouch = AnimotionOnTouch;
            //animotionTouchNoSingleShowFix.aud = GetComponent<AudioSource>();
            //animotionTouchNoSingleShowFix.IsPreview = isPreview;

            //this.enabled = (false);
        }

        private void OnEnable()
        {
            CanPlay = true;
        }

        public override void TouchInteraction()
        {
            PlayInteraction();
            AnimotionOnTouch?.Invoke();
        }

        public void PlayInteraction()
        {
            //限制LLPFS模式下的触发条件
            if (!_isTouch)
                return;

            if (isPreview == false) return;
            //Debug.Log("canplay:" + CanPlay);
            if (CanPlay == false)
            {

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
                return;
            }

            Ani.SetTrigger(AnimatorStr.TOUCH);
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


            //   interactiveCtrlNoSingleShow.Inst.AnimatorTouchSingleShow = this;
            if (gameObject.tag.Equals(Tag.SINGLE_SHOW))
            {
                interactiveCtrlNoSingleShow.Inst.AnimatorTouchSingleShow = this;
                InteractiveCtrl.Inst.AnimatorTouch = null;
                TouchTriggerCtrl.Inst.stopInteract = null;
                interactiveCtrlNoSingleShowFix.Inst.AnimatorTouchSingleShow = null;
            }
            CanPlay = false;
        }

        #region Override

        public override void OnTouchStarted()
        {
            base.OnTouchStarted();

            PlayInteraction();
            AnimotionOnTouch?.Invoke();
        }

        public override void OnPointerClicked()
        {
            base.OnPointerClicked();

            PlayInteraction();
            AnimotionOnTouch?.Invoke();
        }

        public void OnEditModeToggle(bool toggle)
        {
            IsPreview = !toggle;
        }

        #endregion Override
        private bool _isTouch = true;

        public void OnLLPFSModeToggle(bool toggle)
        {
            _isTouch = toggle;
        }

        public void StopCurr()
        {
            throw new System.NotImplementedException();
        }

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