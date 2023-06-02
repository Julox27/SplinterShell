using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    public int vidaPlayer;
    public bool Deslizandose;
    public Caparazon inWorldCaparazon;
    public Player player;

    private void Awake()
    {
        vidaPlayer = 3;
        Deslizandose = false;
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) || vidaPlayer <= 0)
        {
            ResetLevel();
            vidaPlayer = 3;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StopSlide()
    {
        
        Deslizandose = false;
        player.transform.position = inWorldCaparazon.transform.position + new Vector3(0, 3, 0);
        Destroy(inWorldCaparazon.gameObject);
        player.yaLanzoProyectil = false;
        player.meshR.enabled = true;
        player.capColl.enabled = true;
        player.rb.WakeUp();
    }
   

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
