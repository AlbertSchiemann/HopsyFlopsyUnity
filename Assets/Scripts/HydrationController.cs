using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrationController : MonoBehaviour
{
    public float hydrationMax = 100f;
    public float hydrationDecayRate = 10f;
    public float hydrationRestoreAmount = 100f;

    private float hydration;
    public bool isCollidingWithWater;

    public int HydrationUpdateTime = 2; // How often the Hydration should be written in the Console

    int Hydra; // rnd variable name
    int nextTime = 0;

    public UI_Script_WaterBar waterBar;

    [SerializeField] private AudioClip[] _hydrateClip;

    // Start is called before the first frame update
    void Start()
    {
        hydration = hydrationMax;
        HydrationUpdateTime *= 100;

        waterBar.SetMaxHealth(hydrationMax);
    }

    // Update is called once per frame
    void Update()
    {
        RestoreHydration();
       

        LowerHydration();


        CheckHydrationDeathCondition();

        if (nextTime >= Hydra)
        {
            //Debug.Log(hydration);

            Hydra = nextTime + HydrationUpdateTime;
        }
        nextTime++;

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
            Debug.Log("Out of Water - Dead!");
            // Player dies, restart the game here
        }
    }     
}
