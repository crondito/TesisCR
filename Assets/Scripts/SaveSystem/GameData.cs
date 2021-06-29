using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float califCVS;
    public float califAbs;
    public float califUML;
    public float califDdC;

    public bool pasadoFig;
    public bool pasadoSoko;
    public bool pasadoAst;

    public GameData (Game game)
    {
        califCVS = game.califCVS;
        califAbs = game.califAbs;
        califUML = game.califUML;
        califDdC = game.califDdC;

        pasadoFig = game.pasadoFig;
        pasadoSoko = game.pasadoSoko;
        pasadoAst = game.pasadoAst;
    }
}