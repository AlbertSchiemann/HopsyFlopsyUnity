using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FreeFallGridBlock : MonoBehaviour
{
    // This script is just calling the animator of the playerprefab

    public C_LevelSwitchScreens levelScript;

    public float DelayTillReload = .2f;                          // Delay till Scene gets reloaded after death
    private float DelayTillTweenIsOver = 2.5f;
    

    [SerializeField] private AudioClip[] _failClip;         // Sound if the player falls into the abyss
    [SerializeField] private AudioClip[] _wiggleClip;

    [SerializeField] private CameraFollow cameraFollow;

    


    private void Start()
    {

        GameObject levelUIObject = GameObject.Find("Level_UI");
        levelScript = levelUIObject.GetComponent<C_LevelSwitchScreens>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<GridPlayerMovement>().PreventMovement();
            
            player.transform.DORotate(new Vector3(-50, 0, 0), .25f).SetDelay(.5f);
            player.transform.DORotate(new Vector3(0, 20, 10), .25f).SetDelay(.75f);
            player.transform.DORotate(new Vector3(0, -20, 10), .25f).SetDelay(1f);
            player.transform.DORotate(new Vector3(0, 20, -10), .25f).SetDelay(1.25f);
            player.transform.DORotate(new Vector3(0, -20, -10), .25f).SetDelay(1.5f);
            player.transform.DORotate(new Vector3(0, 0, 0), .3f).SetDelay(1.75f);
            player.transform.DOMoveY(-15f, 1f).SetDelay(2f);

            Invoke("Sound", 2f);
            
            //cameraFollow.FallingCamera(); // doesnt work, dont know why

            
            Invoke("Sceneload", DelayTillReload + DelayTillTweenIsOver);
            Invoke("WiggleSound", .5f);
        }
    }

    private void Sound ()
    {
        SoundManager.Instance.PlaySound(_failClip);
    }

    private void WiggleSound ()
    {
        SoundManager.Instance.PlaySound(_wiggleClip);
    }

    void Sceneload()
    {
        AlwaysThere.time = (int)C_Playing.Timer;
        if (!C_LevelSwitchScreens.AdWatched)
            levelScript.OpenAd();
        else levelScript.OpenLoose();
    }
}

