using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> Checkpoints;
    [SerializeField] Vector3 vectorpoint;
    private Player playerScript;

    private void Start()
    {
        vectorpoint = player.transform.position;
        playerScript = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider Collider)
    {
        if (Collider.CompareTag("CheckPoint"))
        {
            vectorpoint = player.transform.position;
                Destroy(Collider.gameObject);
            
        }
        if (Collider.CompareTag("lava"))
        {   
            player.transform.position = vectorpoint;

        }
    }
}
