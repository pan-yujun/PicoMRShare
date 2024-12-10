using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 党风廉政
/// 如果金钟无交互8秒后回到idle状态
/// 金钟动画播放完后返回到idle状态
/// </summary>
public class AnimatorQuit : StateMachineBehaviour
{
    public Image Image;
    public Animator animation;
    float f = 0;
    /// <summary>
    /// OnStateEnter
    /// </summary>
    /// <param name="animator">当前动画器，是这个状态机行为的引用</param>
    /// <param name="stateInfo">当前状态的详细信息</param>
    /// <param name="layerIndex">状态机行为状态的layer 层</param>
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("idle"))
        {
            f += Time.deltaTime;
            if (f>=8)
            {
                Toidle();
            }
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("On"))
        {
            Toidle();
        }
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void  Toidle()
    {
        f = 0; 
        Animator animation1 = GameObject.Find("Tiger").GetComponent<Animator>();
        animation1.Play("idle");
        animation = GameObject.Find("FaZhi").GetComponent<Animator>();
        animation.Play("idle");
    

    }

}