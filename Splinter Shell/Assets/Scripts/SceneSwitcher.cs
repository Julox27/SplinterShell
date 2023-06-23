using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    private Lever lever;
    public string TargetScene;
    void Start()
    {
        lever = GetComponent<Lever>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(lever.isActive)
        {
            SceneManager.LoadScene(TargetScene);

        }
    }
}
