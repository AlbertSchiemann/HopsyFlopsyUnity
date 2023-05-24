using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// completely used to store information of the gridcell in each gameobject itself

public class GridCell : MonoBehaviour
{
    private int posX;
    private int posY;
    private int posZ;

    public GameObject objectInThisGridSpace = null;

    public bool isOccupied = false;

    public void SetPosition(int y, int z)
    {
        
        posY = y;
        posZ = z;
    }
}
