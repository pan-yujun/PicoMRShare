using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class ForceField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void DoRayCast()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo, 1000))
        {
            transform.position = hitInfo.point;
        }
    }
    // Update is called once per frame
    void Update(){
        //if (Input.GetMouseButton(0)) 
        //{
        //    DoRayCast();
        //}
        Shader.SetGlobalVector("HitPosition", transform.position);
        Shader.SetGlobalFloat("HitSize", transform.lossyScale.x);
    }
}
