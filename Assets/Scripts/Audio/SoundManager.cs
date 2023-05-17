using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private AudioSource _musicSource, _effectSource, _atmoSource;
    [SerializeField] private float minPitch = .50f, maxPitch = 1.50f;

    public const string Bg_key = "Background";
    public const string Sfx_key = "Effects";

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

        LoadVolume();
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

    public void LoadVolume() //Volume Saved in VolumeSettings.cs
    {
        float BgVolume = PlayerPrefs.GetFloat(Bg_key, 1f);
        float SfxVolume = PlayerPrefs.GetFloat(Sfx_key, 1f);

        mixer.SetFloat(VolumeSettings.Mixer_Bg, Mathf.Log10(BgVolume) * 20);
        mixer.SetFloat(VolumeSettings.Mixer_Sfx, Mathf.Log10(SfxVolume) * 20);
        Debug.Log("Volume Loaded: " + BgVolume + " " + SfxVolume);
    }
}
