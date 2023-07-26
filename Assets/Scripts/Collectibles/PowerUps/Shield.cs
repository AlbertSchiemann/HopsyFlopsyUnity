using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Prevents player from taking a enemy hit once

    [SerializeField] private AudioClip[] _shieldClip;
    Vector3 objectRotation;
    float newUpdateRate = 0.05f;
    C_PowerUps powerUp;

    void Start()
    {
        InvokeRepeating("SlowUpdate", 0.0f, newUpdateRate);
    }
    void SlowUpdate()
    {
        objectRotation = new Vector3(0, 2f, 1f) + transform.eulerAngles;
        transform.eulerAngles = objectRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Shielded up");
            Destroy(gameObject);
            EnemyMovementArray.canTankHit = true;
            SoundManager.Instance.PlaySound(_shieldClip);
            powerUp.PickUpShield();
        }
    }

}
