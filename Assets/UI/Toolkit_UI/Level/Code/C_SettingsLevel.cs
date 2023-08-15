using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Audio;

public class C_SettingsLevel : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

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

    Button butSwipeInput;
    Button butCrossInput;
    Button butPadInput;
    public static bool _swipeInput = true;
    public static bool _crossInput = false;
    public static bool _padInput = false;

    public const string Mixer_Bg = "Background";
    public const string Mixer_Sfx = "Effects";

    VisualElement visControls;
    VisualElement visCredits;
    VisualElement visSound;
    
    Label txtContact;

    VisualElement BorderCross;
    VisualElement BorderPad;
    VisualElement BorderSwipe;

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

        BorderPad = rootSettings.Q<VisualElement>("vis_border_pad");
        BorderCross = rootSettings.Q<VisualElement>("vis_border_cross");
        BorderSwipe = rootSettings.Q<VisualElement>("vis_border_swipe");

        sliderMusic = rootSettings.Q<Slider>("Sound");
        sliderSFX = rootSettings.Q<Slider>("SFX");

        //sliderMusic.value = PlayerPrefs.GetFloat(SoundManager.Bg_key, 1f);
        //sliderSFX.value = PlayerPrefs.GetFloat(SoundManager.Sfx_key, 1f);

        LoadPrefsInt("MusicIcon");
        LoadPrefsInt("SFXIcon");

        if (LoadPrefsInt("MusicIcon") == 1)
        {
            AlwaysThere.MusicIcon = true;
        }
        else
        {
            AlwaysThere.MusicIcon = false;
        }

        if (LoadPrefsInt("SFXIcon") == 1)
        {
            AlwaysThere.SFXIcon = true;
        }
        else
        {
            AlwaysThere.SFXIcon = false;
        }

        LoadPrefsInt("_swipeInput");
        LoadPrefsInt("_crossInput");
        LoadPrefsInt("_padInput");

        if (LoadPrefsInt("_swipeInput") == 1)
        {
            SwipeInputs();
            _swipeInput = true;
        }
        else
        {
            _swipeInput = false;
        }

        if (LoadPrefsInt("_crossInput") == 1)
        {
            CrossInputs();
            _crossInput = true;
        }
        else
        {
            _crossInput = false;
        }

        if (LoadPrefsInt("_padInput") == 1)
        {
            PadInputs();
            _padInput = true;
        }
        else
        {
            _padInput = false;
        }

        butMusicOn = rootSettings.Q<Button>("but_sound_on");
        butMusicOff = rootSettings.Q<Button>("but_sound_off");
        butSfxOn = rootSettings.Q<Button>("but_sfx_on");
        butSfxOff = rootSettings.Q<Button>("but_sfx_off");

        butSwipeInput = rootSettings.Q<Button>("swipeInput");
        butCrossInput = rootSettings.Q<Button>("crossInput");
        butPadInput = rootSettings.Q<Button>("padInput");

        butSwipeInput.clicked += SwipeInputs;
        butCrossInput.clicked += CrossInputs;
        butPadInput.clicked += PadInputs;

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
        switchScreen.OpenHelp();
    }

    void Store()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenStore();

    }

    void Back()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenPause();
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
        mixer.SetFloat(Mixer_Bg, Mathf.Log10(value) * 20);
    }

    private void SetSfxVolume(float value)
    {
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

    private void SwipeInputs()
    {
        _swipeInput = true;
        _crossInput = false;
        _padInput = false;

        BorderCross.style.borderBottomColor = Color.white;
        BorderCross.style.borderTopColor = Color.white;
        BorderCross.style.borderLeftColor = Color.white;
        BorderCross.style.borderRightColor = Color.white;

        BorderSwipe.style.borderBottomColor = Color.green;
        BorderSwipe.style.borderTopColor = Color.green;
        BorderSwipe.style.borderLeftColor = Color.green;
        BorderSwipe.style.borderRightColor = Color.green;

        BorderPad.style.borderBottomColor = Color.white;
        BorderPad.style.borderTopColor = Color.white;
        BorderPad.style.borderLeftColor = Color.white;
        BorderPad.style.borderRightColor = Color.white;


    }

    private void CrossInputs()
    {
        _swipeInput = false;
        _crossInput = true;
        _padInput = false;

        BorderCross.style.borderBottomColor = Color.green;
        BorderCross.style.borderTopColor = Color.green;
        BorderCross.style.borderLeftColor = Color.green;
        BorderCross.style.borderRightColor = Color.green;

        BorderSwipe.style.borderBottomColor = Color.white;
        BorderSwipe.style.borderTopColor = Color.white;
        BorderSwipe.style.borderLeftColor = Color.white;
        BorderSwipe.style.borderRightColor = Color.white;

        BorderPad.style.borderBottomColor = Color.white;
        BorderPad.style.borderTopColor = Color.white;
        BorderPad.style.borderLeftColor = Color.white;
        BorderPad.style.borderRightColor = Color.white;
    }

    private void PadInputs()
    {
        _swipeInput = false;
        _crossInput = false;
        _padInput = true;

        BorderCross.style.borderBottomColor = Color.white;
        BorderCross.style.borderTopColor = Color.white;
        BorderCross.style.borderLeftColor = Color.white;
        BorderCross.style.borderRightColor = Color.white;

        BorderSwipe.style.borderBottomColor = Color.white;
        BorderSwipe.style.borderTopColor = Color.white;
        BorderSwipe.style.borderLeftColor = Color.white;
        BorderSwipe.style.borderRightColor = Color.white;

        BorderPad.style.borderBottomColor = Color.green;
        BorderPad.style.borderTopColor = Color.green;
        BorderPad.style.borderLeftColor = Color.green;
        BorderPad.style.borderRightColor = Color.green;
    }

    void OnDisable()
    {
        if (AlwaysThere.MusicIcon)
        {
            SavePrefsInt("MusicIcon", 1);
        }
        else
        {
            SavePrefsInt("MusicIcon", 0);
        }

        if (AlwaysThere.SFXIcon)
        {
            SavePrefsInt("SFXIcon", 1);
        }
        else
        {
            SavePrefsInt("SFXIcon", 0);
        }

        if (_swipeInput)
        {
            SavePrefsInt("_swipeInput", 1);
        }
        else
        {
            SavePrefsInt("_swipeInput", 0);
        }

        if (_crossInput)
        {
            SavePrefsInt("_crossInput", 1);
        }
        else
        {
            SavePrefsInt("_crossInput", 0);
        }

        if (_padInput)
        {
            SavePrefsInt("_padInput", 1);
        }
        else
        {
            SavePrefsInt("_padInput", 0);
        }
    }

    public static void SavePrefsInt(string Key, int value)
    {
        PlayerPrefs.SetInt(Key, value);
        PlayerPrefs.Save();
    }

    public static int LoadPrefsInt(string Key)
    {
        int x = PlayerPrefs.GetInt(Key, 0);
        return x;
    }
}



