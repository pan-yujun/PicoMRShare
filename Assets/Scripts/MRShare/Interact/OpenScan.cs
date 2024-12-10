//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class OpenScan : MonoBehaviour
//{
//    private Button button;
//    private GameObject ScanParent;
//    private GameObject Canvas_MainUI;
//    private Toggle VisibleToggle;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
       
//    }
//    public void Touch_openscan()
//    {
//        if (ChannelPlatform.Inst.channel==ChannelEnum.Glasses)
//        {
//            Glasses_OpenScan();
//        }
//        else
//        {
//            Mobile_OpenScan();
//        }
//    }


//    private void Glasses_OpenScan()
//    {
//        VisibleToggle = GameObject.Find("HandMenu").transform.Find("Canvas").transform.Find("ToolMenu").transform.Find("VisibleToggle").GetComponent<Toggle>();
//        if (VisibleToggle!=null)
//        {
//            VisibleToggle.isOn = true;
//        }
//        Canvas_MainUI = GameObject.Find("MainUI").transform.Find("Canvas").gameObject;
//        if (Canvas_MainUI!=null)
//        {
//            Canvas_MainUI.SetActive(true);
//        }
//        ScanParent = GameObject.Find("PointInfoView(Clone)");
//        if (ScanParent!=null)
//        {
//            button = ScanParent.transform.Find("Top").Find("ScanBtn").GetComponent<Button>();
//            ExecuteEvents.Execute(button.gameObject,
//                new PointerEventData(EventSystem.current),
//                ExecuteEvents.pointerClickHandler);
//        }
        
//    }
//    private void Mobile_OpenScan()
//    {
//        ScanParent = GameObject.Find("TabMenuView");
//        if (ScanParent != null)
//        {
//            button = ScanParent.transform.Find("root").Find("ScanBtn").GetComponent<Button>();
//            ExecuteEvents.Execute(button.gameObject,
//                new PointerEventData(EventSystem.current),
//                ExecuteEvents.pointerClickHandler);
//        }
//    }
//}
