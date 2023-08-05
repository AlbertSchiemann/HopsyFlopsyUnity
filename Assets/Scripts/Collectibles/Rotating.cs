using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotationspeed = 0.05f;
    public float direction = -3f;
    Vector3 objectRotation;
    void Start()
    {
        InvokeRepeating("SlowUpdate", 0.0f, rotationspeed);
    }
    void SlowUpdate()
    {
        objectRotation = new Vector3(0, direction, 0) + transform.eulerAngles;
        transform.eulerAngles = objectRotation;
    }
}
