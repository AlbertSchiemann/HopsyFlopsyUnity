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

    public float hydrationMax = 100f;                       // Maximum amount of Hydration
    public float hydrationDecayRate = 10f;                  // Rate in which the Hydration goes down 
    public float hydrationDecayFire = 2f;
    public float hydrationRestoreAmount = 100f;             // Rate in which Hydration gets restored in Water Tiles

    private float hydration;                                // Value of the Hydration
    public bool isCollidingWithWater = false;               // Check if waterTile is colliding
    public bool isCollidingWithFire = false;                // Check if firetile is colliding

    public float Delay = 1.0f;                              // Delay till Scene gets reloaded


    public UI_LevelScript levelScript;
    public UI_Script_WaterBar waterBar;

    [SerializeField] private AudioClip[] _hydrateClip;
    [SerializeField] private AudioClip[] _failClip;

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

        waterBar.SetMaxHealth(hydrationMax);
        
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
            Debug.Log("colliding with fire");
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

    public void CheckHydrationDeathCondition()                              // Check if hydration has reached 0, then the player dies
    {
        if (hydration <= 0)
        {
            levelScript.OpenLoose();
            // Sound is missing
            Invoke("Sceneload", Delay); 
        }
    }

    private void ActivateHydration()
    {
        isHydrationActivated = true;
    }
    private void DeactivateHydration()
    {
        isHydrationActivated = false;
    }
}

