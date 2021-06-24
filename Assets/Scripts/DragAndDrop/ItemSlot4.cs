using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot4 : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject activate;
    [TextArea] public string infoL;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("On Drop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<SimpleTooltip>().infoLeft = infoL;
            activate.SetActive(true);
        }

    }
}
