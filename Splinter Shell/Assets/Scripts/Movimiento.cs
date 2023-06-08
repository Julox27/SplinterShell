using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadRotacionX = 5.0f;
    public GameObject prefabProyectil;
    private bool _isMoving;
    public Animator anim;

    private Player player;
    private Rigidbody rb;
    private Camera mainCamera;

    private void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Obtener el valor de entrada horizontal y vertical del usuario.
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Obtener la dirección hacia adelante de la cámara.
        Vector3 direccionCamara = mainCamera.transform.forward;
        direccionCamara.y = 0f;
        direccionCamara.Normalize();

        // Crear un vector de movimiento basado en el valor de entrada, la dirección de la cámara y la velocidad.
        Vector3 movimiento = (movimientoHorizontal * mainCamera.transform.right + movimientoVertical * direccionCamara) * velocidad;
        movimiento.y = rb.velocity.y; // Mantener la velocidad vertical actual.

        // Aplicar la fuerza al Rigidbody para mover al personaje.
        rb.velocity = movimiento;

        // Rotar el objeto en el eje X.
        float rotacionX = Input.GetAxis("Mouse X") * velocidadRotacionX;
        transform.Rotate(0, rotacionX, 0);

        _isMoving = movimiento.magnitude > 0;
        anim.SetBool("isMoving", _isMoving);
    }
}
