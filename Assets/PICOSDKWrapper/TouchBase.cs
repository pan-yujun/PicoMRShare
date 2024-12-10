using GF;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Assets.PICOSDKWrapper
{
    [RequireComponent(typeof(XRSimpleInteractable))]
    public class TouchBase : GMono
    {
        private XRSimpleInteractable mXRSimple;
        private bool mIsLeftHovering = false;// 左手射线悬浮
        private bool mIsRightHovering = false;// 右手射线悬浮
        private bool mIsPressing = false;
        private void Start()
        {
            AppDispatcher.Instance.AddListener(DispatcherMsg.LeftTriggePerformed, OnLeftTriggeStarted);
            AppDispatcher.Instance.AddListener(DispatcherMsg.LeftTriggeCanceled, OnLeftTriggeCanceled);
            AppDispatcher.Instance.AddListener(DispatcherMsg.RightTriggePerformed, OnRightTriggeStarted);
            AppDispatcher.Instance.AddListener(DispatcherMsg.RightTriggeCanceled, OnRightTriggeCanceled);
            if (mXRSimple == null)
            {
                mXRSimple = GetComponent<XRSimpleInteractable>();
            }
            mXRSimple.hoverEntered.AddListener(OnHoverEntered);
            mXRSimple.hoverExited.AddListener(OnHoverExited);
        }
        private void OnDestroy()
        {
            AppDispatcher.Instance.RemoveListener(DispatcherMsg.LeftTriggePerformed, OnLeftTriggeStarted);
            AppDispatcher.Instance.RemoveListener(DispatcherMsg.LeftTriggeCanceled, OnLeftTriggeCanceled);
            AppDispatcher.Instance.RemoveListener(DispatcherMsg.RightTriggePerformed, OnRightTriggeStarted);
            AppDispatcher.Instance.RemoveListener(DispatcherMsg.RightTriggeCanceled, OnRightTriggeCanceled);
        }
        #region 按键事件
        /// <summary>
        /// Left按键按下
        /// </summary>
        /// <param name="param"></param>
        private void OnLeftTriggeStarted(object param = null)
        {
            //Debug.Log($"[TouchBase]OnLeftTriggeStarted>>{this.name},{mIsLeftHovering}");
            if (mIsLeftHovering)
            {
                mIsPressing = true;
                OnPointerDown();
            }
        }
        /// <summary>
        /// Left按键抬起
        /// </summary>
        /// <param name="param"></param>
        private void OnLeftTriggeCanceled(object param = null)
        {
            //Debug.Log($"[TouchBase]OnLeftTriggeCanceled>>{this.name},mIsLeftHovering:{mIsLeftHovering},mIsPressing:{mIsPressing}");
            if (mIsPressing)
            {
                mIsPressing = false;
                OnPointerUp();
                OnPointerClicked();
            }
        }
        /// <summary>
        /// Left按键按下
        /// </summary>
        /// <param name="param"></param>
        private void OnRightTriggeStarted(object param = null)
        {
            //Debug.Log($"[TouchBase]OnRightTriggeStarted>>{this.name},{mIsRightHovering}");
            if (mIsRightHovering)
            {
                mIsPressing = true;
                OnPointerDown();
            }
        }
        /// <summary>
        /// Right按键抬起
        /// </summary>
        /// <param name="param"></param>
        private void OnRightTriggeCanceled(object param = null)
        {
            //Debug.Log($"[TouchBase]OnRightTriggeCanceled>>{this.name},mIsRightHovering:{mIsLeftHovering},mIsPressing:{mIsPressing}");
            if (mIsPressing)
            {
                mIsPressing = false;
                OnPointerUp();
                OnPointerClicked();
            }
        }
        #endregion

        #region 射线悬浮
        public void OnHoverEntered(HoverEnterEventArgs args)
        {
            //Debug.Log($"[TouchBase]OnHoverEnter>>{this.name},{args}");
            if (args.interactorObject.handedness == UnityEngine.XR.Interaction.Toolkit.Interactors.InteractorHandedness.Left)
            {
                mIsLeftHovering = true;
            }
            else if (args.interactorObject.handedness == UnityEngine.XR.Interaction.Toolkit.Interactors.InteractorHandedness.Right)
            {
                mIsRightHovering = true;
            }
        }
        public void OnHoverExited(HoverExitEventArgs args)
        {
            //Debug.Log($"[TouchBase]OnHoverExited>>{this.name}");
            if (args.interactorObject.handedness == UnityEngine.XR.Interaction.Toolkit.Interactors.InteractorHandedness.Left)
            {
                mIsLeftHovering = false;
            }
            else if (args.interactorObject.handedness == UnityEngine.XR.Interaction.Toolkit.Interactors.InteractorHandedness.Right)
            {
                mIsRightHovering = false;
            }
            if (mIsPressing)
            {
                mIsPressing = false;
                OnPointerUp();
            }
        }
        #endregion
       
        public virtual void TouchInteraction() { }

        public virtual void OnPointerClicked()
        {

        }

        public virtual void OnPointerDown()
        {

        }

        public virtual void OnPointerDragged()
        {

        }

        public virtual void OnPointerUp()
        {

        }

        public virtual void OnTouchCompleted()
        {

        }

        public virtual void OnTouchStarted()
        {

        }

        public virtual void OnTouchUpdated()
        {

        }

        protected override void OnBeforeDestroy()
        {

        }

       
    }
}