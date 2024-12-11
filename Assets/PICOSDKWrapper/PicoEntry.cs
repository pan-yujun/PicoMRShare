using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;

public class PicoEntry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PXR_Manager.EnableVideoSeeThrough = true;
        // 监听透视功能状态
        PXR_Manager.VstDisplayStatusChanged += VstDisplayStatusChanged;
    }
    private void VstDisplayStatusChanged(PxrVstStatus status)
    {
        Debug.Log($"[PicoEntry]VstDisplayStatusChanged>>{status}");
        switch (status)
        {
            case PxrVstStatus.Disabled: // 已关闭
                break;
            case PxrVstStatus.Enabling: // 开启中
                break;
            case PxrVstStatus.Enabled: // 已开启
                break;
            case PxrVstStatus.Disabling: // 关闭中
                break;
        }
    }

}
