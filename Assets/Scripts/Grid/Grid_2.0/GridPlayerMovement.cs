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
    private bool isAllowedToMove = true;       // enables player movement in general
   

    void Start()
    {
        grid2dCreated = grid.getGridCreated();
        //grid2dCreated = grid.getGrid();
        print(grid2dCreated);
        InstantiatePlayer();
        isAllowedToMove = true;
        playerPosition.IsValidMove(1, 6); // Enter the Starting Gridposition of the Player
        //GameStateManagerScript.onGameStart += AllowMovement;
        //GameStateManagerScript.onGamePaused += PreventMovement;
    }

    private void AllowMovement()
    { isAllowedToMove = true;  }
    private IEnumerable DelayedAllowMovement(float delay)
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(delay);
        isAllowedToMove = true;
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    private void PreventMovement()
    { isAllowedToMove = false; }


    void Update()
    {
        if (playerPosition != null && isAllowedToMove == true)
        {
            playerPosition.CheckInput();
            PreventMovement();
            UpdateGameObjectPosition();
            //Debug.Log("Before Delayed movement" + Time.time);
            //DelayedAllowMovement(DelayInBetweenMoves);
            //Debug.Log("After Delayed movement" + Time.time);
            AllowMovement();
        }
        else { Debug.LogError("PlayerPosition is null!"); }
        return;
    }

    private void InstantiatePlayer()
    {
        playerPosition = new PlayerPosition(23, 3, grid2dCreated, playerPrefab);
    }
        
    private void UpdateGameObjectPosition()
    {
        transform.position = new Vector3(playerPosition.posX, 1, playerPosition.posY);
        //player.transform.position = new Vector3(playerPosition.posX, 1, playerPosition.posY);

    }


    
    public class PlayerPosition {              // when Player gets called, he gets a starting-position and the grid reference
        public int posX; 
        public int posY;
        private Grid2DCreated grid;
        private GameObject playerPrefab; // Reference to the player GameObject
        private GameObject player; // Reference to the player GameObject
        private bool isBlockChecked = false; // Flag to track if block below has been checked
        private bool isAllowedToMoveLeft = true; 
        private bool isAllowedToMoveRight = true;
        private bool isAllowedToMoveBack = true;
        private bool isAllowedToMoveForward = true;
        private bool isAllowedToMoveForwardTap = true; 
        public string direction = string.Empty;
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
            if (SwipeManager.shortTap || Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (isAllowedToMoveForwardTap == true)  { moveForwardTap(); }
                else                                    { Debug.Log("Not allowed to Tap Forward."); }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.swipeUp)
            {
                if (isAllowedToMoveForward == true)     { moveForward(); }
                else                                    { Debug.Log("Not allowed to Move Forward."); }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || SwipeManager.swipeDown)
            {
                if (isAllowedToMoveBack == true)        { moveBackward(); }
                else                                    { Debug.Log("Not allowed to Move Back."); }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft)
            {
                if (isAllowedToMoveLeft == true)        { moveLeft(); }
                else                                    { Debug.Log("Not allowed to Move Left."); }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight)
            {
                if (isAllowedToMoveRight == true)       { moveRight(); }
                else                                    { Debug.Log("Not allowed to Move Right."); }
            }
        }

        public void moveLeft ()         {Move(-1, 0); direction =   "Left";}
        public void moveRight ()        {Move(1, 0); direction =    "Right";}
        public void moveForward ()      {Move(0, 1); direction =    "TapForward";}
        public void moveForwardTap ()   {Move(0, 1); direction =    "Forward";}
        public void moveBackward ()     {Move(0, -1); direction =   "Backward";}
        public void Move(int x, int y) 
        {
            int newPosX = posX + x;
            int newPosY = posY + y;

            posX = newPosX;
            posY = newPosY;
            isBlockChecked = false;
            string blocktype = string.Empty;

            
            GridBlockTypeToChoose block = this.grid.getBlockAt(newPosX, newPosY);

            if (block == GridBlockTypeToChoose.NormalBlock){blocktype = "Normalblock!";} 
            else if (block == GridBlockTypeToChoose.NormalBlockBlocked){
                        blocktype = "Blocking Normalblock!";} 
            else if (block == GridBlockTypeToChoose.Bridge){
                        blocktype = "Brideblock!";} 
            else if (block == GridBlockTypeToChoose.BridgeBlocked){
                        blocktype = "Blocking Bridge!";} 
            else if (block == GridBlockTypeToChoose.Water){
                        blocktype = "Waterblock!";} 
            else if (block == GridBlockTypeToChoose.WaterBlocked){
                        blocktype = "Blocking Waterblock!";} 
            else if (block == GridBlockTypeToChoose.Fire){
                        blocktype = "Fireblock!";} 
            else if (block == GridBlockTypeToChoose.FireBlocked){
                        blocktype = "Blocking Fireblock!";} 
            else if (block == GridBlockTypeToChoose.FreeFall) {
                        blocktype = "FreefallBlock!";} 
            else if (block == GridBlockTypeToChoose.Goal) {
                        blocktype = "Goalblock!";} 
            else if (block == GridBlockTypeToChoose.Respawn){
                        blocktype = "Respawnblock!";} 
            else {      Debug.LogError("Not a gridBlock!");}

            Debug.Log($"Trying to Move {direction} onto the block at: {newPosX}, {newPosY}. It is a: {blocktype}");
            playerPrefab.transform.position = new Vector3(posX, 0, posY);
            Debug.Log($"I was able to move on the block at: {newPosX}, {newPosY}");

            IsValidMove(newPosX, newPosY);
            isBlockChecked = false;
              
        }

        private void LogOutputTargetedBlock() {
            Debug.Log($"Position: {this.posX}, {this.posY}");
            Debug.Log($"This is a: { grid.getBlockAt(this.posX, this.posY)}!");
        }
    
        public void IsValidMove(int x, int y)
        {
            int numRows = grid.blocks.GetLength(0);
            int numCols = grid.blocks.GetLength(1);

            if (x >= 0 && x < numCols && y >= 0 && y < numRows)
            {
                
                // Check all four directions around the player
                isAllowedToMoveLeft = IsValidBlock(x - 1, y);
                isAllowedToMoveRight = IsValidBlock(x + 1, y);
                isAllowedToMoveForward = IsValidBlock(x, y + 1);
                isAllowedToMoveBack = IsValidBlock(x, y - 1);
                isAllowedToMoveForwardTap = isAllowedToMoveForward;
                
            }
            else
            {
                Debug.LogError("IsValidMove function errored!");
                return;
            }
        }

        private bool IsValidBlock(int x, int y)
        {
            int numRows = grid.blocks.GetLength(0);
            int numCols = grid.blocks.GetLength(1);

            if (x >= 0 && x < numCols && y >= 0 && y < numRows)
            {
                GridBlockTypeToChoose blockToCheck = grid.getBlockAt(x, y);

                if (    blockToCheck == GridBlockTypeToChoose.NormalBlockBlocked ||
                        blockToCheck == GridBlockTypeToChoose.BridgeBlocked ||
                        blockToCheck == GridBlockTypeToChoose.WaterBlocked ||
                        blockToCheck == GridBlockTypeToChoose.FireBlocked)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                Debug.LogError("IsValidBlock function errored!");
                return false;
            }

            
        }

    }
}
    
//TODO: 
//      Why isnt the Log-output correct regarding the Block below?  grid and the grid in it are different in its direction - playermovement also needs to be mirrored
//      Delay doesnt work