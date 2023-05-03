using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectibleScript : MonoBehaviour
{
    Vector3 newRotation;
    
    float rate = 0.05f;
    void Start()
    {
        InvokeRepeating("SlowUpdate", 0.0f, rate);
    }
    void Update()
    {

    }
    void SlowUpdate()
    {
        newRotation = new Vector3(0, 5, 0) + transform.eulerAngles;
        transform.eulerAngles = newRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { Destroy(gameObject); }
        Debug.Log("test");
    }
}
