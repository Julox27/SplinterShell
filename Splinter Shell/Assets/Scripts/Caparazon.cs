using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caparazon : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direccion;
    private float velocidad = 5f;




    void Start()
    {

        rb = GetComponent<Rigidbody>();
        direccion = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        lastFrameVelocity = rb.velocity;
        GameManager.instance.inWorldCaparazon = this;



    }

    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    [SerializeField]
    private float minVelocity = 10f;

    private Vector3 lastFrameVelocity;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared") || collision.gameObject.CompareTag("BarrelDestroy"))
        {
            Bounce(collision.contacts[0].normal);
        }

    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        direccion = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        //Debug.Log("Out Direction: " + direction);
        rb.velocity = direccion * Mathf.Max(speed, minVelocity);
    }

    

}


