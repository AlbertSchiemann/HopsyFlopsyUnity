using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject cranePrefab;

    [SerializeField] private float movingTime = 5f;
    [SerializeField] private float movingSpeed = 5f;

    void Start()
    {
        


    }

    public class PlayerPosition {                           // when the Player gets called, he gets a starting-position on the grid 
        public int posX; 
        public int posY;
        private Grid2DCreated grid;
        private GameObject playerPrefab;
        private float rotationLeft = 270;                   // Enter Prefab Rotation in Inspector
        private float rotationRight = 90;
        private float rotationForward = 0;
        private float rotationBackward = 180;

        public PlayerPosition(int x, int y, Grid2DCreated grid, GameObject playerPrefab)  // Constructor: Player gets the Position of the Block he is on saved in posX and posY for the next move
        {  
            this.posX = x;
            this.posY = y;
            this.grid = grid;
            this.playerPrefab = playerPrefab;
            /*                                                                            // just Debuglogs for checking if its working properly
            if(isBlockChecked == false){
                LogOutputTargetedBlock();
                isBlockChecked = true;
            }
            */
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<GridPlayerMovement>().PreventMovement();
            // SoundManager.Instance.PlaySound(Crane);

            // Start function for the transform


            // Start crane animation
            // cranePrefab.GetComponent<Animator>().enabled = true;
            // cranePrefab.GetComponent<Animator>().SetBool("moving", true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<GridPlayerMovement>().AllowMovement();
            // stop SoundManager.Instance.PlaySound(Crane);


            
            // Start crane animation backwards
            // cranePrefab.GetComponent<Animator>().enabled = true;
            // cranePrefab.GetComponent<Animator>().SetBool("moving", true);

        }
    }
    // Triggerbox für Start
    // Gridposition nach der Animation
    // Triggerbox für Ende
}
