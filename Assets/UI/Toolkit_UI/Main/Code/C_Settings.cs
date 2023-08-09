using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Audio;

public class C_Settings : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreenW1;

    Button butBack;
    Button butStore;
    Button butHelp;

    Button butCredits;
    Button butSound;
    Button butContact;
    Button butControls;

    [SerializeField] AudioMixer mixer;
    Slider sliderMusic;
    Slider sliderSFX;
    Button butMusicOn;
    Button butMusicOff;
    Button butSfxOn;
    Button butSfxOff;

    public const string Mixer_Bg = "Background";
    public const string Mixer_Sfx = "Effects";

    VisualElement visControls;
    VisualElement visCredits;
    VisualElement visSound;
    Label txtContact;

    [SerializeField] private AudioClip[] _UISound;

    void OnEnable()
    {
        VisualElement rootSettings = GetComponent<UIDocument>().rootVisualElement;

        butHelp = rootSettings.Q<Button>("but_help");
        butStore = rootSettings.Q<Button>("but_store");
        butBack = rootSettings.Q<Button>("but_back");

        butCredits = rootSettings.Q<Button>("but_Credits");
        butSound = rootSettings.Q<Button>("but_Sound");
        butContact = rootSettings.Q<Button>("but_contact");
        butControls = rootSettings.Q<Button>("but_controls");

        visControls = rootSettings.Q<VisualElement>("vis_controls");
        visCredits = rootSettings.Q<VisualElement>("vis_credits");
        visSound = rootSettings.Q<VisualElement>("vis_sound");
        txtContact = rootSettings.Q<Label>("txt_contact");

        sliderMusic = rootSettings.Q<Slider>("Sound");
        sliderSFX = rootSettings.Q<Slider>("SFX");

        //sliderMusic.value = PlayerPrefs.GetFloat(SoundManager.Bg_key, 1f);
        //sliderSFX.value = PlayerPrefs.GetFloat(SoundManager.Sfx_key, 1f);

        butMusicOn = rootSettings.Q<Button>("but_sound_on");
        butMusicOff = rootSettings.Q<Button>("but_sound_off");
        butSfxOn = rootSettings.Q<Button>("but_sfx_on");
        butSfxOff = rootSettings.Q<Button>("but_sfx_off");

        butMusicOn.clicked += MusicOff;
        butMusicOff.clicked += MusicOn;
        butSfxOn.clicked += SfxOff;
        butSfxOff.clicked += SfxOn;

        butCredits.clicked += Credits;
        butSound.clicked += Sound;
        butContact.clicked += Contact;
        butControls.clicked += Controls;

        butHelp.clicked += Help;
        butStore.clicked += Store;
        butBack.clicked += Back;

        Sound();

    }

    void Controls()
    {
        SoundManager.Instance.PlaySound(_UISound);
        visControls.style.display = DisplayStyle.Flex;
        visCredits.style.display = DisplayStyle.None;
        visSound.style.display = DisplayStyle.None;
        txtContact.style.display = DisplayStyle.None;
    }
    void Credits()
    {
        SoundManager.Instance.PlaySound(_UISound);
        visControls.style.display = DisplayStyle.None;
        visCredits.style.display = DisplayStyle.Flex;
        visSound.style.display = DisplayStyle.None;
        txtContact.style.display = DisplayStyle.None;
    }

    void Sound()
    {
        SoundManager.Instance.PlaySound(_UISound);
        visControls.style.display = DisplayStyle.None;
        visCredits.style.display = DisplayStyle.None;
        visSound.style.display = DisplayStyle.Flex;
        txtContact.style.display = DisplayStyle.None;

        if (AlwaysThere.MusicIcon)
        {
            butMusicOff.style.display = DisplayStyle.None;
            butMusicOn.style.display = DisplayStyle.Flex;
        }
        else
        {
            butMusicOff.style.display = DisplayStyle.Flex;
            butMusicOn.style.display = DisplayStyle.None;

            SoundManager.DisableMusic();
        }

        if (AlwaysThere.SFXIcon)
        {
            butSfxOff.style.display = DisplayStyle.None;
            butSfxOn.style.display = DisplayStyle.Flex;
        }
        else
        {
            butSfxOff.style.display = DisplayStyle.Flex;
            butSfxOn.style.display = DisplayStyle.None;

            SoundManager.DisableSfx();
        }
    }

    void Contact()
    {
        SoundManager.Instance.PlaySound(_UISound);
        visControls.style.display = DisplayStyle.None;
        txtContact.style.display = DisplayStyle.Flex;
        visSound.style.display = DisplayStyle.None;
        visCredits.style.display = DisplayStyle.None;
    }


    void Help()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreenW1.OpenHelp();
    }

    void Store()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreenW1.OpenStore();

    }

    void Back()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreenW1.OpenMain();
    }

    /*
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(SoundManager.Bg_key, sliderMusic.value);
        PlayerPrefs.SetFloat(SoundManager.Sfx_key, sliderSFX.value);
        Debug.Log("Current Slider Value on Disable: " + sliderMusic.value + " " + sliderSFX.value);
    }
    */

    private void SetBgVolume(float value)
    {
        Debug.Log("Set Music Volume");
        mixer.SetFloat(Mixer_Bg, Mathf.Log10(value) * 20);
    }

    private void SetSfxVolume(float value)
    {
        Debug.Log("Set SFX Volume");
        mixer.SetFloat(Mixer_Sfx, Mathf.Log10(value) * 20);
    }

    private void MusicOn()
    {
        butMusicOff.style.display = DisplayStyle.None;
        butMusicOn.style.display = DisplayStyle.Flex;

        SoundManager.EnableMusic();
        AlwaysThere.MusicIcon = true;
    }
    private void MusicOff()
    {
        butMusicOff.style.display = DisplayStyle.Flex;
        butMusicOn.style.display = DisplayStyle.None;

        SoundManager.DisableMusic();
        AlwaysThere.MusicIcon = false;
    }
    private void SfxOn()
    {
        butSfxOff.style.display = DisplayStyle.None;
        butSfxOn.style.display = DisplayStyle.Flex;

        SoundManager.EnableSfx();
        AlwaysThere.SFXIcon = true;
    }
    private void SfxOff()
    {
        butSfxOff.style.display = DisplayStyle.Flex;
        butSfxOn.style.display = DisplayStyle.None;

        SoundManager.DisableSfx();
        AlwaysThere.SFXIcon = false;
    }
}



