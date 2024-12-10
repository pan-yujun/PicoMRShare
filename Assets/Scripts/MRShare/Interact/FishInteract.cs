//using Microsoft.MixedReality.Toolkit.Input;
//using UnityEngine;
//using DG.Tweening;
//using HoloSupExp;
//using HoloShare;
//using UnityEngine.Events;

//public class FishInteract : MonoBehaviour, IMixedRealityTouchHandler, IEditModeToggle, IPreview
//{
//    public Transform fish;

//    public bool isRotate = false;

//    [Header("旋转半径")]
//    public float r;

//    [Header("自转速度")]
//    public float rotateSpeed = 3f;
//	public UnityEvent onTouch = new UnityEvent();

//    [Header("自转速度倍数")]
//    public float rotateSpeedMultiple = 1.5f;

//    [Header("自转速度倍数时效")]
//    public float rotateSpeedMultipleTime = 0f;

//    [Header("打开点击触发自转加速")]
//    public bool isTouch = false;

//    [Header("打开距离触发自转加速")]
//    public bool isDistance = false;

//    // 触发距离
//    public float triggerDis = 0.3f;

//    private float rotateSpeedMultipleTimeTemp = 0f;
//    private Transform user;
//    public bool IsPreview
//    {
//        set
//        {
//            IsSwim = value;
//        }
//    }

//    private bool m_IsSwim = false;

//    public bool IsSwim
//    {
//        get { return m_IsSwim; }
//        set
//        {
//            m_IsSwim = value;

//            ToggleFishTouch(value);

//            if (m_IsSwim == false)
//            {
//                fish.transform.localPosition = Vector3.zero;
//                isPos = false;
//            }
//        }
//    }

//    /// <summary>
//    /// 是否已定位
//    /// </summary>
//    [HideInInspector]
//    public bool isPos = false;

//    public bool isTestMode = false;
//    [Tooltip("默认设置成False")]
//    [SerializeField]
//    private bool enableTouch = false;

//    private void ToggleFishTouch(bool toggle)
//    {
//        if (smrCol != null)
//            smrCol.enabled = toggle;
//    }

//    private SkinnedMeshRenderer smr;
//    private BoxCollider smrCol;
//    private NearInteractionTouchableVolume smrNitv;
//    private PlanetTouch planetTouch;
//    private void Start()
//    {
//        smr = GetComponentInChildren<SkinnedMeshRenderer>();
//        user = Camera.main.transform;
//        if (smr != null)
//        {
//            smrCol = smr.gameObject.AddComponent<BoxCollider>();
//            smrNitv = smr.gameObject.AddComponent<NearInteractionTouchableVolume>();

//            planetTouch = smr.gameObject.GetComponent<PlanetTouch>();
//            if(planetTouch == null)
//                planetTouch = smr.gameObject.AddComponent<PlanetTouch>();//增加点击事件
//            planetTouch.onTouch.AddListener(Ontouch);

//            var bounds = smr.bounds;
//            // In world-space!
//            var size = bounds.size;
//            var center = bounds.center;
//            // converted to local space of the collider
//            size = smrCol.transform.InverseTransformVector(size);
//            center = smrCol.transform.InverseTransformPoint(center);

//            smrCol.center = center;
//            smrCol.size = size;

//            ToggleFishTouch(enableTouch);
//        }

//        //GetComponentInParent<HoloObjBase>().toggleBtnAction += () =>
//        //{
//        //    IsTouched = !IsTouched;
//        //};

//        if (isTestMode == true)
//        {
//            IsSwim = !IsSwim;
//        }
//    }

//    private Vector3 targetPos;
//    private Vector3 userPos;
//    private float dis;


//    private void Update()
//    {
//        if (isDistance)
//        {
//            targetPos = new Vector3(smr.transform.position.x, 0, smr.transform.position.z);
//            userPos = new Vector3(user.position.x, 0, user.position.z);
//            dis = Vector3.Distance(targetPos, userPos);
//            if (dis < triggerDis)
//            {
//                rotateSpeedMultipleTimeTemp = rotateSpeedMultipleTime;
//            }
//        }
//        if (IsSwim)
//        {
//            if (isPos == false)
//            {
//                var pos = fish.transform.localPosition;
//                fish.transform.localPosition = new Vector3(pos.x, pos.y, r);
//                isPos = true;
//            }
//            if (rotateSpeedMultipleTimeTemp > 0)
//            {
//                rotateSpeedMultipleTimeTemp -= Time.deltaTime;
//                transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * speedupValue * rotateSpeedMultiple);
//            }
//            else
//            {
//                transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * speedupValue);
//            }

//        }


//    }

//    private float speedupValue = 1f;
//    private void SpeedUp()
//    {
//        DOTween.KillAll();

//        speedupValue = 10f;

//        DOTween.To(() => speedupValue,
//         interpolation => { speedupValue = interpolation; },
//         1,
//         6f);

//    }


//    public void OnTouchStarted(HandTrackingInputEventData eventData)
//    {
//        SpeedUp();
//        onTouch.Invoke();
//    }

//    public void OnTouchUpdated(HandTrackingInputEventData eventData)
//    {
//    }

//    public void OnTouchCompleted(HandTrackingInputEventData eventData)
//    {
//    }

//    public void OnEditModeToggle(bool toggle)
//    {
//        IsSwim = !toggle;
//    }
//    private void Ontouch()
//    {
//        if (isTouch)
//        {
//            rotateSpeedMultipleTimeTemp = rotateSpeedMultipleTime;
//        }

//    }
//}
