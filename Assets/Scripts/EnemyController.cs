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

    void Update()
    {
        if (movingToA)
        {
            // move towards point A
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime);

            // check if enemy has reached point A
            if (transform.position == pointA.position)
            {
                movingToA = false;
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
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // restart the game if the player collides with the enemy
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
