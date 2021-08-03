using UnityEngine;
using UnityEngine.UI;

public class GreenChecker : MonoBehaviour
{
    [SerializeField] GameObject caja1;
    [SerializeField] GameObject caja2;
    [SerializeField] GameObject caja3;
    [SerializeField] GameObject caja4;
    [SerializeField] GameObject activate;

    void Update()
    {
        if (caja1.GetComponent<Image>().color == Color.green &&
            caja2.GetComponent<Image>().color == Color.green &&
            caja3.GetComponent<Image>().color == Color.green &&
            caja4.GetComponent<Image>().color == Color.green)
        {
            activate.SetActive(true);
        }
        else
        {
            activate.SetActive(false);
        }
    }
}
