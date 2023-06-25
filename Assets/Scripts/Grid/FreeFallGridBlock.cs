using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FreeFallGridBlock : MonoBehaviour
{
    // This script is just calling the animator of the playerprefab

    public UI_LevelScript levelScript;
    

    [SerializeField] private AudioClip[] _failClip;         // Sound if the player falls into the abyss
    [SerializeField] private Animator fallingAnimator;      // Animator of the playerprefab that shall be triggered
    

    public float Delay = 1.0f;                              // Delay till Scene gets reloaded

    private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player

    private void Start()
    {
        playerInstantiate = PlayerInstantiate.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            // Debug.Log("Player entered the wind block.");

            playerInstantiate.GetComponent<Animator>().enabled = true;

            playerInstantiate.GetComponent<Animator>().SetBool("fallingBool", true);

            // Debug.Log("Player entered the wind block2.");
            
        }
    }
}
