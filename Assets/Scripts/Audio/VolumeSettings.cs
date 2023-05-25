using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;

    [SerializeField] Slider bgSlider;
    [SerializeField] Slider sfxSlider;
    
    [SerializeField] GameObject bgButtonOn;
    [SerializeField] GameObject sfxButtonOn;
    [SerializeField] GameObject bgButtonOff;
    [SerializeField] GameObject sfxButtonOff;

    public const string Mixer_Bg = "Background";
    public const string Mixer_Sfx = "Effects";


    private void Start()
    {
        bgSlider.value = PlayerPrefs.GetFloat(SoundManager.Bg_key, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(SoundManager.Sfx_key, 1f);
        Debug.Log("Current Slider Value On Start: " + bgSlider.value + " " + sfxSlider.value);

        bgSlider.onValueChanged.AddListener(SetBgVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);

        bgButtonOff.SetActive(true);
        bgButtonOff.SetActive(false);
        sfxButtonOff.SetActive(true);
        bgButtonOff.SetActive(false);
        Debug.Log("sound on of");

    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(SoundManager.Bg_key, bgSlider.value);
        PlayerPrefs.SetFloat(SoundManager.Sfx_key, sfxSlider.value);
        Debug.Log("Current Slider Value on Disable: " + bgSlider.value + " " + sfxSlider.value);
    }

    private void SetBgVolume(float value)
    {
        mixer.SetFloat(Mixer_Bg, Mathf.Log10(value) * 20);
    }

    private void SetSfxVolume(float value)
    {
        mixer.SetFloat(Mixer_Sfx, Mathf.Log10(value) * 20);
    }

//Volume Button Icon Change, weird way to do things but idc
    public void BgSound_On()
    {
        bgButtonOn.SetActive(true);
        bgButtonOff.SetActive(false);
        Debug.Log("sound on");
    }

    public void BgSound_Off()
    {
        bgButtonOn.SetActive(false);
        bgButtonOff.SetActive(true);
        Debug.Log("sound off");
    }

    public void SfxSound_On()
    {
        sfxButtonOn.SetActive(true);
        sfxButtonOff.SetActive(false);
        Debug.Log("sound on");
    }

    public void SfxSound_Off()
    {
        sfxButtonOn.SetActive(false);
        sfxButtonOff.SetActive(true);
        Debug.Log("sound off");
    }
}
