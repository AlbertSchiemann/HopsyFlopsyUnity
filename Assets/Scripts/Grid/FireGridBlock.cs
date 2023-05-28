using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGridBlock : MonoBehaviour
{
    
    public HydrationController hydrationController;
    public WaterGridBlock waterGridBlock;
    public GridCell gridCell;
    public GameGrid gameGrid;
    public FreeFallGridBlock freeFallGridBlock;
    
     // Reference to HydrationController script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Fireblock1");
            
            //Invoke("UpdateCollidingWithFire", 0.1f);
            hydrationController.isCollidingWithFire = true;
            //SoundManager.Instance.PlaySound(_hydrateClip);
            Debug.Log("Player entered the fire block.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Invoke("UpdateCollidingWithFire", 0.1f);
            hydrationController.isCollidingWithFire = true; // Update the local variable
            Debug.Log("Fireblock2");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Invoke("UpdateNotCollidingWithFire", 0.1f);
            hydrationController.isCollidingWithFire = false; // Update the local variable
            Debug.Log("Player left the fire block.");
            //Debug.Log("Fireblock3");
        }
    }

    private void UpdateNotCollidingWithFire()
    {
        hydrationController.isCollidingWithFire = false;
        //Debug.Log("Player left the fire block.");
    }
    private void UpdateCollidingWithFire()
    {
        hydrationController.isCollidingWithFire = true;
        //Debug.Log("Player is in the fire block.");
    }
}
