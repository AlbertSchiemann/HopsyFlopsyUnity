using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private static int heigth = 1; // Höhe y - not changeable
    public static int width = 10; // Breite des Grid
    public static int length = 10; // Länge des Grid
    private static float gridSpacesize = 0.5f; // Abstand zwischen Blöcken

    [SerializeField] private GameObject gridCellPrefab;
    private static GameObject[,] gameGrid;

    //Create the grid at game start
    void Start()
    {
        StartCoroutine (CreateGrid());
    }

    private IEnumerator CreateGrid()
    {
        gameGrid = new GameObject[width, length];

        //check if a gridblock is assigned 
        if (gridCellPrefab == null)
        {
            Debug.LogError("Grid Cell Prefab not assigned");
            yield return null;
        }

        //Making of Grid
        for (int new_y = 0; new_y < width; new_y++) //Breite
        {
            for (int new_z = 0; new_z < length; new_z++) // Länge
            {
                int XCoordinate = new_y + 1; // for giving a correct location-name
                int ZCoordinate = new_z + 1;

                //new Gridspace object for each cell
                gameGrid[new_y, new_z] = Instantiate(gridCellPrefab, 
                    new Vector3(new_y* gridSpacesize, 0, new_z * gridSpacesize), Quaternion.identity); // 3D Vector, so hight = 0 
                gameGrid[new_y, new_z].GetComponent<GridCell>().SetPosition(new_y,new_z); // no idea
                gameGrid[new_y, new_z].transform.parent = transform;   // no idea
                gameGrid[new_y, new_z].gameObject.name = "GridSpace (Y: " + XCoordinate.ToString() + ",Z: " + ZCoordinate.ToString() + ")"; // giving them a Location-name
            
                yield return new WaitForSeconds(.02f); // Delay till next one spawns
                // Debug.Log("Gridblock created!"); 
            
            }
        }

    }

     public Vector2Int GetGridPosFromWorld(Vector3 worldPosition)
    {
        int supernew_x = Mathf.FloorToInt(worldPosition.x / gridSpacesize);
        int supernew_y = Mathf.FloorToInt(worldPosition.y / gridSpacesize);
        int supernew_z = Mathf.FloorToInt(worldPosition.z / gridSpacesize);


        supernew_x = Mathf.Clamp(supernew_x, 0, width);
        supernew_y = Mathf.Clamp(supernew_y, 0, heigth);
        supernew_z = Mathf.Clamp(supernew_z, 0, length);

        return new Vector2Int(supernew_x, supernew_z);


    }
    public Vector3 GetWorldPosFromGridPos(Vector3Int gridPos)
    {
        float x = gridPos.x * gridSpacesize;
        float y = gridPos.y * gridSpacesize;
        float z = gridPos.z * gridSpacesize;

        return new Vector3(x, z, 0); 
    }
    




}
