using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierras : MonoBehaviour
{

    public float speed = 5f;
    public bool movingRight = true;

    private void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            movingRight = !movingRight; // Invierte la dirección de movimiento
        }
       
        
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("El jugador recibió daño.");
                
            }
        
    }

}
