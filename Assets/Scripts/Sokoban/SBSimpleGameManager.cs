using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SBSimpleGameManager : MonoBehaviour
{

    private bool m_ReadyForInput;
    public SBPlayer2 m_Player;
    public GameObject m_NextButton;

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if (moveInput.sqrMagnitude > 0.5)
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                m_Player.Move(moveInput);
                m_NextButton.SetActive(IsLevelComplete());
            }
        }
        else
        {
            m_ReadyForInput = true;
        }
    }

    public void ResetPlayer(GameObject p)
    {
        Vector3 posP = new Vector3(670f, 11f, 0f);
        p.transform.localPosition = posP;
    }

    public void ResetBox(GameObject b)
    {
        Vector3 posP = new Vector3(348f, -97f, 0f);
        b.transform.localPosition = posP;
        b.GetComponent<Image>().color = Color.white;
    }

    bool IsLevelComplete()
    {
        SBBox2[] boxes = FindObjectsOfType<SBBox2>();
        foreach (var box in boxes)
        {
            if (!box.m_OnCross) return false;
        }
        return true;
    }
}
