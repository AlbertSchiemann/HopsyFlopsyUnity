using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerMovement : MonoBehaviour
{
    private Grid2DCreated grid2dCreated;
    [SerializeField] private Grid grid;
    private PlayerPosition playerPosition; // Updated variable name
    [SerializeField] private GameObject playerPrefab; // Updated variable name
    

    void Start()
    {
        grid2dCreated = grid.getGridCreated();
        
        print(grid2dCreated);
        
        InstantiatePlayer();
    }

    void FixedUpdate()
    {
        if (playerPosition != null)
        {
            playerPosition.CheckInput();
            UpdateGameObjectPosition();
        }
        else
        {
            Debug.LogError("PlayerPosition is null!");
        }
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
            this.isBlockChecked = false;

            //InstantiatePlayer();
            CheckBlockBelow();
        }
        
       
        
        public void CheckInput()
        {
            // check for input events and set the target position

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.shortTap)
            {
                moveForward();
                //posY++;
                Debug.Log("TapForward");
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.swipeUp)
            {
                moveForward();
                //posY++;
                Debug.Log("Forward");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || SwipeManager.swipeDown)
            {
                moveBackward();
                //posY++;
                Debug.Log("Backward");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft)
            {
                moveLeft();
                //posY++;
                Debug.Log("Left");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight)
            {
                moveRight();
                //posY++;
                Debug.Log("Right");
            }
        }

        public void moveLeft () {int x = -1; int y = 0; Move(x, y);}
        public void moveRight () {int x = 1; int y = 0; Move(x, y);}
        public void moveForward () {int x = 0; int y = 1; Move(x, y);}
        public void moveBackward () {int x = 0; int y = -1; Move(x, y);}
        public void Move(int x, int y) 
        {
            int newPosX = posX + x;
            int newPosY = posY + y;

            posX = newPosX;
            posY = newPosY;

            if (IsValidMove(newPosX, newPosY).Equals(true))
            {
                Debug.Log($"Trying to Move to block at: {newPosX}, {newPosY}");
                
                
                playerPrefab.transform.position = new Vector3(posX, 0, posY); // Update the position of the player GameObject

                if (!isBlockChecked) // Only trigger the function if not already checked
                {
                    CheckBlockBelow();
                    isBlockChecked = true;
                }
            }
            else
            {
                Debug.Log($"Invalid move: block at: {newPosX}, {newPosY}");
                isBlockChecked = false;
                return;
            }
        
            GridBlockTypeToChoose block = this.grid.getBlockAt(newPosX, newPosY);
            
            if (block == GridBlockTypeToChoose.NormalBlock){
                Debug.Log("It feels pretty normal here!");
                return;
            } else if (block == GridBlockTypeToChoose.NormalBlockBlocked){
                Debug.Log("There is a blocking Object here!");
                return;
            } else if (block == GridBlockTypeToChoose.Bridge){
                Debug.Log("Its getting shaky - Bridgeblock!");
                return;
            } else if (block == GridBlockTypeToChoose.BridgeBlocked){
                Debug.Log("There is a blocking Object on the Bridge!");
                return;
            } else if (block == GridBlockTypeToChoose.Water){
                Debug.Log("Its getting nice and wet in here - Waterblock!");
                return;
            } else if (block == GridBlockTypeToChoose.WaterBlocked){
                Debug.Log("There is a blocking Object in the Water!");
                return;
            } else if (block == GridBlockTypeToChoose.Fire){
                Debug.Log("Its getting hot in here - Fireblock!");
                return;
            } else if (block == GridBlockTypeToChoose.FireBlocked){
                Debug.Log("There is a blocking Object in the Fire!");
                return;
            } else if (block == GridBlockTypeToChoose.FreeFall) {
                Debug.Log("I should fall down rigth now!");
                return;
            } else if (block == GridBlockTypeToChoose.Goal) {
                Debug.Log("YOU WIN! - Goalblock!");
                return;
            } else if (block == GridBlockTypeToChoose.Respawn){
                Debug.Log("I could respawn here!");
                Debug.Log("Its also wet in here!");
                return;
            } else {
                Debug.LogError("Not a gridBlock!");
            }
            isBlockChecked = false;
        }

        private void CheckBlockBelow() {
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
    
//TODO: Why does the Player not always move when the key is pressed?
//      Why isnt the Log-output correct regarding the Block below?
//      Why does the Player move more than 1 Field sometimes?  