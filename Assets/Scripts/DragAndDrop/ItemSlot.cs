﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject self;
    [SerializeField] GameObject deactive;
    [SerializeField] GameObject activate;
    [SerializeField] GameObject activate2;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("On Drop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<Transform>().SetParent(self.transform);
            deactive.SetActive(false);
            activate.SetActive(true);
            activate2.SetActive(true);
        }
        
    }
}
