using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skateboard : MonoBehaviour
{
    // moving forward till hitting an object
    // fast movement

    [SerializeField] private GameObject playerPrefab;            // get a Instantiation of the Player
    [SerializeField] private GameObject skateboardmeshForSkating;        // get a Instantiation of the Skateboard

    Vector3 objectRotation;
    float newUpdateRate = 0.05f;

    Vector3 skateboardPosition = new Vector3(0, 0.5f, 3);

    void Start()
    {
        InvokeRepeating("SlowUpdate", 0.0f, newUpdateRate);
    }
    void SlowUpdate()
    {
        objectRotation = new Vector3(0, -3f, 0) + transform.eulerAngles;
        transform.eulerAngles = objectRotation;
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
}
