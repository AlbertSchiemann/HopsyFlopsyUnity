using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Prevents player from taking a enemy hit once

    [SerializeField] private AudioClip[] _shieldClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Shielded up");
            Destroy(gameObject);
            EnemyMovementArray.canTankHit = true;
            SoundManager.Instance.PlaySound(_shieldClip);
        }
    }
}
