using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaTorreta : MonoBehaviour
{
    private float bTimer = 10;

    private void Awake()
    {

    }
    void Update()
    {
        bTimer -= Time.deltaTime;
        transform.Translate(0, 0,10 * Time.deltaTime, Space.Self);

        if(bTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

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
    }
}
