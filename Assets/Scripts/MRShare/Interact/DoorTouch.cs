//using Microsoft.MixedReality.Toolkit.Input;
//using UnityEngine;

//namespace HoloShare
//{
//    public class DoorTouch : TouchBase
//    {
//        [SerializeField]
//        private Animator ani;

//        public void PlayInteraction()
//        {
//            ani?.SetTrigger(AnimatorStr.TOUCH);
//        }

//        public override void OnTouchStarted(HandTrackingInputEventData eventData)
//        {
//            base.OnTouchStarted(eventData);

//            PlayInteraction();
//        }

//        public override void OnPointerDown(MixedRealityPointerEventData eventData)
//        {
//            base.OnPointerDown(eventData);

//            PlayInteraction();
//        }

//        public override void TouchInteraction()
//        {
//            PlayInteraction();
//        }

//    }
//}