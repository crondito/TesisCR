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
        ResetScene();
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
                m_NextButton.SetActive(IsLevelComplete());
            }
        } else
        {
            m_ReadyForInput = true;
        }
    }

    public void NextLevel()
    {
        DeleteOldObjects();
        m_NextButton.SetActive(false);
        m_LevelBuilder.NextLevel();
        m_LevelBuilder.Build();
        m_Player = FindObjectOfType<SBPlayer>();
    }

    public void ResetScene()
    {
        DeleteOldObjects();
        m_NextButton.SetActive(false);
        m_LevelBuilder.Build();
        m_Player = FindObjectOfType<SBPlayer>();
    }

    public void DeleteOldObjects()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] crosses = GameObject.FindGameObjectsWithTag("Cross");
        foreach (var wall in walls)
        {
            Destroy(wall);
        }
        foreach (var box in boxes)
        {
            Destroy(box);
        }
        foreach (var player in players)
        {
            Destroy(player);
        }
        foreach (var cross in crosses)
        {
            Destroy(cross);
        }
        
    }

    bool IsLevelComplete()
    {
        SBBox[] boxes = FindObjectsOfType<SBBox>();
        foreach(var box in boxes)
        {
            if (!box.m_OnCross) return false;
        }
        return true;
    }
}
