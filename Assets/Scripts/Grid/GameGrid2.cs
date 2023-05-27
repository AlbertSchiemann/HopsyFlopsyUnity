using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
public class GameGrid2 : MonoBehaviour
{
    // How many Block do you want in each axis
    public int heigth; // Höhe y - not changeable
    public int width; // Breite des Grid
    public int length; // Länge des Grid
    public float gridSpacesize; // Abstand zwischen Blöcken
    public float delayToSpawn;

    // Positioning, Scale, Rotation
    [HideInInspector] public Transform _transform;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    //references to other scripts
    public HydrationController hydrationController;
    public WaterGridBlock waterGridBlock;
    public GridCell gridCell;
    public GG ggScript;
    
    // Different GridBlocks
    GameObject waterGridBlockPrefab;
    GameObject gridCellPrefab;

    // see which kind of gridblock we have
    public bool isWaterGridBlock; 


    private static GameObject[,] gameGrid;
    private void Awake()
    {
        // Get Transform component attached to GameObject
        _transform = GetComponent<Transform>();
        _transform.position = position;
        _transform.eulerAngles = rotation;
        _transform.localScale = scale;
        Debug.Log("Game Grid is awake.");

        // Implement the values of the public variables of GG
        if (ggScript != null)
        {
            waterGridBlockPrefab = ggScript.waterBlockPrefab;
            gridCellPrefab = ggScript.gridCellPrefab;
            heigth = ggScript.heigth;
            width = ggScript.width;
            length = ggScript.length;
            gridSpacesize = ggScript.gridSpacesize;
            delayToSpawn = ggScript.delayToSpawn;
            position = ggScript.position;
            rotation = ggScript.rotation;
            scale = ggScript.scale;
            isWaterGridBlock = ggScript.isWaterGridBlock;
        }
        else
        {
            Debug.LogError("GG script reference not assigned to GameGrid script.");
        }
    }

    //Create the grid at game start
    void Start()
    {
        StartCoroutine (CreateGrid());
        //CreateGrid();
        Debug.Log("Game Grid starts.");
    }


    // Start of Creation of the Grid
    private IEnumerator CreateGrid()
    {
        gameGrid = new GameObject[width, length];
        Debug.Log("Create Grid starts.");

        //check if a prefab is assigned 
        if (gridCellPrefab == null)
        {
            Debug.LogError("Grid Cell Prefab not assigned");
            yield return null;
        }

        //Making of Grid
        for (int new_z = 0; new_z < length; new_z++) // Länge / Length
        {
            for (int new_y = 0; new_y < width; new_y++) //Breite / Width
            {
                Debug.Log("Making of Grid starts.");
                
                int XCoordinate = new_y + 1; // for giving a correct location-name
                int ZCoordinate = new_z + 1;

                // Calculate the position using public position values
                Vector3 cellPosition = new Vector3(position.x + new_y * gridSpacesize + gridSpacesize / 2f, 
                position.y + 0.5f, position.z + new_z * gridSpacesize + gridSpacesize / 2f);

                //new Gridspace object for each cell
                if (!isWaterGridBlock)
                    {
                        gameGrid[new_y, new_z] = Instantiate(gridCellPrefab, cellPosition, transform.parent.rotation); // 3D Vector, so height = 0 
                        gameGrid[new_y, new_z].GetComponent<GridCell>().SetPosition(new_y,new_z); // save the position in the grid cell script - i guess 
                        gameGrid[new_y, new_z].transform.parent = _transform;   // set scale, rotation, position
                        gameGrid[new_y, new_z].gameObject.name = "GridSpace (Y: " + XCoordinate.ToString() + ",Z: " + ZCoordinate.ToString() + ")"; // giving them a Location-name  
                    }
                

                if (isWaterGridBlock)
                    {
                        gameGrid[new_y, new_z] = Instantiate(waterGridBlockPrefab, cellPosition, transform.parent.rotation); // 3D Vector, so height = 0 
                        gameGrid[new_y, new_z].GetComponent<GridCell>().SetPosition(new_y,new_z); // save the position in the grid cell script - i guess 
                        gameGrid[new_y, new_z].transform.parent = _transform;   // set scale, rotation, position
                        gameGrid[new_y, new_z].gameObject.name = "GridSpace (Y: " + XCoordinate.ToString() + ",Z: " + ZCoordinate.ToString() + ")"; // giving them a Location-name 
                    }
                              

                yield return new WaitForSeconds(delayToSpawn); // Delay till next one spawns
            }
        }  
    }


    // Convert of world position to grid coordinates
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

    // Convert of grid position to world coordinates
    public Vector3 GetWorldPosFromGridPos(Vector3Int gridPos)
    {
        float x = gridPos.x * gridSpacesize;
        float y = gridPos.y * gridSpacesize;
        float z = gridPos.z * gridSpacesize;

        return new Vector3(x, z, 0); 
    }

    // These functions are useful for converting between grid coordinates and world positions, 
    // allowing you to work with positions in either coordinate system as needed.


    public GameObject GetGridCell(int x, int z)
    {
        if (gameGrid != null && x >= 0 && x < width && z >= 0 && z < length)
        {
            return gameGrid[x, z];
        }
        else
        {
            return null;
        }
    }
  
}
