using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectSource;

    //Code to only have a Single Instance of a Sound Manager alive in the Scene
    void Awake(){
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    //Play Input Sound Method
    public void PlaySound(AudioClip clip){
        _effectSource.PlayOneShot(clip);
    }

    //Change Volume Method
    public void ChangeMasterVolume(float value){
        AudioListener.volume = value;
    }
}
