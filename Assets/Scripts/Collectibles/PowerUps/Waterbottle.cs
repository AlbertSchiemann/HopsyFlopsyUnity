using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbottle : MonoBehaviour
{
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
            Debug.Log("Waterbottle triggered");
            
            SoundManager.Instance.PlaySound(_hydrateClip);

            Destroy(gameObject);

            powerUpManager.Waterbottle();
        }
    }


}
