//using HoloSupExp;
//using Microsoft.MixedReality.Toolkit.UI;
//using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Playables;

//namespace HoloShare
//{
//    /// <summary>
//    ///  年会互动
//    /// </summary>
//    public class AnnualMeetingInteract : MonoBehaviour, IPreview, IEditModeToggle
//    {
//        [SerializeField] public GameObject menu;
//        [SerializeField] private AnnualMeetingShowBtn[] annualMeetingShowBtns;

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

//        BoundsControl[] boundsControls;
//        ObjectManipulator[] objectManipulators;

//        private void Awake()
//        {
//            boundsControls = GetComponentsInChildren<BoundsControl>();
//            objectManipulators = GetComponentsInChildren<ObjectManipulator>();

//            foreach (var item in annualMeetingShowBtns)
//            {
//                item.annualMeetingInteract = this;
//            }
//        }


//        public void ListBtnClick()
//        {
//            menu.SetActive(!menu.activeSelf);
//            if (menu.activeSelf)
//                ResetShowBtns();
//        }

//        private void Start()
//        {
//            ResetShowBtns();
//        }

//        public void ResetShowBtns()
//        {
//            foreach (var item in annualMeetingShowBtns)
//            {
//                item.DeSelect();
//            }
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
//    }
//}