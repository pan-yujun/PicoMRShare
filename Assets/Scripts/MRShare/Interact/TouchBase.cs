//using GF;
//using Microsoft.MixedReality.Toolkit.Input;
//using UnityEngine;

//namespace HoloShare
//{
//    public class TouchBase : GMono, IMixedRealityTouchHandler, IMixedRealityPointerHandler,
//        INetworkInteractInit, INetworkInteractCallBack
//    {
//        public virtual void TouchInteraction() { }

//        public virtual void OnPointerClicked(MixedRealityPointerEventData eventData)
//        {

//        }

//        public virtual void OnPointerDown(MixedRealityPointerEventData eventData)
//        {

//        }

//        public virtual void OnPointerDragged(MixedRealityPointerEventData eventData)
//        {

//        }

//        public virtual void OnPointerUp(MixedRealityPointerEventData eventData)
//        {

//        }

//        public virtual void OnTouchCompleted(HandTrackingInputEventData eventData)
//        {

//        }

//        public virtual void OnTouchStarted(HandTrackingInputEventData eventData)
//        {

//        }

//        public virtual void OnTouchUpdated(HandTrackingInputEventData eventData)
//        {

//        }

//        protected override void OnBeforeDestroy()
//        {

//        }

//        #region 网络互动
//        public virtual string RepeatedlyPoint(string defPointStr)
//        {
//            AnimeSyncModel aim = new AnimeSyncModel();
//            aim.actType = ActType.Anime;
//            aim.trigger = true;
//            ITriggerInteractInfo info = gameObject.GetComponent<ITriggerInteractInfo>();
//            aim.triggerInfo = (info != null) ? info.GetTriggerName(true) : defPointStr;

//            return Serailze(aim);
//        }
        
//        public IScenarioPlayInteract scenarioPlayInteract { get; set; }

//        /// <summary>
//        /// 网络互动
//        /// </summary>
//        /// <param name="info"></param>
//        /// <param name="other"></param>
//        protected virtual void NetworkTriggerInteraction(string info, string other)
//        {
//            IAssistInteractInfo assist = gameObject.GetComponent<IAssistInteractInfo>();
//            if (assist != null)
//            {
//                AnimeSyncModel asm = Deserialize<AnimeSyncModel>(info);                
//                assist.AssistInteract(asm.triggerInfo,false);
//                return;
//            }

//            TouchInteraction();
//        }

//        public void InitPlayInfo(IScenarioPlayInteract playInteract)
//        {
//            scenarioPlayInteract = playInteract;
//        }

//        public virtual void InteractCallBack(string name, string targetId, string info, string other)
//        {
//            NetworkTriggerInteraction(info, other);
//        }

//        /// <summary>
//        /// 网络互动触发
//        /// </summary>
//        protected void NetworkInteractTriggerFunc(string info, string other)
//        {
//            if (scenarioPlayInteract == null) return;

//            scenarioPlayInteract?.InteractFunc(info, other);
//        }


//        protected string Serailze<T>(T t)
//        {
//            string json = JsonUtility.ToJson(t);
//            return json;
//        }

//        protected T Deserialize<T>(string json)
//        {
//            T t = JsonUtility.FromJson<T>(json);
//            return t;
//        }


//        #endregion
//    }
//}