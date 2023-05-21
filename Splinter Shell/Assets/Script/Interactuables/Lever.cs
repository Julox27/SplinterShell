using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactuable
{
    public Lever()
    {
        isActive = false;
    }
    public override void Interact()
    {
        isActive = !isActive;
        Debug.Log("Palanca");
    }
}
