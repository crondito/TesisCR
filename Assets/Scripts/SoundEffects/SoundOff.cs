using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOff : MonoBehaviour
{

    public GameObject button1;
    public GameObject button2;

    private bool isItPlaying;

    private void Start()
    {
        Invoke("AutoPlay", 0.01f);
    }

    private void AutoPlay()
    {
        isItPlaying = FindObjectOfType<SoundManagerScript>().CheckIfPlaying("Theme");
        if (isItPlaying)
        {
            button1.SetActive(true);
            button2.SetActive(false);
        }
        else if (!isItPlaying)
        {
            button1.SetActive(false);
            button2.SetActive(true);
        }
    }

    public void PauseMusic()
    {
        FindObjectOfType<SoundManagerScript>().Pause("Theme");
        button1.SetActive(false);
        button2.SetActive(true);
    }

    public void PlayMusic()
    {
        FindObjectOfType<SoundManagerScript>().Play("Theme");
        button2.SetActive(false);
        button1.SetActive(true);
    }
}
