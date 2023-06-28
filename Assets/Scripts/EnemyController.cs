using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform pointA;            // starting point of the patrol
    public Transform pointB;            // ending point of the patrol
    public float moveSpeed = 1f;        // speed of enemy movement

    private bool movingToA = false;     // flag to indicate if enemy is moving towards point A or B

    public UI_LevelScript levelScript;
    private bool isCollided = false;

    [SerializeField] private AudioClip[] _failClip;

    void Update()
    {
        if (isCollided == false)  //only capable to mave as long the player didnt collide with the enemy
        {
            if (movingToA)
            {
                // move towards point A
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime);

                // check if enemy has reached point A
                if (transform.position == pointA.position)
                {
                    movingToA = false;
                    transform.rotation = Quaternion.Euler(0, 180, 0); // Sets Rotation to LVL design needed rotation - still needs improvement

                }
            }
            else
            {
                // move towards point B
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, moveSpeed * Time.deltaTime);

                // check if enemy has reached point B
                if (transform.position == pointB.position)
                {
                    movingToA = true;
                    transform.rotation = Quaternion.Euler(0, 0, 0); // Rotate the enemy 180 degrees 
                }
            }
        }
      //  else return;  // if the player hits the enemy the enemy stops moving 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.Instance.PlaySound(_failClip);
            // restart the game if the player collides with the enemy
            levelScript.OpenLoose();
            isCollided = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("EnemyCollision - Eaten!");
        }
    }
}