using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    protected bool state;
    [SerializeField] protected Interactuable obj;
    protected virtual void Update()
    {
        updateBehavior();
        state = obj.GetIsActive();
        if (state)
        {
            Function();
        }
        else
        {
            TrapOff();
        }

    }
    public abstract void Function();
    public abstract void TrapOff();
    protected virtual void updateBehavior()
    {

    }
}
