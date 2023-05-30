using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;       // speed of player movement
    public float gridSize = 1f;        // size of the grid
    public Vector3 direction;          // current movement direction
    private bool isAllowedToMove;
    internal bool isMoving = false;    // flag to indicate if player is currently moving
    private Vector3 targetPosition;    // target position for the player to move towards

    Vector2Int currentGridPos;
    public GameGrid gameGrid;         // Reference to the GameGrid script


    [SerializeField] private AudioClip[] _moveClip;

    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
        if (gameGrid == null)
        {
            Debug.LogError("GameGrid script not found in the scene!");
        }

        //currentGridPos = gameGrid.GetGridPosFromWorld(transform.position);
       // targetPosition = gameGrid.GetWorldPosFromGridPos(new Vector3Int
        //targetPosition = transform.position;
       // MovePlayer();

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
            MovePlayer();
        }
    }

    public void CheckInput()
    {
        // check for input events and set the target position
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.swipeUp)
        {
            Vector2Int currentGridPos = gameGrid.GetGridPosFromWorld(transform.position);
            targetPosition = gameGrid.GetWorldPosFromGridPos(new Vector3Int(currentGridPos.x, currentGridPos.y + 1, 0));
            Debug.Log(targetPosition);
            direction = Vector3.forward;
            transform.position = targetPosition;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
            Debug.Log("Forward");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || SwipeManager.swipeDown)
        {
            Vector2Int currentGridPos = gameGrid.GetGridPosFromWorld(transform.position);
            targetPosition = gameGrid.GetWorldPosFromGridPos(new Vector3Int(currentGridPos.x, currentGridPos.y - 1, 0));
            transform.position = targetPosition;
            direction = Vector3.back;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
            Debug.Log("Backward");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft)
        {
            Vector2Int currentGridPos = gameGrid.GetGridPosFromWorld(transform.position);
            targetPosition = gameGrid.GetWorldPosFromGridPos(new Vector3Int(currentGridPos.x - 1, currentGridPos.y, 0));
            direction = Vector3.left;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight)
        {
            Vector2Int currentGridPos = gameGrid.GetGridPosFromWorld(transform.position);
            targetPosition = gameGrid.GetWorldPosFromGridPos(new Vector3Int(currentGridPos.x + 1, currentGridPos.y, 0));
            direction = Vector3.right;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
            Debug.Log("Right");
        }

        /*
        if (!isMoving && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2Int currentGridPos = gameGrid.GetGridPosFromWorld(transform.position);
                Vector2 touchStartPosition = touch.position;

                if (touchStartPosition.y < Screen.height / 2)
                {
                    if (touchStartPosition.x < Screen.width / 2)
                    {
                        Vector2Int currentGridPos = gameGrid.GetGridPosFromWorld(transform.position);
                        targetPosition = gameGrid.GetWorldPosFromGridPos(new Vector3Int(currentGridPos.x - 1, currentGridPos.y, 0));
                        direction = Vector3.left;
                        isMoving = true;
                        SoundManager.Instance.PlaySound(_moveClip);
                        Debug.Log("Left");
                    }
                    else
                    {
                        Vector2Int currentGridPos = gameGrid.GetGridPosFromWorld(transform.position);
                        targetPosition = gameGrid.GetWorldPosFromGridPos(new Vector3Int(currentGridPos.x + 1, currentGridPos.y, 0));
                        direction = Vector3.right;
                        isMoving = true;
                        SoundManager.Instance.PlaySound(_moveClip);
                        Debug.Log("Right");
                    }
                }
                else
                {
                    if (touchStartPosition.x < Screen.width / 2)
                    {
                        Vector2Int currentGridPos = gameGrid.GetGridPosFromWorld(transform.position);
                        targetPosition = gameGrid.GetWorldPosFromGridPos(new Vector3Int(currentGridPos.x, currentGridPos.y - 1, 0));
                        direction = Vector3.back;
                        isMoving = true;
                        SoundManager.Instance.PlaySound(_moveClip);
                        Debug.Log("Backward");
                    }
                    else
                    {
                        Vector2Int currentGridPos = gameGrid.GetGridPosFromWorld(transform.position);
                        targetPosition = gameGrid.GetWorldPosFromGridPos(new Vector3Int(currentGridPos.x, currentGridPos.y + 1, 0));
                        direction = Vector3.forward;
                        isMoving = true;
                        SoundManager.Instance.PlaySound(_moveClip);
                        Debug.Log("Forward");
                    }
                }
            }
        }*/
    }


    public void MovePlayer()
    {
        // Calculate the distance to the target position
        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance > 0)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Snap the player to the exact target position
            transform.position = targetPosition;

            // Stop moving once the target position is reached
            isMoving = false;
        }
    }


    private void AllowMovement()
    {
        isAllowedToMove = true;
    }

    private void PreventMovement()
    {
        isAllowedToMove = false;
    }

}
