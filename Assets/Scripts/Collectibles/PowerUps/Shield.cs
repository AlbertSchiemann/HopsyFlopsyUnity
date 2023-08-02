using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Prevents player from taking a enemy hit once

    [SerializeField] private AudioClip[] _shieldClip;

    [SerializeField] PowerUpManager powerUpManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Shielded up");
            Destroy(gameObject);
            SoundManager.Instance.PlaySound(_shieldClip);
            powerUpManager.Shield();
        }
    }

}
