using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skateboard : MonoBehaviour
{
    private PowerUpManager powerUpManager;
    private PlayerInstantiate playerInstantiate; 

    void Start()
    {
        playerInstantiate = PlayerInstantiate.Instance;
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Destroy(gameObject);

            powerUpManager.Skateboard();
        }
    }
}
