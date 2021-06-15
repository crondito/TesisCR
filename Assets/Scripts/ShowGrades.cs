using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowGrades : MonoBehaviour
{
    public TMP_Text scoreCVS;
    public TMP_Text scoreAbs;
    public TMP_Text scoreUML;
    public TMP_Text scoreDdC;

    public void Start()
    {
        scoreCVS.text = "Calificaci�n:\n" + FindObjectOfType<Game>().califCVS.ToString() + "%";
        scoreAbs.text = "Calificaci�n:\n" + FindObjectOfType<Game>().califAbs.ToString() + "%";
        scoreUML.text = "Calificaci�n:\n" + FindObjectOfType<Game>().califUML.ToString() + "%";
        scoreDdC.text = "Calificaci�n:\n" + FindObjectOfType<Game>().califDdC.ToString() + "%";
    }

}
