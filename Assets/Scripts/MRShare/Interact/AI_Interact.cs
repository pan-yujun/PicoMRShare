//using System.Collections;
//using UnityEngine;
//using DG.Tweening;
//using HoloSupExp;
//using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
//using Microsoft.MixedReality.Toolkit.Input;
//using Random = UnityEngine.Random;

//namespace HoloShare
//{
//    public class AI_Interact : TouchBase, ICanPlay, IPreview, IEditModeToggle
//    {

//        #region 字段和属性
//        [SerializeField]
//        private Transform p1, p2, ball;
//        [Header("转向持续时间")]
//        [SerializeField]
//        private float rotateDuration = 0.5f;
//        [Header("移动持续时间")]
//        [SerializeField]
//        private float moveDuration = 3f;
//        [Header("最小移动距离")]
//        [SerializeField]
//        private float minDistance = 1f;
//        [Header("用户触发交互时动画索引的随机范围")]
//        [SerializeField]
//        private Vector2Int interactAniIndexRange = new Vector2Int(3, 6);
//        [Header("停留状态下动画索引的随机范围")]
//        [SerializeField]
//        private Vector2Int stayAniIndexRange = new Vector2Int(0, 5);
//        [Header("停留状态下播放动画个数的随机范围")]
//        [SerializeField]
//        private Vector2Int stayAniNumRange = new Vector2Int(0, 3);
//        [Header("停留状态下动画间隔时长的随机范围")]
//        [SerializeField]
//        private Vector2 stayAniIntervalRange = new Vector2(1f, 6f);
//        [SerializeField]
//        private AudioClip cryClip;

//        private Animator animator;
//        private Vector3 targetPos;
//        private Coroutine stayCor;
//        private BoundsControl boundsControl;
//        private BoxCollider boxCollider;
//        private bool isUserTouch = false;
//        private bool isUserGrab = false;

//        private Vector2 xRange;
//        public Vector2 XRange
//        {
//            get
//            {
//                xRange.x = p1.localPosition.x;
//                xRange.y = p2.localPosition.x;

//                return xRange;
//            }
//        }

//        private Vector2 zRange;
//        public Vector2 ZRange
//        {
//            get
//            {
//                zRange.x = p1.localPosition.z;
//                zRange.y = p2.localPosition.z;

//                return zRange;
//            }
//        }

//        public bool IsRun
//        {
//            set
//            {
//                animator.SetBool("IsRun", value);
//            }
//        }

//        public bool IsGrab
//        {
//            set
//            {
//                animator.SetBool("IsGrab", value);
//            }
//        }

//        private bool isFly;
//        public bool IsFly
//        {
//            set
//            {
//                isFly = value;
//                animator.SetBool("IsFly", value);
//            }
//        }

//        #endregion

//        #region 接口

//        public bool IsPreview
//        {
//            set
//            {
//                ToggleOperate(!value);
//            }
//        }

//        private bool canPlay = true;
//        public bool CanPlay
//        {
//            get => canPlay; set
//            {
//                canPlay = value;

//                boxCollider.enabled = value;

//                // 用户触发交互后回到Idle状态
//                if (value)
//                {
//                    if (isUserTouch)
//                    {
//                        isUserTouch = false;

//                        StartStay();
//                    }

//                    if (isUserGrab)
//                    {
//                        isUserGrab = false;

//                        Fly();
//                    }
//                }
//            }
//        }

//        public void OnEditModeToggle(bool toggle)
//        {
//            ToggleOperate(toggle);
//            ball.parent.gameObject.SetActive(toggle);
//        }

//        public override void OnPointerDown(MixedRealityPointerEventData eventData)
//        {
//            base.OnPointerDown(eventData);

//            if (eventData.Pointer is SpherePointer)
//            {
//                UserGrab();
//            }
//            else
//            {
//                UserTouch();
//            }
//        }

//        public override void OnPointerUp(MixedRealityPointerEventData eventData)
//        {
//            base.OnPointerUp(eventData);

//            if (eventData.Pointer is SpherePointer)
//            {
//                IsGrab = false;
//            }
//        }

//        #endregion

//        private void Awake()
//        {
//            boundsControl = GetComponent<BoundsControl>();
//            boxCollider = GetComponent<BoxCollider>();

//            animator = GetComponentInChildren<Animator>();

//            if (animator != null)
//            {
//                var temp = animator.gameObject.AddComponent<AniEvent>();

//                temp.iCanPlay = this;
//                temp.ani = animator;
//                temp.AddEventToAnimation(animator);
//            }

//            StartCoroutine(StayIE());

//            //Move();
//        }

//        private Vector3 GetRandomPoint()
//        {
//            Vector3 target;
//            float distance;
//            do
//            {
//                target = new Vector3(Random.Range(XRange.x, XRange.y), 0, Random.Range(ZRange.x, ZRange.y));
//                distance = Vector3.Distance(transform.localPosition, target);
//            } while (distance < minDistance);

//            return target;
//        }

//        private void ResetState()
//        {
//            DOTween.KillAll();
//            if (stayCor != null)
//                StopCoroutine(stayCor);

//            IsRun = false;
//            IsFly = false;
//            CanPlay = false;
//        }

//        private void UserTouch()
//        {
//            if (!CanPlay || isFly) return;

//            ResetState();

//            isUserTouch = true;

//            AudioSource.PlayClipAtPoint(cryClip, transform.position);
//            animator.SetTrigger("6");
//        }

//        private void UserGrab()
//        {
//            ResetState();

//            isUserGrab = true;
//            IsGrab = true;
//        }

//        public void ToggleOperate(bool toggle)
//        {
//            if (boundsControl != null)
//                boundsControl.Active = toggle;
//        }

//        /// <summary>
//        /// 跑向目标点
//        /// </summary>
//        public void Run()
//        {
//            targetPos = GetRandomPoint();
//            ball.localPosition = targetPos;

//            transform.DOLookAt(ball.position, rotateDuration, AxisConstraint.Y);

//            IsRun = true;

//            transform.DOLocalMove(targetPos, moveDuration).onComplete = () =>
//            {
//                IsRun = false;
//                StartStay();
//            };
//        }

//        /// <summary>
//        /// 飞回起始点
//        /// </summary>
//        public void Fly()
//        {
//            targetPos = GetRandomPoint();
//            ball.localPosition = targetPos;

//            transform.DOLookAt(ball.position, rotateDuration, AxisConstraint.Y);

//            IsFly = true;

//            transform.DOLocalMove(targetPos, moveDuration).onComplete = () =>
//             {
//                 IsFly = false;
//                 StartStay();
//             };
//        }

//        private void StartStay()
//        {
//            if (stayCor != null)
//                StopCoroutine(stayCor);
//            stayCor = StartCoroutine(StayIE());
//        }

//        private IEnumerator StayIE()
//        {
//            // 随机动画个数
//            var aniNum = Random.Range(stayAniNumRange.x, stayAniNumRange.y);

//            for (int i = 1; i <= 3; i++)
//            {
//                // 随机动画间隔时长
//                var aniInterval = Random.Range(stayAniIntervalRange.x, stayAniIntervalRange.y);

//                yield return new WaitForSeconds(aniInterval);

//                // 随机一个动画
//                var aniIndex = Random.Range(stayAniIndexRange.x, stayAniIndexRange.y + 1);

//                animator.SetTrigger(aniIndex.ToString());
//                CanPlay = false;

//                while (CanPlay == false)
//                {
//                    yield return 1;
//                }
//            }

//            Run();
//        }
//    }
//}