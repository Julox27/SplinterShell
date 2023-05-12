using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleoController : MonoBehaviour
{
    public int vidaInicial = 1;
    public int vidaActual;
    public Torreta torreta;
    void Start()
    {
        vidaActual = vidaInicial;
    }
    public void RecibirDano(int dano)
    {
        vidaActual -= dano;
        if (vidaActual <= 0)
        {
            DestruirNucleo();
        }
    }
    void DestruirNucleo()
    {
        
        torreta.NucleoDestruido();
        Destroy(gameObject);
    }
}
