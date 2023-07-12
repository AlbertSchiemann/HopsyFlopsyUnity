using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    // Drunkmode - different Sound
    // Player does random movement every few seconds
    // Screen gets shaky?

    [SerializeField] private AudioClip[] _hydrateClip;

    public HydrationController hydrationController;         // Reference to the levels HydrationController 
    private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player

    [SerializeField] private float _dehydrationDelay = .2f;  // recharge Hydration a bit

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            hydrationController.PauseDehydration(_dehydrationDelay, true);
            // SoundManager.Instance.PlaySound(_hydrateClip);
          
        }
    }
}
