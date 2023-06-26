using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    
    public string TargetScene;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Proyectil") && GameManager.instance.Deslizandose)
        {
            SceneManager.LoadScene(TargetScene);

        }
    }
}
