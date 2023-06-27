using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // The Starting Rotation of the Enemy is always according to the grid - so he always faces forward
    // The Starting position has to be handmade for each one, so it cant take the worldposition of the prefab and calculate the gridposition
    // The enemy will always call all direction-functions, but only the ones with points will be executed
    // There is no Update function, as the enemy always moves in a fixed path, so he doesnt need to check for anything


    private Grid2DCreated grid2dCreated;                // Insert the grid of the Level
    [SerializeField] private Grid grid;
    private EnemyPosition enemyPosition; 
    [SerializeField] private GameObject enemyPrefab;    // Insert the Enemy Prefab
    public UI_LevelScript levelScript;                  // Reference to the LevelScript


    public float generalHeigth = .5f;                   // Position in Y Axis of the Prefab, normally on grid with .5f
                                                        // if the Input of a Y Position is higher than the generalHeigth, the generalHeigth gets updated to the new Y Position
                                                        // therefore the generalHeigth should always set the lowest Point of the Enemy
    
    public Vector3 StartingPoint;                       // Starting Coordinates of the Enemy
    [SerializeField] private float moveDelay = 1f;      // Delay between each step of the Enemy
    [SerializeField] private int pointsMoveRight;       // How many Points the Enemy moves to the right
    [SerializeField] private int pointsMoveForward;
    [SerializeField] private int pointsMoveLeft;
    [SerializeField] private int pointsMoveBackward;

    [SerializeField] private bool isLoopActive;         // Choose if the Enemy should spawn at the Starting Point after he finished his path
                                                        // or if he should run the path back and forth in a loop
    
    [SerializeField] private AudioClip[] _failClip;     // Death Sound

    public float DelayTillReload = 1.0f;                          // Delay till Scene gets reloaded after death
    private void Awake()
    {
        GameObject levelUIObject = GameObject.Find("LevelUI");
        levelScript = levelUIObject.GetComponent<UI_LevelScript>();
    }
    void Start()
    {
        if (StartingPoint.y > generalHeigth)            // take the bigger value for the height and start from there
        {
            generalHeigth = StartingPoint.y;
        }
        
        grid2dCreated = grid.getGridCreated();
        //print(grid2dCreated);
        InitiateEnemy();                                // Initiate the Enemy in his Starting Position
        UpdateGameObjectPosition();                     // Set the Transform of the Enemy to his Starting Position

        if (pointsMoveRight != 0)                       // Starting of the Forward Loop - it starts with the first direction that has points
        {
            FLMoveRight(); 
        }
        else if (pointsMoveForward != 0)
        {
            FLMoveForward();
        }
        else if (pointsMoveLeft != 0)
        {
            FLMoveLeft();
        }
        else if (pointsMoveBackward != 0)
        {
            FLMoveBackward();
        }
        else
        {
            Debug.Log("No points to move");             // If there are no points set, the Enemy will not move and we get a Debug Log
        }
    }



    private IEnumerator PerformMovement(int numSteps, System.Action<int> movementAction) // One Step at a time
    {
        for (int i = 0; i < numSteps; i++)
        {
            movementAction(1);
            //Debug.Log("1 Step");
            yield return new WaitForSeconds(moveDelay);
        }
    }


    private IEnumerator WaitAndExecute(int numSteps, System.Action action)              // Wait for a Delay-time and then execute the next step
    {
        yield return new WaitForSeconds(numSteps * moveDelay);
        action.Invoke();
    }

    private void FLMoveRight()                                                          // Forward Loop functions starting here
    {
        StartCoroutine(PerformMovement(pointsMoveRight, MovingRight));
        StartCoroutine(WaitAndExecute(pointsMoveRight, FLMoveForward));
    }

    private void FLMoveForward()
    {
        StartCoroutine(PerformMovement(pointsMoveForward, MovingForward));
        StartCoroutine(WaitAndExecute(pointsMoveForward, FLMoveLeft));
    }

    private void FLMoveLeft()
    {
        StartCoroutine(PerformMovement(pointsMoveLeft, MovingLeft));
        StartCoroutine(WaitAndExecute(pointsMoveLeft, FLMoveBackward));
    }

    private void FLMoveBackward()
    {
        StartCoroutine(PerformMovement(pointsMoveBackward, MovingBackward));            // Check if the Loop is active or not
        StartCoroutine(WaitAndExecute(pointsMoveBackward, () =>
        {
            if (isLoopActive)
            {
                BLMoveBackward();
            }
            else
            {
                InitiateEnemy();
                UpdateGameObjectPosition();
                FLMoveRight();
            }
        }));
    }

    private void BLMoveRight()                                                          // Backward Loop functions starting here
    {
        StartCoroutine(PerformMovement(pointsMoveRight, MovingLeft));
        StartCoroutine(WaitAndExecute(pointsMoveRight, () =>
        {
            InitiateEnemy();
            UpdateGameObjectPosition();
            FLMoveRight();
        }));
    }

    private void BLMoveForward()
    {
        StartCoroutine(PerformMovement(pointsMoveForward, MovingBackward));
        StartCoroutine(WaitAndExecute(pointsMoveForward, BLMoveRight));
    }

    private void BLMoveLeft()
    {
        StartCoroutine(PerformMovement(pointsMoveLeft, MovingRight));
        StartCoroutine(WaitAndExecute(pointsMoveLeft, BLMoveForward));
    }

    private void BLMoveBackward()
    {
        StartCoroutine(PerformMovement(pointsMoveBackward, MovingForward));
        StartCoroutine(WaitAndExecute(pointsMoveBackward, BLMoveLeft));

    }

    private void InitiateEnemy()                                                            // Initiate the Enemy in his Starting Position
    {
        enemyPosition = new EnemyPosition((int)StartingPoint.x, generalHeigth, (int)StartingPoint.z, grid2dCreated, enemyPrefab);
    }
        
    public void MovingRight(int x)                                                          // Move the Enemy and Update the Position
    {
        int newX = enemyPosition.posX + x;
        enemyPosition.posX = newX;
        enemyPrefab.transform.position = new Vector3(enemyPosition.posX, 0, 0);
        UpdateGameObjectPosition();
    }
    public void MovingLeft(int x)
    {
        int newX = enemyPosition.posX - x;
        enemyPosition.posX = newX;
        enemyPrefab.transform.position = new Vector3(enemyPosition.posX, 0, 0);
        UpdateGameObjectPosition();
    }
    public void MovingForward(int z)
    {
        int newZ = enemyPosition.posZ + z;
        enemyPosition.posZ = newZ;
        enemyPrefab.transform.position = new Vector3(0, 0,enemyPosition.posZ);
        UpdateGameObjectPosition();
    }
    public void MovingBackward(int z)
    {
        int newZ = enemyPosition.posZ - z;
        enemyPosition.posZ = newZ;
        enemyPrefab.transform.position = new Vector3(0, 0,enemyPosition.posZ);
        UpdateGameObjectPosition();
    }

    private Vector3 previousPosition;                                                    // save the previous Position of the Enemy for the Rotation                                         

    private void UpdateGameObjectPosition()
    {
        // Calculate current position
        Vector3 currentPosition = new Vector3(enemyPosition.posX, enemyPosition.posY, enemyPosition.posZ);
        enemyPrefab.transform.position = currentPosition;

        // Calculate movement direction
        Vector3 direction = currentPosition - previousPosition;
        previousPosition = currentPosition;

        // Adjust rotation based on movement direction
        if (direction == new Vector3(1, 0, 0))
        {
            enemyPrefab.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (direction == new Vector3(-1, 0, 0))
        {
            enemyPrefab.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else if (direction == new Vector3(0, 0, 1))
        {
            enemyPrefab.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (direction == new Vector3(0, 0, -1))
        {
            enemyPrefab.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

    }
    
    public class EnemyPosition {              // when Player gets called, he gets a starting-position and the grid reference
        public int posX; 
        public float posY;
        public int posZ;
        private Grid2DCreated grid;
        private GameObject enemyPrefab;        // Reference to the Enemy Prefab
        private GameObject enemy;              // Reference to the Enemy

        public string direction = string.Empty;
        public EnemyPosition(int x, float y, int z, Grid2DCreated grid, GameObject enemyPrefab) {  // Constructor: Enemy gets the Position of the Block he is on
            this.posX = x;
            this.posY = y;
            this.posZ = z;
            this.grid = grid;
            this.enemyPrefab = enemyPrefab;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("EnemyCollision - Eaten!");                           // Restart the game if the player collides with the enemy
            //levelScript.OpenLoose();
            Invoke("Sceneload", DelayTillReload);
            
            // PlayerCollision.GetComponent.Sceneload();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
        void Sceneload()
    {
        // restart the game if the player collides with the enemy
        levelScript.OpenLoose();  
    }
}
