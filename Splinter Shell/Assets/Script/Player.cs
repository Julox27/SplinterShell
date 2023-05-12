using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool yaLanzoProyectil = false;
    public float fuerzaLanzamiento = 10f;

    [HideInInspector] public MeshRenderer meshR;
    [HideInInspector] public CapsuleCollider capColl;
    [HideInInspector] public Rigidbody rb;

    private void Start()
    {
        GameManager.instance.player = this;
        meshR = GetComponent<MeshRenderer>();
        capColl = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
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
        else if(Input.GetKeyDown(KeyCode.E) && GameManager.instance.Deslizandose == false)
        {
            Destroy(GameManager.instance.inWorldCaparazon.gameObject);
            yaLanzoProyectil = false;
        }
    }

    private void Shoot()
    {
        Vector3 posicionLanzamiento = transform.position + transform.forward * 2f + Vector3.down * 0.5f; // Vector que indica la posición de lanzamiento
        GameObject proyectil = Instantiate(PrefabManager.instance.Caparazon, posicionLanzamiento + new Vector3(0, 1, 0), transform.rotation);
        Rigidbody rbProyectil = proyectil.GetComponent<Rigidbody>();
        Vector3 direccion = new Vector3(gameObject.transform.forward.x, 0, gameObject.transform.forward.z).normalized;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            yaLanzoProyectil = false;
            Destroy(collision.gameObject);
        }
    }
}
