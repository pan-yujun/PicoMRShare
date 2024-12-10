//using GF;
//using HoloShare;
//using HoloSupExp;
//using UnityEngine;
//using UnityEngine.UI;
///// <summary>
///// 通用脚本
///// 用于子物体需要编辑，但是物体很大或者会遮挡其子物体的按钮使用
///// 在子物体下添加一个“Box”物体 作为编辑模式下的调整物体
///// 结合ChildObjectEditBox和EditChildUI脚本，修复多个子物体编辑EditChildUI都在同一个位置的问题
///// </summary>
//public class ChildObjectEditBoxNonStatic : ChildTranEditor, IPreview, IEditModeToggle
//{
//    public bool isHideCollider = false;
//    public GameObject triggerInteractObject;
//    public ChildDistanceCtrl distanceCtrl;
//    private GameObject editchildUI;

//    private BoxCollider boxCollider;
//    public BoxCollider BoxCollider { get => boxCollider; }


//    private RectTransform top;
//    private Transform canvas;
//    private Button resetBtn;

//    private GameObject template;
//    private Transform editUIParent;
//    public string tranID = string.Empty;
//    public string[] disIDs;
//    public Transform user;
//    private bool isFaceUser;
//    private Vector3 targetRote;
//    [Range(0.1f, 1f)]
//    public float followSmooth = 0.5f;
//    [Header("UI距离物体上边的高度")]
//    public float yOffset = 0.2f;
//    private float uiHeight;
//    private Vector3 targetPos;
//    private bool isPreview = true;
//    private DistanceData distanceData = new DistanceData();
//    private Transform disAdjust;
//    private InputField disInputText;
//    private LayoutGroup content;


//    public HoloObjBase holoObj;




//    private void Awake()
//    {
//        boxCollider = GetComponent<BoxCollider>();
//        if (isHideCollider && boxCollider != null)
//        {
//            boxCollider.enabled = false;
//        }

//        if (BoxMesh == null)
//        {
//            var target = transform.TryFind("Box");
//            if (target != null)
//                BoxMesh = target.GetComponent<MeshRenderer>();
//        }


//        if (template == null)
//            template = Resources.Load<GameObject>("EditChildUINonStatic");


//        if (editUIParent == null)
//            editchildUI = Instantiate(template);

//        editchildUI.name = "EditChildUI_" + transform.name;

//        canvas = editchildUI.transform.TryFind("Canvas");
//        var panel = canvas.TryFind("Panel");
//        top = panel.TryFind("Top").TryGetComp<RectTransform>();
//        resetBtn = top.transform.TryFind("ResetBtn").TryGetComp<Button>();
//        resetBtn.onClick.AddListener(() =>
//        {
//            ResetRotate();
//        });
//        user = Camera.main.transform;


//        if (editchildUI != null)
//            editchildUI.gameObject.SetActive(!isPreview);



//        content = panel.TryFind("Content").TryGetComp<LayoutGroup>();

//        if (content != null)
//            disAdjust = content.transform.TryFind("DisAdjust");
//        if (disAdjust != null)
//        {
//            if (disIDs != null && disIDs.Length > 0)
//                disAdjust.gameObject.SetActive(true);
//            else
//                disAdjust.gameObject.SetActive(false);

//            disInputText = disAdjust.TryFind("BG/Dis/DisInputField").TryGetComp<InputField>();

//        }


//        InitDisAdjust();

//        isFaceUser = true;


//        if (editUIParent == null)
//            uiHeight = (top.sizeDelta.y + content.preferredHeight) * canvas.localScale.y * canvas.parent.localScale.y;

//        SetEditorState(editchildUI.gameObject, false);
//    }

//    private void Start()
//    {
//        if (holoObj != null && holoObj.editUI != null)
//        {

//            editUIParent = holoObj.editUI.transform.parent;
//            if (editUIParent != null)
//            {
//                editchildUI.transform.SetParent(editUIParent);
//                uiHeight = (top.sizeDelta.y + content.preferredHeight) * canvas.localScale.y * canvas.parent.localScale.y * canvas.parent.parent.localScale.y;
//            }

