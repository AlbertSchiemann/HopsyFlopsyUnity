using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerMovement : MonoBehaviour
{
    private Grid2DCreated grid;
    private PlayerPosition player;

    void Start()
    {
        grid = FindObjectOfType<Grid2DCreated>(); // Find the existing Grid2DCreated instance
        //grid = ScriptableObject.CreateInstance<Grid2DCreated>();
        //grid.Initialize(this); // Pass the current instance of GridPlayerMovement to the Initialize method


        player = new PlayerPosition(1, 1, grid);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            player.Move(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            player.Move(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            player.Move(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            player.Move(1, 0);
        }

        UpdateGameObjectPosition();
    }

    private void UpdateGameObjectPosition()
    {
        transform.position = new Vector3(player.posX, 0, player.posY);
    }

    public class PlayerPosition {              // when Player gets called, he gets a starting-position and the grid reference
        public int posX; 
        public int posY;
        Grid2DCreated grid;
        
        public PlayerPosition(int x, int y, Grid2DCreated grid) {  // Constructor: Player gets the Position of the Block he is on
            this.posX = x;  
            this.posY = y;
            this.grid = grid;
            
            CheckBlockBelow();   // Console Output for the current Block
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
                CheckBlockBelow();
            }
            else
            {
                Debug.Log($"Invalid move to block at: {newPosX}, {newPosY}");
            }
        }
        
        /*
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
        */

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


        private void CheckBlockBelow() {
            Debug.Log($"Position: {this.posX}, {this.posY}");
            Debug.Log($"Im on a: { grid.getBlockAt(this.posX, this.posY)} block!");
        }
    
        private bool IsValidMove(int x, int y)
        {
            int numRows = grid.blocks.GetLength(0);
            int numCols = grid.blocks.GetLength(1);

            if (x >= 0 && x < numCols && y >= 0 && y < numRows)
            {
                GridBlockTypeToChoose blockType = grid.getBlockAt(x, y);
                return blockType != GridBlockTypeToChoose.NormalBlockBlocked &&
                    blockType != GridBlockTypeToChoose.BridgeBlocked;
            }

            return false;

        }
    }
}
    
//todo: gameobject reference to the "player"- in script is not  working
