using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbottle : MonoBehaviour
{
    [SerializeField] PowerUpManager powerUpManager;
    private PlayerInstantiate playerInstantiate; 

    [SerializeField] private AudioClip[] _hydrateClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Waterbottle triggered");
            
            SoundManager.Instance.PlaySound(_hydrateClip);

            Destroy(gameObject);

            powerUpManager.Waterbottle();
        }
    }


}
