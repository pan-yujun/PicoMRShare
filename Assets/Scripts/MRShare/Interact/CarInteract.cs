using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteract : MonoBehaviour
{
    private string color1= "Car01Color01";
    private string color2 = "Car01Color02";
    private string color3 = "Car01Color03";
    private string color4 = "Car01Color04";
    private string color5 = "Car01Color05";
    private string color6 = "Car01Color06";
    private string color7 = "Car01Color07";
    List<string> AllColor;
    int i = 0;
    Animator animator;
    void Start()
    {
        AllColor = new List<string>(); 
        AllColor.Add(color1);
        AllColor.Add(color2);
        AllColor.Add(color3);
        AllColor.Add(color4);
        AllColor.Add(color5);
        AllColor.Add(color6);
        AllColor.Add(color7);
         animator = this.GetComponent<Animator>();
    }
    public void QHColor()
    {
        animator.Play(AllColor[i]);
        i++;
        if (i>=7)
        {
            i = 0;
        }
    }
}
