using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerMovement : MonoBehaviour
{
    private Grid2DCreated grid2dCreated;
    [SerializeField] private Grid grid;
    private PlayerPosition playerPosition; // Updated variable name
    [SerializeField] private GameObject playerPrefab; // Updated variable name
    
    public float DelayInBetweenMoves = .2f;
    private bool isAllowedToMove;       // enables player movement

    void Start()
    {
        grid2dCreated = grid.getGridCreated();
        print(grid2dCreated);
        InstantiatePlayer();
        isAllowedToMove = true;
        GameStateManagerScript.onGameStart += AllowMovement;
        GameStateManagerScript.onGamePaused += PreventMovement;
    }

    private void AllowMovement()
    { isAllowedToMove = true;  }
    private IEnumerable DelayedAllowMovement(float delay)
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(delay);
        AllowMovement();
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    private void PreventMovement()
    { isAllowedToMove = false; }
    void Update()
    {
        if (playerPosition != null)
        {
            
            if (isAllowedToMove == true)
            {
                playerPosition.CheckInput();
                PreventMovement();
                UpdateGameObjectPosition();
                //Debug.Log("Before Delayed movement" + Time.time);
                //DelayedAllowMovement(DelayInBetweenMoves);
                AllowMovement();
                
            }
            else  { return; }
        }
        else { Debug.LogError("PlayerPosition is null!"); }
        return;
    }

    private void InstantiatePlayer()
    {
        playerPosition = new PlayerPosition(1, 1, grid2dCreated, playerPrefab);
    }
        
    private void UpdateGameObjectPosition()
    {
        transform.position = new Vector3(playerPosition.posX, 1, playerPosition.posY);
    }


    
    public class PlayerPosition {              // when Player gets called, he gets a starting-position and the grid reference
        public int posX; 
        public int posY;
        private Grid2DCreated grid;
        private GameObject playerPrefab; // Reference to the player GameObject
        private GameObject player; // Reference to the player GameObject
        private bool isBlockChecked = false; // Flag to track if block below has been checked
        
        public PlayerPosition(int x, int y, Grid2DCreated grid, GameObject playerPrefab) {  // Constructor: Player gets the Position of the Block he is on
            this.posX = x;
            this.posY = y;
            this.grid = grid;
            this.playerPrefab = playerPrefab;
            
            
            if(isBlockChecked == false){
                LogOutputTargetedBlock();
                isBlockChecked = true;
            }
        }
        
        public void CheckInput()
        {
            // check for input events and set the target position
            if (SwipeManager.shortTap || Input.GetKeyDown(KeyCode.Mouse0) )
            {
                moveForward();
                Debug.Log("TapForward");
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.swipeUp)
            {
                moveForward();
                Debug.Log("Forward");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || SwipeManager.swipeDown)
            {
                moveBackward();
                Debug.Log("Backward");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft)
            {
                moveLeft();
                Debug.Log("Left");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight)
            {
                moveRight();
                Debug.Log("Right");
            }
        }

        public void moveLeft () {Move(-1, 0);}
        public void moveRight () {Move(1, 0);}
        public void moveForward () {Move(0, 1);}
        public void moveBackward () {Move(0, -1);}
        public void Move(int x, int y) 
        {
            int newPosX = posX + x;
            int newPosY = posY + y;

            posX = newPosX;
            posY = newPosY;
            isBlockChecked = false;

            Debug.Log($"Trying to Move to block at: {newPosX}, {newPosY}");
            GridBlockTypeToChoose block = this.grid.getBlockAt(newPosX, newPosY);
            Debug.Log($"The Block I am aiming for is a:");

            if (block == GridBlockTypeToChoose.NormalBlock){Debug.Log("Normalblock!");} 
            else if (block == GridBlockTypeToChoose.NormalBlockBlocked){
                        Debug.Log("Blocking Normalblock!");} 
            else if (block == GridBlockTypeToChoose.Bridge){
                        Debug.Log("Brideblock!");} 
            else if (block == GridBlockTypeToChoose.BridgeBlocked){
                        Debug.Log("Blocking Bridge!");} 
            else if (block == GridBlockTypeToChoose.Water){
                        Debug.Log("Waterblock!");} 
            else if (block == GridBlockTypeToChoose.WaterBlocked){
                        Debug.Log("Blocking Waterblock!");} 
            else if (block == GridBlockTypeToChoose.Fire){
                        Debug.Log("Fireblock!");} 
            else if (block == GridBlockTypeToChoose.FireBlocked){
                        Debug.Log("Blocking Fireblock!");} 
            else if (block == GridBlockTypeToChoose.FreeFall) {
                        Debug.Log("FreefallBlock!");} 
            else if (block == GridBlockTypeToChoose.Goal) {
                        Debug.Log("Goalblock!");} 
            else if (block == GridBlockTypeToChoose.Respawn){
                        Debug.Log("Respawnblock!");} 
            else {      Debug.LogError("Not a gridBlock!");}

            if (IsValidMove(newPosX, newPosY).Equals(true))
            {
                playerPrefab.transform.position = new Vector3(posX, 0, posY); // Update the position of the player GameObject
                Debug.Log($"I was able to move on the block at: {newPosX}, {newPosY}");
            }
            else if (IsValidMove(newPosX, newPosY).Equals(false))
            {
                Debug.Log($"Invalid move! Blocker at: {newPosX}, {newPosY}");
            }
            else
            {
                Debug.LogError("ValidMove function errored - neither true or false!");
            }
            isBlockChecked = false;
            
            
        }

        private void LogOutputTargetedBlock() {
            Debug.Log($"Position: {this.posX}, {this.posY}");
            Debug.Log($"This is a: { grid.getBlockAt(this.posX, this.posY)}!");
        }
    
        public bool IsValidMove(int x, int y)
        {
            int numRows = grid.blocks.GetLength(0);
            int numCols = grid.blocks.GetLength(1);

            if (posX >= 0 && posX < numCols && posY >= 0 && posY < numRows)
            {
                GridBlockTypeToChoose blockToCheck = grid.getBlockAt(posX, posY);
                
                if (    blockToCheck == GridBlockTypeToChoose.NormalBlockBlocked 
                     || blockToCheck == GridBlockTypeToChoose.BridgeBlocked 
                     || blockToCheck == GridBlockTypeToChoose.WaterBlocked 
                     || blockToCheck == GridBlockTypeToChoose.FireBlocked)
                {
                    return false;
                }
                else if (    
                        blockToCheck == GridBlockTypeToChoose.NormalBlock 
                     || blockToCheck == GridBlockTypeToChoose.Bridge 
                     || blockToCheck == GridBlockTypeToChoose.Water 
                     || blockToCheck == GridBlockTypeToChoose.Fire
                     || blockToCheck == GridBlockTypeToChoose.FreeFall 
                     || blockToCheck == GridBlockTypeToChoose.Respawn
                     || blockToCheck == GridBlockTypeToChoose.Goal)
                {
                    return true;
                }
                else
                {
                    Debug.LogError("Block is not valid for a ValidMove Check Up!");
                    return false;
                }   
            }

            return false;
        }
    }
}
    
//TODO: 
//      Why isnt the Log-output correct regarding the Block below?  grid and the grid in it are different in its direction - playermovement also needs to be mirrored
//      Delay doesnt work