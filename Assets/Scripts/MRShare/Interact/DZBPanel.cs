//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Microsoft.MixedReality.Toolkit.Input;
//using RenderHeads.Media.AVProVideo;

//namespace HoloShare
//{
//    public class DZBPanel : MonoBehaviour
//    {
//        private const string DH = "DZBDH";
//        private const string FC = "DZBFC";
//        private const string JS = "DZBJS";
//        private const string ZD = "DZBZD";
//        private const string XJ = "DZBXJ";

//        public SpriteRenderer displaySprite;
//        public int curSpriteIndex = -1;

//        public MediaPlayer mediaPlayer;

//        // 图片
//        public Sprite[] dzbZdPics; //党支部制度
//        public Sprite[] dzbDhPics; //党支部大会
//        public Sprite[] dzbXjPics; //党支部选举
//        public Sprite[] dzbFcPics; //党支部风采
//        public Sprite[] dzbJsPics; //党组织建设

//        // 视频（路径）
//        //public string dzbZdVids; //党支部制度
//        //public string dzbDhVids; //党支部大会
//        //public string dzbXjVids; //党支部选举
//        //public string dzbFcPVids; //党支部风采
//        //public string dzbJsVids; //党组织建设

//        public GameObject mainPanel;
//        public GameObject choicePanel;
//        public GameObject picPanel;
//        public GameObject vidPanel;

//        public PointerHandler returnBtn;


//        public PointerHandler leftBtn;
//        public PointerHandler rightBtn;

//        public GameObject dangHui;

//        Stack<GameObject> pageQue = new Stack<GameObject>();

//        public string curPartName = "";

//        private VideoCtrl videoCtrl;

//        public void PlayVideo()
//        {
//            mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.AbsolutePathOrURL, GetVidUrl(curPartName), true);
//        }

//        public Sprite[] GetCurSprs(string name)
//        {
//            Sprite[] sprs = null;
//            switch (name)
//            {
//                case "党支部制度":
//                    sprs = dzbZdPics;
//                    break;
//                case "党支部大会":
//                    sprs = dzbDhPics;
//                    break;
//                case "党支部选举":
//                    sprs = dzbXjPics;
//                    break;
//                case "党支部风采":
//                    sprs = dzbFcPics;
//                    break;
//                case "党支部建设":
//                    sprs = dzbJsPics;
//                    break;
//                default:
//                    Debug.LogError($"找不到：{name}");
//                    break;
//            }

//            return sprs;
//        }

//        public string GetVidUrl(string name)
//        {
//            string urlStr = null;
//            switch (name)
//            {
//                case "党支部制度":
//                    urlStr = videoCtrl.vidUrls[0];
//                    break;
//                case "党支部大会":
//                    urlStr = videoCtrl.vidUrls[1];
//                    break;
//                case "党支部选举":
//                    urlStr = videoCtrl.vidUrls[2];
//                    break;
//                case "党支部风采":
//                    urlStr = videoCtrl.vidUrls[3];
//                    break;
//                case "党支部建设":
//                    urlStr = videoCtrl.vidUrls[4];
//                    break;
//                default:
//                    break;
//            }

//            return urlStr;
//        }

//        private void PointResponseForOtherWindows(GameObject go, System.Action action)
//        {
//            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
//            {
//                A.MouseClick mousePoint = go.GetComponent<A.MouseClick>();
//                if (mousePoint == null)
//                    mousePoint = go.AddComponent<A.MouseClick>();

//                mousePoint.pointClick = action;
//            }
//        }

//        private void Awake()
//        {
//            videoCtrl = GetComponent<VideoCtrl>();

//            leftBtn.OnPointerClicked.AddListener((data) => SwitchPic(-1));
//            rightBtn.OnPointerClicked.AddListener((data) => SwitchPic(1));

//            PointResponseForOtherWindows(leftBtn.gameObject, () => SwitchPic(-1));
//            PointResponseForOtherWindows(rightBtn.gameObject, () => SwitchPic(1));
//            PointResponseForOtherWindows(returnBtn.gameObject, () => Back());

