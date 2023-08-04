using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skateboard : MonoBehaviour
{
    private PowerUp_Manager powerUpManager;
    private PlayerInstantiate playerInstantiate; 

    void Start()
    {
        playerInstantiate = PlayerInstantiate.Instance;
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUp_Manager>();
    }

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