//        }

//    }

//    public bool IsPreview
//    {
//        set
//        {
//            isPreview = value;
//            if (BoxMesh != null)
//                BoxMesh.enabled = (!value);
//            if (editchildUI != null)
//                editchildUI.gameObject.SetActive(!value);
//            if (isHideCollider && boxCollider != null)
//            {
//                boxCollider.enabled = (!value);
//            }

//        if (editchildUI != null)
//                SetEditorState(editchildUI.gameObject, false);
//        }
//    }
//    public void OnEditModeToggle(bool toggle)
//    {
//        if (BoxMesh != null)
//            BoxMesh.enabled = (toggle);
//        if (editchildUI != null)
//            editchildUI.gameObject.SetActive(toggle);
//        if (isHideCollider && boxCollider != null)
//        {
//            boxCollider.enabled = toggle;
//        }

//        if (editchildUI != null)
//            SetEditorState(editchildUI.gameObject, false);
//    }

//    public void ResetRotate()
//    {
//        Vector3 newV = new Vector3(0, transform.eulerAngles.y, 0);
//        transform.eulerAngles = newV;
//        this.GetComponent<TranRecorder>().Done();
//        // Done();
//    }



//    // Update is called once per frame
//    void Update()
//    {

//        if (boxCollider != null && editchildUI != null)
//        {
//            float scale = editchildUI.transform.localScale.x / (editchildUI.transform.lossyScale.x);
//            editchildUI.transform.localScale = new Vector3(scale, scale, scale);


//            targetPos = boxCollider.bounds.center + Vector3.up * boxCollider.bounds.size.y * 0.5f + Vector3.up * (uiHeight + yOffset);

//            editchildUI.transform.position = Vector3.Lerp(transform.position, targetPos, followSmooth);

//            if (user != null && isFaceUser)
//            {
//                targetRote = new Vector3(editchildUI.transform.position.x, 0, editchildUI.transform.position.z)
//                                - new Vector3(user.position.x, 0, user.position.z);

//                editchildUI.transform.forward = Vector3.Lerp(editchildUI.transform.forward, targetRote, followSmooth);
//            }


//        }

//    }
//    private void OnDestroy()
//    {
//        if (editchildUI != null)
//        {
//            Destroy(editchildUI);
//        }
//    }

//    public void InitDisAdjust()
//    {

//        if (disInputText != null)
//        {
//            disInputText.onEndEdit.AddListener((val) =>
//            {
//                if (triggerInteractObject != null)
//                {
//                    ChildTriggerInteract[] triggerInteracts = triggerInteractObject.GetComponents<ChildTriggerInteract>();

//                    for (int i = 0; i < triggerInteracts.Length; i++)
//                    {
//                        triggerInteracts[i].triggerDis = float.Parse(val);

//                    }


//                    if (distanceCtrl != null)
//                    {
//                        if (disIDs != null && disIDs.Length > 0)
//                        {
//                            for (int j = 0; j < disIDs.Length; j++)
//                            {
//                                DistanceData distanceData = new DistanceData();
//                                distanceData.m_ID = disIDs[j];
//                                distanceData.triggerDistance = float.Parse(val);

//                                distanceCtrl.disDataTable.UpdateDisData(distanceData);

//                            }
//                        }

//                    }
//                }

//                if (holoObj != null && distanceCtrl != null)
//                {
//                    holoObj.UpdateOtherData(OtherDataType.Distance, distanceCtrl.disDataTable);

//                }
//            });
//        }
//    }

//    public void UpdateDistanceUI(DisDataTable data)
//    {

//        if (disIDs != null && disIDs.Length > 0)
//        {
//            distanceData.m_ID = disIDs[0];
//            if (data.GetDisData(disIDs[0]) != null)
//                distanceData.triggerDistance = data.GetDisData(disIDs[0]).triggerDistance;

//            if (disInputText != null)
//            {
//                disInputText.text = distanceData.triggerDistance.ToString();

//            }
//        }
//    }

//    public void SetEditChildUIState(bool active)
//    {
//        if (editchildUI)
//            editchildUI?.SetActive(false);
//    }
//}
