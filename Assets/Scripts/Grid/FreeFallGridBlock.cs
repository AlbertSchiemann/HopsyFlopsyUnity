using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FreeFallGridBlock : MonoBehaviour
{
    // This script is just calling the animator of the playerprefab

    public C_LevelSwitchScreens levelScript;

    public float DelayTillReload = .2f;                          // Delay till Scene gets reloaded after death
    

    [SerializeField] private AudioClip[] _failClip;         // Sound if the player falls into the abyss
    [SerializeField] private Animator fallingAnimator;      // Animator of the playerprefab that shall be triggered
    


    private PlayerInstantiate playerInstantiate;            // get a Instantiation of the Player

    private void Start()
    {
        playerInstantiate = PlayerInstantiate.Instance;
        GameObject levelUIObject = GameObject.Find("Level_UI");
        levelScript = levelUIObject.GetComponent<C_LevelSwitchScreens>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            // Debug.Log("Player entered the wind block.");
            Invoke("Sceneload", DelayTillReload);
            GameObject player = other.gameObject;
            
            player.GetComponent<GridPlayerMovement>().PreventMovement();
            SoundManager.Instance.PlaySound(_failClip);

            //playerInstantiate.GetComponent<Animator>().enabled = true;

            //playerInstantiate.GetComponent<Animator>().SetBool("fallingBool", true);


            // Debug.Log("Player entered the wind block2.");

        }
    }
        void Sceneload()
    {
        if (!C_LevelSwitchScreens.AdWatched)
            levelScript.OpenAd();
        else levelScript.OpenLoose();
    }
}

