using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
public class InputManager : MonoBehaviour
{
    GameGrid gameGrid;
    [SerializeField] private LayerMask whatIsAGridLayer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        GridCell cellMouseIsOver = IsMouseOverAGridSpace();
        if (cellMouseIsOver != null)
        {
            if (Input.GetMouseButtonDown(0))
            { 
                cellMouseIsOver.GetComponentInChildren<SpriteRenderer>().material.color = Color.green;
                Debug.Log(cellMouseIsOver.isOccupied);
            }
        }
    }
    //Returns Grid cell if mouse is over grid cell orelse returns null
    private GridCell IsMouseOverAGridSpace()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, whatIsAGridLayer))
        {
            return hitInfo.transform.GetComponent<GridCell>();

        }
        else{
            return null;
        }
    }
    
}
*/