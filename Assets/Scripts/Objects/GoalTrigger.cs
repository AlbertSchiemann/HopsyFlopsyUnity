using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private GameStateManagerScript gameStateManagerScript;
    [SerializeField] private CameraFollow cameraFollow;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            cameraFollow.GoalCameraride();
            other.GetComponent<GridPlayerMovement>().CallOfPlayerWin();

        }
    }
}
