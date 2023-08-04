using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float delayTillDeathscreenShows = .2f;
    public C_LevelSwitchScreens levelScript;
    [SerializeField] private AudioClip[] _failClip;

    public static bool canTankHit = false;
    [SerializeField] private AudioClip[] _deflectClip;
    C_PowerUps powerUp;

    private void Awake()
    {
        GameObject levelUIObject = GameObject.Find("Level_UI");
        levelScript = levelUIObject.GetComponent<C_LevelSwitchScreens>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!canTankHit)
            {
                Invoke("Sceneload", delayTillDeathscreenShows);
                GameObject player = other.gameObject;
                player.GetComponent<GridPlayerMovement>().PreventMovement();
                SoundManager.Instance.PlaySound(_failClip);
            }
            else
            {
                Debug.Log("DEFLECT");
                SoundManager.Instance.PlaySound(_deflectClip);
                canTankHit = false;
                powerUp.UseShield();
            }
        }
    }
    void Sceneload()
    {
        levelScript.OpenLoose();
    }
}
