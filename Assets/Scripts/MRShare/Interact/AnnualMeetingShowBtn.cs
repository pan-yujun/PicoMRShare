//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Events;
//using Microsoft.MixedReality.Toolkit.Input;
//using UnityEngine.Playables;

//namespace HoloShare
//{
//    public class AnnualMeetingShowBtn : AnnualMeetingBtn
//    {
//        [SerializeField] private Color defCol = Color.black;
//        [SerializeField] private Color32 selectCol = new Color32(255, 246, 141, 255);
//        [SerializeField] private PlayableDirector playableDirector;
//        public AnnualMeetingInteract annualMeetingInteract;
//        private Text text;

//        public UnityEvent OnSelect = new UnityEvent();
//        public UnityEvent OnDeSelect = new UnityEvent();

//        private static AnnualMeetingShowBtn curAnnualMeetingBtn;

//        private bool isSelect;
//        public bool IsSelect
//        {
//            get
//            {
//                return isSelect;
//            }

//            set
//            {
//                isSelect = value;

//                if (isSelect)
//                    OnSelect?.Invoke();
//                else
//                    OnDeSelect?.Invoke();
//            }
//        }

//        private void Awake()
//        {
//            text = GetComponentInChildren<Text>();

//            OnSelect.AddListener(Select);

//            OnDeSelect.AddListener(DeSelect);          
//        }

//        public void Select()
//        {
//            if (curAnnualMeetingBtn != null)
//                curAnnualMeetingBtn.DeSelect();

//            text.color = selectCol;
//            playableDirector.Play();

//            annualMeetingInteract.menu.SetActive(false);

//            curAnnualMeetingBtn = this;
//        }

//        public void DeSelect()
//        {
//            text.color = defCol;
//            playableDirector.time = 0;
//            playableDirector.Stop();
//            playableDirector.Evaluate();
//        }

//        public override void OnPointerClicked(MixedRealityPointerEventData eventData)
//        {
//            base.OnPointerClicked(eventData);

//            IsSelect = !isSelect;
//        }
//    }
//}