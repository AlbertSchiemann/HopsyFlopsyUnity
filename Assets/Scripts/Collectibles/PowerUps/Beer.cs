using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    // Drunkmode - different Sound
    // Player does random movement every few seconds
    // Screen gets shaky?

    [SerializeField] private AudioClip[] _hydrateClip;
    [SerializeField] public Material transparent;
    
    Vector3 objectRotation;
    float newUpdateRate = 0.05f;

    public float drunkmodeduration = 15f;

    public HydrationController hydrationController;         // Reference to the levels HydrationController 
    [SerializeField] private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player
    public CameraFollow cameraFollow;


    void Start()
    {
        InvokeRepeating("SlowUpdate", 0.0f, newUpdateRate);
    }
    void SlowUpdate()
    {
        objectRotation = new Vector3(0, 5f, 0) + transform.eulerAngles;
        transform.eulerAngles = objectRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(GetComponent<Collider>());
            GameObject cube = gameObject.transform.Find("Cylinder").gameObject;
            cube.GetComponent<MeshRenderer>().material = transparent;
            cameraFollow.shakeDuration = drunkmodeduration;
            hydrationController.BeerHydration();
            Invoke("RandomCall" , 2f);
            Invoke("RandomCall" , 5f);
            Invoke("RandomCall" , 8f);
            Invoke("RandomCall" , 11f);


        }
    }

    void RandomCall()
    {
        playerInstantiate.GetComponent<GridPlayerMovement>().RandomMovement();
    }
}
