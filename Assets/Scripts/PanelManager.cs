using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelManager : MonoBehaviour
{

    public void PanelChanger(GameObject panelToActivate)
    {
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        foreach (var panel in panels)
        {
            panel.gameObject.SetActive(false);
        }

        panelToActivate.gameObject.SetActive(true);
    }

    public void ShowGameObject(GameObject gameObjectToShow)
    {
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel2");
        foreach (var panel in panels)
        {
            panel.gameObject.SetActive(false);
        }
        gameObjectToShow.gameObject.SetActive(true);
    }

    public void SimpleShowGameObject(GameObject gameObjectToShow)
    {
        gameObjectToShow.gameObject.SetActive(true);
    }

    public void HideGameObject(GameObject gameObjectToHide)
    {
        gameObjectToHide.gameObject.SetActive(false);
    }

}
