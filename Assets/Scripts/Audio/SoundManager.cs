using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectSource, _atmoSource;
    [SerializeField] private float minPitch = .50f, maxPitch = 1.50f;

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

    //Soundeffect Array, for randomized sounds in pitch and file
    public void PlaySound(AudioClip[] clip){
        int randomIndex = Random.Range(0, clip.Length);
        float randomPitch = Random.Range(minPitch, maxPitch);
        AudioClip _soundbyte = clip[randomIndex];

        _effectSource.clip = _soundbyte;
        _effectSource.pitch = randomPitch;
        _effectSource.Play();
    }

    //MasterVolume changer for a Slider
    public void ChangeMasterVolume(float value){
        AudioListener.volume = value;
    }
}
