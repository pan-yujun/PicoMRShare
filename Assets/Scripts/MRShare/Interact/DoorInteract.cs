//using HoloSupExp;
//using UnityEngine;

//namespace HoloShare
//{
//    public class DoorInteract : MonoBehaviour, IPreview, IEditModeToggle
//    {
//        [SerializeField]
//        private BoxCollider box;

//        private bool isPreview;
//        public bool IsPreview
//        {
//            set
//            {
//                isPreview = value;
//                box.enabled = !value;
//            }
//        }

//        public void OnEditModeToggle(bool toggle)
//        {
//            IsPreview = !toggle;
//        }
//    }
//}