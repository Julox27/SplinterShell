using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactuable
{
    public AudioClip interact;
    public Light luz;

    private void Awake()
    {
        luz.intensity = 0;
    }
    public Lever()
    {
        isActive = false;
        
    }
    public override void Interact()
    {
        isActive = !isActive;
        Debug.Log("Palanca");
        if(isActive )
        {
            luz.intensity = 10;
        }
        else { luz.intensity = 0;}
        AudioSource.PlayClipAtPoint(interact, transform.position, 1);
    }
}
