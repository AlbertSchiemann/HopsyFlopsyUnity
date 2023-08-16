using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyCollision : MonoBehaviour
{
    public float delayTillDeathscreenShows = .2f;
    public C_LevelSwitchScreens levelScript;
    [SerializeField] private AudioClip[] _failClip;

    public static bool canTankHit = false;
    [SerializeField] private AudioClip[] _deflectClip;
    C_PowerUps powerUp;
    private PlayerInstantiate playerInstantiate;

    [SerializeField] private CameraRide cameraRide;
    [SerializeField] private GameObject DeathSpeechbubble;
    [SerializeField] private GameObject player;
    private Vector3 SpeachbubbleRotation = new (120, -10, 180);
    private Vector3 PlayerRotationAtDeath = new (-60, 45, -70);
    private Vector3 PlayerPositionChangeAtDeath = new (-.54f, 5.9f, -2.89f);
    private bool SpeachbubbleEatenTwoSpawned = false;

    void Start ()
    {
        playerInstantiate = PlayerInstantiate.Instance;
    }
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
                GameObject player = playerInstantiate.gameObject;
                Invoke("Sceneload", 2.3f);
                player.GetComponent<GridPlayerMovement>().PreventMovement();
                SoundManager.Instance.PlaySound(_failClip);
                Vibration.Vibrate(1000);
                if (!SpeachbubbleEatenTwoSpawned)
                {
                    SpeachbubbleEatenDeath();
                    cameraRide.DeathCamera();

                    player.transform.DOMove(player.transform.position + PlayerPositionChangeAtDeath, .6f).SetEase(Ease.Linear);
                    player.transform.DORotate(PlayerRotationAtDeath, .6f).SetDelay(.5f);
                    
                }
                else return;
            }
            else
            {
                SoundManager.Instance.PlaySound(_deflectClip);
                Vibration.Vibrate(200);
                canTankHit = false;
                powerUp.UseShield();
            }
        }
    }
    public void SpeachbubbleEatenDeath ()
    {
        GameObject player = playerInstantiate.gameObject;
        Invoke("DelaySpeachbubble2", .01f);
        SpeachbubbleEatenTwoSpawned = true;                                                         
    }
    private void DelaySpeachbubble2 ()
    {
        GameObject player = playerInstantiate.gameObject;
        GameObject newObject1 = Instantiate(DeathSpeechbubble, new Vector3(player.transform.position.x + PlayerPositionChangeAtDeath.x + 1f, PlayerPositionChangeAtDeath.y + .8f, player.transform.position.z + PlayerPositionChangeAtDeath.z + 1.12f), Quaternion.Euler(SpeachbubbleRotation));
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTankHit = false;
            if (powerUp == null) { return; }
            powerUp.UseShield();
        }
    }
    void Sceneload()
    {
        AlwaysThere.time = (int)C_Playing.Timer;
        if (!C_LevelSwitchScreens.AdWatched)
            levelScript.OpenAd();
       else levelScript.OpenLoose();
    }
}
