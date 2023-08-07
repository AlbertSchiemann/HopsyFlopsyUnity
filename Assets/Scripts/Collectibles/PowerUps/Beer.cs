using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    // Drunkmode - different Sound
    // Player does random movement every few seconds
    // Screen gets shaky?

    private PowerUpManager powerUpManager;
    private PlayerInstantiate playerInstantiate; 

    [SerializeField] private AudioClip[] _hydrateClip;

    void Start()
    {
        playerInstantiate = PlayerInstantiate.Instance;
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            SoundManager.Instance.PlaySound(_hydrateClip);

            Destroy(gameObject);

            powerUpManager.Beer();
        }
    }
}
