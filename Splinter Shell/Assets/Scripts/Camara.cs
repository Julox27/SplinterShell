using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float sensibilidad = 5.0f; // Sensibilidad de la camara al movimiento del ratón
    public bool invertirY = false; // Invertir o no el movimiento vertical del ratón
    public float distancia = 5.0f; // Distancia de la camara al objetivo
    private Transform objetivo; // Transform del objetivo que sigue la camara
    private float rotacionX = 0.0f; // Rotacion horizontal de la camara
    private float rotacionY = 0.0f; // Rotacion vertical de la camara
    public float distanciaColision = 1f; // Distancia de colision para evitar que la camara atraviese objetos
    public float maxYAngle = 80.0f; // El ángulo máximo hacia arriba
    public float minYAngle = 0.0f; // El ángulo máximo hacia abajo


    internal static Camera main;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor del ratón en el centro de la pantalla
        AjustarCamara(GameManager.instance.player.transform);

    }

    void Update()
    {
        if (GameManager.instance.Deslizandose == false)
        {
            objetivo = GameManager.instance.player.transform;

            AjustarCamara(GameManager.instance.player.transform);
            
        }
        else
        {
            objetivo = GameManager.instance.inWorldCaparazon.transform;
            AjustarCamara(GameManager.instance.inWorldCaparazon.transform);
        }

        rotacionY = Mathf.Clamp(rotacionY, minYAngle, maxYAngle);
    }

    private void AjustarCamara(Transform objetivo)
    {
        rotacionX += Input.GetAxis("Mouse X") * sensibilidad; // Añade el movimiento horizontal del ratón a la rotación X
        if (invertirY)
        {
            rotacionY += Input.GetAxis("Mouse Y") * sensibilidad; // Añade el movimiento vertical del ratón a la rotación Y invertida
        }
        else
        {
            rotacionY -= Input.GetAxis("Mouse Y") * sensibilidad; // Añade el movimiento vertical del ratón a la rotación Y
        }

        rotacionY = Mathf.Clamp(rotacionY, -90.0f, 90.0f); // Limita la rotación vertical de la cámara a un rango de -90 a 90 grados

        Quaternion rotacion = Quaternion.Euler(rotacionY, rotacionX, 0); // Calcula la rotación de la cámara a partir de las rotaciones X e Y
        Vector3 direccion = rotacion * Vector3.forward; // Calcula la dirección de la cámara a partir de la rotación
        Vector3 posicionObjetivo = objetivo.position - direccion * distancia; // Calcula la posición objetivo de la cámara a partir de la dirección y la distancia

        RaycastHit hit;
        if (Physics.Raycast(objetivo.position, -direccion, out hit, distanciaColision)) // Si la cámara está colisionando con un objeto en su dirección de movimiento
        {
            // Ajustar la posición de la cámara para que esté justo en frente del objeto detectado
            transform.position = hit.point + hit.normal * 0.1f; // Se mueve la cámara hacia el punto de colisión más la normal multiplicada por una pequeña fracción, para evitar atravesar el objeto
        }
        else // Si no hay colisión
        {
            // Mover la cámara a la posición objetivo
            transform.position = posicionObjetivo; // Se mueve la cámara hacia la posición objetivo
        }

        transform.LookAt(objetivo); // Hace que la cámara mire al objetivo
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * 10f); // Mueve la cámara hacia la derecha o la izquierda según el movimiento horizontal del jugador
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * 10f); // Mueve la cámara hacia adelante o hacia atrás según el movimiento vertical del jugador
    }
}
