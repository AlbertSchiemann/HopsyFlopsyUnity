using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    // stops hydration decay for some extra seconds

    [SerializeField] private AudioClip[] _hydrateClip;

    public HydrationController hydrationController;         // Reference to the levels HydrationController 
    private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player

    [SerializeField] private float _dehydrationDelay = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            hydrationController.PauseDehydration(_dehydrationDelay, true);
            SoundManager.Instance.PlaySound(_hydrateClip);
          
        }
    }




}
