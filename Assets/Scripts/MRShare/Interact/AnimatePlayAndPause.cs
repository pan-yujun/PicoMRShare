using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 简单的动画停止，暂停，播放功能（由外部调用）
/// </summary>
public class AnimatePlayAndPause : MonoBehaviour
{
    [SerializeField]
    private Animator[] m_TargetAnimatorArr;
    private float[] mAnimatorSpeedArr;

    // Start is called before the first frame update
    void Start()
    {
        mAnimatorSpeedArr = new float[m_TargetAnimatorArr.Length];
        for (int i = 0; i < m_TargetAnimatorArr.Length; i++)
        {
            mAnimatorSpeedArr[i] = m_TargetAnimatorArr[i].speed;
        }
    }


    /// <summary>
    /// 继续
    /// </summary>
    public void PlayAnimate()
    {
        for (int i = 0; i < m_TargetAnimatorArr.Length; i++)
        {
            m_TargetAnimatorArr[i].speed = mAnimatorSpeedArr[i];
        }
    }

    /// <summary>
    /// 暂停
    /// </summary>
    public void PauseAnimate()
    {
        for (int i = 0; i < m_TargetAnimatorArr.Length; i++)
        {
            m_TargetAnimatorArr[i].speed = 0;
        }
    }

    public void AnimateNoEnabled()
    {
        for (int i = 0; i < m_TargetAnimatorArr.Length; i++)
        {
            m_TargetAnimatorArr[i].enabled = false;
        }
    }
    

    public void AnimateEnabled()
    {
        for (int i = 0; i < m_TargetAnimatorArr.Length; i++)
        {
            m_TargetAnimatorArr[i].enabled = true;
        }
    }
}
