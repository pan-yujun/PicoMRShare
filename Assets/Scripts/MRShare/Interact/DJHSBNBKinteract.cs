//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using HoloShare;
//using HoloSupExp;
///// <summary>
///// 红色百年柱子上的图片放大缩小 控制石柱暂停播放
///// </summary>
//public class DJHSBNBKinteract : MonoBehaviour
//{
//    public DJHSBNDistanceinteract  ani;//需要播放的动画
//    private float speed = 0.1f;

//    private bool istouch=false;
//    public GameObject[] ZPQAllZP;
//    public GameObject NowZPObj;
//    public GameObject NextZPObj;
//    private int NextPlayObjnumber;
//    private float timeRecd;

    
//    void Start()
//    {
        
//    }
//    private void Update()
//    {
       
//    }
//    public void SetInt(int i)
//    {
//        NextPlayObjnumber = i;
//    }
//    public void PhotoTouch()
//    {
//        //关闭当前正在播放的照片物体动画,如果为当前正在播放的照片物体空，则不需要执行该步骤
//        if (NowZPObj!=null)
//            NowZPObj.GetComponent<Animator>().Play("Picidle");
//        //打开目标播放的照片物体动画，暂停柱子动画。如果是当前正在播放物体==目标播放物体，则关闭当前正在播放的照片物体动画，并打开柱子动画
//        if (NowZPObj != null)
//        {
//            NextZPObj = ZPQAllZP[NextPlayObjnumber];
//            if (NowZPObj != NextZPObj)
//            {
               
//                NextZPObj.GetComponent<Animator>().Play("Pic");
//                StopAni();

//                NowZPObj = NextZPObj;
//                if (NowZPObj == NextZPObj)
//                {
//                    NextZPObj = null;
//                    istouch = false;
//                }
//            }
//            else
//            {
//                istouch = !istouch;
//                if (!istouch)
//                {
//                    NextZPObj.GetComponent<Animator>().Play("Pic");
//                    StopAni();
//                }
//                else
//                {
                  
//                    StartAni();
//                }
//                NextZPObj = null;
//            }
//        }
//        else
//        {
//            NowZPObj = ZPQAllZP[NextPlayObjnumber];
//            NowZPObj.GetComponent<Animator>().Play("Pic");
//            StopAni();
//        }

//    }
//    //关闭
//    public void ClosePic()
//    {
//        if (NowZPObj!=null)
//        NowZPObj.GetComponent<Animator>().Play("Picidle");
//    }
//    public void CloseZPQ()
//    {
//        this.GetComponent<Animator>().Play("Switchdisappear");
//        // Invoke("ZPQActive", 1);
//        this.gameObject.SetActive(false);
//    }
//    private void ZPQActive()
//    {
//        this.gameObject.SetActive(false);
//    }




//    /// <summary>
//    /// 停止柱子当前动画
//    /// </summary>
//    private void StopAni()
//    {
//        ani.isZPQ = false;
//    }
//    /// <summary>
//    /// 打开柱子当前动画
//    /// </summary>
//    private void StartAni()
//    {
//        ani.isZPQ = true;
//    }
//}
