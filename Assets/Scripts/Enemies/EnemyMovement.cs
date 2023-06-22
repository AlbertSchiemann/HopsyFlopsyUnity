using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Grid2DCreated grid2dCreated;
    [SerializeField] private Grid grid;
    private PlayerPosition playerPosition; 
    [SerializeField] private GameObject playerPrefab; 

    public float generalHeigth = .5f;  // Position in Y Axis of the Prefab
    
    public Vector3 StartingPoint;
    //public int pointA_X, pointA_Y, pointA_Z;
    //public int pointB_X, pointB_Y, pointB_Z;
    //public int pointC_X, pointC_Y, pointC_Z;
    //public int pointD_X, pointD_Y, pointD_Z;
    //public int pointE_X, pointE_Y, pointE_Z;

    public int pointsMoveRight;
    public int pointsMoveLeft;
    public int pointsMoveForward;
    public int pointsMoveBackward;

    private int movementsMAX = 0;
    private int movementsCounter = 1;


    //private bool movingTowardsPointA = false;
    //private bool movingTowardsPointB = false;
    //private bool movingTowardsPointC = false;
    //private bool movingTowardsPointD = false;
    //private bool movingTowardsPointE = false;
    bool isProcessingMovement;

    private float movementSpeed = 2f;
    private bool onTheWayBack = false;
    void Start()
    {
        grid2dCreated = grid.getGridCreated();
        print(grid2dCreated);
        InitiateEnemy();
        //movingTowardsPointB = true;
        isProcessingMovement = false;
        movementsMAX = pointsMoveRight + pointsMoveLeft + pointsMoveForward + pointsMoveBackward;

    }

    private void PreventMovement()
    { 
        isProcessingMovement = false;
    }
    private void MovementDelay()
    {
        Invoke(nameof(PreventMovement), .1f);
    }

    void Update()
    {
        if (playerPosition != null)
        {
            //transform.LookAt();
            if(!onTheWayBack && !isProcessingMovement)
            {

                for (int i = 1; i < pointsMoveRight; i++)    {
                    
                    if (!isProcessingMovement) 
                    { 
                        MovingRight   (1);
                        UpdateGameObjectPosition();
                        Debug.Log("+1 Step R");
                        movementsCounter++;
                        MovementDelay(); 
                        isProcessingMovement = true; 
                        
                    }
                    
                    
                }
                for (int i = 1; i < pointsMoveLeft; i++)     {
                    
                    if (!isProcessingMovement) 
                    { 
                        MovingLeft    (1);
                        UpdateGameObjectPosition();
                        Debug.Log("+1 Step L");
                        movementsCounter++;
                        MovementDelay(); 
                        isProcessingMovement = true; 
                        
                    }
                    
                }
                for (int i = 1; i < pointsMoveForward; i++)  {
                    
                    if (!isProcessingMovement) 
                    { 
                        MovingForward (1);
                        UpdateGameObjectPosition(); 
                        Debug.Log("+1 Step F");
                        movementsCounter++;
                        MovementDelay(); 
                        isProcessingMovement = true;
                        
                    }
                    
                }
                for (int i = 1; i < pointsMoveBackward; i++) {
                    
                    if (!isProcessingMovement) 
                    { 
                        MovingBackward(1);
                        UpdateGameObjectPosition();
                        Debug.Log("+1 Step B");
                        movementsCounter++;
                        MovementDelay(); 
                        isProcessingMovement = true;
                         
                    }
                    
                }
                
                if (movementsCounter == movementsMAX) {
                    onTheWayBack = true;
                }
                
                
            }
            else if(onTheWayBack == true && !isProcessingMovement)
            {

                for (int i = 1; i < pointsMoveForward; i++) {
                    
                    if (!isProcessingMovement) 
                    { 
                        MovingBackward(1);
                        UpdateGameObjectPosition();
                        Debug.Log("-1 Step B");
                        movementsCounter--;
                        MovementDelay(); 
                        isProcessingMovement = true;
                         
                    }
                    
                }
                for (int i = 1; i < pointsMoveBackward; i++)  {
                    
                    if (!isProcessingMovement) 
                    { 
                        MovingForward (1);
                        UpdateGameObjectPosition();
                        Debug.Log("-1 Step F");
                        movementsCounter--;
                        MovementDelay(); 
                        isProcessingMovement = true; 
                        
                    }
                    
                }
                for (int i = 1; i < pointsMoveRight; i++)     {
                    
                    if (!isProcessingMovement) 
                    { 
                        
                        MovingLeft   (1);
                        UpdateGameObjectPosition();
                        Debug.Log("-1 Step L");
                        movementsCounter--;
                        MovementDelay(); 
                        isProcessingMovement = true; 
                        
                    }
                    
                }
                for (int i = 1; i < pointsMoveLeft; i++)    {
                    
                    if (!isProcessingMovement) 
                    { 
                        
                        MovingRight   (1);
                        UpdateGameObjectPosition();
                        Debug.Log("-1 Step R");
                        movementsCounter--;
                        MovementDelay(); 
                        isProcessingMovement = true; 
                        
                    }
                    
                }
                if (movementsCounter == 0) {
                    onTheWayBack = false;
                }

            }
            else return;


        }
        else { Debug.LogError("PlayerPosition is null!"); }
    }

    private void InitiateEnemy()
    {
        playerPosition = new PlayerPosition((int)StartingPoint.x, (int)StartingPoint.y, (int)StartingPoint.z, grid2dCreated, playerPrefab);
    }
        
    public void MovingRight(int x)
    {
        int newX = playerPosition.posX + x;
        playerPosition.posX = newX;
        playerPrefab.transform.position = new Vector3(playerPosition.posX, 0, 0);
    }
    public void MovingLeft(int x)
    {
        int newX = playerPosition.posX - x;
        playerPosition.posX = newX;
        playerPrefab.transform.position = new Vector3(playerPosition.posX, 0, 0);
    }
    public void MovingForward(int z)
    {
        int newZ = playerPosition.posZ + z;
        playerPosition.posZ = newZ;
        playerPrefab.transform.position = new Vector3(0, 0,playerPosition.posZ);
    }
    public void MovingBackward(int z)
    {
        int newZ = playerPosition.posZ - z;
        playerPosition.posZ = newZ;
        playerPrefab.transform.position = new Vector3(0, 0,playerPosition.posZ);
    }

    private void UpdateGameObjectPosition()
    {
        transform.position = new Vector3(playerPosition.posX, playerPosition.posY, playerPosition.posZ);
        //player.transform.position = new Vector3(playerPosition.posX, 1, playerPosition.posY);

    }
    
    public class PlayerPosition {              // when Player gets called, he gets a starting-position and the grid reference
        public int posX; 
        public int posY;
        public int posZ;
        private Grid2DCreated grid;
        private GameObject playerPrefab; // Reference to the player GameObject
        private GameObject player; // Reference to the player GameObject

        public string direction = string.Empty;
        public PlayerPosition(int x, int y, int z, Grid2DCreated grid, GameObject playerPrefab) {  // Constructor: Player gets the Position of the Block he is on
            this.posX = x;
            this.posY = y;
            this.posZ = z;
            this.grid = grid;
            this.playerPrefab = playerPrefab;

        }
    }
    public class CheckpointPosition {              // when Player gets called, he gets a starting-position and the grid reference
        public int posX;
        public int height; 
        public int posY;
        private Grid2DCreated grid;


        public string direction = string.Empty;
        public CheckpointPosition(int x, int height,int y, Grid2DCreated grid) {  // Constructor: Player gets the Position of the Block he is on
            this.posX = x;
            this.height = height;
            this.posY = y;
            this.grid = grid;


        }
    }
}
