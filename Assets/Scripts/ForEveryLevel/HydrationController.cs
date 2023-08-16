using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HydrationController : MonoBehaviour
{
    // This script is responsible for the hydration of the player
    // The player loses hydration over time
    // The player loses hydration faster if he is colliding with fire
    // The player gains hydration if he is colliding with water
    // If the hydration reaches 0, the player dies
    
    bool isHydrationActivated;

    public static float hydrationMax = 100f;                       // Maximum amount of Hydration
    public float hydrationDecayRate = 18f;                  // Rate in which the Hydration goes down 
    public float hydrationDecayFire = 2f;
    public float hydrationRestoreAmount = 100f;             // Rate in which Hydration gets restored in Water Tiles

    private float hydration;                                // Value of the Hydration
    public bool isCollidingWithWater = false;               // Check if waterTile is colliding
    public bool isCollidingWithFire = false;                // Check if firetile is colliding

    public float DelayTillReload = .2f;                          // Delay till Scene gets reloaded after death


    [SerializeField] C_LevelSwitchScreens levelScript;
    public C_WaterBar waterBar;

    [SerializeField] C_PowerUps powerUp;
    [SerializeField] CameraRide cameraRide;

    [SerializeField] private AudioClip[] _hydrateClip;
    [SerializeField] private AudioClip[] _failClip;

    private PlayerInstantiate playerInstantiate;
    [SerializeField] PowerUpManager powerUpManager;
    [SerializeField] private GameObject DeathSpeechbubble;
    [SerializeField] private GameObject player;
    private Vector3 SpeachbubbleRotation = new (120, -10, 180);
    private Vector3 PlayerRotationAtDeath = new (-60, 45, -70);
    private Vector3 PlayerPositionChangeAtDeath = new (-.54f, 5.9f, -2.89f);
    private bool SpeachbubbleSpawned = false;

    public bool pauseactive;
    private bool isHydrationDangerouslyLow = false;






    public static HydrationController Instance { get; private set; }    // Instantiatie the Hydration Controller to assign it automatically

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);                                        // Ensure only one instance of the HydrationController exists
            return;
        }
        Instance = this;
    }
    
    void Start()
    {
        playerInstantiate = PlayerInstantiate.Instance;
        
        hydration = hydrationMax;

      
        GameStateManagerScript.onGameStart += ActivateHydration;
        GameStateManagerScript.onGamePaused += DeactivateHydration;

    }

    void FixedUpdate ()
    {
        
        if (isHydrationActivated == false) 
        { 
            return; 
        }

        else
        {
            RestoreHydration();
            LowerHydration();
            LowerHydrationOnFire(); 
            CheckHydrationDeathCondition();   
        }

        if ((hydration < hydrationMax / 5) && (!isHydrationDangerouslyLow))
        {
            HydrationVibration();
            isHydrationDangerouslyLow = true;
        }
        else if (hydration >= hydrationMax / 5)
        {
            isHydrationDangerouslyLow = false;
        }
    }
    
    private void HydrationVibration()
    {
        Vibration.Vibrate(500);
        Invoke("HydrationVibration", 1);
    }

    public void LowerHydration()                                        // Decrease hydration over time
    {                                                                   // Reset hydration to maximum if colliding with water
        if (!isCollidingWithWater)
        {     
            hydration -= hydrationDecayRate * Time.deltaTime;
            waterBar.SetHealth(hydration);
        }
        else
        {
            hydration += hydrationRestoreAmount * Time.deltaTime;
            hydration = Mathf.Clamp(hydration, 0f, hydrationMax);
            waterBar.SetHealth(hydration);           
        }
    }

    public void LowerHydrationOnFire()                                  // Decrease hydration over time even faster if colliding with fire
    {
        if (isCollidingWithFire)
        {
            hydration -= hydrationDecayRate * hydrationDecayFire * Time.deltaTime ;
            waterBar.SetHealth(hydration);
        }
        else
        {
            return;
        }
    }
    

    public void RestoreHydration()                                          // Restore hydration if colliding with water
    {
        if (isCollidingWithWater)
        {          
            if (hydration < hydrationMax)
            {
                hydration += hydrationRestoreAmount * Time.deltaTime;
                hydration = Mathf.Clamp(hydration, 0f, hydrationMax);
                waterBar.SetHealth(hydration);
            }
        }
    }

    // used for Power Ups:
    public void PauseDehydration(float pausetime)
    {
        if (pauseactive)
        {
            watercollision();
        }
        Timer(pausetime);
    }
    private void Timer (float pausetime)
    {
        Invoke("watercollisiondisabled", pausetime);
        Invoke("Pausestop", pausetime);
    }
    private void Pausestop ()
    {
        pauseactive = false;
    }

    public void Pausestart ()
    {
        pauseactive = true;
    }

    

    public void CheckHydrationDeathCondition()                              // Check if hydration has reached 0, then the player dies
    {
       if (hydration <= 5 && powerUpManager.waterbottleThere == true)
        {
            //SoundManager.Instance.PlaySound(_hydrateClip);
            
            powerUp.UseBottle();
            powerUpManager.waterbottleThere = false;
        }
        else if (hydration <= 0 && powerUpManager.waterbottleThere == false)
        {
            GameObject player = playerInstantiate.gameObject;
            player.GetComponent<GridPlayerMovement>().PreventMovement();
            
            Invoke("Sceneload", 2.3f); 
            SoundManager.Instance.PlaySound(_failClip);
            

            if (!SpeachbubbleSpawned)
            {
                SpeachbubbleDeath();
                cameraRide.DeathCamera();

                player.transform.DOMove(player.transform.position + PlayerPositionChangeAtDeath, .6f).SetEase(Ease.Linear);
                player.transform.DORotate(PlayerRotationAtDeath, .6f).SetDelay(.5f);
            }
            else return; 
        }
        else if (hydration >= 0)
        {
            return;
        }
        else
        {
            Debug.LogError("Hydrationdeath is fucked up...");
        }
    }
    public void SpeachbubbleDeath ()
    {
        SpeachbubbleSpawned = true;  
        Invoke("DelaySpeachbubbleHydro", .01f);                                                       
    }
    public void DelaySpeachbubbleHydro ()
    {
        GameObject newObject1 = Instantiate(DeathSpeechbubble, new Vector3(player.transform.position.x + PlayerPositionChangeAtDeath.x + 1f, PlayerPositionChangeAtDeath.y + .8f, player.transform.position.z + PlayerPositionChangeAtDeath.z + 1.12f), Quaternion.Euler(SpeachbubbleRotation));
    }
    public void MaxHydration()
    {
        hydration = hydrationMax;
        waterBar.SetMaxHealth();
    }

    public void BeerHydration()
    {
        hydration = hydration +20;
        waterBar.SetHealth(hydration);
    }
    
    void Sceneload()
    {
        AlwaysThere.time = (int)C_Playing.Timer;
        if (!C_LevelSwitchScreens.AdWatched)
            levelScript.OpenAd();
        else levelScript.OpenLoose();
    }


    public void ActivateHydration()
    {
        isHydrationActivated = true;
    }
    public void DeactivateHydration()
    {
        isHydrationActivated = false;
    }
    public void watercollision()
    {
        isCollidingWithWater = true;
    }
    public void watercollisiondisabled()
    {
        isCollidingWithWater = false;
    }
    
}

