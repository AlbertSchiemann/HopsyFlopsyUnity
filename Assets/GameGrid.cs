using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private int heigth = 10;
    private int width = 10;
    private float GridSpacesize = 1f;

    [SerializeField] private GameObject gridCellPrefab;
    private GameObject[,] gameGrid;

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
            gameGrid[x,y] = Instantiate(gridCellPrefab, new Vector3(x* GridSpacesize, y * GridSpacesize), Quaternion.identity);
            gameGrid[x, y].transform.parent = transform;
            gameGrid[x, y].gameObject.name = "GridSpace ( X: " + x.ToString() + " , Y: " + y.ToString() + ")";
        }
    }

    }





}
