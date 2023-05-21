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

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Timer();
    }

    // Update is called once per frame
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
        findTag = false;
    }
    void FindGameObject()
    {
        gameObjectFind = gameObject.GetComponent<GameObject>();
        if (gameObjectFind=null)
        {
            findGameObject = false;
        }    
    }
    void KeyPressed()
    {
        keyPressed = false;
    }
}
