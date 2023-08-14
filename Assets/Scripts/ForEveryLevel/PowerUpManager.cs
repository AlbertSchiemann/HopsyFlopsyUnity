using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private PlayerInstantiate playerInstantiate;
    public HydrationController hydrationController;

    [SerializeField] CameraFollow verticalCameraFollow;
    public bool waterbottleThere = false;
    [SerializeField] private GameObject skateboardmeshForSkating; 
    public float drunkmodedurationBeer = 12f;
    [SerializeField] private float _dehydrationDelayBubble = 5f;
    public C_PowerUps powerUp;
    public C_WaterBar waterBar;
    Vector3 skateboardPosition = new Vector3(0.12f, 0.1f, 0);

    public static PlayerInstantiate Instance { get; private set; }
    public static PowerUpManager InstanceP { get; private set; }
    void Start()
    {
        playerInstantiate = PlayerInstantiate.Instance;
    }

    public void Waterbottle()
    {
        if  (waterbottleThere == false) 
        {
            Vibration.Vibrate(100);
            waterbottleThere = true;
            Debug.Log("Waterbottle triggered");
            powerUp.PickUpBottle();
        }
        else 
        {
            Debug.Log("Waterbottle already there");
        }
    }

    public void Beer()
    {
        Vibration.Vibrate(100);
        verticalCameraFollow.shakeDuration = drunkmodedurationBeer;
        hydrationController.BeerHydration();
        waterBar.Drunk();
        AlwaysThere.Drunk = true;
        Invoke("RandomCall" ,  2f);
        Invoke("RandomCall" ,  4f);
        Invoke("RandomCall" ,  6f);
        Invoke("RandomCall" ,  8f);
        Invoke("RandomCall" , 10f);
        Invoke("RandomCall" , 12f);
    }   

    public void Bubble()
    {
        Vibration.Vibrate(100);
        hydrationController.Pausestart();
        hydrationController.PauseDehydration(_dehydrationDelayBubble);
    }
    public void Skateboard()
    {
        Vibration.Vibrate(100);
        Instantiate(skateboardmeshForSkating, playerInstantiate.transform.position - skateboardPosition, skateboardmeshForSkating.transform.rotation, playerInstantiate.transform);
        playerInstantiate.GetComponent<GridPlayerMovement>().SkateboardMovement();
        Invoke("DestroySkateboard", 1.55f);
    }
    public void Shield()
    {
        Vibration.Vibrate(100);
        EnemyMovementArray.canTankHit = true;
        powerUp.PickUpShield();
    } 
    public void Refill()
    {
        hydrationController.MaxHydration();
        waterbottleThere = false;
        waterBar.SetHealth(99f);
    }

    public bool WaterbottleChecker ()
    {
        if (waterbottleThere)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void RandomCall()
    {
        playerInstantiate.GetComponent<GridPlayerMovement>().RandomMovement();
    }
}
