using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject button;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("On Drop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            button.SetActive(true);
            
        }
        
    }
}
