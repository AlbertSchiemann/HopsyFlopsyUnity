using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;        // speed of player movement
    public float gridSize = 1f;         // size of the grid
    public Vector3 direction;          // current movement direction
    private bool isAllowedToMove;
    internal bool isMoving = false;     // flag to indicate if player is currently moving
    private Vector3 targetPosition;    // target position for the player to move towards

    /*
    public bool AllowedToMoveFront = true;
    public bool AllowedToMoveBack = true;
    public bool AllowedToMoveLeft = true;
    public bool AllowedToMoveRigth = true;
    */

    [SerializeField] private AudioClip[] _moveClip;

    void Start()
    {
        isAllowedToMove = false;
        GameStateManagerScript.onGameStart += AllowMovement;
        GameStateManagerScript.onGamePaused += PreventMovement;
    }
    void Update()
    {
        RunDebug();
        if (!isAllowedToMove) { return; }

        if (!isMoving)
        {
            CheckInput();
        }

        if (isMoving)
        {
            MovePlayer();
        }

        /*
        if (!isMoving && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                targetPosition = transform.position + Vector3.forward * gridSize;
                direction = Vector3.forward;
                isMoving = true;
            }
        }*/

        if (SwipeManager.swipeRight)
        {
            targetPosition = transform.position + Vector3.right * gridSize;
            direction = Vector3.right;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
        }
        if (SwipeManager.swipeLeft)
        {
            targetPosition = transform.position + Vector3.left * gridSize;
            direction = Vector3.left;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
        }
        if (SwipeManager.swipeUp)
        {
            targetPosition = transform.position + Vector3.forward * gridSize;
            direction = Vector3.forward;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
        }
        if (SwipeManager.swipeDown)
        {
            targetPosition = transform.position + Vector3.back * gridSize;
            direction = Vector3.back;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
        }

    }
    public void RunDebug()
    {

    }
    public void CheckInput()
    {
        // check for input events and set the target position
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.swipeUp) /*&& AllowedToMoveFront == true*/)
        {
            targetPosition = transform.position + Vector3.forward * gridSize;
            direction = Vector3.forward;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
            Debug.Log("Forward");
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || SwipeManager.swipeDown) /*&& AllowedToMoveFront == true*/)
        {
            targetPosition = transform.position + Vector3.back * gridSize;
            direction = Vector3.back;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
            Debug.Log("Backward");
        }
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft) /*&& AllowedToMoveFront == true*/)
        {
            targetPosition = transform.position + Vector3.left * gridSize;
            direction = Vector3.left;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
            Debug.Log("Left");
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight) /*&& AllowedToMoveFront == true*/)
        {
            targetPosition = transform.position + Vector3.right * gridSize;
            direction = Vector3.right;
            isMoving = true;
            SoundManager.Instance.PlaySound(_moveClip);
            Debug.Log("Rigth");
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
}
