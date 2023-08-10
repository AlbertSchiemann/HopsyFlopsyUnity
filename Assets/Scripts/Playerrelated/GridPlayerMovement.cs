using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public HydrationController hydrationController;
  
    [SerializeField] private int StartX = 23;                          // Position of the Prefab in the Scene
    [SerializeField] private int StartY =  3;       
                  

    public float PlayerHeigth = 1f;                        // Position in Y Axis of the Prefab
    private bool isAllowedToMove = true;                    // enables player movement in general

    public bool UpdateActive = true;                        // enables the update of the playerposition

    [SerializeField] private AudioClip[] _moveClip;
    [SerializeField] private AudioClip[] _collisionClip;
    [SerializeField] private AudioClip[] _hydrateClip;
    [SerializeField] private GameObject bucket;
    [SerializeField] private GameObject cablecart;

    void Start()
    {
        grid2dCreated = grid.getGridCreated();
        print(grid2dCreated);
        InstantiatePlayer();
        isAllowedToMove = true;                                             // Enter the Starting Gridposition of the Player, so a check of the surrounding blocks gets called
        playerPosition.IsValidMove(StartX, StartY);                                   // and the player cant move through blocked blocks              
        UpdateGameObjectPosition();
        isAllowedToMove = false;

        //GameStateManagerScript.onGameStart += AllowMovement;
        Invoke("CameraStart", CameraFollow.TotalDelayForCameraRide);
        GameStateManagerScript.onGamePaused += PreventMovement;           
    }

    private void CameraStart ()
    {
        AllowMovement();
        Debug.Log("CameraStart");
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
        public string direction = string.Empty;             // dunno
        public Ease animEase = Ease.Linear;                // Animation Ease
        public Ease animEaseRotate = Ease.InOutFlash;          // Animation Ease
        public Ease animEaseCollide = Ease.InOutFlash;          // Animation Ease
        public Ease animEaseJump = Ease.InOutExpo;          // Animation Ease
        public float collisionAnimationTimer = 0.1f; 


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
                    if (isAllowedToMoveForward == true) 
                    { 
                        moveForward(); 
                        //playerPrefab.transform.DORotate(new Vector3(-90, 180, rotationForward), 0.2f).SetEase(animEaseRotate);
                        playerPrefab.transform.rotation = Quaternion.Euler(-90, 180, rotationForward); 
                        SoundManager.Instance.PlaySound(moveClip); 
                        playerPrefab.GetComponent<SkinLoader>().AnimationTrigger();
                    }
                    else
                    {
                        playerPrefab.transform.DOMove(new Vector3(posX, PlayerHeigth, posY - collisionAnimationTimer), initialMoveTimer*2f).SetEase(animEaseCollide);
                        SoundManager.Instance.PlaySound(collClip);
                        playerPrefab.transform.DOMove(new Vector3(posX, PlayerHeigth, posY + collisionAnimationTimer), initialMoveTimer*2f).SetEase(animEaseCollide).SetDelay(collisionAnimationTimer);
                    }
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || SwipeManager.swipeUp || C_Playing.upTap || C_Playing.upCrossTap)
                {
                    if (isAllowedToMoveForward == true) 
                    { 
                        moveForward(); 
                        //playerPrefab.transform.DORotate(new Vector3(-90, 180, rotationForward), 0.2f).SetEase(animEaseRotate);
                        playerPrefab.transform.rotation = Quaternion.Euler(-90, 180, rotationForward); 
                        SoundManager.Instance.PlaySound(moveClip); 
                        playerPrefab.GetComponent<SkinLoader>().AnimationTrigger();
                    }
                    else 
                    {
                        playerPrefab.transform.DOMove(new Vector3(posX, PlayerHeigth, posY - collisionAnimationTimer), initialMoveTimer*2f).SetEase(animEaseCollide);
                        SoundManager.Instance.PlaySound(collClip);
                        playerPrefab.transform.DOMove(new Vector3(posX, PlayerHeigth, posY + collisionAnimationTimer), initialMoveTimer*2f).SetEase(animEaseCollide).SetDelay(collisionAnimationTimer);
                    }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || SwipeManager.swipeDown || C_Playing.downTap || C_Playing.downCrossTap)
                {
                    if (isAllowedToMoveBack == true) 
                    { 
                        moveBackward(); 
                        /*
                        if (playerPrefab.transform.rotation.z != 0 && playerPrefab.transform.rotation.y != 0)
                        {
                            playerPrefab.transform.DORotate(new Vector3(-90, 180, rotationBackward), 0.2f).SetEase(animEaseRotate);
                        }
                        */
                        
                        playerPrefab.transform.rotation = Quaternion.Euler(-90, 180, rotationBackward); 
                        SoundManager.Instance.PlaySound(moveClip); 
                        playerPrefab.GetComponent<SkinLoader>().AnimationTrigger();
                    }
                    else 
                    {
                        playerPrefab.transform.DOMove(new Vector3(posX, PlayerHeigth, posY + collisionAnimationTimer), initialMoveTimer*2f).SetEase(animEaseCollide);
                        SoundManager.Instance.PlaySound(collClip);
                        playerPrefab.transform.DOMove(new Vector3(posX, PlayerHeigth, posY - collisionAnimationTimer), initialMoveTimer*2f).SetEase(animEaseCollide).SetDelay(collisionAnimationTimer);
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || SwipeManager.swipeLeft || C_Playing.leftTap || C_Playing.leftCrossTap)
                {
                    if (isAllowedToMoveLeft == true) 
                    {   
                        moveLeft(); 
                        //playerPrefab.transform.DORotate(new Vector3(-90, 180, rotationLeft), 0.2f).SetEase(animEaseRotate);
                        playerPrefab.transform.rotation = Quaternion.Euler(-90, 180, rotationLeft); 
                        SoundManager.Instance.PlaySound(moveClip);
                        playerPrefab.GetComponent<SkinLoader>().AnimationTrigger();
                    }
                    else 
                    { 
                        playerPrefab.transform.DOMove(new Vector3(posX - collisionAnimationTimer, PlayerHeigth, posY), initialMoveTimer*2f).SetEase(animEaseCollide);
                        SoundManager.Instance.PlaySound(collClip);
                        playerPrefab.transform.DOMove(new Vector3(posX + collisionAnimationTimer, PlayerHeigth, posY), initialMoveTimer*2f).SetEase(animEaseCollide).SetDelay(collisionAnimationTimer);
                    }
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || SwipeManager.swipeRight || C_Playing.rightTap || C_Playing.rightCrossTap)
                {
                    if (isAllowedToMoveRight == true)
                    { 
                        moveRight(); 
                        //playerPrefab.transform.DORotate(new Vector3(-90, 180, rotationRight), 0.2f).SetEase(animEaseRotate);
                        playerPrefab.transform.rotation = Quaternion.Euler(-90, 180, rotationRight); 
                        SoundManager.Instance.PlaySound(moveClip); 
                        playerPrefab.GetComponent<SkinLoader>().AnimationTrigger();
                    }
                    else 
                    {
                        playerPrefab.transform.DOMove(new Vector3(posX + collisionAnimationTimer, PlayerHeigth, posY), initialMoveTimer*2f).SetEase(animEaseCollide);
                        SoundManager.Instance.PlaySound(collClip);
                        playerPrefab.transform.DOMove(new Vector3(posX - collisionAnimationTimer, PlayerHeigth, posY), initialMoveTimer*2f).SetEase(animEaseCollide).SetDelay(collisionAnimationTimer);
                    }
                }
            }     
        }

        public void moveLeft ()         {Move(-1, 0); direction =   "Left";}            // Move on the Grid
        public void moveRight ()        {Move( 1, 0); direction =    "Right";}
        public void moveForward ()      {Move( 0, 1); direction =    "TapForward";}
        public void moveForwardTap ()   {Move( 0, 1); direction =    "Forward";}
        public void moveBackward ()     {Move( 0,-1); direction =   "Backward";}
        public void moveCrane()         {Move( 2, 2); direction =    "Crane";}

        public void PlayerWin()         
        {
            playerPrefab.transform.DOMove( new Vector3 (21f,1.75f,119f),1f).SetEase(animEaseJump);
            playerPrefab.transform.DOMove( new Vector3 (61f,1.75f,119f),3f).SetDelay(1.5f).SetEase(animEaseJump);
            
        }
        public void moveSkateboard()    
        {
            // umstellen auf playerposition
            //playerPrefab.transform.position = new Vector3(posX, -16.85f, posY);
            
            if(isAllowedToMoveForward)
            {
                playerPrefab.transform.position = new Vector3(posX, PlayerHeigth, posY++);
                IsValidMove(posX, posY);	
            }
            else if (!isAllowedToMoveForward)
            {
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

            

            //playerPrefab.transform.position = new Vector3(posX, 0, posY);
            playerPrefab.transform.DOMove(new Vector3(posX, PlayerHeigth, posY), initialMoveTimer*2f).SetEase(animEase);

            

            IsValidMove(newPosX, newPosY);                                              // Check the surrounding Blocks of the Player after every move to get the bools 
                                                                                        // for the next movedirections set up
              
        }

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
    public void CallOfPlayerWin()
    {
        playerPosition.PlayerWin();
        cablecart.transform.DOMove( new Vector3 (39.80000114f,-3.81999969f,120.059998f),3f).SetDelay(1.5f).SetEase(Ease.InOutExpo);
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
