using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardian : Enemy
{
    
    Transform objectivePosition;
    
    void Update()
    {
        
        if (GameManager.instance.player.yaLanzoProyectil)
        {
            ChaseShell();
           
        }
        else
        {
            ChasePlayer();
        }
    }
    void ChaseShell()
    {   float spMove = speed * Time.deltaTime;
        objectivePosition = GameManager.instance.inWorldCaparazon.transform;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, objectivePosition.position.z), spMove);
    }
    void ChasePlayer()
    {
        float spMove = speed * Time.deltaTime;
        objectivePosition = GameManager.instance.player.transform;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, objectivePosition.position.z), spMove);
    }
}
