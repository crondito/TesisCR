using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOff : MonoBehaviour
{

    public GameObject button1;
    public GameObject button2;

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
