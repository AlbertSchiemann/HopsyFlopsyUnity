using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public int heigth = 10; // Höhe y
    public int width = 10; // Breite x
    public int length = 10; // Länge z
    public float gridSpacesize =      /*5f;*/  0.5f;

    [SerializeField] private GameObject gridCellPrefab;
    private static GameObject[,,] gameGrid;

    //Created the grid at game start
    void Start()
    {
        StartCoroutine (CreateGrid());
    }

    private IEnumerator CreateGrid()
    {
        gameGrid = new GameObject[heigth, width, length];

        if (gridCellPrefab == null)
        {
            Debug.LogError("Grid Cell Prefab not assigned");
            yield return null;
        }

    //Making of Grid
    for (int new_x= 0; new_x < 1; new_x++)
        {
            for (int new_y= 0; new_y < 1; new_y++)
            {
                for (int new_z = 0; new_z < 1; new_z++)
                {
                    //new Gridspace object for each cell
                    gameGrid[new_x, new_y, new_z] = Instantiate(gridCellPrefab, new Vector3(new_x* gridSpacesize, new_y* gridSpacesize, new_z * gridSpacesize), Quaternion.identity);
                    gameGrid[new_x, new_y, new_z].GetComponent<GridCell>().SetPosition(new_x,new_y,new_z);
                    gameGrid[new_x, new_y, new_z].transform.parent = transform;
                    gameGrid[new_x, new_y, new_z].gameObject.name = "GridSpace ( X: " + new_x.ToString() + ",  Y: " + new_y.ToString() + ",Z: " + new_z.ToString() + ")";
                
                    yield return new WaitForSeconds(.02f); // Delay till next one spawns
                }
            }
        }

    }

    /*public Vector2Int GetGridPosFromWorld(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / gridSpacesize);
        int y = Mathf.FloorToInt(worldPosition.y / gridSpacesize);
        int z = Mathf.FloorToInt(worldPosition.z / gridSpacesize);


        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(x, 0, heigth);
        z = Mathf.Clamp(x, 0, length);

        return new Vector2Int(x, z);


    }
    public Vector3 GetWorldPosFromGridPos(Vector3Int gridPos)
    {
        float x = gridPos.x * gridSpacesize;
        float y = gridPos.y * gridSpacesize;
        float z = gridPos.z * gridSpacesize;

        return new Vector3(x, z, 0); 
    }
    */




}
