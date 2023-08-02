using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skateboard : MonoBehaviour
{
    [SerializeField] PowerUpManager powerUpManager;
    private PlayerInstantiate playerInstantiate; 

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Skateboard triggered");
            


            Destroy(gameObject);

            powerUpManager.Skateboard();
        }
    }
}
