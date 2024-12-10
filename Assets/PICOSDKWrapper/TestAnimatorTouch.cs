using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
namespace Assets.PICOSDKWrapper
{
    [RequireComponent(typeof(XRSimpleInteractable))]
    public class TestAnimatorTouch : MonoBehaviour
    {
        public InputActionReference mTriggerButton;
        public bool mOpenTouch = true;// ÊÇ·ñ¿ªÆô¼ì²â´¥Ãþ
        private XRSimpleInteractable mXRSimple;
        private bool mIsHovering = false;
        private Rigidbody mRigidbody;
        private void OnEnable()
        {
            InputAction mTriggerButton_Action = GetInputAction(mTriggerButton);
            if (mTriggerButton_Action != null)
            {
                mTriggerButton_Action.started += OnTriggerButtonStarted;
                mTriggerButton_Action.performed += OnTriggerButtonPerformed;
                mTriggerButton_Action.canceled += OnTriggerButtonCanceled;
            }
            if (mOpenTouch)
            {
                mRigidbody = GetComponent<Rigidbody>();
                if (mRigidbody == null)
                {
                    mRigidbody = this.gameObject.AddComponent<Rigidbody>();
                }
            }
        }
        private void OnDisable()
        {
            InputAction mTriggerButton_Action = GetInputAction(mTriggerButton);
            if (mTriggerButton_Action != null)
            {
                mTriggerButton_Action.performed -= OnTriggerButtonPerformed;
            }
        }
        static InputAction GetInputAction(InputActionReference actionReference)
        {
    #pragma warning disable IDE0031 // Use null propagation -- Do not use for UnityEngine.Object types
            return actionReference != null ? actionReference.action : null;
    #pragma warning restore IDE0031
        }

        #region °´Å¥¼ì²â
        private void OnTriggerButtonStarted(InputAction.CallbackContext context)
        {
            Debug.Log("[AnimatorTouch]OnTriggerButtonStarted");
        }
        private void OnTriggerButtonPerformed(InputAction.CallbackContext context)
        {
            Debug.Log("[AnimatorTouch]OnTriggerButtonPerformed");
        }
        private void OnTriggerButtonCanceled(InputAction.CallbackContext context)
        {
            Debug.Log("[AnimatorTouch]OnTriggerButtonCanceled");
        }
        #endregion

        private void Start()
        {
            if (mXRSimple == null)
            {
                mXRSimple = GetComponent<XRSimpleInteractable>();
            }
            mXRSimple.hoverEntered.AddListener(OnHoverEntered);
            mXRSimple.hoverExited.AddListener(OnHoverExited);
        }

        #region ÉäÏßÐü¸¡
        public void OnHoverEntered(HoverEnterEventArgs args)
        {
            //Debug.Log($"OnHoverEnter>>{this.name}");
            mIsHovering = true;
        }
        public void OnHoverExited(HoverExitEventArgs args)
        {
            //Debug.Log($"OnHoverExited>>{this.name}");
            mIsHovering = false;
        }
        #endregion

        #region ´¥Ãþ¼ì²â
        private void OnTriggerEnter(Collider other)
        {
            if (!mOpenTouch) return;
            Debug.Log($"OnTriggerEnter>>{other.tag}");
        }

        private void OnTriggerStay(Collider other)
        {
            if (!mOpenTouch) return;
            Debug.Log($"OnTriggerStay>>{other.tag}");
        }
        private void OnTriggerExit(Collider other)
        {
            if (!mOpenTouch) return;
            Debug.Log($"OnTriggerExit>>{other.tag}");
        }
        #endregion
    }

}