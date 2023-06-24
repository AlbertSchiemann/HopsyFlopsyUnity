using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemMov : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool continuousMovement = true;
    public int[] moveSequence;
    public float delayBetweenMoves = 1f;

    private int currentMoveIndex = 0;
    private bool isMovingForward = true;
    private bool isWaiting = false;

    void Start()
    {
        if (moveSequence.Length > 0)
        {
            ExecuteNextMove();
        }
    }

    void ExecuteNextMove()
    {
        int moveCount = moveSequence[currentMoveIndex];

        if (isMovingForward)
        {
            StartCoroutine(MoveForward(moveCount));
        }
        else
        {
            StartCoroutine(MoveBackward(moveCount));
        }
    }

    IEnumerator MoveForward(int moveCount)
    {
        for (int i = 0; i < moveCount; i++)
        {
            // Move one step forward in the current direction
            // Replace this with your own grid-based movement logic
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            yield return new WaitForSeconds(delayBetweenMoves);
        }

        currentMoveIndex = (currentMoveIndex + 1) % moveSequence.Length;

        if (currentMoveIndex == 0 && !isMovingForward)
        {
            // Case 1: Completed a full cycle and reached the end
            // Teleport back to the starting point
            // Replace this with your own logic to reset the enemy's position
            transform.position = Vector3.zero;
            yield return new WaitForSeconds(delayBetweenMoves);
        }

        isMovingForward = true;
        ExecuteNextMove();
    }

    IEnumerator MoveBackward(int moveCount)
    {
        for (int i = 0; i < moveCount; i++)
        {
            // Move one step backward in the current direction
            // Replace this with your own grid-based movement logic
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            yield return new WaitForSeconds(delayBetweenMoves);
        }

        currentMoveIndex = (currentMoveIndex - 1 + moveSequence.Length) % moveSequence.Length;

        if (currentMoveIndex == moveSequence.Length - 1 && isMovingForward)
        {
            // Case 2: Completed a full cycle and reached the start
            // Reverse the movement direction without teleporting
            isMovingForward = false;
            yield return new WaitForSeconds(delayBetweenMoves);
        }

        ExecuteNextMove();
    }
}
