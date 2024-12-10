//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace HoloShare
//{
//    public class FaceToUser : MonoBehaviour
//    {
//        private Transform user;

//        private void Start()
//        {
//            user = Camera.main.transform;
//        }

//        private void Update()
//        {
//            Vector3 targetRote = new Vector3(transform.position.x, 0, transform.position.z)
//                                    - new Vector3(user.position.x, 0, user.position.z);

//            transform.forward = Vector3.Lerp(transform.forward, targetRote, 0.5f);
//        }
//    }
//}