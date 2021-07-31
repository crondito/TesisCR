using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int puntos;
    public TextMeshProUGUI textoPuntos;

    public int vidasTanque = 3;
    public TextMeshProUGUI textoVidas;

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
}
