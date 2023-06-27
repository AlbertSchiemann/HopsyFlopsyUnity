using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGridBlock : MonoBehaviour
{
    // This script is just working as a trigger for the HydrationController script
    // and updates it if the player is colliding with the fire block or not

    [SerializeField] private AudioClip[] _sizzleClip;
    public HydrationController hydrationController;         // Reference to the HydrationController of the level
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
            hydrationController.isCollidingWithFire = true;
            SoundManager.Instance.PlaySound(_sizzleClip);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hydrationController.isCollidingWithFire = true;     // Update the variable in hydrationController
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hydrationController.isCollidingWithFire = false;
            SoundManager.Instance.StopSound(_sizzleClip);
        }
    }
}
