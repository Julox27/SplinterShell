using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : Trap
{

    public float initialSpeed = 5f;
    protected float speed;
    public bool movingRight = true;
    public Button button;
    public override void Function()
    {
        speed = initialSpeed;
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (!movingRight)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    public override void TrapOff()
    {
        speed = 0;
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
