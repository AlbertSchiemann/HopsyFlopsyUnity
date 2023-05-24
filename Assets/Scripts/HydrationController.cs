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
    private bool isCollidingWithWater; // Check if waterTile is colliding
    public float Delay = 1.0f; // Delay till Scene gets reloaded
    public int HydrationUpdateTime = 2; // How often the Hydration should be written in the Console

    


    public UI_LevelScript levelScript;
    public UI_Script_WaterBar waterBar;

    [SerializeField] private AudioClip[] _hydrateClip;
    [SerializeField] private AudioClip[] _failClip;

    // Start is called before the first frame update
    void Start()
    {
        hydration = hydrationMax;
        HydrationUpdateTime *= 100;

        waterBar.SetMaxHealth(hydrationMax);
        isHydrationActivated = false;
        GameStateManagerScript.onGameStart += ActivateHydration;
        GameStateManagerScript.onGamePaused += DeactivateHydration;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHydrationActivated) { return; };
        RestoreHydration();
        LowerHydration();
        CheckHydrationDeathCondition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            // SoundManager.Instance.PlaySound(_hydrateClip);
            isCollidingWithWater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isCollidingWithWater = false;
        }
    }

    public void LowerHydration()
    {
        if (!isCollidingWithWater)
        {
            // Decrease hydration over time
            hydration -= hydrationDecayRate * Time.deltaTime;
            waterBar.SetHealth(hydration);
        }
    }

    public void RestoreHydration()
    {
        if (isCollidingWithWater)
        {
            //Restore Hydration if in water
            if (hydration < hydrationMax)
            {
                hydration = hydrationMax;
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
            Invoke("Sceneload", Delay);
            SoundManager.Instance.PlaySound(_failClip);
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
