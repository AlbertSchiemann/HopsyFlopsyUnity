using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public float Delay = 1.0f;
    public UI_LevelScript levelScript;

    [SerializeField] private AudioClip[] _failClip;
    [SerializeField] private BoxCollider LeftBoxCollider;
    [SerializeField] private BoxCollider RigthBoxCollider;
    [SerializeField] private BoxCollider FrontBoxCollider;
    [SerializeField] private BoxCollider BackBoxCollider;
    [SerializeField] private BoxCollider FishCollider;
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy von Player getroffen!");
        }
        /*
        if (other.gameObject.tag == "Obstacle")
        {

            PlayerMovement pm = GetComponent<PlayerMovement>();
            pm.AllowedToMoveLeft = false;

            Debug.Log("Links-Stop!");

            Debug.Log("Obstacle von Player Getroffen!");
        }
        */

        if(other.gameObject.tag == "DeathZoneFreeFall")
        {
            Debug.Log("Free Fall Death");
            Invoke("Sceneload", Delay);
            SoundManager.Instance.PlaySound(_failClip);
        }
    }

    /*
    private void OnTriggerExit(Collider other2)
    {
        PlayerMovement pm = GetComponent<PlayerMovement>();
            pm.AllowedToMoveLeft = true;

            Debug.Log("Links-Weiter!");
    }
    */

    void Sceneload()
    {
        // restart the game if the player collides with the enemy
        levelScript.OpenLoose();  
        //AlwaysThere.OpenLevelLoose=true;
          }
}
