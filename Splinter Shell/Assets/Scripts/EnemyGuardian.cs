using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardian : MonoBehaviour
{
    [SerializeField] int speed;
    Transform objectivePosition;
    void Update()
    {
        float spMove = speed * Time.deltaTime;
        if (GameManager.instance.player.yaLanzoProyectil)
        {
            objectivePosition = GameManager.instance.inWorldCaparazon.transform;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, objectivePosition.position.z), spMove);
        }
        else
        {
            objectivePosition = GameManager.instance.player.transform;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, objectivePosition.position.z), spMove);
        }
    }
}
