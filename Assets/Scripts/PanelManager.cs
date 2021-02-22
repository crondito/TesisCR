using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
