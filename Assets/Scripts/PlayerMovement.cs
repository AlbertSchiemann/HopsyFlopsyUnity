using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;        // speed of player movement
    public float gridSize = 1f;         // size of the grid
    public Vector3 direction;          // current movement direction

    private bool isMoving = false;     // flag to indicate if player is currently moving
    private Vector3 targetPosition;    // target position for the player to move towards

    void Update()
    {
        if (!isMoving)
        {
            // check for input events and set the target position
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                targetPosition = transform.position + Vector3.forward * gridSize;
                direction = Vector3.forward;
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                targetPosition = transform.position + Vector3.back * gridSize;
                direction = Vector3.back;
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                targetPosition = transform.position + Vector3.left * gridSize;
                direction = Vector3.left;
                isMoving = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                targetPosition = transform.position + Vector3.right * gridSize;
                direction = Vector3.right;
                isMoving = true;
            }
        }

        if (isMoving)
        {
            // calculate the distance to the target position
            float distance = Vector3.Distance(transform.position, targetPosition);

            if (distance > 0)
            {
                // move towards the target position
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                // stop moving once the target position is reached
                isMoving = false;
            }
        }
    }
}
