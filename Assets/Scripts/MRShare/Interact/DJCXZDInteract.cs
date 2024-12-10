//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using HoloSupExp;
//using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
//using Microsoft.MixedReality.Toolkit.UI;
//namespace HoloShare
//{
//    /// <summary>
//    /// 党建新系列初心之地
//    /// </summary>
//    public class DJCXZDInteract : MonoBehaviour, IPreview, IEditModeToggle
//    {
//        public PlanetTouch FH_button;//返航按钮
//        public PlanetTouch QC_button;//启程按钮
//        public Animator CXZDbg;
//        public BoundsControl[] boundsControls;
//        public ObjectManipulator[] objectManipulators;
//        public Animator[] HC_childAni;//红船子物体的动画
//        public Animator[] SKM_childAni;//石库门子物体的动画
//        public Animator HC_gameobject;
//        public Animator SKM_gameobject;
//        public bool IsPreview
//        {
//            set
//            {
//                Toggle(!value);
//            }
//        }
//        public void OnEditModeToggle(bool toggle)
//        {
//            Toggle(toggle);
//        }
//        public void Toggle(bool toggle)
//        {
//            foreach (BoundsControl boundsControl in boundsControls)
//            {
//                boundsControl.enabled = toggle;
//            }

//            foreach (ObjectManipulator objectManipulator in objectManipulators)
//            {
//                objectManipulator.enabled = toggle;
//            }
//        }
//        // Start is called before the first frame update
//        void Awake()
//        {
//            boundsControls = GetComponentsInChildren<BoundsControl>();
//            objectManipulators = GetComponentsInChildren<ObjectManipulator>();
//            FH_button.onTouch.AddListener(()=> {
//                foreach (var item in HC_childAni)
//                {
//                    item.Play("idle");
//                }
//                HC_gameobject.Play("Scaledisappear");
                
//                Invoke("FH_buttonEvent", 1f);
//            });
//            QC_button.onTouch.AddListener(()=> {
//                foreach (var item in SKM_childAni)
//                {
//                    item.Play("idle");
//                }
//                SKM_gameobject.Play("Scaledisappear");
                
//                Invoke("QC_buttonEvent", 1f);
//            });
//        }

//        // Update is called once per frame
//        void Update()
//        {

//        }
//        /// <summary>
//        /// 红船上的返航按钮
//        /// </summary>
//        private void FH_buttonEvent()
//        {

//            HC_gameobject.gameObject.SetActive(false);
//            SKM_gameobject.gameObject.SetActive(true);
//            SKM_gameobject.Play("Scaleappear");
           
//            CXZDbg.Play("BGwallClose");
//        }
//        /// <summary>
//        /// 石库门上面的启程按钮
//        /// </summary>
//        private void QC_buttonEvent()
//        {
//            SKM_gameobject.gameObject.SetActive(false);

//            HC_gameobject.gameObject.SetActive(true);
//            HC_gameobject.Play("Scaleappear");
           
//            CXZDbg.Play("BGwallClose");
//        }

//    }
//}