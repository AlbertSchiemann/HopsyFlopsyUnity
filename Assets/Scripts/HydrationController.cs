using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrationController : MonoBehaviour
{
    bool isHydrationActivated;

    public float hydrationMax = 100f; // Maximum amount of Hydration
    public float hydrationDecayRate = 10f; // Rate in which the Hydration goes down 
    public float hydrationRestoreAmount = 100f; // Rate in which Hydration gets restored in Water Tiles

    private float hydration; // Value of the Hydration
    public bool isCollidingWithWater = false; // Check if waterTile is colliding
    public float Delay = 1.0f; // Delay till Scene gets reloaded

    [SerializeField] private WaterGridBlock waterGridBlock; // Reference to WaterGridBlock script

    public HydrationController hydrationController;
    public GridCell gridCell;
    public GameGrid gameGrid;
    public UI_LevelScript levelScript;
    public UI_Script_WaterBar waterBar;

    [SerializeField] private AudioClip[] _hydrateClip;
    [SerializeField] private AudioClip[] _failClip;

    // Start is called before the first frame update
    void Start()
    {
        hydration = hydrationMax;

        waterBar.SetMaxHealth(hydrationMax);
        
        GameStateManagerScript.onGameStart += ActivateHydration;
        GameStateManagerScript.onGamePaused += DeactivateHydration;

        // Get reference to WaterGridBlock script
        // waterGridBlock = FindObjectOfType<WaterGridBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isHydrationActivated == false) 
        { 
            return; 
        }

        else
        {
            RestoreHydration();
            LowerHydration();
            CheckHydrationDeathCondition();   
        }
    }
    

    public bool IsCollidingWithWater()
    {
        return isCollidingWithWater = true;
    }

    public void LowerHydration()
    {
        if (!isCollidingWithWater)
        {
            // Decrease hydration over time
            hydration -= hydrationDecayRate * Time.deltaTime;
            waterBar.SetHealth(hydration);
        }
        else
        {
            // Reset hydration to maximum if colliding with water
            hydration += hydrationRestoreAmount * Time.deltaTime;
            hydration = Mathf.Clamp(hydration, 0f, hydrationMax);
            waterBar.SetHealth(hydration);
        }
    }

    public void RestoreHydration()
    {
        // Restore Hydration if needed
        if (isCollidingWithWater == true)
        {
           
            if (hydration < hydrationMax)
            {
                //hydration = hydrationMax;
                hydration += hydrationRestoreAmount * Time.deltaTime;
                hydration = Mathf.Clamp(hydration, 0f, hydrationMax);
                waterBar.SetHealth(hydration);
            }
        }
    }

    public void CheckHydrationDeathCondition()
    {
        // Check if hydration has reached 0
        if (hydration <= 0)
        {
            levelScript.OpenLoose();
            SoundManager.Instance.PlaySound(_failClip);
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

// Blubbel
