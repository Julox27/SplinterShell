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
    private Vector3 rotacionActual;

    private void Start()
    {
        rotacionActual = transform.rotation.eulerAngles;
        player = GetComponent<Player>();
    }

    void Update()
    {
        // Obtener el valor de entrada horizontal y vertical del usuario.
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Crear un vector de movimiento basado en el valor de entrada y la velocidad.
        Vector3 movimiento = gameObject.transform.forward * movimientoVertical + gameObject.transform.right * movimientoHorizontal;
        movimiento.Normalize();

        movimiento *= velocidad * Time.deltaTime;

        // Rotar el objeto en el eje X.
        float rotacionX = Input.GetAxis("Mouse X") * velocidadRotacionX;
        transform.Rotate(0, rotacionX, 0);

        // Mover el objeto en la dirección del vector de movimiento.
        transform.position += movimiento;
        _isMoving = movimiento.magnitude > 0;
        anim.SetBool("isMoving", _isMoving);
    }

    public bool GetIsMoving()
    {
        return _isMoving;
    }
}