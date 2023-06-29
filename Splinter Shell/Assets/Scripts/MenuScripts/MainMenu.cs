using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject ControlsPanel;
    [SerializeField] GameObject Buttons;

    private void Awake()
    {
        ControlsPanel.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ControlsButton()
    {
        ControlsPanel.SetActive(true);
        Buttons.SetActive(false);
    }

    public void BackButton()
    {
        ControlsPanel.SetActive(false);
        Buttons.SetActive(true);
    }
}