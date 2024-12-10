using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ShakeCamera : MonoBehaviour 
{

	private float shakeTime = 0.0f;
    private float fps = 60.0f;
    private float frameTime = 0.0f;
    private Rect caRect = new Rect(0,0,1,1);
    private bool isShakeCamera = false;
	private float currentShakeDalta = 0.005f;

    public float shakeDelta = 0.005f;
    public float shakeAllTime = 2;
	public float delayTime = -1;
	
	public bool shakeTimeDecay = true;

    public Camera cam;		
	
    // Use this for initialization
    void Start()
    {
        fps = 60.0f;
		if(null != cam && delayTime > 0)
		{
			Invoke("ShakeCamera",delayTime);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if(null != cam && isShakeCamera)
        {
            shakeTime += Time.deltaTime;
            if (shakeTime >= shakeAllTime)
            {
                cam.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                isShakeCamera = false;
                shakeTime = 0.1f;
                fps = 60.0f;
                frameTime = 0.01f;
            }
            else
            {
				if(shakeTimeDecay)
				{
					currentShakeDalta = shakeDelta*(1 - shakeTime/shakeAllTime);
				}
				cam.rect = new Rect(currentShakeDalta * (-1.0f + 2.0f * Random.value), currentShakeDalta * (-1.0f + 2.0f * Random.value), 1.0f, 1.0f);
            }
        }
    }

    [ContextMenu("Shake")]
    public void ShakeCamera()
    {
        isShakeCamera = true;
        shakeTime = 0;
        frameTime = 0;
		currentShakeDalta = shakeDelta;
    }

    public void ShakeCamera(Camera ca)
    {
        isShakeCamera = true;
        shakeTime = 0;
        frameTime = 0;

        if(null != ca)
        {
            cam = ca;
            caRect = cam.rect;
        }
    }

    void OnDestroy()
    {
        if(null != cam)
        {
            cam.rect = caRect;
        }
    }
}
