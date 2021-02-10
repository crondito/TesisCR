using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBGameManager : MonoBehaviour
{
    public SBLevelBuilder m_LevelBuilder;
    public GameObject m_NextButton;
    private bool m_ReadyForInput;
    private SBPlayer m_Player;

    private void Start()
    {
        m_LevelBuilder.Build();
        m_Player = FindObjectOfType<SBPlayer>();
    }

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
                //m_NextButton.SetActive(IsLevelComplete());
            }
        } else
        {
            m_ReadyForInput = true;
        }
    }

    public void NextLevel()
    {
        // m_NextButton.SetActive(false);
        m_LevelBuilder.NextLevel();
        m_LevelBuilder.Build();
        // StartCoroutine(ResetSceneAsync());
    }

    public void ResetScene()
    {
        // StartCoroutine(ResetSceneAsync());
    }
}
