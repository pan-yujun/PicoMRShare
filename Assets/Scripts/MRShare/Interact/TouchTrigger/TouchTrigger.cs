//using HoloSupExp;
//using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchBase = Assets.PICOSDKWrapper.TouchBase;

namespace HoloShare
{
    /// <summary>
    /// 触摸触发
    /// </summary>
    public class TouchTrigger : TouchBase, ICanPlay, IStopInteract
    {
        private bool canPlay;
        protected bool isPreview;
        private bool _isTouch = true;
        public List<Animator> notSingleShowAnis;

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

        private void OnEnable()
        {
            Enable();
        }

        private void Awake()
        {
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        protected virtual void Enable()
        {
            CanPlay = true;
        }

        protected virtual void OnAwake() { }
        protected virtual void OnStart() { }
        protected virtual void OnUpdate() { }
        protected virtual void OnStopAnima() { }

        protected virtual void OnTouch()
        {
            TriggerInteraction();
        }

        protected virtual void OnClick()
        {
            TriggerInteraction();
        }

        protected virtual void TriggerInteraction()
        {
            

            if (CanPlay == false)
            {
                if (gameObject.tag.Equals(Tag.SINGLE_SHOW))
                {
                    if (notSingleShowAnis != null && notSingleShowAnis.Count != 0)
                    {
                        foreach (var item in notSingleShowAnis)
                        {
                            item.Play(AnimatorStr.IDLE);
                        }
                    }
                }
            }
            else
            {
                if (notSingleShowAnis != null && notSingleShowAnis.Count != 0)
                {
                    foreach (var item in notSingleShowAnis)
                    {
                        item.SetTrigger(AnimatorStr.TOUCH);
                    }
                }

                if (gameObject.tag.Equals(Tag.SINGLE_SHOW))
                {
                    InteractiveCtrl.Inst.AnimatorTouch = null;
                    TouchTriggerCtrl.Inst.stopInteract = this;
					interactiveCtrlNoSingleShow.Inst.AnimatorTouchSingleShow = null;
                    interactiveCtrlNoSingleShowFix.Inst.AnimatorTouchSingleShow = null;
                }
            }
        }

        public override void OnTouchStarted()
        {
            //限制LLPFS模式下的触发条件
            if (!_isTouch)
                return;

            if (!isPreview) return;

            base.OnTouchStarted();
            OnTouch();
        }

        public override void OnPointerClicked()
        {
            //限制LLPFS模式下的触发条件
            if (!_isTouch)
                return;

            if (!isPreview) return;

            base.OnPointerClicked();
            OnClick();
        }

        /// <summary>
        /// pc编辑器内调用
        /// </summary>
        public override void TouchInteraction() 
        {
            //限制LLPFS模式下的触发条件
            if (!_isTouch)
                return;

            if (!isPreview) return;

            base.TouchInteraction();
            TriggerInteraction();
        }


        public void OnEditModeToggle(bool toggle)
        {
            IsPreview = !toggle;
        }

        public void StopCurr()
        {
            OnStopAnima();
        }

        public void OnLLPFSModeToggle(bool toggle)
        {
            _isTouch = toggle;
        }
    }
}