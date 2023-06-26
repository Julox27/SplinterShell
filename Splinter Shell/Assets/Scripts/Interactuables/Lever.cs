using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactuable
{
    public AudioClip interact;
    public Transform rotatingObject;
    Quaternion activeRotation = Quaternion.Euler(0, 0, 30);
    Quaternion inactiveRotation = Quaternion.Euler(0, 0, -30);
    public Lever()
    {
        isActive = false;
    }

    private void Start()
    {
        rotatingObject.localRotation = inactiveRotation; // Establecer la rotación inicial como la rotación inactiva    
    }

    public override void Interact()
    {
        isActive = !isActive;
        Debug.Log("Palanca");

        if (isActive)
        {
            rotatingObject.localRotation = activeRotation;
        }
        else
        {
            rotatingObject.localRotation = inactiveRotation;
        }

        AudioSource.PlayClipAtPoint(interact, transform.position, 1);
    }
}