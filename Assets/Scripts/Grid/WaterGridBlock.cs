using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGridBlock : MonoBehaviour
{
    // script is just working with the HydrationController 
    // and updates it if the player is colliding with the water block or not


    [SerializeField] private AudioClip[] _hydrateClip;
    public HydrationController hydrationController;         // Reference to the levels HydrationController 
    private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player


    private void Start()
    {
        hydrationController = HydrationController.Instance;
        playerInstantiate = PlayerInstantiate.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hydrationController.isCollidingWithWater = true;

            // SoundManager.Instance.PlaySound(_hydrateClip);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hydrationController.isCollidingWithWater = true; // Update the local variable

            // Sound missing
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hydrationController.isCollidingWithWater = false; // Update the local variable
            //Debug.Log("Player left the water block.");
        }
    }
}
