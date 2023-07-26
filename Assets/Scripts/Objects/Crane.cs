using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject cranePrefab;
    // [SerializeField] private AudioClip[] _craneclip;         // cranesound

    [SerializeField] private float animationSpeed = 1f;            // insert speed of the craneanimation
     

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Crane triggered");
            playerPrefab.GetComponent<GridPlayerMovement>().UpdateActive = false;
            
            playerPrefab.GetComponent<GridPlayerMovement>().PreventMovement();
            
            playerPrefab.GetComponent<GridPlayerMovement>().CraneMovement();
            

            // SoundManager.Instance.PlaySound(Crane);
                        // Start of crane animation
            // cranePrefab.GetComponent<Animator>().enabled = true;
            // cranePrefab.GetComponent<Animator>().SetBool("moving", true);
            // player.GetComponent<Animator>().enabled = true;
            // player.GetComponent<Animator>().SetBool("moving", true);

            Invoke("AfterAnimation", animationSpeed);
            Invoke("AfterAnimationUpdate", animationSpeed);

            playerPrefab.GetComponent<GridPlayerMovement>().UpdateActive = true;

        }
    }
    private void AfterAnimation()
    {
        playerPrefab.GetComponent<GridPlayerMovement>().AllowMovement();
    }
    private void AfterAnimationUpdate()
    {
        playerPrefab.GetComponent<GridPlayerMovement>().UpdateGameObjectPosition();
    }
}



// laut Heiko:
// Animator bauen in unity der den Player transformed
// Gridposition nach der Animation festlegen und player dort hinsetzen

// Gridposition vor animation als input optional