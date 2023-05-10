using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("PlayerCollision Getroffen!");
        }
        
        if(other.gameObject.tag == "Ground")
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag != "Ground")
        {
            rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}
