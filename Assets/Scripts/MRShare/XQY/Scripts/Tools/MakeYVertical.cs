using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeYVertical : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
    }
}