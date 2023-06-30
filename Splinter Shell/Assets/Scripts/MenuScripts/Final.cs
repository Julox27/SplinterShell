using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}