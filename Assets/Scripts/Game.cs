using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public float califCVS = 0f;
    public float califAbs = 0f;
    public float califUML = 0f;
    public float califDdC = 0f;

    public bool pasadoFig = false;
    public bool pasadoSoko = false;
    public bool pasadoAst = false;

    public void Awake()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();

        califCVS = data.califCVS;
        califAbs = data.califAbs;
        califUML = data.califUML;
        califDdC = data.califDdC;

        pasadoFig = data.pasadoFig;
        pasadoSoko = data.pasadoSoko;
        pasadoAst = data.pasadoAst;
    }

    public void ResetGame()
    {
        califCVS = 0f;
        califAbs = 0f;
        califUML = 0f;
        califDdC = 0f;

        pasadoFig = false;
        pasadoSoko = false;
        pasadoAst = false;

        SaveGame();
    }
}
