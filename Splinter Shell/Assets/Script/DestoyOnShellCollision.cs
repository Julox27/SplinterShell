using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyOnShellCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            Destroy(this.gameObject);
        }
    }
}