//            var btns = mainPanel.GetComponentsInChildren<PointerHandler>(true);

//            foreach (var item in btns)
//            {
//                if (item.GetComponentInChildren<TextMesh>().text != "拍照")
//                {
//                    void _PointEvent()
//                    {
//                        Forward(choicePanel);

//                        curPartName = item.GetComponentInChildren<TextMesh>().text;

//                        SwitchPic(1);
//                    }

//                    PointResponseForOtherWindows(item.gameObject, _PointEvent);

//                    item.OnPointerClicked.AddListener(
//                   (data) =>
//                   {
//                       _PointEvent();
//                   }
//                   );
//                }

//            }

//            returnBtn.OnPointerClicked.AddListener(
//               (data) => Back()
//               );

//            var choiceBtns = choicePanel.GetComponentsInChildren<PointerHandler>(true);
//            foreach (var item in choiceBtns)
//            {
//                // 图片按钮
//                if (item.name.Equals("caidan001"))
//                {
//                    PointResponseForOtherWindows(item.gameObject, () => Forward(picPanel));

//                    item.OnPointerClicked.AddListener(
//                   (data) =>
//                   {
//                       Forward(picPanel);
//                   }
//                   );
//                }
//                // 视频按钮
//                else if (item.name.Equals("caidan002"))
//                {
//                    PointResponseForOtherWindows(item.gameObject, () =>
//                    {
//                        Forward(vidPanel);
//                        PlayVideo();
//                    });
//                    item.OnPointerClicked.AddListener(
//                   (data) =>
//                   {
//                       Forward(vidPanel);
//                       PlayVideo();
//                   }
//                   );
//                }

//            }
//        }

//        public void SwitchPic(int pic)
//        {
//            curSpriteIndex += pic;

//            // 第一页
//            if (curSpriteIndex == 0)
//            {
//                leftBtn.gameObject.SetActive(false);
//                rightBtn.gameObject.SetActive(true);
//            }
//            // 最后一页
//            else if (curSpriteIndex == GetCurSprs(curPartName).Length - 1)
//            {
//                leftBtn.gameObject.SetActive(true);
//                rightBtn.gameObject.SetActive(false);
//            }

//            var temp = GetCurSprs(curPartName);
//            if (curSpriteIndex <= temp.Length - 1)
//                displaySprite.sprite = temp[curSpriteIndex];
//        }

//        private void Start()
//        {
//            Forward(mainPanel);
//        }

//        float timeCount = 0;
//        float timeLimit = 2;

//        public void Forward(GameObject panel)
//        {
//            if (pageQue.Count < 0) return;

//            if (panel.name.Equals("KJMP2_pic") || panel.name.Equals("KJMP2_video"))
//            {
//                dangHui.SetActive(false);
//            }
//            else
//            {
//                dangHui.SetActive(true);
//            }

//            if (pageQue.Count != 0)
//            {
//                // 如果有上一页的话则隐藏
//                pageQue.Peek().SetActive(false);
//            }

//            // 显示新的页面
//            panel.SetActive(true);
//            pageQue.Push(panel);

//            if (pageQue.Count >= 2)
//            {
//                returnBtn.gameObject.SetActive(true);
//            }
//            else
//            {
//                returnBtn.gameObject.SetActive(false);
//            }
//        }

//        public void Back()
//        {
//            // 如果只剩一页，则无法操作
//            if (pageQue.Count <= 1) return;

//            pageQue.Pop().SetActive(false);

//            pageQue.Peek().SetActive(true);

//            if (pageQue.Peek().name.Equals("KJMP2_pic") || pageQue.Peek().name.Equals("KJMP2_video"))
//            {
//                dangHui.SetActive(false);
//            }
//            else
//            {
//                dangHui.SetActive(true);
//            }

//            if (pageQue.Count >= 2)
//            {
//                returnBtn.gameObject.SetActive(true);
//            }
//            else
//            {
//                returnBtn.gameObject.SetActive(false);
//            }
//        }
//    }
//}
