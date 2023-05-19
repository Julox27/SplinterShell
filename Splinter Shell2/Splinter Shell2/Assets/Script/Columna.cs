using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columna : MonoBehaviour
{

    public Vector3 transformI;
    public Vector3 rotationI;
    private Quaternion newRotation;
    // Start is called before the first frame update
    void Start()
    {
        newRotation = Quaternion.Euler(rotationI.x, rotationI.y, rotationI.z);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Proyectil"))
        {
            transform.position = transformI;
            transform.rotation = newRotation;


        }
    }
}
