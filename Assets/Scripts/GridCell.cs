using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    private int posX;
    private int posY;

    public GameObject objectInThisGridSpace = null;

    public bool isOccupied = false;

    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
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
