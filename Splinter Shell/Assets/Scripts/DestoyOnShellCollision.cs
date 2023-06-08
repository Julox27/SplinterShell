using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyOnShellCollision : MonoBehaviour
{
    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            particles.Play();
            Destroy(this.gameObject, particles.duration);
            
        }
    }
}
