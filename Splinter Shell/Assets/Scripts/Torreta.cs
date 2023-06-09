using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    [SerializeField] private float shootTimer = 1;
    public Transform bulletShooter;
    public int nucleosMaximos = 3;
    public int nucleosRestantes;
    public float distanciaDisparo = 10f;
    private GameObject player;
    void Start()
    {
        nucleosRestantes = nucleosMaximos;
        player = GameObject.FindWithTag("Player");
    }
    

        void Update()
    {
        if(GameManager.instance.Deslizandose)
        {
            transform.rotation = Quaternion.LookRotation(GameManager.instance.inWorldCaparazon.transform.position - gameObject.transform.position);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(GameManager.instance.player.transform.position - gameObject.transform.position);
        }
        shootTimer -= Time.deltaTime;
        float distanciaAlJugador = Vector3.Distance(transform.position, player.transform.position);
        if (distanciaAlJugador <= distanciaDisparo)
        {
            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = 1f;
            }
        }

        }

    private void Shoot()
    {
        Instantiate(PrefabManager.instance.BalaTorreta, bulletShooter.position, bulletShooter.rotation);
    }
    
    public void NucleoDestruido()
    {
        nucleosRestantes--;
        if (nucleosRestantes <= 0)
        {
            DestruirTorreta();
        }
    }

    public void DestruirTorreta()
    {
        Destroy(gameObject);
    }


}
