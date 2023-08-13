using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public enum Direction
{
    Right,
    Forward,
    Left,
    Backward
}

public class EnemyMovementArray : MonoBehaviour
{
    [Serializable]
    public struct MovementStruct
    {
        public Direction Movementdirection;
        public int Directionslength;
    }
    [SerializeField] MovementStruct[] movementDirection; // Array of the Movement Directions and their length
    [SerializeField] private  Ease animEase = Ease.Linear; // Ease of the Movement




    // The Starting Rotation of the Enemy is always according to the grid - so he always faces forward
    // The Starting position has to be handmade for each one, so it cant take the worldposition of the prefab and calculate the gridposition
    // The enemy will always call all direction-functions, but only the ones with points will be executed
    // There is no Update function, as the enemy always moves in a fixed path, so he doesnt need to check for anything
    public Vector3 StartingPoint;                       // Starting Coordinates of the Enemy
    public float generalHeigth = .5f;                   // Position in Y Axis of the Prefab, normally on grid with .5f
                                                        // if the Input of a Y Position is higher than the generalHeigth, the generalHeigth gets updated to the new Y Position
                                                        // therefore the generalHeigth should always set the lowest Point of the Enemy
    [SerializeField] private float moveDelay = 1f;      // Delay between each step of the Enemy
    private Grid2DCreated grid2dCreated;                // Insert the grid of the Level
    [SerializeField] private Grid grid;
    private EnemyPosition enemyPosition;
    [SerializeField] private GameObject enemyPrefab;    // Insert the Enemy Prefab
    public C_LevelSwitchScreens levelScript;                  // Reference to the LevelScripts
    [SerializeField] private AudioClip[] _failClip;     // Death Sound

    public static bool canTankHit = false;              // Shield Power-Up Bool
    [SerializeField] private AudioClip[] _deflectClip;  // Shield Destroy Sound

    public float delayTillDeathscreenShows = .2f;                          // Delay till Scene gets reloaded after death
    private float delayTillStartOfMovement = .01f;                          // Delay till Enemy gets destroyed after death
    private int currentMovementStep;

    public C_PowerUps powerUp;

    private void Awake()
    {
        GameObject levelUIObject = GameObject.Find("Level_UI");
        levelScript = levelUIObject.GetComponent<C_LevelSwitchScreens>();
        currentMovementStep = 0;
    }
    void Start()
    {
        
        if (StartingPoint.y > generalHeigth)            // take the bigger value for the height and start from there
        {
            generalHeigth = StartingPoint.y;
        }

        grid2dCreated = grid.getGridCreated();
        InitiateEnemy();                                // Initiate the Enemy in his Starting Position
        UpdateGameObjectPosition();                     // Set the Transform of the Enemy to his Starting Position
        Invoke("StartMovement", delayTillStartOfMovement);            // Start the Movement after a delay
    }

    private void StartMovement()
    {
        if (currentMovementStep < movementDirection.Length)
        {
            currentMovementStep++;
        }
        else if (currentMovementStep == movementDirection.Length)
        {
            currentMovementStep = 0;
            InBetweenLooping();
            return;
        }
        else {
            Debug.Log("Return StartMovement");
            return; 
        }



        MovementStruct current = movementDirection[currentMovementStep - 1];

        switch (current.Movementdirection)
        {
            case Direction.Right:
                FLMoveRight(current.Directionslength);
                //Debug.Log("1");
                break;
            case Direction.Forward:
                FLMoveForward(current.Directionslength);
                //Debug.Log("2");
                break;
            case Direction.Left:
                FLMoveLeft(current.Directionslength);
                //Debug.Log("3");
                break;
            case Direction.Backward:
                FLMoveBackward(current.Directionslength);
               //Debug.Log("4");
                break;
            default:
                Debug.Log("No Movement Implemented for the Enemy in Inspector");
                break;
        }
    }
    private void InBetweenLooping()
    {
        InitiateEnemy();
        UpdateGameObjectPosition();
        StartMovement();
    }
    private IEnumerator PerformMovement(int numSteps, System.Action<int> movementAction) // One Step at a time
    {
        for (int f = 0; f < numSteps; f++)
        {
            movementAction(1);
            yield return new WaitForSeconds(moveDelay);
        }
        StartMovement();
    }


