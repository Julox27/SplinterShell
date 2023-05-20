using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool yaLanzoProyectil = false;
    public float fuerzaLanzamiento = 10f;
    public float jumpForce;
    public float gravity;
    private bool isOnFloor;

    [HideInInspector] public MeshRenderer meshR;
    [HideInInspector] public CapsuleCollider capColl;
    [HideInInspector] public Rigidbody rb;

    private void Start()
    {
        GameManager.instance.player = this;
        meshR = GetComponent<MeshRenderer>();
        capColl = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -gravity, 0);
    }

    private void Update()
    {
        if(!yaLanzoProyectil)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Slide();
                meshR.enabled = false;
                capColl.enabled = false;
                rb.Sleep();
            }
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            if(GameManager.instance.Deslizandose == false)
            {
                Destroy(GameManager.instance.inWorldCaparazon.gameObject);
                yaLanzoProyectil = false;
            }
            else
            {
                GameManager.instance.StopSlide();
            }
        }

        if (Physics.Raycast(transform.position, -transform.up, 2f))
        {
            isOnFloor = true;
            RaycastHit hit1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }          
        }
        else
        {
            isOnFloor = false;
        }
       
    }

    void jump()
    {

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }


    private void Shoot()
    {
        Vector3 posicionLanzamiento = transform.position + transform.forward * 2f + Vector3.down * 0.5f; // Vector que indica la posición de lanzamiento
        GameObject proyectil = Instantiate(PrefabManager.instance.Caparazon, posicionLanzamiento + new Vector3(0, 1, 0), transform.rotation);
        Rigidbody rbProyectil = proyectil.GetComponent<Rigidbody>();
        Vector3 direccion = new Vector3(gameObject.transform.forward.x, 0.2f, gameObject.transform.forward.z).normalized;
        rbProyectil.AddForce(direccion * fuerzaLanzamiento, ForceMode.Impulse);
        yaLanzoProyectil = true;
    }

    private void Slide()
    {
        Vector3 posicionLanzamiento = transform.position + transform.forward * 2f + Vector3.down * 0.5f; // Vector que indica la posición de lanzamiento
        GameObject proyectil = Instantiate(PrefabManager.instance.Caparazon, posicionLanzamiento + new Vector3(0, 1, 0), transform.rotation);
        Rigidbody rbProyectil = proyectil.GetComponent<Rigidbody>();
        Vector3 direccion = new Vector3(gameObject.transform.forward.x, 0, gameObject.transform.forward.z).normalized;
        rbProyectil.AddForce(direccion * fuerzaLanzamiento, ForceMode.Impulse);
        GameManager.instance.Deslizandose = true;
        yaLanzoProyectil = true;
    }

    public bool GetIsOnFloor()
    {
        return isOnFloor;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            yaLanzoProyectil = false;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("lava"))
        {

            Destroy(this.gameObject);
        }
    }
}
