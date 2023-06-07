using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GridBlockTypeToChoose {
    NormalBlock,        //0
    NormalBlockBlocked, //1
    Bridge,             //2
    BridgeBlocked,      //3
    Water,              //4
    WaterBlocked,       //5
    Fire,               //6
    FireBlocked,        //7
    FreeFall,           //8
    Goal,               //9
    Respawn             //10
}
    
public class Grid : MonoBehaviour{

    [SerializeField] public GameObject NormalBlockPrefab;
    [SerializeField] public GameObject NormalBlockBlockedPrefab;
    [SerializeField] public GameObject BridgePrefab;
    [SerializeField] public GameObject BridgeBlockedPrefab;
    [SerializeField] public GameObject WaterPrefab;
    [SerializeField] public GameObject WaterBlockedPrefab;
    [SerializeField] public GameObject FirePrefab;
    [SerializeField] public GameObject FireBlockedPrefab;
    [SerializeField] public GameObject FreeFallPrefab;
    [SerializeField] public GameObject GoalPrefab;
    [SerializeField] public GameObject RespawnPrefab;

    //public int Length;
    //public int Width;

    public void Start() {
        Grid2DCreated sg = ScriptableObject.CreateInstance<Grid2DCreated>();
        sg.Initialize(this);
        PlayerFish playerFish = new PlayerFish(1, 1, sg);
        
        
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

        if (NormalBlockPrefab == null){
            Debug.LogError("No NormalBlockPrefab assigned!");
        }
        if (NormalBlockBlockedPrefab == null) {
            Debug.LogError("No NormalBlockBlockedPrefab assigned!");
        }
        if (BridgePrefab == null) {
            Debug.LogError("No BridgePrefab assigned!");
        }
        if (BridgeBlockedPrefab == null) {
            Debug.LogError("No BridgeBlockedPrefab assigned!");
        }
        if (WaterPrefab == null) {
            Debug.LogError("No WaterPrefab assigned!");
        }
        if (WaterBlockedPrefab == null) {
            Debug.LogError("No WaterBlockedPrefab assigned!");
        }
        if (FirePrefab == null) {
            Debug.LogError("No FirePrefab assigned!");
        }
        if (FireBlockedPrefab == null) {
            Debug.LogError("No FireBlockedPrefab assigned!");
        }
        if (FreeFallPrefab == null) {
            Debug.LogError("No FreeFallPrefab assigned!");
        }
        if (GoalPrefab == null) {
            Debug.LogError("No GoalPrefab assigned!");
        }
        if (RespawnPrefab == null) {
            Debug.LogError("No RespawnPrefab assigned!");
        }

    }
    
}

public class Grid2DCreated : ScriptableObject  {   

    int[,] blocks;      // Int Array for the Grid
    GameObject[] prefabs;   // Array for the Prefabs

    public void Initialize(Grid grid) {
        blocks = new int[,] {
                // y (up) ->
            //{5, 5, 5, 5}, // x (right)
            //{5, 1, 2, 5}, // |
            //{5, 2, 2, 5}, // V
            //{5, 3, 0, 6},
            //{5, 5, 5, 5}

            {1,  1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1},      // ---------------------------------  // surrounded by walls
            {1, 10, 0, 7, 8, 8, 8, 1,  5, 5, 0, 7, 1},      // | R   FB  A  A  A  -  W  W   FB |  // 2 ways
            {1,  4, 0, 6, 2, 2, 2, 4, 10, 4, 0, 6, 1},      // | W    F  B  B  B  W  R  W    F |  // R-Respawn, -normal, F-Fire, FB-Blocking Fire, A-Air  
            {1,  0, 0, 0, 2, 3, 2, 5,  4, 5, 1, 0, 1},      // |         B BB  B WB  W WB -    |  // B-Bridge,BB-Blocked Bridge, W-Water, WB-Blocking Water
            {1,  0, 1, 1, 8, 8, 8, 8,  1, 1, 0, 6, 1},      // |   -  -  A  A  A  A  -  -    F |  // G-Goal
            {1,  0, 4, 4, 0, 6, 6, 6,  6, 0, 0, 6, 1},      // |   W  W     F  F  F  F       F |
            {1,  4, 4, 5, 6, 6, 7, 7,  1, 4, 0, 9, 1},      // | W W WB  F  F FB FB  -  W    G |
            {1,  1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1}       // ---------------------------------
        };
        
        prefabs = new GameObject[] {
            grid.NormalBlockPrefab,          //  0
            grid.NormalBlockBlockedPrefab,   //  1
            grid.BridgePrefab,               //  2
            grid.BridgeBlockedPrefab,        //  3
            grid.WaterPrefab,                //  4
            grid.WaterBlockedPrefab,         //  5
            grid.FirePrefab,                 //  6
            grid.FireBlockedPrefab,          //  7
            grid.FreeFallPrefab,             //  8
            grid.GoalPrefab,                 //  9
            grid.RespawnPrefab               // 10
        };

        WriteBlocks();
    }

    
    
