using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
   
    public Image barraDeVida;

    public float vidaActual;

    public float vidaMaxima;

   
    public void Update()
    {
        
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
        vidaActual = FindObjectOfType<GameManager>().m_vidaActual;

        if (vidaActual <= 0)
        {
            FindObjectOfType<GameManager>().GameOver();
            
        }
        
    }
}
