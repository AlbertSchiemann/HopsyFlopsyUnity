using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    float newUpdateRate = 0.05f;
    Vector3 objectRotation;
    void Start()
    {
        InvokeRepeating("SlowUpdate", 0.0f, newUpdateRate);
    }
    void SlowUpdate()
    {
        objectRotation = new Vector3(0, -3f, 0) + transform.eulerAngles;
        transform.eulerAngles = objectRotation;
    }
}
