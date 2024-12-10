//using GF;
//using HoloShare;
//using HoloSupExp;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
///// <summary>
///// 通用脚本
///// 用于子物体需要编辑，但是物体很大或者会遮挡其子物体的按钮使用
///// 在子物体下添加一个“Box”物体 作为编辑模式下的调整物体
///// </summary>
//public class ChildObjectEditBox : ChildTranEditor, IPreview, IEditModeToggle
//{
//    [HideInInspector]
//    public EditChildUI editchildUI;

//    private BoxCollider boxCollider;
//    public BoxCollider BoxCollider { get => boxCollider; }
//    void Awake() {
//        boxCollider = GetComponent<BoxCollider>();
//        if (BoxMesh == null)
//        {
//            var target = transform.TryFind("Box");
//            if (target != null)
//                BoxMesh = target.GetComponent<MeshRenderer>();
//        }

//        editchildUI = EditChildUI.Create(this);

//        SetEditorState(editchildUI.gameObject, false);
//    }
//    public bool IsPreview
//    {
//        set
//        {
//            if (BoxMesh != null)
//                BoxMesh.enabled=(!value);
//            if (editchildUI != null)
//                editchildUI.gameObject.SetActive(!value);

//            SetEditorState(editchildUI.gameObject, false);
//        }
//    }
//    public void OnEditModeToggle(bool toggle)
//    {
//        if (BoxMesh != null)
//            BoxMesh.enabled = (toggle);
//        if (editchildUI != null)
//            editchildUI.gameObject.SetActive(toggle);

//        SetEditorState(editchildUI.gameObject,false);
//    }

//    public void ResetRotate()
//    {
//        Vector3 newV = new Vector3(0, transform.eulerAngles.y, 0);
//        transform.eulerAngles = newV;
//        this.GetComponent<TranRecorder>().Done();
//       // Done();
//    }

//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//    private void OnDestroy()
//    {
//        if (editchildUI!=null)
//        {
//            Destroy(editchildUI.gameObject);
//        }
//    }
//}
