using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    bool setActive = false;
    public bool GetSetActive()
    {
        return setActive;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            setActive = true;
            Destroy(gameObject);
        }
    }
}
