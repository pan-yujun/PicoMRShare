using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleMask : MonoBehaviour {
    public RectMask2D mask;
    public Material mt;
    public ScrollRect scrollRect;
    private void Awake()
    {
        mt = GetComponent<ParticleSystem>().GetComponent<Renderer>().material;
    }
    public void SetRectInfo(RectMask2D rectMask, ScrollRect scrollRect)
    {
        mask = rectMask;
        this.scrollRect = scrollRect;
        this.scrollRect.onValueChanged.AddListener((e) => SetClip());
        SetClip();
    }
    void SetClip()
    {
        Vector3[] wc = new Vector3[4];
        mask.GetComponent<RectTransform>().GetWorldCorners(wc);   //  计算World space中的点坐标
        var clipRect = new Vector4(wc[0].x, wc[0].y, wc[2].x, wc[2].y);     //选取左下角和右上角
        mt.SetVector("_ClipRect", clipRect);                                //设置裁剪区域
        mt.SetFloat("_UseClipRect", 1.0f);                                  //开启裁剪
    }
}
