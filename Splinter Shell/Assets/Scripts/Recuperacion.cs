using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recuperacion : MonoBehaviour
{
    Player player;
    MeshRenderer meshR;
    BoxCollider bcd;
    Light light;
    public AudioClip interact;
    public AudioClip slowMotion;
    public Image canvasSlowMotion;
    public bool activeSlowMotion;
    public float cooldown = 3;
    public float fadeDuration = 1f;
    public float timeScale;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        meshR = GetComponent<MeshRenderer>();
        bcd = gameObject.GetComponent<BoxCollider>();
        light = gameObject.GetComponentInChildren<Light>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (player.canSlide==false && (other.CompareTag("Player") || other.CompareTag("Proyectil") && player.isInsideCaparazon))
        {
            player.canSlide = true;
            meshR.enabled = false;
            bcd.enabled = false;
            light.enabled = false;
            AudioSource.PlayClipAtPoint(interact, transform.position, 1);
            StartCoroutine(ReactivateJump());
            if (activeSlowMotion)
            {
                AudioSource.PlayClipAtPoint(slowMotion, transform.position, 1);
                StartCoroutine(SlowMotion());
                StartCoroutine(FadeInImage());
                if (other.CompareTag("Proyectil"))
                {
                    player.PlayerActive();
                }
            }
        }
    }

    private IEnumerator SlowMotion()
    {
        canvasSlowMotion.enabled = true;
        Time.timeScale = 0.2f;

        float endTime = Time.realtimeSinceStartup + 2f;

        while (Time.realtimeSinceStartup < endTime && !Input.GetMouseButtonDown(1))
        {
            yield return null;
        }

        Time.timeScale = 1f;
        canvasSlowMotion.enabled = false;
    }
    private IEnumerator ReactivateJump()
    {
        yield return new WaitForSeconds(cooldown);
        meshR.enabled = true;
        bcd.enabled = true;
        light.enabled = true;
    }
    private IEnumerator FadeInImage()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime * 2f;

            canvasSlowMotion.color = new Color(canvasSlowMotion.color.r, canvasSlowMotion.color.g, canvasSlowMotion.color.b, timer / fadeDuration);

            yield return null;
        }

        canvasSlowMotion.color = new Color(canvasSlowMotion.color.r, canvasSlowMotion.color.g, canvasSlowMotion.color.b, 1f);
    }
  
}

