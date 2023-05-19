using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Trap
{
    BoxCollider bcd;
    bool isOn;
    public int cooldown = 2;
    float timer;

    Renderer spikesRenderer;
   
    private void Start()
    {
        bcd = this.gameObject.GetComponent<BoxCollider>();
        spikesRenderer = GetComponent<Renderer>();
        isOn = true;
    }
    protected override void updateBehavior()
    {
        bcd.enabled = isOn;
        spikesRenderer.enabled = isOn;
    }
    public override void Function()
    {
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            isOn = !isOn;
            timer = 0;
        }
    }

    private void OnOff()
    {
        isOn = !isOn;
        timer = 0;
    }

    public override void TrapOff()
    {
        isOn = false;
    }

    //Matar al jugador

    //void OnTriggerEnter(Collider other)
    //{
    //    Player player = GetComponent<Player>();
    //    if (player != null)
    //    {
    //        matar al jugador
    //    }
    //}

}
