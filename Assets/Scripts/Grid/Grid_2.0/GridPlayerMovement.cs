using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerMovement : MonoBehaviour
{
    [SerializeField] private Grid2DCreated grid;
    private PlayerPosition playerPosition; // Updated variable name
    [SerializeField] private GameObject playerPrefab; // Updated variable name
    

    void Start()
    {
        grid = FindObjectOfType<Grid2DCreated>(); // Find the existing Grid2DCreated instance
        //grid = ScriptableObject.CreateInstance<Grid2DCreated>();
        //grid.Initialize(this); // Pass the current instance of GridPlayerMovement to the Initialize method
        
        
        InstantiatePlayer();

        //playerPosition = new PlayerPosition(1, 1, grid, playerPrefab); // Instantiate PlayerPosition and pass the playerPrefab

        // Set the initial position of the GameObject
        //transform.position = new Vector3(playerPosition.posX, 0, playerPosition.posY);
    
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
        playerPosition = new PlayerPosition(1, 1, grid, playerPrefab);
    }

    private void UpdateGameObjectPosition()
    {
        transform.position = new Vector3(playerPosition.posX, 0, playerPosition.posY);
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
        
       /* private void InstantiatePlayer()
        {
            if (player == null)
            {
                player = Instantiate(playerPrefab, new Vector3(posX, 0, posY), Quaternion.identity);
            }
        }
        */
        
        public void CheckInput()
        {
            // check for input events and set the target position

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.shortTap)
            {
                moveForward();
                posY++;
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
        
        /*
        void Start() {

            PlayerPosition player = new PlayerPosition(0, 0, sg);
            PlayerPosition playerFish = new PlayerPosition(1, 1, sg);
            
            
            playerFish.moveUp();
            playerFish.moveRight();
            playerFish.moveDown();
            playerFish.moveLeft();

            playerFish.moveUp(); 
            playerFish.moveRight();
            playerFish.moveUp();
            playerFish.moveUp();
            playerFish.moveUp();
            playerFish.moveUp();
            playerFish.moveUp();
            playerFish.moveUp();
            playerFish.moveUp();
            playerFish.moveUp();
            playerFish.moveUp();
            playerFish.moveRight();
            playerFish.moveRight();
            playerFish.moveRight();
            playerFish.moveDown();
            playerFish.moveRight();
            playerFish.moveRight();
            playerFish.moveUp();    //Goal
        }
        */
        
        public void Move(int x, int y) 
        {

            int newPosX = posX + x;
            int newPosY = posY + y;

            if (IsValidMove(newPosX, newPosY))
            {
                Debug.Log($"Moving to block at: {newPosX}, {newPosY}");
                posX = newPosX;
                posY = newPosY;
                
                // Update the position of the player GameObject
                player.transform.position = new Vector3(posX, 0, posY);


                if (!isBlockChecked) // Only trigger the function if not already checked
                {
                    CheckBlockBelow();
                    isBlockChecked = true;
                }
            }
            else
            {
                Debug.Log($"Invalid move to block at: {newPosX}, {newPosY}");
            }
        
        

        
            Debug.Log($"Checking Block at: { newPosX } , { newPosY }");
            GridBlockTypeToChoose block = this.grid.getBlockAt(newPosX, newPosY);

            
            if (block == GridBlockTypeToChoose.NormalBlock){
                this.posX = newPosX;
                this.posY = newPosY;
                Debug.Log("It feels pretty normal here!");
                CheckBlockBelow();
                return;
            } else if (block == GridBlockTypeToChoose.NormalBlockBlocked){
                Debug.Log("There is a blocking Object here!");
                CheckBlockBelow();
                return;
            } else if (block == GridBlockTypeToChoose.Bridge){
                this.posX = newPosX;
                this.posY = newPosY;
                Debug.Log("Its getting shaky - Bridgeblock!");
                CheckBlockBelow();
                return;
            } else if (block == GridBlockTypeToChoose.BridgeBlocked){
                Debug.Log("There is a blocking Object on the Bridge!");
                CheckBlockBelow();
                return;
            } else if (block == GridBlockTypeToChoose.Water){
                this.posX = newPosX;
                this.posY = newPosY;
                Debug.Log("Its getting nice and wet in here - Waterblock!");
                CheckBlockBelow();
                return;
            } else if (block == GridBlockTypeToChoose.WaterBlocked){
                Debug.Log("There is a blocking Object in the Water!");
                CheckBlockBelow();
                return;
            } else if (block == GridBlockTypeToChoose.Fire){
                this.posX = newPosX;
                this.posY = newPosY;
                Debug.Log("Its getting hot in here - Fireblock!");
                CheckBlockBelow();
                return;
            } else if (block == GridBlockTypeToChoose.FireBlocked){
                Debug.Log("There is a blocking Object in the Fire!");
                CheckBlockBelow();
                return;
            } else if (block == GridBlockTypeToChoose.FreeFall) {
                Debug.Log("I should fall down rigth now!");
                CheckBlockBelow();
                return;
            } else if (block == GridBlockTypeToChoose.Goal) {
                this.posX = newPosX;
                this.posY = newPosY;
                CheckBlockBelow();
                Debug.Log("YOU WIN! - Goalblock!");
                return;
            } else if (block == GridBlockTypeToChoose.Respawn){
                this.posX = newPosX;
                this.posY = newPosY;
                Debug.Log("I could respawn here!");
                Debug.Log("Its also wet in here!");
                CheckBlockBelow();
                return;
            } else {
                Debug.LogError("Not a gridBlock!");
            }
        }

        public void moveLeft () {
            int x = -1;
            int y = 0;
            Move(x, y);

        }
        public void moveRight () {
            int x = 1;
            int y = 0;
            Move(x, y);
        }
        public void moveForward () {
            int x = 0;
            int y = 1;
            Move(x, y);
        }
        public void moveBackward () {
            int x = 0;
            int y = -1;
            Move(x, y);
        }


        private void CheckBlockBelow() {
            Debug.Log($"Position: {this.posX}, {this.posY}");
            Debug.Log($"Im on a: { grid.getBlockAt(this.posX, this.posY)} block!");
        }
    
        public bool IsValidMove(int x, int y)
        {
            int numRows = grid.blocks.GetLength(0);
            int numCols = grid.blocks.GetLength(1);

            if (x >= 0 && x < numCols && y >= 0 && y < numRows)
            {
                GameObject blockObject = GetBlockAtPosition(x, y);

                if (blockObject != null)
                {
                    NotBlockingGridBlock notBlockingBlock = blockObject.GetComponent<NotBlockingGridBlock>();
                    BlockingGridBlock blockingBlock = blockObject.GetComponent<BlockingGridBlock>();

                    if (notBlockingBlock != null)
                    {
                        return !notBlockingBlock.isBlocking;
                    }
                    else if (blockingBlock != null)
                    {
                        return blockingBlock.isBlocking;
                    }
                    else
                    {
                        // If the block does not have either NotBlockingGridBlock or BlockingGridBlock,
                        // assume it is a valid move (not blocking).
                        return true;
                    }
                }
            }

            return false;
        }
        
        private GameObject GetBlockAtPosition(int x, int y)
        {
            GameObject blockObject = null;

            int numRows = grid.blocks.GetLength(0);
            int numCols = grid.blocks.GetLength(1);

            return blockObject;
        }
        


    }
}
    
//todo: Player gets spawned a million times 
