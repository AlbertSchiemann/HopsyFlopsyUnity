using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGridBlock : MonoBehaviour
{
    public bool isCollidingWithWater; // Declare the variable here

    public HydrationController hydrationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hydrationController != null && !isCollidingWithWater) // Use the local variable
            {
                hydrationController.RestoreHydration();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithWater = true; // Update the local variable
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithWater = false; // Update the local variable
        }
    }
}
