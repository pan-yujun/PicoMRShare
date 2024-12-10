//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class RiseNumber : MonoBehaviour
//{
//    [Tooltip("上涨最大值")]
//    public float MaxNumber;
//    [Tooltip("上涨初始值")]
//    public float MinNumber;
//    [Tooltip("上涨增量")]
//    public float AddNumber;
//    [Tooltip("上涨间隔时间")]
//    public float RiseSpeed;


//    private float RiseSpeedTemp;
//    private float MinNumberTemp;


//    private TextMeshPro textMeshPro;

//    private void Awake()
//    {
//        RiseSpeedTemp = RiseSpeed;
//        MinNumberTemp = MinNumber;
//        textMeshPro = this.GetComponent<TextMeshPro>();
//    }

//    void Update()
//    {
//        if (MaxNumber> MinNumber)
//        {
//            RiseSpeed -= Time.deltaTime;
//            if (RiseSpeed<=0)
//            {
//                MinNumber = MinNumber + AddNumber;
//                if (textMeshPro != null)
//                {
//                    textMeshPro.text = MinNumber.ToString();
//                }
         
//                RiseSpeed = RiseSpeedTemp;
//            }
            
//        }
//    }
//    void OnDisable()
//    {

//        RiseSpeed = RiseSpeedTemp;
//        MinNumber = MinNumberTemp;
//    }

//}
