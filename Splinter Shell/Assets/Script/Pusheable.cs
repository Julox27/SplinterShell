using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusheable : MonoBehaviour
{
    private Vector3 initialPosition;
    private GameObject push;
    private bool isPushing;

    void Start()
    {
        initialPosition = transform.position;
        push = GameObject.FindWithTag("Push");
        isPushing = false;
    }

    void Update()
    {
        if (isPushing)
        {
            Vector3 pushDirection = push.transform.position - initialPosition;
            pushDirection.y = 0f;
            pushDirection.Normalize();
            transform.position = initialPosition + pushDirection * (push.transform.position - initialPosition).magnitude;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Push"))
        {
            isPushing = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Push"))
        {
            isPushing = false;
        }
    }
}


