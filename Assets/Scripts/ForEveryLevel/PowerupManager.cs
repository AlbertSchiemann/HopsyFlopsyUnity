using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PowerUpManager : MonoBehaviour
{
    private PlayerInstantiate playerInstantiate;
    public HydrationController hydrationController;
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
}
