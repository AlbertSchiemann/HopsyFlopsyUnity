using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = .1f; // speed of enemy movement

    private Grid2DCreated grid2dCreated;
    [SerializeField] private Grid grid;
    private EnemyPosition enemyPosition; 
    [SerializeField] private GameObject enemyPrefab;

    public Vector3 pointA;
    public Vector3 pointB;
    public Vector3 pointC;
    public Vector3 pointD;
    public Vector3 pointE;

    private bool movingTowardsPointA = false;
    private bool movingTowardsPointB = false;
    private bool movingTowardsPointC = false;
    private bool movingTowardsPointD = false;
    private bool movingTowardsPointE = false;
    


    public float generalHeight = 0.5f;


    void Start()
    {
        grid2dCreated = grid.getGridCreated();
        InstantiateEnemy();
        //UpdateGameObjectPosition();
        movingTowardsPointB = true;
    }

    private void Update()
    {
        UpdateGameObjectPosition();

        if (movingTowardsPointB)
        {
            MoveToNextPoint(new Vector3(pointB.x, pointB.y, pointB.z));
            if (enemyPosition.posX == (int)pointB.x && enemyPosition.posY == (int)pointB.z)
            {
                movingTowardsPointB = false;
                movingTowardsPointC = true;
            }
        }
        else if (movingTowardsPointC && pointC.x != 0)
        {
            MoveToNextPoint(new Vector3(pointC.x, pointC.y, pointC.z));
            if (enemyPosition.posX == (int)pointC.x && enemyPosition.posY == (int)pointC.z)
            {
                movingTowardsPointC = false;
                movingTowardsPointD = true;
            }
        }
        else if (movingTowardsPointD && pointD.x != 0)
        {
            MoveToNextPoint(new Vector3(pointD.x, pointD.y, pointD.z));
            if (enemyPosition.posX == (int)pointD.x && enemyPosition.posY == (int)pointD.z)
            {
                movingTowardsPointD = false;
                movingTowardsPointE = true;
            }
        }
        else if (movingTowardsPointE && pointE.x != 0)
        {
            MoveToNextPoint(new Vector3(pointE.x, pointE.y, pointE.z));
            if (enemyPosition.posX == (int)pointE.x && enemyPosition.posY == (int)pointE.z)
            {
                movingTowardsPointE = false;
                movingTowardsPointD = true;
            }
        }
        else if (movingTowardsPointD && pointD.x != 0)
        {
            MoveToNextPoint(new Vector3(pointD.x, pointD.y, pointD.z));
            if (enemyPosition.posX == (int)pointD.x && enemyPosition.posY == (int)pointD.z)
            {
                movingTowardsPointD = false;
                movingTowardsPointC = true;
            }
        }
        else if (movingTowardsPointC && pointC.x != 0)
        {
            MoveToNextPoint(new Vector3(pointC.x, pointC.y, pointC.z));
            if (enemyPosition.posX == (int)pointC.x && enemyPosition.posY == (int)pointC.z)
            {
                movingTowardsPointC = false;
                movingTowardsPointB = true;
            }
        }
        else if (movingTowardsPointB)
        {
            MoveToNextPoint(new Vector3(pointB.x, pointB.y, pointB.z));
            if (enemyPosition.posX == (int)pointB.x && enemyPosition.posY == (int)pointB.z)
            {
                movingTowardsPointB = false;
                movingTowardsPointA = true;
            }
        }
        else if (movingTowardsPointA)
        {
            MoveToNextPoint(new Vector3(pointA.x, pointA.y, pointA.z));
            if (enemyPosition.posX == (int)pointA.x && enemyPosition.posY == (int)pointA.z)
            {
                movingTowardsPointA = false;
                movingTowardsPointB = true;
            }
        }
    }

    private void InstantiateEnemy()
    {
        enemyPosition = new EnemyPosition((int)pointA.x, generalHeight, (int)pointA.z, grid2dCreated, enemyPrefab);
    }
    private void UpdateGameObjectPosition()
    {
        transform.position = new Vector3(enemyPosition.posX, (generalHeight > pointA.y) ? generalHeight : pointA.y, enemyPosition.posY);
    }
/*
    private void MoveToNextPoint(Vector3 targetPoint)
    {
        Vector3 targetPosition = new Vector3(targetPoint.x, (generalHeight > targetPoint.y) ? generalHeight : targetPoint.y, targetPoint.z);
        // set the vector where the enemy goes to
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // ---------------------HERE IS THE ERROR_________________
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // move to the targetposition of the vector before, in a transform of the enemy, by a speed
        
        transform.LookAt(targetPosition);
        // let the enemy face the direction it goes to

        Debug.Log(targetPosition);
        // Console Output
    }
    */
    private void MoveToNextPoint(Vector3 targetPoint)
{
    Vector3 targetPosition = new Vector3(targetPoint.x, (generalHeight > targetPoint.y) ? generalHeight : targetPoint.y, targetPoint.z);
    float step = moveSpeed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

    transform.LookAt(targetPosition);
}




    public class EnemyPosition {              // when Player gets called, he gets a starting-position and the grid reference
        public int posX; 
        public int posY;
        public float generalHeight = .5f;
        private Grid2DCreated grid;
        private GameObject enemyPrefab; // Reference to the player GameObject
        private GameObject enemy; // Reference to the player GameObject
        public EnemyPosition(int x, float height,int y, Grid2DCreated grid, GameObject enemyPrefab) {  // Constructor: Player gets the Position of the Block he is on
            this.posX = x;
            this.posY = y;
            this.generalHeight = height;
            this.grid = grid;
            this.enemyPrefab = enemyPrefab;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("EnemyCollision - Eaten!");
                // Restart the game if the player collides with the enemy
                // levelScript.OpenLoose();
                // PlayerCollision.GetComponent.Sceneload();
                // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

