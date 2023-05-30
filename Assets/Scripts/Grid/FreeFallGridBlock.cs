using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FreeFallGridBlock : MonoBehaviour
{
    public HydrationController hydrationController;
    public WaterGridBlock waterGridBlock;
    public GridCell gridCell;
    public GameGrid gameGrid;
    public FireGridBlock fireGridBlock;
    public UI_LevelScript levelScript;

    [SerializeField] private AudioClip[] _failClip;
    [SerializeField] private Animator fallingAnimator;
    

    public float Delay = 1.0f; // Delay till Scene gets reloaded

    private PlayerInstantiate playerInstantiate;

    private void Start()
    {
        playerInstantiate = PlayerInstantiate.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            Debug.Log("Player entered the wind block.");

            playerInstantiate.GetComponent<Animator>().enabled = true;

            playerInstantiate.GetComponent<Animator>().SetBool("fallingBool", true);

            Debug.Log("Player entered the wind block2.");
            
        }
    }
}
