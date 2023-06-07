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
    public static void Start() {
        Grid2DCreated sg = new Grid2DCreated();
        
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
    }
    
}

public class Grid2DCreated {   

    int[,] blocks;
    
    public Grid2DCreated() {
        this.blocks = new int[,] {
                // y (up) ->
            //{5, 5, 5, 5}, // x (right)
            //{5, 1, 2, 5}, // |
            //{5, 2, 2, 5}, // V
            //{5, 3, 0, 6},
            //{5, 5, 5, 5}

            {1,  1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1},      // ---------------------------------  // surrounded by walls
            {1, 10, 0, 7, 8, 8, 8, 1,  5, 5, 0, 7, 1},      // | R   FB  A  A  A  |  W  W   FB |  // 2 ways
            {1,  4, 0, 6, 2, 2, 2, 4, 10, 4, 0, 6, 1},      // | W    F  B  B  B  W  R  W    F |  // R-Respawn, -normal, F-Fire, FB-Blocking Fire, A-Air  
            {1,  0, 0, 0, 2, 3, 2, 5,  4, 5, 1, 0, 1},      // |         B BB  B WB  W WB -    |  // B-Bridge,BB-Blocked Bridge, W-Water, WB-Blocking Water
            {1,  0, 1, 1, 8, 8, 8, 8,  1, 1, 0, 6, 1},      // |   -  -  A  A  A  A  -  -    F |  // G-Goal
            {1,  0, 4, 4, 0, 6, 6, 6,  6, 0, 0, 6, 1},      // |   W  W     F  F  F  F       F |
            {1,  4, 4, 5, 6, 6, 7, 7,  1, 4, 0, 9, 1},      // | W W WB  F  F FB FB  |  W    G |
            {1,  1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1}       // ---------------------------------
        };
        
        writeBlocks(blocks);
    }
    
    public GridBlockTypeToChoose getBlockAt(int x, int y) {
        return (GridBlockTypeToChoose) blocks[x,y];
    }
    
    static void writeBlocks(int[,] blocks) {
        for (int row = 0; row < blocks.GetLength(0); row++) {
            for (int col = 0 ; col < blocks.GetLength(1); col++) {
                Debug.Log((GridBlockTypeToChoose) blocks[row, col] + " ");
            }
            Debug.Log("1");
        }
        Debug.Log("2");
    }
}

class PlayerFish {
    int posX; 
    int posY;
    Grid2DCreated grid;
    
    public PlayerFish(int x, int y, Grid2DCreated grid) {
        this.posX = x;
        this.posY = y;
        this.grid = grid;
        
        blockBelow();
    }
    
    public void move(int x, int y) {
        int nuPosX = this.posX + x;
        int nuPosY = this.posY + y;
        Debug.Log($"Checking Block at: { nuPosX } , { nuPosY }");
        GridBlockTypeToChoose block = this.grid.getBlockAt(nuPosX, nuPosY);

        
        if (block == GridBlockTypeToChoose.NormalBlock){
            this.posX = nuPosX;
            this.posY = nuPosY;
            Debug.Log("It feels pretty normal here!");
            blockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.NormalBlockBlocked){
            Debug.Log("There is a blocking Object here!");
            blockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.Bridge){
            this.posX = nuPosX;
            this.posY = nuPosY;
            Debug.Log("Its getting shaky - Bridgeblock!");
            blockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.BridgeBlocked){
            Debug.Log("There is a blocking Object on the Bridge!");
            blockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.Water){
            this.posX = nuPosX;
            this.posY = nuPosY;
            Debug.Log("Its getting nice and wet in here - Waterblock!");
            blockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.WaterBlocked){
            Debug.Log("There is a blocking Object in the Water!");
            blockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.Fire){
            this.posX = nuPosX;
            this.posY = nuPosY;
            Debug.Log("Its getting hot in here - Fireblock!");
            blockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.FireBlocked){
            Debug.Log("There is a blocking Object in the Fire!");
            blockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.FreeFall) {
            Debug.Log("I should fall down rigth now!");
            blockBelow();
            return;
        } else if (block == GridBlockTypeToChoose.Goal) {
            this.posX = nuPosX;
            this.posY = nuPosY;
            blockBelow();
            Debug.Log("YOU WIN! - Goalblock!");
            return;
        } else if (block == GridBlockTypeToChoose.Respawn){
            this.posX = nuPosX;
            this.posY = nuPosY;
            Debug.Log("I could respawn here!");
            Debug.Log("Its also wet in here!");
            blockBelow();
            return;
        } else {
            Debug.LogError("Not a gridBlock!");
        }
        
    }
    public void moveLeft () {
        int x = -1;
        int y = 0;
        move(x, y);

    }
    public void moveRight () {
        int x = 1;
        int y = 0;
        move(x, y);
    }
    public void moveUp () {
        int x = 0;
        int y = 1;
        move(x, y);
    }
    public void moveDown () {
        int x = 0;
        int y = -1;
        move(x, y);
    }


    void blockBelow() {
        Debug.Log($"Position: { this.posX } , { this.posY }");
        Debug.Log($"Im on a: { grid.getBlockAt(this.posX, this.posY) } block!");
    }
}