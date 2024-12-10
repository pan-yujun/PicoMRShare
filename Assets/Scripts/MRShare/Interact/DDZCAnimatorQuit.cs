//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
///// <summary>
///// 党的征程 未读 已读 正在读取状态切换
///// </summary>
//public class DDZCAnimatorQuit : StateMachineBehaviour
//{
    
//    /// <summary>
//    /// OnStateEnter
//    /// </summary>
//    /// <param name="animator">当前动画器，是这个状态机行为的引用</param>
//    /// <param name="stateInfo">当前状态的详细信息</param>
//    /// <param name="layerIndex">状态机行为状态的layer 层</param>
//    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        animator.gameObject.transform.Find("DDZC_ZG_YD").gameObject.SetActive(false);
//    }
//    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
      
//    }
//    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        animator.gameObject.transform.Find("DDZC_ZG_YD").gameObject.SetActive(true);
//        animator.gameObject.transform.Find("DDZC_ZG_XZ").gameObject.SetActive(false);

//    }

//    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {

//    }
//    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {

//    }

//}