using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleOnStart : MonoBehaviour
{   void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
    }

}
