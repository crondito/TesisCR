using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenChecker3 : MonoBehaviour
{

    [SerializeField] public List<GameObject> cajas;
    [SerializeField] GameObject activate;

    private int counter = 0;

    void Update()
    {
        if (counter < cajas.Count)
        {
            algo();
        }
        else if (counter >= cajas.Count)
        {
            activate.SetActive(true);
        }
    }

    private void algo()
    {
        foreach (GameObject caja in cajas)
        {
            if (caja.GetComponent<Image>().color == Color.green)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
        }
    }
}
