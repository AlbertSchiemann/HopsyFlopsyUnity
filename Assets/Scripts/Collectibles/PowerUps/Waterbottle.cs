using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbottle : MonoBehaviour
{
    // Activatable - fills up hydration bar to some extend
    // gets activated automatically when hydration drops to 0
    [SerializeField] private AudioClip[] _hydrateClip;
    [SerializeField] public Material transparent;

    public HydrationController hydrationController;         // Reference to the levels HydrationController 
    private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player

    public int waterbottlecounter = 0;

    public bool useWaterbottle = false;

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
                GameObject cube = gameObject.transform.Find("Cylinder").gameObject;
                cube.GetComponent<MeshRenderer>().material = transparent;
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
