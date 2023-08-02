using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerMovement : MonoBehaviour
{
    // in General- this script is responsible for the movement of the player on the grid
    // the player gets a starting position on the grid and can move in all 4 directions
    // the player can only move on certain blocks, which are defined in the Grid2DCreated.cs script
    // thats why there is a checkup of the surrounding blocks, so the player cant move through blocked blocks
    // the player isnt allowed to move on those blocks, but he can move on the blocks that arent blocked
    // the player can move by pressing the arrow keys or by swiping on the screen
    // the player can only move one block at a time, so he cant move diagonally
    // there is also a delay in between the moves, so the player cant move too fast
    // the player also rotates in the direction he moved

    private Grid2DCreated grid2dCreated;                    // get the gridreference of the lvl
    [SerializeField] private Grid grid;
    private PlayerPosition playerPosition;                  // get the player-coordinates and transform them into grid coordinates
    [SerializeField] private GameObject playerPrefab; 
    [SerializeField] private AudioClip[] _hydrateClip;
    public HydrationController hydrationController;
  
    [SerializeField] private int StartX = 23;                          // Position of the Prefab in the Scene
    [SerializeField] private int StartY =  3;                          

    public float PlayerHeigth = 1f;                        // Position in Y Axis of the Prefab
    private bool isAllowedToMove = true;                    // enables player movement in general

    public bool UpdateActive = true;                        // enables the update of the playerposition

    [SerializeField] private AudioClip[] _moveClip;
    [SerializeField] private AudioClip[] _collisionClip;
    [SerializeField] private Waterbottle waterbottle;
    [SerializeField] private GameObject bucket;

    void Start()
    {
        grid2dCreated = grid.getGridCreated();
        print(grid2dCreated);
        InstantiatePlayer();
        isAllowedToMove = true;                                             // Enter the Starting Gridposition of the Player, so a check of the surrounding blocks gets called
        playerPosition.IsValidMove(StartX, StartY);                                   // and the player cant move through blocked blocks              
        UpdateGameObjectPosition();
        isAllowedToMove = false;

        GameStateManagerScript.onGameStart += AllowMovement;            
        GameStateManagerScript.onGamePaused += PreventMovement;           // Pause doesnt work yet
    }

    void Update()
    {
        if (playerPosition != null && isAllowedToMove == true)
        {
            playerPosition.CheckInput(_moveClip, _collisionClip, _hydrateClip);

            if (UpdateActive)
            {
                UpdateGameObjectPosition();
            }
            
            playerPosition.Update();
        }else if (isAllowedToMove == false) { return; }
        else { Debug.LogError("PlayerPosition is null!"); }
    }

    private void InstantiatePlayer()                        // Instantiate the Player at the starting position
    {
        playerPosition = new PlayerPosition(StartX, StartY, grid2dCreated, playerPrefab);
    }
        
    public void UpdateGameObjectPosition()                 // Update the Position of the Player on the Grid by transforming his position
    {
        transform.position = new Vector3(playerPosition.posX, PlayerHeigth, playerPosition.posY);
    }

    public class PlayerPosition {                           // when the Player gets called, he gets a starting-position on the grid 
        public int posX; 
        public int posY;
        private float rotationLeft = 270;                   // Enter Prefab Rotation in Inspector
        private float rotationRight = 90;
        private float rotationForward = 0;
        private float rotationBackward = 180;
        private float PlayerHeigth = 1f;
        private Grid2DCreated grid;
        private GameObject playerPrefab;                    // Reference to the player GameObject
        private PowerUpManager powerUpManager;                    // Reference to the Waterbottle GameObject
        private HydrationController hydrationController;    // Reference to the HydrationController
        private bool isAllowedToMoveLeft = true;            // Bool to track if player is allowed to move into a direction or not
        private bool isAllowedToMoveRight = true;
        private bool isAllowedToMoveBack = true;
        private bool isAllowedToMoveForward = true;
        private bool isAllowedToMoveForwardTap = true; 
        private bool skatingNotHit = true;
        public string direction = string.Empty;             // dunno

        public float initialMoveTimer = 0.15f;               // Alberts stuff of Delay
        public float moveTimer;
        public bool isMoving = false;
        C_PowerUps powerUps;
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

        public void Update()
        {
            if (isMoving)
            {
                moveTimer -= Time.deltaTime;
                if (moveTimer <= 0)
                {
                    isMoving = false;
                }
            }
        }
        

        public void CheckInput(AudioClip[] moveClip, AudioClip[] collClip, AudioClip[] _hydrateClip)            // Check for Input and call the Move-Function
        {
            if (!isMoving)
            {
                if (SwipeManager.shortTap)
                {
                    if (isAllowedToMoveForward == true) { moveForward(); playerPrefab.transform.rotation = Quaternion.Euler(-90, 180, rotationForward); SoundManager.Instance.PlaySound(moveClip); }
                    else
                    {
                        //Debug.Log("Not allowed to Move Forward.");
                        SoundManager.Instance.PlaySound(collClip);
                        playerPrefab.GetComponent<SkinLoader>().currentSkin.GetComponent<Animator>().SetTrigger("jump");
                    }
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.swipeUp || CrossTapManager.upTap || JoyStickManager.upTap)
                {
                    if (isAllowedToMoveForward == true) { moveForward(); playerPrefab.transform.rotation = Quaternion.Euler(-90, 180, rotationForward); SoundManager.Instance.PlaySound(moveClip); }
                    else 
                    {
                        //Debug.Log("Not allowed to Move Forward.");
                        SoundManager.Instance.PlaySound(collClip);
                        playerPrefab.GetComponent<SkinLoader>().currentSkin.GetComponent<Animator>().SetTrigger("jump");
                    }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || SwipeManager.swipeDown || CrossTapManager.downTap || JoyStickManager.downTap)
                {
                    if (isAllowedToMoveBack == true) { moveBackward(); playerPrefab.transform.rotation = Quaternion.Euler(-90, 180, rotationBackward); SoundManager.Instance.PlaySound(moveClip); }
                    else 
                    {
                        // Debug.Log("Not allowed to Move Back."); 
                        SoundManager.Instance.PlaySound(collClip);
                        playerPrefab.GetComponent<SkinLoader>().currentSkin.GetComponent<Animator>().SetTrigger("jump");
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft || CrossTapManager.leftTap || JoyStickManager.leftTap)
                {
                    if (isAllowedToMoveLeft == true) { moveLeft(); playerPrefab.transform.rotation = Quaternion.Euler(-90, 180, rotationLeft); SoundManager.Instance.PlaySound(moveClip); }
                    else 
                    {
                        // Debug.Log("Not allowed to Move Left."); 
                        SoundManager.Instance.PlaySound(collClip);
                        playerPrefab.GetComponent<SkinLoader>().currentSkin.GetComponent<Animator>().SetTrigger("jump");
                    }
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight || CrossTapManager.rightTap || JoyStickManager.rightTap)
                {
                    if (isAllowedToMoveRight == true) { moveRight(); playerPrefab.transform.rotation = Quaternion.Euler(-90, 180, rotationRight); SoundManager.Instance.PlaySound(moveClip); }
                    else 
                    {
                        // Debug.Log("Not allowed to Move Right.");
                        SoundManager.Instance.PlaySound(collClip);
                        playerPrefab.GetComponent<SkinLoader>().currentSkin.GetComponent<Animator>().SetTrigger("jump");
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Space pressed");
                    if (powerUpManager.WaterbottleChecker() == true)
                    {
                        
                        powerUps.UseBottle();
                        //SoundManager.Instance.PlaySound(_hydrateClip);
                        Debug.Log("Waterbottle used");
                    }
                    else if (powerUpManager.WaterbottleChecker() == false)
                    {
                        Debug.Log("No Waterbottle");
                    }
                    else { Debug.Log("Error");}
                }
            }     
        }

        public void moveLeft ()         {Move(-1, 0); direction =   "Left";}            // Move on the Grid
        public void moveRight ()        {Move( 1, 0); direction =    "Right";}
        public void moveForward ()      {Move( 0, 1); direction =    "TapForward";}
        public void moveForwardTap ()   {Move( 0, 1); direction =    "Forward";}
        public void moveBackward ()     {Move( 0,-1); direction =   "Backward";}
        public void moveCrane()         {Move( 2, 2); direction =    "Crane";}
        public void moveSkateboard()    
        {
            // umstellen auf playerposition
            //playerPrefab.transform.position = new Vector3(posX, -16.85f, posY);
            Debug.Log("Skating1");
            if(isAllowedToMoveForward)
            {
                Debug.Log("Skating2");
                playerPrefab.transform.position = new Vector3(posX, PlayerHeigth, posY++);
                IsValidMove(posX, posY);	
            }
            else if (!isAllowedToMoveForward)
            {
                Debug.Log("Skating3");
                playerPrefab.transform.position = new Vector3(posX, PlayerHeigth, posY--);
                return;
            }
            else {Debug.LogError("Skateboarding not functioning!");}

            direction =    "Skateboard";
        }
        public void Move(int x, int y) 
        {
            int newPosX = posX + x;
            int newPosY = posY + y;

            posX = newPosX;
            posY = newPosY;
            string blocktype = string.Empty;

            isMoving = true;
            moveTimer = initialMoveTimer;
           
            GridBlockTypeToChoose block = this.grid.getBlockAt(newPosX, newPosY);           // Check the Block the Player wants to move on

            if (block == GridBlockTypeToChoose.NormalBlock){blocktype = "Normalblock!";} 
            else if (block == GridBlockTypeToChoose.NormalBlockBlocked){
                        blocktype = "Blocking Normalblock!";} 
            else if (block == GridBlockTypeToChoose.Bridge){
                        blocktype = "Bridgeblock!";} 
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

            // Debug.Log($"Trying to Move {direction} onto the block at: {newPosX}, {newPosY}. It is a: {blocktype}");

            playerPrefab.transform.position = new Vector3(posX, 0, posY);

            // Debug.Log($"I was able to move on the block at: {newPosX}, {newPosY}");  // just Debuglogs for checking if its working properly

            IsValidMove(newPosX, newPosY);                                              // Check the surrounding Blocks of the Player after every move to get the bools 
                                                                                        // for the next movedirections set up
              
        }
        /*
        private void LogOutputTargetedBlock() {                                         // just for the check, if the grid is working properly and the player can detect the blocks
            Debug.Log($"Position: {this.posX}, {this.posY}");
            Debug.Log($"This is a: { grid.getBlockAt(this.posX, this.posY)}!");
        }
        */
        public void IsValidMove(int x, int y)                                           // Set the bools up for the surrounding blocks of the player
        {                                                                               // decides if the player can move in a direction or not
            int numRows = grid.blocks.GetLength(0);
            int numCols = grid.blocks.GetLength(1);

            if (x >= 0 && x < numCols && y >= 0 && y < numRows)
            {                                                                                             
                isAllowedToMoveLeft = IsValidBlock(x - 1, y);                           // Check all four directions around the player
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

        private bool IsValidBlock(int x, int y)                                             // Compare the block the player wants to move on with the blocked blocks
        {                                                                                   // if the block is blocked, the player cant move on it
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
    public void AllowMovement()
    {
        isAllowedToMove = true;
    }
    public void PreventMovement()
    {
        isAllowedToMove = false;
    }
    public void CraneMovement()
    {
        playerPosition.moveCrane();
    }
    public void SkateboardMovement()
    {
        
        Debug.Log($"{playerPosition.posX} {playerPosition.posY} = SkateboardMovement - Position");
        Invoke("CallOfMoveSkateboard", .2f);
        Invoke("CallOfMoveSkateboard", .4f);
        Invoke("CallOfMoveSkateboard", .55f);
        Invoke("CallOfMoveSkateboard", .65f);
        Invoke("CallOfMoveSkateboard", .75f);
        Invoke("CallOfMoveSkateboard", .85f);
        Invoke("CallOfMoveSkateboard", .95f);
        Invoke("CallOfMoveSkateboard", 1.1f);
        Invoke("CallOfMoveSkateboard", 1.25f);
        Invoke("CallOfMoveSkateboard", 1.4f);
        Invoke("CallOfMoveSkateboard", 1.55f);

    
        Invoke("AllowMovement", 1.55f);
        // Skateboard unter player spawnen
     
    }

    public void CallOfMoveSkateboard()
    {
        playerPosition.moveSkateboard();
    }
    public void RandomMovement()
    {
        int randomNum = Random.Range(0, 4);

        switch(randomNum){
        case 0:
            playerPosition.moveLeft();
            GameObject newObject1 = Instantiate(bucket, new Vector3(playerPosition.posX, 2, playerPosition.posY), Quaternion.identity);
            
        break;
        case 1:
            playerPosition.moveRight();
            GameObject newObject2 = Instantiate(bucket, new Vector3(playerPosition.posX, 2, playerPosition.posY), Quaternion.identity);
            
        break;
        case 2:
            playerPosition.moveForward();
            GameObject newObject3 = Instantiate(bucket, new Vector3(playerPosition.posX, 2, playerPosition.posY), Quaternion.identity);
            
        break;
        case 3:
            playerPosition.moveBackward();
            GameObject newObject4 = Instantiate(bucket, new Vector3(playerPosition.posX, 2, playerPosition.posY), Quaternion.identity);
            
        break;
        }
    }
    
}
