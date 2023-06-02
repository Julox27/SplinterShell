using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float sensibilidad = 5.0f; // Sensibilidad de la camara al movimiento del ratÛn
    public bool invertirY = false; // Invertir o no el movimiento vertical del ratÛn
    public float distancia = 5.0f; // Distancia de la camara al objetivo
    private Transform objetivo; // Transform del objetivo que sigue la camara
    private float rotacionX = 0.0f; // Rotacion horizontal de la camara
    private float rotacionY = 0.0f; // Rotacion vertical de la camara
    public float distanciaColision = 1f; // Distancia de colision para evitar que la camara atraviese objetos


    internal static Camera main;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor del ratÛn en el centro de la pantalla
    }

    void Update()
    {
        if (GameManager.instance.Deslizandose == false)
        {
            objetivo = GameManager.instance.player.transform;
            FueraDeCaparazon();
        }
        else
        {
            objetivo = GameManager.instance.inWorldCaparazon.transform;
            DentroDeCaparazon();
        }
    }

    private void DentroDeCaparazon()
    {
        rotacionX += Input.GetAxis("Mouse X") * sensibilidad; // AÒade el movimiento horizontal del ratÛn a la rotaciÛn X
        if (invertirY)
        {
            rotacionY += Input.GetAxis("Mouse Y") * sensibilidad; // AÒade el movimiento vertical del ratÛn a la rotaciÛn Y invertida
        }
        else
        {
            rotacionY -= Input.GetAxis("Mouse Y") * sensibilidad; // AÒade el movimiento vertical del ratÛn a la rotaciÛn Y
        }

        rotacionY = Mathf.Clamp(rotacionY, -90.0f, 90.0f); // Limita la rotaciÛn vertical de la c·mara a un rango de -90 a 90 grados

        Quaternion rotacion = Quaternion.Euler(rotacionY, rotacionX, 0); // Calcula la rotaciÛn de la c·mara a partir de las rotaciones X e Y
        Vector3 direccion = rotacion * Vector3.forward; // Calcula la direcciÛn de la c·mara a partir de la rotaciÛn
        Vector3 posicionObjetivo = objetivo.position - direccion * distancia; // Calcula la posiciÛn objetivo de la c·mara a partir de la direcciÛn y la distancia

        RaycastHit hit;
        if (Physics.Raycast(objetivo.position, -direccion, out hit, distanciaColision)) // Si la c·mara estÅEcolisionando con un objeto en su direcciÛn de movimiento
        {
            // Ajustar la posiciÛn de la c·mara para que estÅEjusto en frente del objeto detectado
            transform.position = hit.point + hit.normal * 0.1f; // Se mueve la c·mara hacia el punto de colisiÛn m·s la normal multiplicada por una pequeÒa fracciÛn, para evitar atravesar el objeto
        }
        else // Si no hay colisiÛn
        {
            // Mover la c·mara a la posiciÛn objetivo
            transform.position = posicionObjetivo; // Se mueve la c·mara hacia la posiciÛn objetivo
        }

        transform.LookAt(objetivo); // Hace que la c·mara mire al objetivo
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * 10f); // Mueve la c·mara hacia la derecha o la izquierda seg˙n el movimiento horizontal del jugador
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * 10f); // Mueve la c·mara hacia adelante o hacia atr·s seg˙n el movimiento vertical del jugador
    }

    private void FueraDeCaparazon()
    {
        rotacionX += Input.GetAxis("Mouse X") * sensibilidad; // AÒade el movimiento horizontal del ratÛn a la rotaciÛn X
        if (invertirY)
        {
            rotacionY += Input.GetAxis("Mouse Y") * sensibilidad; // AÒade el movimiento vertical del ratÛn a la rotaciÛn Y invertida
        }
        else
        {
            rotacionY -= Input.GetAxis("Mouse Y") * sensibilidad; // AÒade el movimiento vertical del ratÛn a la rotaciÛn Y
        }

        rotacionY = Mathf.Clamp(rotacionY, -90.0f, 90.0f); // Limita la rotaciÛn vertical de la c·mara a un rango de -90 a 90 grados

        Quaternion rotacion = Quaternion.Euler(rotacionY, rotacionX, 0); // Calcula la rotaciÛn de la c·mara a partir de las rotaciones X e Y
        Vector3 direccion = rotacion * Vector3.forward; // Calcula la direcciÛn de la c·mara a partir de la rotaciÛn
        Vector3 posicionObjetivo = objetivo.position - direccion * distancia; // Calcula la posiciÛn objetivo de la c·mara a partir de la direcciÛn y la distancia

        RaycastHit hit;
        if (Physics.Raycast(objetivo.position, -direccion, out hit, distanciaColision)) // Si la c·mara estÅEcolisionando con un objeto en su direcciÛn de movimiento
        {
            // Ajustar la posiciÛn de la c·mara para que estÅe justo en frente del objeto detectado
            transform.position = hit.point + hit.normal * 0.1f; // Se mueve la c·mara hacia el punto de colisiÛn m·s la normal multiplicada por una pequeÒa fracciÛn, para evitar atravesar el objeto
        }
        else // Si no hay colisiÛn
        {
            // Mover la c·mara a la posiciÛn objetivo
            transform.position = posicionObjetivo; // Se mueve la c·mara hacia la posiciÛn objetivo
        }

        transform.LookAt(objetivo); // Hace que la c·mara mire al objetivo
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * 10f); // Mueve la c·mara hacia la derecha o la izquierda seg˙n el movimiento horizontal del jugador
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * 10f); // Mueve la c·mara hacia adelante o hacia atr·s seg˙n el movimiento vertical del jugador
    }
}