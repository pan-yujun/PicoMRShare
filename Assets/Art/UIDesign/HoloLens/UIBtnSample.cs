using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBtnSample : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    Button btn;

    public GameObject hover;
    public GameObject select;

    private void Start()
    {
        btn = GetComponent<Button>();      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowImg(hover);
    }  

    public void OnPointerExit(PointerEventData eventData)
    {
        HideImg(hover);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ShowImg(select);
        btn.interactable = false;
    }

    private void HideImg(GameObject imgObj)
    {
        imgObj.SetActive(false);
    }

    private void ShowImg(GameObject imgObj)
    {
        imgObj.SetActive(true);
    }
}
