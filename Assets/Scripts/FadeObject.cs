using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    private bool fadeOut;
    public float fadeSpeed;

    private void Update()
    {
        fadeOutObject();

        if (fadeOut)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a <= 0)
            {
                fadeOut = false;
            }
        }
    }

    private void OnEnable()
    {
        Color objectColor = this.GetComponent<Renderer>().material.color;
        objectColor.a = 1f;
        this.GetComponent<Renderer>().material.color = objectColor;
    }

    public void fadeOutObject()
    {
        fadeOut = true;
    }
}
