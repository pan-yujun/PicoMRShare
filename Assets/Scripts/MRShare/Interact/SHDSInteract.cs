//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SHDSInteract : MonoBehaviour
//{
//    public GameObject[] gameObjects;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    int i = 0;
//    public void NextObj()
//    {
//        i++;
//        if (i >= gameObjects.Length)
//            i = 0;

//        if (i == 0)
//        {
//            gameObjects[gameObjects.Length - 1].SetActive(false); 
//        }
//        else
//        {
//            gameObjects[i - 1].SetActive(false);
//        }
          

//        gameObjects[i].SetActive(true);
//        gameObjects[i].GetComponent<Animator>().Play("Juanzhou");

//    }
//    public void CloseObj()
//    {
//        foreach (var item in gameObjects)
//        {
//            if (item.activeSelf)
//            {
//                item.GetComponent<Animator>().Play("idle");
//            }
//        }
//    }
//}
