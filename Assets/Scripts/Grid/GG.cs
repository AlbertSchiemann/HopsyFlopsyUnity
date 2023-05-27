using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG : MonoBehaviour
{
    
    [HideInInspector] public GameGrid gameGrid;
    
    // How many Block do you want in each axis
    [HideInInspector] public int heigth = 1; // Höhe y - not changeable
    public int width = 10; // Breite des Grid
    public int length = 10; // Länge des Grid
    [HideInInspector] public float gridSpacesize = .5f; // Abstand zwischen Blöcken
    [HideInInspector] public float delayToSpawn = .01f;

    // Positioning, Scale, Rotation
    [HideInInspector] public Transform _transform;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    // Different GridBlocks
    public HydrationController hydrationController;
    public WaterGridBlock waterGridBlock;
    public GridCell gridCell;

    [HideInInspector] public bool isWaterGridBlock = false; // see if the Gridblock is also a WaterGridBlock

    [SerializeField] public GameObject waterBlockPrefab;
    
    // Use the assigned Gameobject to copy from
    [SerializeField] public GameObject gridCellPrefab;
}
