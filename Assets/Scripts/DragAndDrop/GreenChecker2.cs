using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenChecker2 : MonoBehaviour
{
    [SerializeField] GameObject caja1;
    [SerializeField] GameObject caja2;
    [SerializeField] GameObject caja3;
    [SerializeField] GameObject caja4;
    [SerializeField] GameObject caja5;
    [SerializeField] GameObject caja6;
    [SerializeField] GameObject activate;

    // Update is called once per frame
    void Update()
    {
        if (caja1.GetComponent<Image>().color == Color.green &&
            caja2.GetComponent<Image>().color == Color.green &&
            caja3.GetComponent<Image>().color == Color.green &&
            caja4.GetComponent<Image>().color == Color.green &&
            caja5.GetComponent<Image>().color == Color.green &&
            caja6.GetComponent<Image>().color == Color.green)
        {
            activate.SetActive(true);
        }
        else
        {
            activate.SetActive(false);
        }
    }
}
