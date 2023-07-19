using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrationController : MonoBehaviour
{
    // This script is responsible for the hydration of the player
    // The player loses hydration over time
    // The player loses hydration faster if he is colliding with fire
    // The player gains hydration if he is colliding with water
    // If the hydration reaches 0, the player dies
    
    bool isHydrationActivated;

    public static float hydrationMax = 100f;                       // Maximum amount of Hydration
    public float hydrationDecayRate = 10f;                  // Rate in which the Hydration goes down 
    public float hydrationDecayFire = 2f;
    public float hydrationRestoreAmount = 100f;             // Rate in which Hydration gets restored in Water Tiles

    private float hydration;                                // Value of the Hydration
    public bool isCollidingWithWater = false;               // Check if waterTile is colliding
    public bool isCollidingWithFire = false;                // Check if firetile is colliding

    public float DelayTillReload = .2f;                          // Delay till Scene gets reloaded after death


    public C_LevelSwitchScreens levelScript;
    public C_WaterBar waterBar;

    [SerializeField] private AudioClip[] _hydrateClip;
    [SerializeField] private AudioClip[] _failClip;
    [SerializeField] Waterbottle waterbottle;                    // Reference to the Waterbottle GameObject

    private PlayerInstantiate playerInstantiate;



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
            //Debug.Log("colliding with fire");
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
    public void PauseDehydration(float pausetime, bool pauseactive)
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
        Invoke("pauseactive = false", pausetime);
    }
    private void Pausestop (bool pauseactive)
    {
        pauseactive = false;
    }

    

    public void CheckHydrationDeathCondition()                              // Check if hydration has reached 0, then the player dies
    {
       if (hydration <= 0 && waterbottle.WaterbottleChecker() == true)
        {
            waterbottle.Refill();
            //SoundManager.Instance.PlaySound(_hydrateClip);
            Debug.Log("Waterbottle used");
        }
        else if (hydration <= 0)
        {
            Invoke("Sceneload", DelayTillReload); 
            SoundManager.Instance.PlaySound(_failClip);
            GameObject player = playerInstantiate.gameObject;
            player.GetComponent<GridPlayerMovement>().PreventMovement();

        }
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
        // restart the game if the player collides with the enemy
        levelScript.OpenLoose();  
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

