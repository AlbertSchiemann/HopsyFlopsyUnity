using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public float Delay = 1.0f;
    public UI_LevelScript levelScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy von Player getroffen!");
        }

        if (other.gameObject.tag == "Obstacle")
        {
            gameObject.GetComponent<PlayerMovement>().StopPlayer();

            Debug.Log("Obstacle von Player Getroffen!");
        }

        if(other.gameObject.tag == "DeathZoneFreeFall")
        {
            Debug.Log("Free Fall Death");
            Invoke("Sceneload", Delay);
        }
    }

    void Sceneload()
    {
        // restart the game if the player collides with the enemy
        levelScript.OpenLoose();  
        //AlwaysThere.OpenLevelLoose=true;
          }
}
