using UnityEngine;
/*
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

    private VectorGridTransform realPointA;
    private VectorGridTransform realPointB;
    private VectorGridTransform realPointC;
    private VectorGridTransform realPointD;
    private VectorGridTransform realPointE;

    private bool movingTowardsPointA = false;
    private bool movingTowardsPointB = false;
    private bool movingTowardsPointC = false;
    private bool movingTowardsPointD = false;
    private bool movingTowardsPointE = false;
    
    public float generalHeight = 0.5f;


    void Start()
    {
        grid2dCreated = grid.getGridCreated();
        print(grid2dCreated);

        InstantiateEnemy();
        InstantiateVectors();
        //UpdateGameObjectPosition();
        movingTowardsPointB = true;
    }
/*
    private void Update()
    {
        UpdateGameObjectPosition();

        
        if(movingTowardsPointB)
        {
            MoveToNextPoint(new Vector3(realPointB.posX, realPointB.posY, realPointB.posZ));

            if (enemyPosition.posX == realPointB.posX && enemyPosition.posY == realPointB.posZ)
            {
                movingTowardsPointB = false;
                movingTowardsPointA = true;
                Debug.Log("Moving to B done");
            }
        }
        if(movingTowardsPointA)
        {
            MoveToNextPoint(new Vector3(realPointA.posX, realPointA.posY, realPointA.posZ));

            if (enemyPosition.posX == realPointA.posX && enemyPosition.posY == realPointA.posZ)
            {
                movingTowardsPointA = false;
                movingTowardsPointB = true;
                Debug.LogError("Moving to A done");
            }
        }


        Debug.Log("Update done");
    
/*
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
        */
    //}
    /*
    private void InstantiateVectors()
    {
        realPointA = new VectorGridTransform(pointA.x, pointA.y, pointA.z, grid2dCreated);
        realPointB = new VectorGridTransform(pointB.x, pointB.y, pointB.z, grid2dCreated);
        realPointC = new VectorGridTransform(pointC.x, pointC.y, pointC.z, grid2dCreated);
        realPointD = new VectorGridTransform(pointD.x, pointD.y, pointD.z, grid2dCreated);
        realPointE = new VectorGridTransform(pointE.x, pointE.y, pointE.z, grid2dCreated);

        Debug.Log("InstantiateVector - done");
    }
    private void InstantiateEnemy()
    {
        //enemyPosition = new EnemyPosition((int)realPointA.posX,(int)realPointA.posZ, grid2dCreated, enemyPrefab);
        enemyPosition = new EnemyPosition(1,1, grid2dCreated, enemyPrefab);
        Debug.Log("InstantiateEnemy - done");
    }
    private void UpdateGameObjectPosition()
    {
        //transform.position = new Vector3(enemyPosition.posX, (generalHeight > pointA.y) ? generalHeight : pointA.y, enemyPosition.posY);
        transform.position = new Vector3(enemyPosition.posX, generalHeight, enemyPosition.posY);
        Debug.Log("Updating Position");
    }

    private void MoveToNextPoint(Vector3 targetPoint)
    {
        Debug.Log("Move gets called");
        //Vector3 targetPosition = new Vector3(targetPoint.x, (generalHeight > targetPoint.y) ? generalHeight : targetPoint.y, targetPoint.z);
        // set the vector where the enemy goes to
        Vector3 targetPosition = new Vector3(targetPoint.x, generalHeight, targetPoint.z);
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
    




    public class EnemyPosition {              // when Player gets called, he gets a starting-position and the grid reference
        public int posX; 
        public int posY;
        private Grid2DCreated grid;
        private GameObject enemyPrefab; // Reference to the player GameObject
        private GameObject enemy; // Reference to the player GameObject
        public EnemyPosition(int x,int y, Grid2DCreated grid, GameObject enemyPrefab) {  // Constructor: Player gets the Position of the Block he is on
            this.posX = x;
            this.posY = y;
            this.grid = grid;
            this.enemyPrefab = enemyPrefab;
            Debug.Log("EnemyPosition - Constructor done");
        }
    }

    public class VectorGridTransform {
        public float posX; 
        public float posY;
        public float posZ;
        private Grid2DCreated grid;

        public VectorGridTransform (float x,float height,float y, Grid2DCreated grid) {  // Constructor: Player gets the Position of the Block he is on
            this.posX = x;
            this.posY = height;
            this.posZ = y;
            this.grid = grid;
            Debug.Log("VectorGridTransform - Constructor done");
        }

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

*/