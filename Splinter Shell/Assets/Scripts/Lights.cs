using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    Light light;
    private float timer;
    public float cooldown = 2f;
    public float minIntensity = 0.1f;
    public float maxIntensity = 1f;

     void Start()
    {
        light = GetComponent<Light>();
        light.intensity = minIntensity;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            timer = 0;
            float targetIntensity = (light.intensity == minIntensity) ? maxIntensity : minIntensity;
            light.intensity = targetIntensity;
        }
    }
}
