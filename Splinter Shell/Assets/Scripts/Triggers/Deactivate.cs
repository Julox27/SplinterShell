using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public bool time = false;
    public int waitTime;
    public bool findTag = false;
    public string tagFind;
    public bool findGameObject = false;
    public GameObject gameObjectFind;
    public bool keyPressed = false;
    public KeyCode keyCheck = KeyCode.Space;

    float timer = 0;
    void Update()
    {
        //Desactiva los objetos, si se cumplen las condiciones requeridas, en este caso si queremos agregar condiciones, hay que agregar su variable booleana aca
        if (!time && !findTag && !keyPressed && !findGameObject)
        {
            Destroy(this.gameObject);
        }



        if (time)
        {
            Timer();
        }
        if (findTag)
        {
            FindTag();
        }
        if (findGameObject)
        {
            FindGameObject();
        }
        if (keyPressed)
        {
            KeyPressed();
        }

    }
    void Timer()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            time = false;
        }
     
    }
    void FindTag()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagFind);
        if (objectsWithTag.Length <= 0)
        {
            findTag = false;
        }
    }
    void FindGameObject()
    {
        if (gameObjectFind == null)
        {
            findGameObject = false;
        }
    }
    void KeyPressed()
    {
        if (Input.GetKeyDown(keyCheck))
        {
            keyPressed = false;
        }

    }
}
