using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PowerUpManager : MonoBehaviour
{
    private PlayerInstantiate playerInstantiate;
    public HydrationController hydrationController;
    public bool waterbottleThere = false;
    [SerializeField] private GameObject skateboardmeshForSkating; 

    

    public static PowerUpManager Instance { get; private set; }


    void Start()
    {
        playerInstantiate = PlayerInstantiate.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Waterbottle()
    {
        
    }
    public void Bubble()
    {

    }
    public void Skateboard()
    {
        
    }

    public void Refill()
    {

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
}
/*
public class Waterbottle : MonoBehaviour
{
    // Activatable - fills up hydration bar to some extend
    // gets activated automatically when hydration drops to 0
    [SerializeField] private AudioClip[] _hydrateClip;

    public HydrationController hydrationController;         // Reference to the levels HydrationController 
    private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player

    public bool waterbottleThere = false;

    public bool useWaterbottle = false;
    Vector3 objectRotation;
    float newUpdateRate = 0.05f;

    [SerializeField] C_PowerUps powerUp;

    void Start()
    {
        InvokeRepeating("SlowUpdate", 0.0f, newUpdateRate);
    }
    void SlowUpdate()
    {
        objectRotation = new Vector3(0, -5f, 0) + transform.eulerAngles;
        transform.eulerAngles = objectRotation;
    }

    public void Refill()
    {
        hydrationController.MaxHydration();
        waterbottleThere = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if  (waterbottleThere == false) 
            {
                waterbottleThere = true;
                Debug.Log("Waterbottlecounter = " + waterbottleThere);
                Destroy(GetComponent<Collider>());
                GameObject cube = gameObject.transform.Find("Bottle").gameObject;
                Destroy(cube);
                Debug.Log("Waterbottle triggered");
                powerUp.PickUpBottle();
            }
            else
            {
                Debug.Log("Already got a Waterbottle");
            }
        }
    }
    
}



private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(GetComponent<Collider>());
            GameObject cube = gameObject.transform.Find("Skateboard").gameObject;
            Destroy(cube);

            Debug.Log("Skateboard triggered");
            //playerPrefab.GetComponent<GridPlayerMovement>().UpdateActive = false;
            
            Instantiate(skateboardmeshForSkating, playerPrefab.transform.position - skateboardPosition, playerPrefab.transform.rotation, playerPrefab.transform);
            playerPrefab.GetComponent<GridPlayerMovement>().SkateboardMovement();
            Invoke("DestroySkateboard", 1.55f);
            
        }
    }
*/