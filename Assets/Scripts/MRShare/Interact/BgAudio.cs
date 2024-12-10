//using GF;
//using HoloSupExp;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace HoloShare
//{
//    public class BgAudio : AudioCtrl, IPreview,IEditModeToggle,ILLPFSModeToggle
//    {
//        public bool IsPreview
//        {
//            set
//            {
//                if (value)
//                {
//                    audioSource.Play();
//                }
//                else
//                {
//                    audioSource.Stop();
//                }
//            }
//        }

//        private AudioSource audioSource;

//        private void Awake()
//        {
//            audioSource = transform.TryFind("SpatialAudio").TryGetComp<AudioSource>();
//        }

//        public void OnEditModeToggle(bool toggle)
//        {
//            if (audioSource == null) return;
//            if (toggle)
//            {
//                audioSource?.Stop();
//            }
//            else
//            {
//                audioSource?.Play();
//            }
//        }

//        public void OnLLPFSModeToggle(bool toggle)
//        {
//            if (toggle)
//            {
//                if (audioSource != null)
//                {
//                    audioSource?.Play();
//                }
//            }
//            else
//            {
//                if (audioSource != null)
//                {
//                    audioSource?.Stop();
//                }
//            }
//        }
//    }
//}