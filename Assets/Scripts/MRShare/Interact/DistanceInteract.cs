//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using UnityEngine.Events;
//using HoloShare;
//using Newtonsoft.Json;

//namespace HoloSupExp
//{
//    public class DistanceInteract : MonoBehaviour, IOtherData, IPreview, IEditModeToggle, IDistanceTrigger,IReset
//    {
//        public Animator ani;
//        [Tooltip("同上面ani一起touch和idle")]
//        public Animator[] aniArr;
//        private Transform user;

//        private bool canPlay = true;

//        // 触发距离
//        public float triggerDis = 0.3f;

//        public bool enableInteract = false;

//        public UnityAction<string> ShowDis;
//        public UnityEvent TriggerTouchEvent = new UnityEvent();

//        public bool TriggerOnce = false;
//        private bool _isTriggerred = false;

//        public bool IsPreview
//        {
//            set
//            {
//                enableInteract = value;
//            }
//        }

//        private void Start()
//        {
//            if (ani == null)
//                ani = GetComponentInChildren<Animator>();
//            user = Camera.main.transform;
//            if(GetComponent<HoloObjBase>() != null && GetComponent<HoloObjBase>().editUI != null)
//                ShowDis += GetComponent<HoloObjBase>().editUI.ShowDis;
//        }

//        private DistanceData distanceData;

//        private OtherDataType otherDataType = OtherDataType.Distance;

//        public OtherDataType OtherDataType
//        {
//            get
//            {
//                return otherDataType;
//            }
//        }

//        private HoloObjBase holoObjBase;
//        public HoloObjBase HoloObjBase { get => holoObjBase; set => holoObjBase = value; }
//        public float interactDistance { get => triggerDis; set => triggerDis = value; }

//        public object InitData(object data)
//        {
//            if (data != null)
//            {
//                distanceData = JsonConvert.DeserializeObject<DistanceData>((data as OtherData).m_Data);
//            }
//            else
//            {
//                distanceData = new DistanceData(0.3f);
//            }

//            triggerDis = distanceData.triggerDistance;

//            HoloObjBase.editUI.UpdateDistanceUI(distanceData, true);

//            return distanceData;
//        }

//        public object UpdateData(object data)
//        {
//            distanceData = data as DistanceData;
           
//            if (distanceData != null)
//            {
//                triggerDis = distanceData.triggerDistance;

//                HoloObjBase.editUI.UpdateDistanceUI(distanceData, false);
//            }
            

//            return distanceData;
//        }

//        public object GetData()
//        {
//            return distanceData;
//        }

//        public void PlayInteraction()
//        {
//            if (canPlay == false) return;
//            if (_isTriggerred && TriggerOnce)
//            {
//                return;
//            }
//            ani?.SetTrigger("Touch");
//            CommonEffectTool.SetAnimatorState(aniArr,AnimatorStr.TOUCH);
//            _isTriggerred = true;

//            canPlay = false;
//            TriggerTouchEvent?.Invoke();
//        }

//        private Vector3 targetPos;
//        private Vector3 userPos;
//        private float dis;

//        private void Update()
//        {
//            targetPos = new Vector3(transform.position.x, 0, transform.position.z);
//            userPos = new Vector3(user.position.x, 0, user.position.z);

//            dis = Vector3.Distance(targetPos, userPos);

//            ShowDis?.Invoke(dis.ToString("0.00"));

//            if (dis < triggerDis && enableInteract)
//            {
//                PlayInteraction();
//            }

//            if (canPlay == false)
//            {
//                // 动画结束后，并且用户走出触发范围后，才能再次触发互动
//                if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f && dis > triggerDis)
//                {
//                    canPlay = true;

//                    ShowDis?.Invoke(dis.ToString("0.00") + "√");
//                }
//                else
//                {
//                    ShowDis?.Invoke(dis.ToString("0.00") + "X");
//                }
//            }
//        }

//        public void OnEditModeToggle(bool toggle)
//        {
//            IsPreview = !toggle;
//        }

//        public void ResetData()
//        {
//            canPlay = true;
//            _isTriggerred = false;
//            ani?.Play(AnimatorStr.IDLE);
//            CommonEffectTool.SetAnimatorState(aniArr, AnimatorStr.IDLE);
//        }

        
//    }
//}