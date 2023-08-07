using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    // stops hydration decay for some extra seconds

    [SerializeField] private AudioClip[] _hydrateClip;

    private PowerUpManager powerUpManager;
    private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player


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

            powerUpManager.Bubble();
        }
    }
}
