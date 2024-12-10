//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DZWXinteract : MonoBehaviour
//{
//    public Camera ARcamera;
//    public Camera thiscamera;
//    public BoxCollider EnterDoorBox;
//    public BoxCollider ExitDoorBox;
//    public GameObject CSM;
//    public GameObject VRZT;
//    public GameObject[] CSMObjS;
//    public GameObject[] MEN02;
//    public Animator[] animatiors;
//    public bool iscollision = true;
//    private  float opentime=1f;
//    public GameObject HCDT_DH;
//    public Animator HCDT_DH_Animator;
//    void Start()
//    {
//        ARcamera = Camera.main;
//        thiscamera = this.GetComponent<Camera>();
//    }
//    void Update()
//    {
//        this.transform.position = ARcamera.transform.position;
//        this.transform.rotation = ARcamera.transform.rotation;
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.transform.name == "EnterDoor")
//        {
//            if (iscollision)
//                EnterDoor();
//        }
//        if (other.transform.name == "ExitDoor")
//        {
//            if (!iscollision)
//                ExitDoor();
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.transform.name == "EnterDoor")
//        {
//            iscollision = false;
//        }
//        if (other.transform.name == "ExitDoor")
//        {
//            iscollision = true;
//        }
//    }

//    void EnterDoor()
//    {
//        ARcamera.cullingMask |= (1 << 14);
//        thiscamera.cullingMask = 1 << 0;
//        foreach (var item in CSMObjS)
//        {
//            item.SetActive(false);
//        }
//        foreach (var item in MEN02)
//        {
//            item.layer = 14;
//        }
//    }
//    void ExitDoor()
//    {
    
//        ARcamera.cullingMask &= ~(1 << 14);
//        thiscamera.cullingMask = 1 << 14;
//        foreach (var item in CSMObjS)
//        {
//            item.SetActive(true);
//        }
//        foreach (var item in MEN02)
//        {
//            item.layer = 0;
//        }
//        foreach (var item in animatiors)
//        {
//            item.Play("idle");
//        }
//        SetactiveDH(true);
//    }
//    private void OnDestroy()
//    {
//        ExitDoor();
//    }
//    private void openenter()
//    {
//        EnterDoorBox.enabled = true;
//    }

//    public void SetactiveDH(bool b)
//    {
//        HCDT_DH.SetActive(b);
//    }
//    int i;
//    public void PlayDHAnimation()
//    {
      
//        if (i==0)
//        {
//            HCDT_DH_Animator.Play("AM_DH_bian01");
//           i++;
//        }
//        else
//        {
//            HCDT_DH_Animator.Play("AM_DH_bian02");
//            i = 0;
//        }
      
//    }
   

//}
