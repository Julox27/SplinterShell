using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActive : MonoBehaviour
{
    [SerializeField] protected TriggerZone Trigger;
    protected bool state;
    int childCount;
    void Start()
    {
        childCount = transform.childCount;
    }
    protected virtual void Update()
    {
        UpdateBehavior();
        state = Trigger.GetSetActive();
        if (state)
        {
            ActivarHijos();
        }
    }

    private void ActivarHijos()
    {
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
    }
    private void DesactivarHijos()
    {
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
    }
    protected virtual void Function()
    {

    }
    protected virtual void UpdateBehavior()
    {

    }
}