    public GridBlockTypeToChoose getBlockAt(int x, int y) {
        return (GridBlockTypeToChoose) blocks[x,y];
    }
    
    /*static void writeBlocks(int[,] blocks) {
        for (int row = 0; row < blocks.GetLength(0); row++) {
            for (int col = 0 ; col < blocks.GetLength(1); col++) {
                Debug.Log((GridBlockTypeToChoose) blocks[row, col] + " ");
            }
            Debug.Log("1");
        }
        Debug.Log("2");
    } */
    void WriteBlocks() 
    {
        //Length = blocks.GetLength(0);
        //Width = blocks.GetLength(1);
        int numRows = blocks.GetLength(0);
        int numCols = blocks.GetLength(1);
        float blockSize = .5f;

        for (int row = 0; row < numRows; row++) 
        {
            for (int col = 0; col < numCols; col++) 
            {
                int blockValue = blocks[row, col];                                                   // asking for the size of each direction
                GridBlockTypeToChoose blockType = (GridBlockTypeToChoose)blockValue;                 // asking for the type of the block
                GameObject prefab = prefabs[blockValue];                                             // asking for the prefab in the spot

                // Instantiate the prefab at the corresponding position
                Vector3 position = new Vector3(col * blockSize, 0 ,(numRows - 1 - row) * blockSize); // managing the blocksize of .5 and the grid beeing bottom up
                Instantiate(prefab, position, Quaternion.identity);                                  // Create(what to create, where to create, in what size/rotation)
            }
        }
    }
}

class PlayerFish {              // when Player gets called, he gets a starting-position and the grid reference
    int posX; 
    int posY;
    Grid2DCreated grid;
    
    public PlayerFish(int x, int y, Grid2DCreated grid) {  // Constructor: Player gets the Position of the Block he is on
        this.posX = x;  
        this.posY = y;
        this.grid = grid;
        
        checkBlockBelow();   // Console Output for the current Block
    }
    
    public void Move(int x, int y) {
        int nuPosX = this.posX + x;
        int nuPosY = this.posY + y;
        Debug.Log($"Checking Block at: { nuPosX } , { nuPosY }");
        GridBlockTypeToChoose block = this.grid.getBlockAt(nuPosX, nuPosY);

        
        if (block == GridBlockTypeToChoose.NormalBlock){
            this.posX = nuPosX;
            this.posY = nuPosY;
            Debug.Log("It feels pretty normal here!");
            checkBlockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.NormalBlockBlocked){
            Debug.Log("There is a blocking Object here!");
            checkBlockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.Bridge){
            this.posX = nuPosX;
            this.posY = nuPosY;
            Debug.Log("Its getting shaky - Bridgeblock!");
            checkBlockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.BridgeBlocked){
            Debug.Log("There is a blocking Object on the Bridge!");
            checkBlockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.Water){
            this.posX = nuPosX;
            this.posY = nuPosY;
            Debug.Log("Its getting nice and wet in here - Waterblock!");
            checkBlockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.WaterBlocked){
            Debug.Log("There is a blocking Object in the Water!");
            checkBlockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.Fire){
            this.posX = nuPosX;
            this.posY = nuPosY;
            Debug.Log("Its getting hot in here - Fireblock!");
            checkBlockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.FireBlocked){
            Debug.Log("There is a blocking Object in the Fire!");
            checkBlockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.FreeFall) {
            Debug.Log("I should fall down rigth now!");
            checkBlockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.Goal) {
            this.posX = nuPosX;
            this.posY = nuPosY;
            checkBlockBelow();
            Debug.Log("YOU WIN! - Goalblock!");
            return;
        } else if (block == GridBlockTypeToChoose.Respawn){
            this.posX = nuPosX;
            this.posY = nuPosY;
            Debug.Log("I could respawn here!");
            Debug.Log("Its also wet in here!");
            checkBlockBelow();
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
    public void moveUp () {
        int x = 0;
        int y = 1;
        Move(x, y);
    }
    public void moveDown () {
        int x = 0;
        int y = -1;
        Move(x, y);
    }


    void checkBlockBelow() {
        Debug.Log($"Position: { this.posX } , { this.posY }");
        Debug.Log($"Im on a: { grid.getBlockAt(this.posX, this.posY) } block!");
    }
}