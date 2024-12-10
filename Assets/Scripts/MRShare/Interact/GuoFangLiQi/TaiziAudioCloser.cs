//using HoloShare;
//using UnityEngine;

///// <summary>
///// 关闭模型介绍
///// </summary>
//public class TaiziAudioCloser : MonoBehaviour
//{
//    private AnimatorTouch animotionTouchNoSingleShowFix;
//    void Start()
//    {
//        animotionTouchNoSingleShowFix = GetComponent<AnimatorTouch>();
//        if (animotionTouchNoSingleShowFix != null)
//            animotionTouchNoSingleShowFix.AnimationOnTouch.AddListener(() => SetModelIntroductionState());
//    }

//    private void SetModelIntroductionState()
//    {
//        if (animotionTouchNoSingleShowFix != null)
//        {

//            if (!animotionTouchNoSingleShowFix.CanPlay)
//            {
//                ModelIntroductionInstance.Inst.CloseLastAudio(null);
               
//            }


//        }
//    }
//}
