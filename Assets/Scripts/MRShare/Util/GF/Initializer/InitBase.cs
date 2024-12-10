using System.Collections.Generic;
using UnityEngine;

namespace GF
{
    public interface IInit
    {
        /// <summary>
        /// 1.全局只会执行一次
        /// 2.保持树状的初始化结构，必须遵循如下规则：
        /// OnInit只能被OnInit调用，最顶层的OnInit由Initializer来调用
        /// </summary>
        void OnInit();
    }

    public class InitBase : MonoBehaviour
    {
        public List<Transform> initList = new List<Transform>();

        protected void StartInit()
        {
            // 按List设定好的顺序执行初始化操作
            for (int i = 0; i < initList.Count; i++)
            {
                var initCom = initList[i].GetComponent<IInit>();

                if (initCom == null)
                {
                    Debug.Log($"查找不到初始化接口，物体名：{initList[i].name}");
                }
                else
                {
                    //Debug.Log("开始初始化:"+ initList[i].name);
                    initCom.OnInit();
                }
            }
        }
    }
}