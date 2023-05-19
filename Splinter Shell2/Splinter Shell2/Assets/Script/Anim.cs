using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Movimiento moveAnim;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        moveAnim = GetComponent<Movimiento>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
        
    {
        if (moveAnim.GetIsMoving())
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
