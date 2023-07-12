using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbottle : MonoBehaviour
{
    // Activatable - fills up hydration bar to some extend
    // gets activated automatically when hydration drops to 0
    [SerializeField] private AudioClip[] _hydrateClip;

    public HydrationController hydrationController;         // Reference to the levels HydrationController 
    private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player

    public int waterbottlecounter = 0;

    public bool useWaterbottle = false;

    private float _dehydrationDelay = 1f;  // recharge Hydration a bit

    public void Start()
    {
        if (useWaterbottle)   
        {
            hydrationController.PauseDehydration(_dehydrationDelay, true);
            SoundManager.Instance.PlaySound(_hydrateClip);
            waterbottlecounter--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if  (waterbottlecounter == 0) 
            {
                Destroy(gameObject);
            }

            waterbottlecounter = 1;

          
        }
    }
    public bool WaterbottleChecker ()
    {
        if (waterbottlecounter > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
