using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    [HideInInspector] public static PrefabManager instance;
    public GameObject Caparazon;
    public GameObject BalaTorreta;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(this);
    }
}
