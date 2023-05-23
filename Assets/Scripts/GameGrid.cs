using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{

    // How many Block do you want in each axis
    private static int heigth = 1; // Höhe y - not changeable
    public  int width = 10; // Breite des Grid
    public  int length = 10; // Länge des Grid
    public float gridSpacesize = .5f; 
    public float delayToSpawn = .01f;

    // Abstand zwischen Blöcken



    // Animation        - doesnt work
    // private Animator GridCubeAnimate;

    // [SerializeField] bool AnimationOn = true;


    // Positioning, Scale, Rotation
    private Transform _transform;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    
    private void Awake()
    {
        // Get Transform component attached to GameObject
        _transform = GetComponent<Transform>();
        _transform.position = position;
        _transform.eulerAngles = rotation;
        _transform.localScale = scale;
    }
    

    // Use the assigned Gameobject to copy from
    [SerializeField] private GameObject gridCellPrefab;
    private static GameObject[,] gameGrid;



    //Create the grid at game start
    void Start()
    {
        StartCoroutine (CreateGrid());
    }



    // Start of Creation of the Grid
    private IEnumerator CreateGrid()
    {
        gameGrid = new GameObject[width, length];

        //check if a prefab is assigned 
        if (gridCellPrefab == null)
        {
            Debug.LogError("Grid Cell Prefab not assigned");
            yield return null;
        }


        //Making of Grid
        for (int new_z = 0; new_z < length; new_z++) // Länge
{
            for (int new_y = 0; new_y < width; new_y++) //Breite
            {
                int XCoordinate = new_y + 1; // for giving a correct location-name
                int ZCoordinate = new_z + 1;

                // Calculate the position using public position values
                Vector3 cellPosition = new Vector3(position.x + new_y * gridSpacesize + gridSpacesize / 2f, 
                position.y + 0.5f, position.z + new_z * gridSpacesize + gridSpacesize / 2f);

                //new Gridspace object for each cell
                gameGrid[new_y, new_z] = Instantiate(gridCellPrefab, cellPosition, transform.parent.rotation); // 3D Vector, so height = 0 
                gameGrid[new_y, new_z].GetComponent<GridCell>().SetPosition(new_y,new_z); // save the position in the grid cell script - i guess 
                gameGrid[new_y, new_z].transform.parent = _transform;   // set scale, rotation, position
                gameGrid[new_y, new_z].gameObject.name = "GridSpace (Y: " + XCoordinate.ToString() + ",Z: " + ZCoordinate.ToString() + ")"; // giving them a Location-name


                /*
                if (GridCubeAnimate != null && AnimationOn == true)  // Animation for created gridblocks, with the ability to not animate
                {
                    Animator animator = gameGrid[new_y, new_z].AddComponent<Animator>();
                    animator.runtimeAnimatorController = GridCubeAnimate.runtimeAnimatorController; ;
                }
                */
                

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
  
}
