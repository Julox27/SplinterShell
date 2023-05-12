using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    [SerializeField] private float shootTimer = 1;
    public Transform bulletShooter;

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

        if(shootTimer <= 0)
        {
            Shoot();
            shootTimer = 3;
        }
    }

    private void Shoot()
    {
        Instantiate(PrefabManager.instance.BalaTorreta, bulletShooter.position, bulletShooter.rotation);
    }
}
