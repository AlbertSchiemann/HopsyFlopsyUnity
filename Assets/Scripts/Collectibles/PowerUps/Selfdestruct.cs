using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruct : MonoBehaviour
{
    public float selfdestructtime = 2f;
    void Awake()
    {
        Destroy(gameObject, selfdestructtime);
    }
    
}
