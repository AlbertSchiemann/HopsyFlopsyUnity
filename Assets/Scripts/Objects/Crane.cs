using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject cranePrefab;
    private Grid2DCreated grid2dCreated;                // Insert the grid of the Level
    [SerializeField] private Grid grid;
    [SerializeField] private AudioClip[] _craneclip;         // cranesound

    [SerializeField] private float animationSpeed = 1f;            // speed of the craneanimation
    [SerializeField] private Vector3 GridPositionOfPlayerAfterAnimation;
    [SerializeField] private Vector3 GridPositionOfPlayerBeforeAnimation;     
        
    
    public class PlayerPosition {                           // when the Player gets called, he gets a starting-position on the grid 
        public int posX; 
        public int posY;
        public float posZ;
        private Grid2DCreated grid;
        private GameObject playerPrefab;
        public PlayerPosition(int x, float z, int y, Grid2DCreated grid, GameObject playerPrefab)  // Constructor: Player gets the Position of the Block he is on saved in posX and posY for the next move
        {  
            this.posX = x;
            this.posY = y;
            this.posZ = z;
            this.grid = grid;
            this.playerPrefab = playerPrefab;
        }
    }
    private GameObject startBox;
    private GameObject endBox;

    void start ()
    {
        grid2dCreated = grid.getGridCreated();

        //startBox = cranePrefab.GetComponent<GameObject>().StartBox; // Get reference to the StartBox component
        //endBox = cranePrefab.GetComponent<GameObject>().EndBox; // Get reference to the EndBox
    }

    // craneprefab.GetComponent<StartBox>().OnTriggerEnter();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<GridPlayerMovement>().PreventMovement();
            SaveGridPositionOfPlayer();
            // SoundManager.Instance.PlaySound(Crane);
                        // Start of crane animation
            cranePrefab.GetComponent<Animator>().enabled = true;
            cranePrefab.GetComponent<Animator>().SetBool("moving", true);
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<Animator>().SetBool("moving", true);

            Invoke("GridpositionAfterAnimation", animationSpeed);

        }
    }

    // craneprefab.GetComponent<EndBox>().OnTriggerEnter();
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<GridPlayerMovement>().AllowMovement();
        }
    }

    private void SaveGridPositionOfPlayer()
    {
        PlayerPosition playerPosition = new PlayerPosition((int)GridPositionOfPlayerBeforeAnimation.x, GridPositionOfPlayerBeforeAnimation.y, (int)GridPositionOfPlayerBeforeAnimation.z, grid2dCreated, playerPrefab);
    }

    private void GridpositionAfterAnimation()
    {
        transform.position = new Vector3(GridPositionOfPlayerAfterAnimation.x, GridPositionOfPlayerAfterAnimation.y, GridPositionOfPlayerAfterAnimation.z);
    }
}


// laut Heiko:
// Animator bauen in unity der den Player transformed
// Gridposition nach der Animation festlegen und player dort hinsetzen

// Gridposition vor animation als input optional