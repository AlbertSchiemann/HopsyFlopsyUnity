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
    [SerializeField] public GameObject player;

    public float Delay = 1.0f; // Delay till Scene gets reloaded

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            Debug.Log("Player entered the wind block.");

            player.GetComponent<Animator>().enabled = true;
            
            fallingAnimator.SetBool("FreeFallBool", true);
            
            Debug.Log("Player entered the wind block2.");
            
        }
    }
}
