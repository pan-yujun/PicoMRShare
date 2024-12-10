using UnityEngine;

public class OscillatingMove : MonoBehaviour
{

    public Vector3 startPos;
    public Vector3 endPos;

    
    public float acceleration;

    private float curAcceleration;
    private float velocity;
    private float halfDis = 0;

    private void Start()
    {
        halfDis = Vector3.Distance(startPos,endPos)/2;
    }

    void Update()
    {
        if (Vector3.Distance(transform.localPosition, endPos) > halfDis)
        {
            curAcceleration = acceleration;
        }
        else
        {
            curAcceleration = -acceleration;
        }
        velocity += curAcceleration * Time.deltaTime;
        transform.localPosition += (endPos - startPos).normalized * velocity;

        if (AtTargetPoint())
        {
            SwapAndReverse();
        }
    }

    void SwapAndReverse()
    {
        Vector3 tem = startPos;
        startPos = endPos;
        endPos = tem;

        velocity = 0;

        //(startPos, endPos) = (endPos, startPos);
        //shouldAccelerate = !shouldAccelerate;
        //reverse = !reverse;
    }

    bool AtTargetPoint()
    {
        float distanceToEndPoint = Vector3.Distance(transform.localPosition, endPos);
        return distanceToEndPoint < 0.01f;
    }
}