using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    private int state = 0; // 0 patrol, 1 seeking, 2 charging

    private Player target;
    float targetDis;
    bool atRange = false;

    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    int wpIndex = 0;

    [SerializeField] float detectionRange;

    [SerializeField] float patrolSpeed;
    public float rotSpeed;

    [SerializeField] float chaseSpeed;
    bool onSight = false;
    bool charging = false;

    float timerAnimation = 2f;

    void Update()
    {
        target = GameManager.instance.player;
        targetDis = (target.gameObject.transform.position - gameObject.transform.position).magnitude;

        if (!charging)
        {
            if (targetDis < detectionRange)
            {
                atRange = true;
                state = 1;
            }
            else
            {
                atRange = false;
                state = 0;
            }
        }

        switch (state)
        {
            case 0:
                Debug.Log("Caso 0");
                onSight = false;
                timerAnimation = 2f;
                Patrol();
                break;

            case 1:
                Debug.Log("Caso 1");
                Seeking();
                break;

            case 2:
                Debug.Log("Caso 2");
                Charge();
                break;

            default:
                onSight = false;
                timerAnimation = 2f;
                Patrol();
                break;
        }
    }



    private void Patrol()
    {
        if (Vector3.Distance(transform.position, wayPoints[wpIndex].position) < 0.1f)
        {
            wpIndex++;

            if (wpIndex >= wayPoints.Count)
            {
                wpIndex = 0;
            }
        }

        Vector3 direction = wayPoints[wpIndex].position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[wpIndex].position, patrolSpeed * Time.deltaTime);
    }

    private void Seeking()
    {
        Vector3 direction = target.gameObject.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

        Invoke("StateChanger", 1f);

        if (onSight)
        {
            timerAnimation -= Time.deltaTime;
            if (timerAnimation > 0)
            {
                Debug.Log("amenazando");
            }
            else
            {
                charging = true;
                state = 2; //charging
            }
        }
    }

    private void Charge()
    {
        if (charging)
        {
            transform.Translate(Vector3.forward * chaseSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //aplicar que al colisionar con paredes o el jugador, charging = false;
    }

    private void StateChanger()
    {
        onSight = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
