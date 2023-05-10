using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("PlayerCollision Getroffen!");
        }

        if(other.gameObject.tag == "DeathZoneFreeFall")
        {
            Debug.Log("Free Fall Death");
             // restart the game if the player collides with the enemy
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        } 
    }
}
