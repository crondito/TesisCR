using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLocks : MonoBehaviour
{
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;
    public int nextUnlock;

    private void Start()
    {
        if (FindObjectOfType<Game>().pasadoFig) { lock1.SetActive(false); } else { lock1.SetActive(true); }
        if (FindObjectOfType<Game>().pasadoSoko) { lock2.SetActive(false); } else { lock2.SetActive(true); }
        if (FindObjectOfType<Game>().pasadoSoko) { lock3.SetActive(false); } else { lock3.SetActive(true); }
        if (FindObjectOfType<Game>().pasadoAst) { lock4.SetActive(false); } else { lock4.SetActive(true); }
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
            //FindObjectOfType<Game>().pasadoAst = true;
            lock3.SetActive(false);
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
        }

        FindObjectOfType<Game>().SaveGame();
    }
}
