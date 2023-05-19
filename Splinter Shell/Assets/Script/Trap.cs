using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    protected bool State;
    [SerializeField] protected Interactuable obj;
    protected virtual void Update()
    {
        updateBehavior();
        State = obj.GetIsActive();
        if (State)
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
