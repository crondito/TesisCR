using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLocks : MonoBehaviour
{
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;
    public GameObject lock5;
    public GameObject lock6;
    public int nextUnlock;

    private void Start()
    {
        if (FindObjectOfType<Game>().pasadoFig) { lock1.SetActive(false); } else { lock1.SetActive(true); }
        if (FindObjectOfType<Game>().pasadoSoko) { lock2.SetActive(false); } else { lock2.SetActive(true); }
        if (FindObjectOfType<Game>().pasadoSoko) { lock3.SetActive(false); } else { lock3.SetActive(true); }
        if (FindObjectOfType<Game>().pasadoAst) { lock4.SetActive(false); } else { lock4.SetActive(true); }
        if (FindObjectOfType<Game>().pasadoAst) { lock5.SetActive(false); } else { lock5.SetActive(true); }
        if (FindObjectOfType<Game>().pasadoFinal) { lock6.SetActive(false); } else { lock6.SetActive(true); }
    }

    public void UnlockNext()
    {
        if (nextUnlock == 0)
        {
            FindObjectOfType<Game>().pasadoFig = true;
            lock1.SetActive(false);
        }
        else if (nextUnlock == 1)
        {
            FindObjectOfType<Game>().pasadoSoko = true;
            lock2.SetActive(false);
            lock3.SetActive(false);
            //FindObjectOfType<Game>().pasadoAst = true;
        }
        /*else if (nextUnlock == 1)
        {
            FindObjectOfType<Game>().pasadoAst = true;
            lock3.SetActive(false);
        }*/
        else if (nextUnlock == 2)
        {
            FindObjectOfType<Game>().pasadoAst = true;
            lock4.SetActive(false);
            lock5.SetActive(false);
        }
        else if (nextUnlock == 3)
        {
            FindObjectOfType<Game>().pasadoFinal = true;
            lock6.SetActive(false);
        }

        FindObjectOfType<Game>().SaveGame();
    }
}
