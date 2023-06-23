using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recuperacion : MonoBehaviour
{
    Player player;
    MeshRenderer meshR;
    BoxCollider bcd;
    public AudioClip interact;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        meshR = GetComponent<MeshRenderer>();
        bcd = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (player.canSlide==false && (other.CompareTag("Player") || other.CompareTag("Proyectil") && player.isInsideCaparazon))
        {
            player.canSlide = true;
            meshR.enabled = false;
            bcd.enabled = false;
            AudioSource.PlayClipAtPoint(interact, transform.position, 1);
            StartCoroutine(ReactivateJump());
        }
    }

    private IEnumerator ReactivateJump()
    {
        yield return new WaitForSeconds(5);

        meshR.enabled = true;
        bcd.enabled = true;
    }
}
