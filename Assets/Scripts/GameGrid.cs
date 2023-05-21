using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private int heigth = 10;
    private int width = 10;
    private float gridSpacesize = 1f;

    [SerializeField] private GameObject gridCellPrefab;
    private static GameObject[,] gameGrid;

    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        gameGrid = new GameObject[heigth, width];

        if (gridCellPrefab == null)
        {
            Debug.LogError("Grid Cell Prefab not assigned");
            return;
        }

    //Making of Grid
    for (int y = 0; y < heigth; y++)
        {
            for (int x= 0; x < width; x++)
            {
                //new Gridspace object for each cell
                gameGrid[x,y] = Instantiate(gridCellPrefab, new Vector3(x* gridSpacesize, y * gridSpacesize), Quaternion.identity);
                gameGrid[x,y].GetComponent<GridCell>().SetPosition(x,y);
                gameGrid[x, y].transform.parent = transform;
                gameGrid[x, y].gameObject.name = "GridSpace ( X: " + x.ToString() + " , Y: " + y.ToString() + ")";
            }
        }

    }

    public Vector2Int GetGridPosFromWorld(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / gridSpacesize);
        int y = Mathf.FloorToInt(worldPosition.z / gridSpacesize);


        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(x, 0, heigth);

        return new Vector2Int(x,y);


    }
    public Vector3 GetGridPosFromPos(Vector2Int gridPos)
    {
        float x = gridPos.x * gridSpacesize;
        float y = gridPos.y * gridSpacesize;

        return new Vector3(x, 0, y); 
    }




}
