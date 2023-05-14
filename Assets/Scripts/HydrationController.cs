using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrationController : MonoBehaviour
{
    public float hydrationMax = 100f;
    public float hydrationDecayRate = 10f;
    public float hydrationRestoreAmount = 50f;

    private float hydration;

    public int HydrationUpdateTime = 2; // How often the Hydration should be written in the Console

    int Hydra; // rnd variable name
    int nextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        hydration = hydrationMax;
        HydrationUpdateTime *= 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


/*
    LowerHydration();

    CheckHydrationDeathCondition();

        
        if (nextTime >= Hydra) 
        {
            Debug.Log(hydration);
            
            Hydra = nextTime + HydrationUpdateTime; 
        }
nextTime++;


public void LowerHydration()
{
    // Decrease hydration over time
    hydration -= hydrationDecayRate * Time.deltaTime;
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

    // checking water collision, does not work yet, useful after player collision is added
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            hydration += hydrationRestoreAmount;
            if (hydration > hydrationMax)
            {
                hydration = hydrationMax;
            }
            Destroy(other.gameObject);
        }
    }
    */
}
