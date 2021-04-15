using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    [SerializeField] GameObject button;

    public void ActivarODesactivar()
    {
        if (button.activeSelf == true)
        {
            button.SetActive(false);
        }
        else if (button.activeSelf == false)
        {
            button.SetActive(true);
        }
    }
}
