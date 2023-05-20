using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : TriggerActive
{
    BoxCollider bcd;
    Renderer doorRenderer;
    public bool startActive = false;
    private bool hasInteracted;
    void Start()
    {
        bcd = this.gameObject.GetComponent<BoxCollider>();
        doorRenderer = GetComponent<Renderer>();
        bcd.enabled = startActive;
        doorRenderer.enabled = startActive;
    }
    protected override void Function()
    {
        if (!hasInteracted)
        {
            startActive = !startActive;
            bcd.enabled = startActive;
            doorRenderer.enabled = startActive;
            hasInteracted = true;
        }

    }

}
