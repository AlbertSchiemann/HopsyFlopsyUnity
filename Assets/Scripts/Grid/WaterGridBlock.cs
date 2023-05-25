using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGridBlock : MonoBehaviour
{
    
    [SerializeField] private AudioClip[] _hydrateClip;
    public HydrationController hydrationController; // Reference to HydrationController script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hydrationController.isCollidingWithWater = true;
            //SoundManager.Instance.PlaySound(_hydrateClip);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hydrationController.isCollidingWithWater = true; // Update the local variable
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hydrationController.isCollidingWithWater = false; // Update the local variable
        }
    }
}
