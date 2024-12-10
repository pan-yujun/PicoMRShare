using UnityEngine;
using System.Collections;

public enum MarkerType
{
    Smooth = 0,
    Transform = 1,
    Beizer = 2,
    BeizerCorner = 3,
    Corner = 4
}

[System.Serializable]
public partial class SplineBendMarker : MonoBehaviour
{
    public SplineBend splineScript;
    [UnityEngine.HideInInspector]
    public int num;
    public MarkerType type;
    //var prewHandleTransform : Transform;
    //var nextHandleTransform : Transform;
    [UnityEngine.HideInInspector]
    public Vector3 position;
    [UnityEngine.HideInInspector]
    public Vector3 up;
    [UnityEngine.HideInInspector]
    public Vector3 prewHandle; //in marker local coords
    [UnityEngine.HideInInspector]
    public Vector3 nextHandle;
    //var prewHandleLength : float;
    //var nextHandleLength : float;
    [UnityEngine.HideInInspector]
    public float dist; //distance from the first marker
    [UnityEngine.HideInInspector]
    public float percent; //marker pos in a whole spline from 0 to 1
    [UnityEngine.HideInInspector]
    public Vector3[] subPoints; //beizer points from this marker to the next one
    [UnityEngine.HideInInspector]
    public float[] subPointPercents;
    [UnityEngine.HideInInspector]
    public float[] subPointFactors;
    [UnityEngine.HideInInspector]
    public float[] subPointMustPercents;
    public bool expandWithScale;
    [UnityEngine.HideInInspector]
    public Vector3 oldPos;
    [UnityEngine.HideInInspector]
    public Vector3 oldScale;
    [UnityEngine.HideInInspector]
    public Quaternion oldRot;
    /*
var subPoints : Vector3[] = new Vector3[3]; //beizer points from this marker to the next one
var subPointPercents : float[] = new float[3];
var subPointFactors : float[] = new float[3];
var subPointMustPercents : float[] = new float[3];
*/
    public virtual void Init(SplineBend script, int mnum) //called from SplineBend
    {
        this.splineScript = script;
        this.num = mnum;
        this.up = this.transform.up;
        this.position = script.transform.InverseTransformPoint(this.transform.position); //localPosition
        //position = script.transform.localPosition;
        //marker position in script tfm coordsys
        //even if marker not a script tfm child
        //finding next and prew markers
        SplineBendMarker nextMarker = null;
        SplineBendMarker prewMarker = null;
        if (this.num > 0)
        {
            prewMarker = this.splineScript.markers[this.num - 1];
        }
        if (this.num < (this.splineScript.markers.Length - 1))
        {
            nextMarker = this.splineScript.markers[this.num + 1];
        }
        //calculating marker distance
        if (!!prewMarker)
        {
            this.dist = prewMarker.dist + SplineBend.GetBeizerLength(prewMarker, this);
        }
        else
        {
            this.dist = 0;
        }
        //amendments in first (and last) marker prew-next if spline is closed
        if (this.splineScript.closed && (this.num == (this.splineScript.markers.Length - 1)))
        {
            nextMarker = this.splineScript.markers[this.splineScript.markers.Length - 2];
            nextMarker = this.splineScript.markers[1];
        }
        //creating sub-points
        if (!!nextMarker)
        {
            if (this.subPoints == null)
            {
                this.subPoints = new Vector3[10];
            }
            float percentStep = 1f / (this.subPoints.Length - 1);
            int p = 0;
            while (p < this.subPoints.Length)
            {
                this.subPoints[p] = SplineBend.AlignPoint(this, nextMarker, percentStep * p, new Vector3(0, 0, 0));
                p++;
            }
            //percent data
            float totalDist = 0;
            this.subPointPercents[0] = 0;
            float mustStep = 1f / (this.subPoints.Length - 1);
            p = 1;
            while (p < this.subPoints.Length)
            {
                this.subPointPercents[p] = totalDist + (this.subPoints[p - 1] - this.subPoints[p]).magnitude;
                totalDist = this.subPointPercents[p];
                this.subPointMustPercents[p] = mustStep * p;
                p++;
            }
            p = 1;
            while (p < this.subPoints.Length)
            {
                this.subPointPercents[p] = this.subPointPercents[p] / totalDist;
                p++;
            }
            p = 0;
            while (p < (this.subPoints.Length - 1))
            {
                this.subPointFactors[p] = mustStep / (this.subPointPercents[p + 1] - this.subPointPercents[p]);
                p++;
            }
        }
        //finding next marker position - we will use it in switch below
        Vector3 nextMarkerPosition = new Vector3(0, 0, 0);
        if (!!nextMarker)
        {
            nextMarkerPosition = script.transform.InverseTransformPoint(nextMarker.transform.position);
        }
        switch (this.type)
        {
            case MarkerType.Smooth:
                if (!nextMarker)
                {
                    this.prewHandle = (prewMarker.position - this.position) * 0.333f;
                    this.nextHandle = -this.prewHandle * 0.99f;
                }
                else
                {
                    if (!prewMarker)
                    {
                        this.nextHandle = (nextMarkerPosition - this.position) * 0.333f;
                        this.prewHandle = -this.nextHandle * 0.99f;
                    }
                    else
                    {
                        this.nextHandle = Vector3.Slerp(-(prewMarker.position - this.position) * 0.333f, (nextMarkerPosition - this.position) * 0.333f, 0.5f);
                        this.prewHandle = Vector3.Slerp((prewMarker.position - this.position) * 0.333f, -(nextMarkerPosition - this.position) * 0.333f, 0.5f);
                    }
                }
                break;
            case MarkerType.Transform:
                if (!!prewMarker)
                {
                    float prewDist = (this.position - prewMarker.position).magnitude;
                    this.prewHandle = ((-this.transform.forward * this.transform.localScale.z) * prewDist) * 0.4f;
                }
                if (!!nextMarker)
                {
                    float nextDist = (this.position - nextMarkerPosition).magnitude;
                    this.nextHandle = ((this.transform.forward * this.transform.localScale.z) * nextDist) * 0.4f;
                }
                break;
            case MarkerType.Corner:
                if (!!prewMarker)
                {
                    this.prewHandle = (prewMarker.position - this.position) * 0.333f;
                }
                else
                {
                    this.prewHandle = new Vector3(0, 0, 0);
                }
                if (!!nextMarker)
                {
                    this.nextHandle = (nextMarkerPosition - this.position) * 0.333f;
                }
                else
                {
                    this.nextHandle = new Vector3(0, 0, 0);
                }
                break;
        }
        //avoiding zero-length handle vectors
        //if (nextHandle.sqrMagnitude==0 && prewHandle.sqrMagnitude==0) { nextHandle=Vector3(0.001,0,0); prewHandle=Vector3(-0.001,0,0); }
        if ((this.nextHandle - this.prewHandle).sqrMagnitude < 0.01f)
        {
            this.nextHandle = this.nextHandle + new Vector3(0.001f, 0, 0);
        }
    }

    public SplineBendMarker()
    {
        this.subPoints = new Vector3[10];
        this.subPointPercents = new float[10];
        this.subPointFactors = new float[10];
        this.subPointMustPercents = new float[10];
    }

}