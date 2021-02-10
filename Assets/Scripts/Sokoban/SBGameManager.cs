using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBGameManager : MonoBehaviour
{

    private bool m_ReadyForInput;
    public SBPlayer m_Player;

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if(moveInput.sqrMagnitude > 0.5)
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                m_Player.Move(moveInput);
                // m_NextButton.SetActive(IsLevelComplete());
            }
        } else
        {
            m_ReadyForInput = true;
        }
    }
}
