//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using UnityEngine.Events;
//using HoloShare;
//using Newtonsoft.Json;
//namespace HoloSupExp
//{
//    public class DJHSBNDistanceinteract : MonoBehaviour, IPreview, IEditModeToggle
//    {
//       // public Animator ani;//需要播放的动画
//       // private Transform user;//摄像头
        
//       // private bool canPlay = true;

//       // // 触发距离
//       // public float triggerDis = 1f;

//       // public bool enableInteract = true;

//       //// public UnityAction<string> ShowDis;

//       // public bool TriggerOnce = true;
//       // private bool _isTriggerred = false;

//        public GameObject[] AllND;//下方七个按钮
//        public DJHSBNBKinteract[] AllZPQ;//七个按钮对应的照片墙
//        public GameObject ZPQ;
//        public float ZPQspeed = 0.01f;
//        public bool isZPQ = true;
//        private float _objtransformY;

//        private DJHSBNBKinteract NowPlayObj;//当前正在播放的物体
//        private DJHSBNBKinteract NextPlayObj;//下一个播放的物体
//        private int NextPlayObjnumber;
//        public bool IsPreview
//        {
//            set
//            {
//               // enableInteract = value;
//            }
//        }


     
//        private void Start()
//        {
//            //if (ani == null)
//            //    ani = GetComponentInChildren<Animator>();
//            //user = Camera.main.transform;
//            NowPlayObj = AllZPQ[0];
//            //  ShowDis += GetComponent<HoloObjBase>().editUI.ShowDis;
//            _objtransformY = ZPQ.transform.localRotation.eulerAngles.y;
//        }
//        #region 距离检测 触发动画
//        //private DistanceData distanceData;

//        //private OtherDataType otherDataType = OtherDataType.Distance;

//        //public OtherDataType OtherDataType
//        //{
//        //    get
//        //    {
//        //        return otherDataType;
//        //    }
//        //}

//        //private HoloObjBase holoObjBase;
//        //public HoloObjBase HoloObjBase { get => holoObjBase; set => holoObjBase = value; }

//        //public object InitData(object data)
//        //{
//        //    if (data != null)
//        //    {
//        //        distanceData = JsonConvert.DeserializeObject<DistanceData>((data as OtherData).m_Data);
//        //    }
//        //    else
//        //    {
//        //        distanceData = new DistanceData(0.3f);
//        //    }

//        //    triggerDis = distanceData.triggerDistance;

//        //    HoloObjBase.editUI.UpdateDistanceUI(distanceData, true);

//        //    return distanceData;
//        //}

//        //public object UpdateData(object data)
//        //{
//        //    distanceData = data as DistanceData;

//        //    triggerDis = distanceData.triggerDistance;

//        //    HoloObjBase.editUI.UpdateDistanceUI(distanceData, false);

//        //    return distanceData;
//        //}

//        //public object GetData()
//        //{
//        //    return distanceData;
//        //}

//        //public void PlayInteraction()
//        //{
//        //    if (canPlay == false) return;
//        //    if (_isTriggerred && TriggerOnce)
//        //    {
//        //        return;
//        //    }
//        //    ani?.SetTrigger("Touch");
//        //    _isTriggerred = true;

//        //    canPlay = false;
//        //    AllNDOpenCollider();
//        //}

//        //private Vector3 targetPos;
//        //private Vector3 userPos;
//        //private float dis;
       
//        private void Update()
//        {
//           // targetPos = new Vector3(transform.position.x, 0, transform.position.z);
//        //    userPos = new Vector3(user.position.x, 0, user.position.z);

//         //   dis = Vector3.Distance(targetPos, userPos);

//         //  // ShowDis?.Invoke(dis.ToString("0.00"));

//        //    if (dis < triggerDis && enableInteract)
//        //    {
//        //        PlayInteraction();
//         //   }

//            ////if (canPlay == false)
//            ////{
//            ////    // 动画结束后，并且用户走出触发范围后，才能再次触发互动
//            ////    if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f && dis > triggerDis)
//            ////    {
//            ////        canPlay = true;

//            ////        ShowDis?.Invoke(dis.ToString("0.00") + "√");
//            ////    }
//            ////    else
//            ////    {
//            ////        ShowDis?.Invoke(dis.ToString("0.00") + "X");
//            ////    }
//            ////}
//            if (isZPQ)
//            {
//                ZPQ.transform.localRotation = Quaternion.Euler(0, _objtransformY += ZPQspeed, 0);
//            }
//        }

//        public void OnEditModeToggle(bool toggle)
//        {
//        //    IsPreview = !toggle;
//        }
//        /// <summary>
//        /// 打开下方七个物体的碰撞体 使其可以点击
//        /// </summary>
//        private void AllNDOpenCollider()
//        {
//            foreach (var item in AllND)
//            {
//                item.GetComponent<BoxCollider>().enabled = true;
//            }
//        }
//        #endregion


//        public void SetInt(int i)
//        {
//            NextPlayObjnumber = i; 
//            NextPlayObj = AllZPQ[NextPlayObjnumber];
//        }
//        public void NDTouch()
//        {
//            //关闭已打开的照片
//            NowPlayObj.ClosePic();
//            //播放当前正在播放的物体的下落动画
//            //关闭当前正在播放的物体
//            NowPlayObj.CloseZPQ();
//            //打开目标物体  可能存在逻辑先后的问题
//            NowPlayObj = NextPlayObj;
//            NextPlayObj.gameObject.SetActive(true);
//            isZPQ = true;
//            if (NextPlayObj!=NowPlayObj)
//            {
                
//            }
//            else
//            {
//              //  AllND[NextPlayObjnumber].GetComponent<Animator>().Play("NianDai");
//            }  
           


//        }

//    }
//}