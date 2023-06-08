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

    private Vector3 GetRespawnPosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(inWorldCaparazon.transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Piso"))
            {
                return hit.point + new Vector3(0, 1f, 0);

            }
        }

        // Fallback to original respawn position
        return hit.point + new Vector3(0, 1f, 0);
    }
}
