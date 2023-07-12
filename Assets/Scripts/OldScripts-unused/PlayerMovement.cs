using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;        // speed of player movement
    public float gridSize = 1f;         // size of the grid
    public Vector3 direction;           // current movement direction
    
    private bool isAllowedToMove;       // enables player movement
    internal bool isMoving = false;     // flag to indicate if player is currently moving
    private Vector3 targetPosition;     // target position for the player to move towards

    private Vector3 targetPositionOnGrid;

    public int gridPostionX = 0;
    public int gridPostionY = 0;
    public int gridPostionZ = 0;

    [SerializeField] private PlayerCollision collisionChecker;

    public Waterbottle waterbottle;

    [SerializeField] private AudioClip[] _moveClip;

    void Start()
    {
        isAllowedToMove = false;
        GameStateManagerScript.onGameStart += AllowMovement;
        GameStateManagerScript.onGamePaused += PreventMovement;
    }

    void Update()
    {
        if (!isAllowedToMove) { return; }

        if (!isMoving)
        {
            CheckInput();
        }

        if (isMoving)
        {
            MovePlayerOnGrid();
        }

        PrintGridCoordinates();
    }

    public void CheckInput()
    {
        //Create Rays On the Input check only
        collisionChecker.rayCastForw = new Ray(transform.position, transform.TransformDirection(collisionChecker.forwardRay * collisionChecker.RayRange));
        collisionChecker.rayCastBackw = new Ray(transform.position, transform.TransformDirection(collisionChecker.backwardRay * collisionChecker.RayRange));
        collisionChecker.rayCastLeft = new Ray(transform.position, transform.TransformDirection(collisionChecker.leftRay * collisionChecker.RayRange));
        collisionChecker.rayCastRight = new Ray(transform.position, transform.TransformDirection(collisionChecker.rightRay * collisionChecker.RayRange));
        
        // check for input events and set the target position
        if(!collisionChecker.noMoveForward)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.shortTap)
            {
                targetPosition = transform.position + Vector3.forward * gridSize;
                direction = Vector3.forward;
                isMoving = true;
                SoundManager.Instance.PlaySound(_moveClip);
                gridPostionZ++;
                Debug.Log("TapForward");
            }
        }
        if(!collisionChecker.noMoveForward)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.swipeUp)
            {
                targetPosition = transform.position + Vector3.forward * gridSize;
                direction = Vector3.forward;
                isMoving = true;
                SoundManager.Instance.PlaySound(_moveClip);
                gridPostionZ++;
                Debug.Log("Forward");
            }
        }
        if(!collisionChecker.noMoveBackward)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || SwipeManager.swipeDown)
            {
                targetPosition = transform.position + Vector3.back * gridSize;
                direction = Vector3.back;
                isMoving = true;
                SoundManager.Instance.PlaySound(_moveClip);
                gridPostionZ--;
                Debug.Log("Backward");
            }
        }
        if(!collisionChecker.noMoveLeft)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft)
            {
                targetPosition = transform.position + Vector3.left * gridSize;
                direction = Vector3.left;
                isMoving = true;
                SoundManager.Instance.PlaySound(_moveClip);
                gridPostionX--;
                Debug.Log("Left");
            }
        }
        if(!collisionChecker.noMoveRight)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight)
            {
                targetPosition = transform.position + Vector3.right * gridSize;
                direction = Vector3.right;
                isMoving = true;
                SoundManager.Instance.PlaySound(_moveClip);
                gridPostionX++;
                Debug.Log("Right");
            }
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

    public void StopPlayer()
    {
        isMoving = false;
    }
    private void AllowMovement()
    {
        isAllowedToMove = true;
    }
    private void PreventMovement()
    {
        isAllowedToMove = false;
    }

    public void PrintGridCoordinates()
    {
        Debug.Log ("Grid Coordinates - " + gridPostionX + "," + gridPostionY + "," + gridPostionZ);
    }

    
    public void MovePlayerOnGrid()
    {
        targetPositionOnGrid = new Vector3(gridPostionX*gridSize, gridPostionY * gridSize, gridPostionZ*gridSize);
        // calculate the distance to the target position
        float distance = Vector3.Distance(transform.position, targetPositionOnGrid);

        if (distance > 0)
        {
            // move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPositionOnGrid, moveSpeed * Time.deltaTime);

        }
        else
        {
            // stop moving once the target position is reached
            isMoving = false;
        }
    }
    
}
