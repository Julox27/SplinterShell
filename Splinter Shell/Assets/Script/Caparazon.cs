using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caparazon : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direccion;
    private float velocidad = 5f;
    public float fuerzaDeDesaceleracion = 0.1f;
    [SerializeField] private float slideTimer;


    void Start()
    {
        slideTimer = 3;
        rb = GetComponent<Rigidbody>();
        direccion = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        lastFrameVelocity = rb.velocity;
        GameManager.instance.inWorldCaparazon = this;

        if (GameManager.instance.Deslizandose)
        {
            slideTimer -= Time.deltaTime;
            if(slideTimer <= 0)
            {
                GameManager.instance.StopSlide();
                GameManager.instance.player.transform.position = gameObject.transform.position + new Vector3(0,2,0);
                GameManager.instance.Deslizandose = false;
                GameManager.instance.player.yaLanzoProyectil = false;
                Destroy(gameObject);
            }
        }
        Movement();
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
        if(collision.gameObject.CompareTag("Pared"))
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

    private void Movement()
    {
        if(GameManager.instance.Deslizandose)
        {
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            transform.position += gameObject.transform.right * movimientoHorizontal * (velocidad / 2) * Time.deltaTime;
        }
            transform.position += direccion * velocidad * 2 * Time.deltaTime;
    }
}


