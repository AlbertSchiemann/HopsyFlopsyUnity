using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if(other.gameObject.tag == "DeathZoneFreeFall")
        {
            Debug.Log("Free Fall Death");
             // restart the game if the player collides with the enemy
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Untagged")
        {
            rigidbody.constraints = RigidbodyConstraints.None;
            Debug.Log("Exit");
        } 
    }

    private void OnCollisionEnter(Collision other)
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


}
