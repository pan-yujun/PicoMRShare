using HoloEngine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.PICOSDKWrapper
{
    /// <summary>
    /// 检测自定义按键
    /// </summary>
    public class InputActionManagerWrapper : SingletonMono<InputActionManagerWrapper>
    {
        public InputActionReference mLeftTriggerButton;
        public InputActionReference mRightTriggerButton;
        private InputAction mLeftTriggerButton_Action;
        private InputAction mRightTriggerButton_Action;
        private void Start()
        {
            mLeftTriggerButton_Action = GetInputAction(mLeftTriggerButton);
            mRightTriggerButton_Action = GetInputAction(mRightTriggerButton);
            if (mLeftTriggerButton_Action != null)
            {
                mLeftTriggerButton_Action.started += OnLeftTriggerStarted;
                mLeftTriggerButton_Action.performed += OnLeftTriggerPerformed;
                mLeftTriggerButton_Action.canceled += OnLeftTriggerCanceled;
            }
            if (mRightTriggerButton_Action != null)
            {
                mRightTriggerButton_Action.started += OnRightTriggerStarted;
                mRightTriggerButton_Action.performed += OnRightTriggerPerformed;
                mRightTriggerButton_Action.canceled += OnRightTriggerCanceled;
            }
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (mLeftTriggerButton_Action != null)
            {
                mLeftTriggerButton_Action.started -= OnLeftTriggerStarted;
                mLeftTriggerButton_Action.performed -= OnLeftTriggerPerformed;
                mLeftTriggerButton_Action.canceled -= OnLeftTriggerCanceled;
            }
            if (mRightTriggerButton_Action != null)
            {
                mRightTriggerButton_Action.started -= OnRightTriggerStarted;
                mRightTriggerButton_Action.performed -= OnRightTriggerPerformed;
                mRightTriggerButton_Action.canceled -= OnRightTriggerCanceled;
            }
        }
        private InputAction GetInputAction(InputActionReference actionReference)
        {
#pragma warning disable IDE0031 // Use null propagation -- Do not use for UnityEngine.Object types
            return actionReference != null ? actionReference.action : null;
#pragma warning restore IDE0031
        }

        #region 按钮检测
        private void OnLeftTriggerStarted(InputAction.CallbackContext context)
        {
            //Debug.Log($"[AnimatorTouch]OnLeftTriggerStarted>>{context.ReadValue<float>()}");
            AppDispatcher.Instance.Dispatch(DispatcherMsg.LeftTriggeStarted);
        }
        private void OnLeftTriggerPerformed(InputAction.CallbackContext context)
        {
            //Debug.Log($"[AnimatorTouch]OnLeftTriggerPerformed>>{context.ReadValue<float>()}");
            AppDispatcher.Instance.Dispatch(DispatcherMsg.LeftTriggePerformed);
        }
        private void OnLeftTriggerCanceled(InputAction.CallbackContext context)
        {
            //Debug.Log($"[AnimatorTouch]OnLeftTriggerCanceled>>{context.ReadValue<float>()}");
            AppDispatcher.Instance.Dispatch(DispatcherMsg.LeftTriggeCanceled);
        }
        private void OnRightTriggerStarted(InputAction.CallbackContext context)
        {
            //Debug.Log($"[AnimatorTouch]OnRightTriggerStarted>>{context.ReadValue<float>()}");
            AppDispatcher.Instance.Dispatch(DispatcherMsg.RightTriggeStarted);
        }
        private void OnRightTriggerPerformed(InputAction.CallbackContext context)
        {
            //Debug.Log($"[AnimatorTouch]OnRightTriggerPerformed>>{context.ReadValue<float>()}");
            AppDispatcher.Instance.Dispatch(DispatcherMsg.RightTriggePerformed);
        }
        private void OnRightTriggerCanceled(InputAction.CallbackContext context)
        {
            //Debug.Log($"[AnimatorTouch]OnRightTriggerCanceled>>{context.ReadValue<float>()}");
            AppDispatcher.Instance.Dispatch(DispatcherMsg.RightTriggeCanceled);
        }
        #endregion

    }
}