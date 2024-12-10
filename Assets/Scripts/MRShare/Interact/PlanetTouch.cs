//using HoloSupExp;
//using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.Events;
using TouchBase = Assets.PICOSDKWrapper.TouchBase;

namespace HoloShare
{
    /// <summary>
    /// Unity event for a pointer event. Contains the pointer event data.
    /// </summary>
    [System.Serializable]
    public class PointerUnityEvent : UnityEvent { }

    /// <summary>
    /// 专用于点击互动的通用脚本
    /// </summary>

    public class PlanetTouch : TouchBase, ICanPlay
    {
        public UnityEvent onTouch = new UnityEvent();
        public UnityEvent onTouchCompleted = new UnityEvent();
        /// <summary>
        /// Unity event raised on pointer clicked.
        /// </summary>
        public PointerUnityEvent ClickedEvent = new PointerUnityEvent();

        //private bool isPreview;
        //public bool IsPreview { get => isPreview; set => isPreview = value; }
        private bool canPlay;
        public bool CanPlay
        {
            get => canPlay; set
            {
                canPlay = value;
            }
        }
        //private bool _isTouch = true;

        [SerializeField]
        private Animator ani;

        public Animator Ani { get => ani; set => ani = value; }

        private void Awake()
        {
            OnAwake();

        }


        private void OnEnable()
        {
            Enable();
        }



        protected virtual void OnAwake()
        {
            if (Ani == null)
            {
                Ani = GetComponent<Animator>();
            }

            if (Ani != null)
            {
                var temp = Ani.gameObject.AddComponent<AniEvent>();

                temp.iCanPlay = this;
                temp.ani = Ani;
                temp.AddEventToAnimation(Ani);
            }
        }

        protected virtual void Enable()
        {
            CanPlay = true;
        }


        #region Hololens和手机端调用
        public override void OnTouchStarted()
        {
            ////限制LLPFS模式下的触发条件
            //if (!_isTouch)
            //    return;

            //if (isPreview == false) return;

            base.OnTouchStarted();

            OnClickAction();


        }

        public override void OnTouchUpdated()
        {
            ////限制LLPFS模式下的触发条件
            //if (!_isTouch)
            //    return;

            //if (isPreview == false) return;

            base.OnTouchUpdated();
        }

        public override void OnTouchCompleted()
        {
            ////限制LLPFS模式下的触发条件
            //if (!_isTouch)
            //    return;

            //if (isPreview == false) return;

            base.OnTouchCompleted();
            onTouchCompleted.Invoke();
        }

        public override void OnPointerClicked()
        {
            //陆战之王中点击敌军坦克isPreview会变成false,莫名其妙，所以将这部分代码拿到前面来
            //if (!eventData.used)
                ClickedEvent.Invoke();

            ////限制LLPFS模式下的触发条件
            //if (!_isTouch)
            //    return;

            //if (isPreview == false) return;

            base.OnPointerClicked();

            OnClickAction();
        }
        #endregion

        protected virtual void OnClickAction()
        {
            onTouch?.Invoke();
        }

        /// <summary>
        /// XRInspiro里调用
        /// </summary>
        public override void TouchInteraction()
        {
            ////限制LLPFS模式下的触发条件
            //if (!_isTouch)
            //    return;

            //if (isPreview == false) return;

            base.TouchInteraction();
            OnClickAction();

        }

        //public void OnEditModeToggle(bool toggle)
        //{
        //    IsPreview = !toggle;
        //}

        //public void OnLLPFSModeToggle(bool toggle)
        //{
        //    _isTouch = toggle;
        //}
    }
}