using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// completely used to store information of the gridcell in each gameobject itself

public class GridCell : MonoBehaviour
{
    private int posX;
    private int posY;
    private int posZ;

    public HydrationController hydrationController;
    public WaterGridBlock waterGridBlock;
    public GridCell gridCell;
    public GameGrid gameGrid;

    public GameObject objectInThisGridSpace; // variable can be used to reference any object that occupies the grid cell. It can be set to null if the cell is empty

    public bool isOccupied = false; // variable indicates whether the grid cell is currently occupied by an object
    
    public void SetPosition(int yy, int zz)
    {
        posY = yy;
        posZ = zz;
        
    }

    private void Awake()
    {
        
        if (objectInThisGridSpace!=null)
        {
            isOccupied = true;
        }
    }
}
