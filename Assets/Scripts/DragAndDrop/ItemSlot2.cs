using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemSlot2 : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject self;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("On Drop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<Transform>().SetParent(self.transform);
        }
        
    }
}
