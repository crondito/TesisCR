using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemSlot1 : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject desaparece1;
    [SerializeField] GameObject aparece1;
    [SerializeField] GameObject desaparece2;
    [SerializeField] GameObject aparece2;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("On Drop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            button.SetActive(true);

            if (eventData.pointerDrag.gameObject.tag == "square")
            {
                desaparece1.SetActive(false);
                aparece1.SetActive(true);
            }
            else if (eventData.pointerDrag.gameObject.tag == "circle")
            {
                desaparece2.SetActive(false);
                aparece2.SetActive(true);
            }

        }
        
    }
}
