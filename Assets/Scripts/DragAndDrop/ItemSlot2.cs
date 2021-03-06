using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot2 : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject self;
    [SerializeField] GameObject activar;

    public void OnDrop(PointerEventData eventData)
    {
        
        //Debug.Log("On Drop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (eventData.pointerDrag.gameObject.tag == self.tag)
            {
                self.GetComponent<Image>().color = Color.green;
                eventData.pointerDrag.gameObject.GetComponent<Image>().raycastTarget = false;
                self.GetComponent<ItemSlot2>().enabled = false;
                activar.SetActive(true);
                FindObjectOfType<SoundManagerScript>().Play("Success");
            } else
            {
                self.GetComponent<Image>().color = Color.red;
                FindObjectOfType<SoundManagerScript>().Play("Failure");
            }
        }
    }
}
