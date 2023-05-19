using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactuable
{
    public int cooldown;
    public bool initialState;


    private void Start()
    {
        isActive = initialState;
    }
    public override void Interact()
    {
        isActive = !isActive;

        StartCoroutine(offTime());


    }

    private IEnumerator offTime()
    {
        yield return new WaitForSeconds(cooldown);
        isActive = !isActive;
    }

}
