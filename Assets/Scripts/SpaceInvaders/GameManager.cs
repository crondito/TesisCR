using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int puntos;
    public TextMeshProUGUI textoPuntos;

    public int vidasTanque = 3;
    public TextMeshProUGUI textoVidas;

    public GameObject win;
    public GameObject lose;

    public void AddPuntos(int punt)
    {
        this.puntos += punt;
        UpdatePuntos();
    }

    private void UpdatePuntos()
    {
        this.textoPuntos.text = "PUNTOS: " + this.puntos;
    }

    public void QuitarVida()
    {
        this.vidasTanque -= 1;
        UpdateVidas();
    }

    public void UpdateVidas()
    {
        this.textoVidas.text = "VIDAS: " + this.vidasTanque;
    }

    public void WipeBoard()
    {
        GameObject[] panels = GameObject.FindGameObjectsWithTag("SI-");
        foreach (var panel in panels)
        {
            panel.gameObject.SetActive(false);
        }
        
        if (this.vidasTanque <= 0)
        {
            lose.SetActive(true);
        }
        else
        {
            win.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
