using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Assets.PICOSDKWrapper
{ 
    public class TestPicoSDK : MonoBehaviour
    {
        private XRSimpleInteractable mXRSimple;
        private void Start()
        {
            //AppDispatcher.Instance.AddListener(DispatcherMsg.TriggeStarted, OnTriggeStarted);
            if (mXRSimple == null)
            {
                mXRSimple = GetComponent<XRSimpleInteractable>();
            }
            //mXRSimple.focusEntered.AddListener(OnFocusEntered);
            //mXRSimple.focusExited.AddListener(OnFocusExited);
            //mXRSimple.selectEntered.AddListener(OnSelectEntered);
            //mXRSimple.selectExited.AddListener(OnSelectExited);
            //mXRSimple.hoverEntered.AddListener(OnHoverEntered);
            //mXRSimple.hoverExited.AddListener(OnHoverExited);
            //mXRSimple.activated.AddListener(OnActivate);
            //mXRSimple.deactivated.AddListener(OnDeactivated);
        }
        #region 物体聚焦
        public void OnFocusEntered(FocusEnterEventArgs args)
        {
            Debug.Log($"[TestPicoSDK]OnFocusEntered>>{this.name}");
        }
        public void OnFocusExited(FocusExitEventArgs args)
        {
            Debug.Log($"[TestPicoSDK]OnFocusExited>>{this.name}");
        }
        #endregion
        #region 物体选择
        public void OnSelectEntered(SelectEnterEventArgs args)
        {
            Debug.Log($"[TestPicoSDK]OnSelectEntered>>{this.name}");
        }
        public void OnSelectExited(SelectExitEventArgs args)
        {
            Debug.Log($"[TestPicoSDK]OnSelectExited>>{this.name}");
        }
        #endregion
        #region 射线悬浮
        public void OnHoverEntered(HoverEnterEventArgs args)
        {
            Debug.Log($"[TestPicoSDK]OnHoverEnter>>{this.name}");
        }
        public void OnHoverExited(HoverExitEventArgs args)
        {
            Debug.Log($"[TestPicoSDK]OnHoverExited>>{this.name}");
        }
        #endregion
        #region 物体激活
        public void OnActivate(ActivateEventArgs args)
        {
            Debug.Log($"[TestPicoSDK]OnActivate>>{this.name}");
        }
        public void OnDeactivated(DeactivateEventArgs args)
        {
            Debug.Log($"[TestPicoSDK]OnDeactivated>>{this.name}");
        }
        #endregion

        public void TestHover1()
        {
            Debug.Log($"[TestPicoSDK]TestHover1>>{this.name}");
        }
        public void TestHover2()
        {
            Debug.Log($"[TestPicoSDK]TestHover2>>{this.name}");
        }
        public void Test1()
        {
            Debug.Log($"[TestPicoSDK]Test1>>{this.name}");
        }
        public void Test2()
        {
            Debug.Log($"[TestPicoSDK]Test2>>{this.name}");
        }
    }

}