    private void FLMoveRight(int Directionslength)                                                          // Forward Loop functions starting here
    {
        StartCoroutine(PerformMovement(Directionslength, MovingRight));
    }

    private void FLMoveForward(int Directionslength)
    {
        StartCoroutine(PerformMovement(Directionslength, MovingForward));
    }

    private void FLMoveLeft(int Directionslength)
    {
        StartCoroutine(PerformMovement(Directionslength, MovingLeft));
    }

    private void FLMoveBackward(int Directionslength)
    {
        StartCoroutine(PerformMovement(Directionslength, MovingBackward));            // Check if the Loop is active or not
    }

    private void InitiateEnemy()                                                            // Initiate the Enemy in his Starting Position
    {
        enemyPosition = new EnemyPosition((int)StartingPoint.x, generalHeigth, (int)StartingPoint.z, grid2dCreated, enemyPrefab);
    }

    public void MovingRight(int x)                                                          // Move the Enemy and Update the Position
    {
        int newX = enemyPosition.posX + x;
        enemyPosition.posX = newX;
        //enemyPrefab.transform.position = new Vector3(enemyPosition.posX, 0, 0);
        enemyPrefab.transform.DOMoveX(enemyPosition.posX, moveDelay).SetEase(animEase);
        UpdateGameObjectPosition();
    }
    public void MovingLeft(int x)
    {
        int newX = enemyPosition.posX - x;
        enemyPosition.posX = newX;
        //enemyPrefab.transform.position = new Vector3(enemyPosition.posX, 0, 0);
        enemyPrefab.transform.DOMoveX(enemyPosition.posX, moveDelay).SetEase(animEase);
        UpdateGameObjectPosition();
    }
    public void MovingForward(int z)
    {
        int newZ = enemyPosition.posZ + z;
        enemyPosition.posZ = newZ;
        //enemyPrefab.transform.position = new Vector3(0, 0, enemyPosition.posZ);
        enemyPrefab.transform.DOMoveZ(enemyPosition.posZ, moveDelay).SetEase(animEase);
        UpdateGameObjectPosition();
        
    }
    public void MovingBackward(int z)
    {
        int newZ = enemyPosition.posZ - z;
        enemyPosition.posZ = newZ;
        //enemyPrefab.transform.position = new Vector3(0, 0, enemyPosition.posZ);
        enemyPrefab.transform.DOMoveZ(enemyPosition.posZ, moveDelay).SetEase(animEase);
        UpdateGameObjectPosition();
        
    }

    private Vector3 previousPosition;                                                    // save the previous Position of the Enemy for the Rotation                                         

    private void UpdateGameObjectPosition()
    {
        // Calculate current position
        Vector3 currentPosition = new Vector3(enemyPosition.posX, enemyPosition.posY, enemyPosition.posZ);
        //enemyPrefab.transform.position = currentPosition;

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

    public class EnemyPosition
    {              // when Player gets called, he gets a starting-position and the grid reference
        public int posX;
        public float posY;
        public int posZ;
        private Grid2DCreated grid;
        private GameObject enemyPrefab;        // Reference to the Enemy Prefab
        private GameObject enemy;              // Reference to the Enemy

        public string direction = string.Empty;
        public EnemyPosition(int x, float y, int z, Grid2DCreated grid, GameObject enemyPrefab)
        {  // Constructor: Enemy gets the Position of the Block he is on
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
            if (!canTankHit)
            {
                //Debug.Log("EnemyCollision - Eaten!");                           // Restart the game if the player collides with the enemy
                //levelScript.OpenLoose();
                Invoke("Sceneload", delayTillDeathscreenShows);
                GameObject player = other.gameObject;
                player.GetComponent<GridPlayerMovement>().PreventMovement();
                SoundManager.Instance.PlaySound(_failClip);

                // PlayerCollision.GetComponent.Sceneload();
                // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                SoundManager.Instance.PlaySound(_deflectClip);
                canTankHit = false;
                powerUp.UseShield();
                return;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTankHit = false;
            if (powerUp == null) { return; }
            powerUp.UseShield();
        }
    }
    void Sceneload()
    {
        AlwaysThere.time = (int)C_Playing.Timer;
        if (!C_LevelSwitchScreens.AdWatched)
            levelScript.OpenAd();
        else levelScript.OpenLoose();
    }
}


