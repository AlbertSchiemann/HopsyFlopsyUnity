using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiate : MonoBehaviour
{
    
    // Start is called before the first frame update
    public static PlayerInstantiate Instance { get; private set; }  // Instantiatie the Player Controller to assign it automatically

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Ensure only one instance of the Player exists
            return;
        }

        Instance = this;
    }
}
