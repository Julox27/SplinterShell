using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactuable : MonoBehaviour
{
    public bool isActive;
    protected bool isNearby;
    bool shellColission;
    protected bool hasInteracted; //Para que solo interactue una vez en una misma colision
    protected static KeyCode intButton = KeyCode.F;

    protected virtual void Update()
    {
        Debug.Log("El estado es " + isActive);
        // Si 1 o 2
        if (!hasInteracted && ((isNearby && Input.GetKeyDown(intButton)) || shellColission))
        {
            Interact();
            Debug.Log("Interactuo");
            hasInteracted = true;
        }
        GetIsActive();
    }
    public abstract void Interact();
    public bool GetIsActive()
    {
        return isActive;    
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Interact"))
        {
            isNearby = true;
        }

        if (col.CompareTag("Proyectil"))
        {
            shellColission = true;
            //El caparazon choco con un objeto Interactuable (2)
            Debug.Log("El caparazon choco con un objeto Interactuable (2)");
        }
    }
    private void OnTriggerExit(Collider col)
    {
        isNearby = false;
        shellColission = false;
        hasInteracted = false;
    }

}
