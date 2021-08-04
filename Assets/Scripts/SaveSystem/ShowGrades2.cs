using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowGrades2 : MonoBehaviour
{
    public TMP_Text progress;

    private string pasadoFig;
    private string pasadoSoko;
    private string pasadoAst;
    private string pasadoFinal;

    public void Start()
    {
        if (FindObjectOfType<Game>().pasadoFig) { pasadoFig = "Terminado!"; } else { pasadoFig = "No Terminado!"; }
        if (FindObjectOfType<Game>().pasadoSoko) { pasadoSoko = "Terminado!"; } else { pasadoSoko = "No Terminado!"; }
        if (FindObjectOfType<Game>().pasadoAst) { pasadoAst = "Terminado!"; } else { pasadoAst = "No Terminado!"; }
        if (FindObjectOfType<Game>().pasadoFinal) { pasadoFinal = "Terminado!"; } else { pasadoFinal = "No Terminado!"; }

        progress.text = "PRUEBAS\n\n"
                      + "Prueba CVS: " + FindObjectOfType<Game>().califCVS.ToString() + "%\n"
                      + "Prueba Abstracción: " + FindObjectOfType<Game>().califAbs.ToString() + "%\n"
                      + "Prueba UML: " + FindObjectOfType<Game>().califUML.ToString() + "%\n"
                      + "Prueba Diagrama de Clases: " + FindObjectOfType<Game>().califDdC.ToString() + "%\n"
                      + "\n\n"
                      + "EJERCICIOS\n\n"
                      + "Ejercicio Figuras: " + pasadoFig + "\n"
                      + "Ejercicio Sokoban: " + pasadoSoko + "\n"
                      + "Ejercicio Asteroids: " + pasadoAst + "\n"
                      + "Ejercicio Space Invaders: " + pasadoFinal + "\n";
        
    }
}
