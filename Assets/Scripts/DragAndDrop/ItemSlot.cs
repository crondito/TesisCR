using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject cir1;
    [SerializeField] GameObject cir2;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("On Drop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            button.SetActive(true);
            cir1.SetActive(false);
            cir2.SetActive(true);
        }
        
    }
}
