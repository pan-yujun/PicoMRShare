using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GF
{
    /// <summary>
    /// 初始化器
    /// 统一的初始化入口，主要为了避免频繁使用Mono生命周期函数来初始化而造成的逻辑混乱。
    /// </summary>
    public class Initializer : InitBase
    {
        private void Start()
        {
            StartInit();
        }
    }
}