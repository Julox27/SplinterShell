using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactuable
{
    public int cooldown;
    public bool initialState;
    public bool onCooldown = false;

    public AudioClip interact;
    public AudioClip timer;

    AudioSource auso;

    private void Start()
    {
        isActive = initialState;
        auso = gameObject.GetComponent<AudioSource>();
    }
    public override void Interact()
    {
        if (!onCooldown)
        {
            isActive = !isActive;
            StartCoroutine(offTime());
            AudioSource.PlayClipAtPoint(interact, transform.position, 1);
            auso.PlayOneShot(timer, 1);
        }
    }

    private IEnumerator offTime()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldown);
        auso.Stop();
        isActive = !isActive;
        onCooldown = false;
    }

}
