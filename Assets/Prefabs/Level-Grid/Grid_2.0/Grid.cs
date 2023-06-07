using System;


public enum BlockType {
  Stone,
  Bridge,
  Wood,
  Water,
  Lava,
  Hole,
  Goal
}
    
public class Program {
    public static void Main() {
        SimpleGrid sg = new SimpleGrid();
        
        Frog frog = new Frog(1, 1, sg);
        
        // move down
        frog.move(0, -1);
        
        // move up
        frog.move(0, 1);
        
        // move up
        frog.move(0, 1);
        
        // move left
        frog.move(-1, 0);
        
        // move right
        frog.move(1, 0);
        
        // move right
        frog.move(1, 0);
        
        // move up
        frog.move(0, 1);
    }
    
}

public class SimpleGrid {   

    int[,] blocks;
    
    public SimpleGrid() {
        this.blocks = new int[,] {
            // y (up) ->
            {5, 5, 5, 5}, // x (right)
            {5, 1, 2, 5}, // |
            {5, 2, 2, 5}, // V
            {5, 3, 0, 6},
            {5, 5, 5, 5}
        };
        
        writeBlocks(blocks);
    }
    
    public BlockType getBlockAt(int x, int y) {
        return (BlockType) blocks[x,y];
    }
    
    static void writeBlocks(int[,] blocks) {
        for (int row = 0; row < blocks.GetLength(0); row++) {
            for (int col = 0 ; col < blocks.GetLength(1); col++) {
                Console.Write((BlockType) blocks[row, col] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

class Frog {
    int posX; 
    int posY;
    SimpleGrid grid;
    
    public Frog(int x, int y, SimpleGrid grid) {
        this.posX = x;
        this.posY = y;
        this.grid = grid;
        
        blockBelow();
    }
    
    public void move(int x, int y) {
        int nuPosX = this.posX + x;
        int nuPosY = this.posY + y;
        Console.WriteLine($"Checking Block at: { nuPosX } , { nuPosY }");
        BlockType block = this.grid.getBlockAt(nuPosX, nuPosY);
        if (block == BlockType.Hole) {
            Console.WriteLine("this is a hole! I can not move");
            blockBelow();
            return;
        } else if (block == BlockType.Goal) {
            this.posX = nuPosX;
            this.posY = nuPosY;
            blockBelow();
            Console.WriteLine("YOU WIN!");
            return;
        } else {
            this.posX = nuPosX;
            this.posY = nuPosY;
            blockBelow();
        }
        
    }
    
    void blockBelow() {
        Console.WriteLine($"Position: { this.posX } , { this.posY }");
        Console.WriteLine($"Im am on a: { grid.getBlockAt(this.posX, this.posY) } block!");
    }
}