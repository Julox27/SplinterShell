using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Trap
{
    MeshCollider bcd;
    Renderer doorRenderer;

    private void Start()
    {
        bcd = this.gameObject.GetComponent<MeshCollider>();
        doorRenderer = GetComponent<Renderer>();
    }
    public override void Function()
    {
        bcd.enabled = false;
        doorRenderer.enabled = false;
    }

    public override void TrapOff()
    {
        bcd.enabled = true;
        doorRenderer.enabled = true;
    }
}

