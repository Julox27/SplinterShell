using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaTorreta : MonoBehaviour
{
    private float bTimer = 10;
    public int numeroDeNucleos = 3;
    public int vidaInicialNucleos = 1;

    void Update()
    {
        bTimer -= Time.deltaTime;
        transform.Translate(0, 0,30 * Time.deltaTime, Space.Self);

        if(bTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Choque contra Jugador, hice dano");
            GameManager.instance.vidaPlayer--;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Choque contra entorno");
            Destroy(gameObject);
       
        }

        if (collision.gameObject.CompareTag("Nucleo"))
        {
            NucleoController nucleo = collision.gameObject.GetComponent<NucleoController>();
            nucleo.RecibirDano(1);
           
            Destroy(gameObject);
        }
    }

}


