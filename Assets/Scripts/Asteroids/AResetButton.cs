using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AResetButton : MonoBehaviour
{
    public GameObject player;
    public GameObject ast1;
    public GameObject ast2;
    public GameObject ast3;

    private Vector3 playerPosition;
    private Vector3 ast1Position;
    private Vector3 ast2Position;
    private Vector3 ast3Position;
    private Quaternion playerRotation;

    public void Start()
    {
        playerPosition = player.transform.position;
        playerRotation = player.transform.rotation;

        ast1Position = ast1.transform.position;
        ast2Position = ast2.transform.position;
        ast3Position = ast3.transform.position;
    }

    public void ResetGame()
    {
        var asts = GameObject.FindGameObjectsWithTag("Asteroid");
        var playr = GameObject.FindGameObjectsWithTag("Player");

        for (var i = 0; i < asts.Length; i++)
        {
            asts[i].SetActive(false);
        }

        for (var i = 0; i < playr.Length; i++)
        {
            playr[i].SetActive(false);
        }
    }

    public void RestartGame()
    {
        player.transform.position = playerPosition;
        player.transform.rotation = playerRotation;
        player.SetActive(true);

        ast1.transform.position = ast1Position;
        ast1.SetActive(true);

        ast2.transform.position = ast2Position;
        ast2.SetActive(true);

        ast3.transform.position = ast3Position;
        ast3.SetActive(true);
    }
}
