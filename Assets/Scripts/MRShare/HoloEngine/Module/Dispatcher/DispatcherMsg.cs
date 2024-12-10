using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 整个app公用的
/// </summary>
public partial class DispatcherMsg
{
    public const uint AppMsgId = 1000;
    
    public const uint MessageBoxOpen = AppMsgId + 1;// MeassageBox打开
    public const uint MessageBoxClose = AppMsgId + 2;// MeassageBox关闭

    public const uint WindowSizeChange = AppMsgId + 3;// app窗口大小变化

    public const uint System_Error = AppMsgId + 4000;
    public const uint System_Error_ClearAccountData = AppMsgId + 4001;


}
