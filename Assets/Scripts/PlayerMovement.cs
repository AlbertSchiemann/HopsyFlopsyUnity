using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 15f;        // speed of player movement
    public float gridSize = 5f;         // size of the grid
    public Vector3 direction;          // current movement direction

    public float hydrationMax = 100f;
    public float hydrationDecayRate = 10f;
    public float hydrationRestoreAmount = 50f;

    private float hydration;

    public int HydrationUpdateTime = 1;
    float nextTime = 0;

    private bool isMoving = false;     // flag to indicate if player is currently moving
    private Vector3 targetPosition;    // target position for the player to move towards

    void Start()
    {
        hydration = hydrationMax;
    }
    void Update()
    {
        RunDebug();

        if (!isMoving)
        {
            CheckInput();
        }

        if (isMoving)
        {
            MovePlayer();
        }

        LowerHydration();

        CheckHydrationDeathCondition();

        if (Time.time >= nextTime) 
        {
            Debug.Log(hydration);
            nextTime += HydrationUpdateTime; 
        }
        
    }
    public void RunDebug()
    {

    }
    public void CheckInput()
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

    public void MovePlayer()
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

    public void LowerHydration()
    {
        // Decrease hydration over time
        hydration -= hydrationDecayRate * Time.deltaTime;
    }

    public void CheckHydrationDeathCondition()
    {
        // Check if hydration has reached 0
        if (hydration <= 0)
        {
            Debug.Log("DEAD");
            // Player dies, restart the game here
        }
    }

    // checking water collision, does not work yet, useful after player collision is added
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            hydration += hydrationRestoreAmount;
            if (hydration > hydrationMax)
            {
                hydration = hydrationMax;
            }
            Destroy(other.gameObject);
        }
    }
    */
}
