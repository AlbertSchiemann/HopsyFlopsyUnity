using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    private int posX;

    private int posY;
    private int posZ;

    public GameObject objectInThisGridSpace = null;

    public bool isOccupied = false;

    public void SetPosition(int x, int y, int z)
    {
        posX = x;
        posY = y;
        posZ = z;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
