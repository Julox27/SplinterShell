using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Trap
{
    public Transform topPoint; // Punto más alto
    public Transform bottomPoint; // Punto más bajo
    public float speed = 5f; // Velocidad de movimiento del ascensor
    float step;

    private bool movingUp = true; // Variable para controlar la dirección del movimiento

    protected override void updateBehavior()
    {
        step = speed * Time.deltaTime;
    }
    public override void Function()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, topPoint.position, step);
  
    }

    public override void TrapOff()
    {
        transform.position = Vector3.MoveTowards(transform.position, bottomPoint.position, step);
    }
}
