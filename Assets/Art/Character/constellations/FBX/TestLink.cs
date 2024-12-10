using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestLink : MonoBehaviour
{

    public Transform prefab;

    public Transform[] postionList;

    public Transform lineObj;

    private void Start()
    {
        lineObj = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
        lineObj.parent = transform;
    }

    private void Update()
    {
        UpdateLine();
    }

    Transform photo;
    Transform root;

    private void UpdateLine()
    {
        float scale_z = Vector3.Distance(postionList[0].position, postionList[1].position);

        lineObj.position = (postionList[0].position + postionList[1].position) / 2;

        Vector3 prefabLocalScale = lineObj.localScale;

        if (root == null)
            root = transform.root;
        if (photo == null)
            photo = root.Find("Photos");

        lineObj.localScale = new Vector3(prefabLocalScale.x, prefabLocalScale.y, scale_z / photo.localScale.z/ root.localScale.z);

        lineObj.LookAt(postionList[1]);

    }
}
