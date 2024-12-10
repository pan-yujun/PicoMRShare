using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GF
{
    /// <summary>
    /// 初始化组，同类型的分到一起，方便管理
    /// </summary>
    public class InitGroup : InitBase, IInit
    {
        public void OnInit()
        {
            StartInit();
        }
    }
}