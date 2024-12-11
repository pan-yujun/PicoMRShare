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
        // ����͸�ӹ���״̬
        PXR_Manager.VstDisplayStatusChanged += VstDisplayStatusChanged;
    }
    private void VstDisplayStatusChanged(PxrVstStatus status)
    {
        Debug.Log($"[PicoEntry]VstDisplayStatusChanged>>{status}");
        switch (status)
        {
            case PxrVstStatus.Disabled: // �ѹر�
                break;
            case PxrVstStatus.Enabling: // ������
                break;
            case PxrVstStatus.Enabled: // �ѿ���
                break;
            case PxrVstStatus.Disabling: // �ر���
                break;
        }
    }

}
