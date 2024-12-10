using HoloShare;
using UnityEngine;

/// <summary>
/// 控制模型介绍的开启和上一个介绍的关闭
/// </summary>
public class ModelIntroductionCtl : MonoBehaviour
{

    private AnimotionTouchNoSingleShowFix animotionTouchNoSingleShowFix;
    private Transform introductionObj;

    // Start is called before the first frame update
    void Start()
    {
        animotionTouchNoSingleShowFix = GetComponent<AnimotionTouchNoSingleShowFix>();
        introductionObj = transform.parent.Find("dianji");
        if (animotionTouchNoSingleShowFix != null)
            animotionTouchNoSingleShowFix.AnimotionOnTouch.AddListener(() => SetModelIntroductionState());
    }



    public void SetModelIntroductionState()
    {
        if (animotionTouchNoSingleShowFix != null && introductionObj != null)
        {

            if (!animotionTouchNoSingleShowFix.CanPlay)
            {
                ModelIntroductionInstance.Inst.CloseLastAudio(introductionObj);
                if (!introductionObj.gameObject.activeSelf)
                    introductionObj.gameObject.SetActive(true);

            }

        }
    }


    public void CloseLastAudio()
    {
        ModelIntroductionInstance.Inst.CloseLastAudio(null);
    }
}
