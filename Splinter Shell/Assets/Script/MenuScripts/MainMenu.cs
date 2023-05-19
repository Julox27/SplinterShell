using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject ControlsPanel;

    private void Awake()
    {
        ControlsPanel.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("EscenaDePrueba");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ControlsButton()
    {
        ControlsPanel.SetActive(true);
    }

    public void BackButton()
    {
        ControlsPanel.SetActive(false);
    }
}