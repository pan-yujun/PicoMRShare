//using Microsoft.MixedReality.Toolkit.Input;
//using RenderHeads.Media.AVProVideo;
//using System.Collections;
//using UnityEngine;

//namespace HoloShare
//{
//    public class VideoPlayer : MonoBehaviour
//    {
//        private bool isDebug = false;

//        private MediaPlayer mediaPlayer;
//        public MediaPlayer MediaPlayer { get => mediaPlayer = mediaPlayer == null ? VideoCtrl.GetComponentInChildren<MediaPlayer>() : mediaPlayer; }

//        private VideoCtrl videoCtrl;
//        public VideoCtrl VideoCtrl { get => videoCtrl = videoCtrl == null ? GetComponentInParent<VideoCtrl>() : videoCtrl; }

//        private void OnEnable()
//        {
//            if (MediaPlayer != null)
//            {
//                //MediaPlayer.Events.AddListener(MediaEventHandler);          

//                string videoUrl = isDebug ? MediaPlayer.m_VideoPath : VideoCtrl.vidUrls[0];

//                Debug.Log("【打开视频并播放】:" + videoUrl);

//                MediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.AbsolutePathOrURL, videoUrl, true);
//            }
//        }

//        private void OnDisable()
//        {
//            if (MediaPlayer != null)
//            {
//                MediaPlayer.Control.Stop();

//                //MediaPlayer.Events.RemoveListener(MediaEventHandler);
//            }
//        }

//        //private void MediaEventHandler(MediaPlayer arg0, MediaPlayerEvent.EventType arg1, ErrorCode arg2)
//        //{

//        //}

//    }
//}
