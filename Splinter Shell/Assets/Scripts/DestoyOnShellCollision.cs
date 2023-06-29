using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyOnShellCollision : MonoBehaviour
{
    private ParticleSystem particles;
    public AudioClip destroy;

    private void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            particles.Play();
            Destroy(this.gameObject, particles.duration);
            AudioSource.PlayClipAtPoint(destroy, transform.position, 0.5f);
        }
    }
}
