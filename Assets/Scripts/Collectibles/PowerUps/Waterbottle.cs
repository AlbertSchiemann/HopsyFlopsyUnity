using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbottle : MonoBehaviour
{
    // Activatable - fills up hydration bar to some extend
    // gets activated automatically when hydration drops to 0
    [SerializeField] private AudioClip[] _hydrateClip;

    public HydrationController hydrationController;         // Reference to the levels HydrationController 
    private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player

    public int waterbottlecounter = 0;

    public bool useWaterbottle = false;
    Vector3 objectRotation;
    float newUpdateRate = 0.05f;

    //C_PowerUp powerUp;

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
    }
    public void DeleteBottle()
    {
        waterbottlecounter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if  (waterbottlecounter == 0) 
            {
                waterbottlecounter = 1;
                Debug.Log("Waterbottlecounter = " + waterbottlecounter);
                Destroy(GetComponent<Collider>());
                GameObject cube = gameObject.transform.Find("Bottle").gameObject;
                Destroy(cube);
                //powerUp.PickUpBottle();
            }
            else
            {
                Debug.Log("Already got a Waterbottle");
            }
        }
    }
    public bool WaterbottleChecker ()
    {
        if (waterbottlecounter > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
