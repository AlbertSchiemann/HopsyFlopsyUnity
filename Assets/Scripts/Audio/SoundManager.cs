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

    private bool hasPlayedSound = false;
    private bool isAllowedToPlay = false;
    private bool playingBg = false;

    public const string Bg_key = "Background";
    public const string Sfx_key = "Effects";
    
    private void Awake(){
        //Code to only have a Single Instance of a Sound Manager alive in the Scene
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        //Subscription to Game State Manager
        isAllowedToPlay = false;
        GameStateManagerScript.onGameStart += AllowSound;
        GameStateManagerScript.onGamePaused += DenySound;

        DontDestroyOnLoad(gameObject);

        //Load the Volume settings, previously made by the User
        LoadVolume();
    }

    private void Update()
    {
        if(isAllowedToPlay && !playingBg)
        {
            _musicSource.Play();
            _atmoSource.Play();
            playingBg = true;
        }
        else if(!isAllowedToPlay && playingBg)
        {
            _musicSource.Stop();
            _atmoSource.Stop();
            playingBg = false;
        }
    }

    //Soundeffect Array, for randomized sounds in pitch and file
    public void PlaySound(AudioClip[] clip){
        if (isAllowedToPlay)
        {
            int randomIndex = Random.Range(0, clip.Length);
            float randomPitch = Random.Range(minPitch, maxPitch);
            AudioClip _soundbyte = clip[randomIndex];

            if (!hasPlayedSound)
            {
                _effectSource.clip = _soundbyte;
                _effectSource.pitch = randomPitch;
                _effectSource.Play();
                hasPlayedSound = true;
            }

            hasPlayedSound = false;
        }
        
    }

    public void StopSound(AudioClip[] clip)
    {
        AudioClip _soundbyte = clip[0];

        _effectSource.clip = _soundbyte;
        _effectSource.Stop();
    }

    public void LoadVolume() //Volume Saved in VolumeSettings.cs
    {
        float BgVolume = PlayerPrefs.GetFloat(Bg_key, 1f);
        float SfxVolume = PlayerPrefs.GetFloat(Sfx_key, 1f);

        mixer.SetFloat(VolumeSettings.Mixer_Bg, Mathf.Log10(BgVolume) * 20);
        mixer.SetFloat(VolumeSettings.Mixer_Sfx, Mathf.Log10(SfxVolume) * 20);
        //Debug.Log("Volume Loaded: " + BgVolume + " " + SfxVolume);
    }

    public void AllowSound()
    {
        isAllowedToPlay = true;
    }

    public void DenySound()
    {
        isAllowedToPlay = false;
    }
}
