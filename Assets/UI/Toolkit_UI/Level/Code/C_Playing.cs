using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_Playing : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butPause;

    Button butConfirm;
    VisualElement visControls;

    //Swipe Input reference
    [SerializeField] private SwipeManager swipeManager;

    //Cross Field Input
    Button butTop, butBot, butLeft, butRight;
    public static bool upTap, downTap, leftTap, rightTap = false;
    GroupBox CrossField;

    //Control Pad Input
    Button topCross, botCross, leftCross, rightCross;
    public static bool upCrossTap, downCrossTap, leftCrossTap, rightCrossTap = false;
    GroupBox PadField;

    private GameStateManagerScript GameStateManagerScript;

    [SerializeField] private AudioClip[] _UISound;

    public static float Timer;

    VisualElement waterSlider;

    VisualElement BorderCross;
    VisualElement BorderPad;
    VisualElement BorderSwipe;

    Button butSwipeInput;
    Button butCrossInput;
    Button butPadInput;
    public static bool _swipeInput = true;
    public static bool _crossInput = false;
    public static bool _padInput = false;


    private void Awake()
    {
        GameObject GameStateManager = GameObject.Find("GameStateManager");
        GameStateManagerScript = GameStateManager.GetComponent<GameStateManagerScript>();
    }

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        GameStateManagerScript.StartGame();

        butConfirm = root.Q<Button>("but_confirm");
        visControls = root.Q<VisualElement>("vis_input");

        butPause = root.Q<Button>("but_pause");
        waterSlider = root.Q<VisualElement>("Foreground");

        CrossField = root.Q<GroupBox>("CrossTap");
        butTop = root.Q<Button>("topButton");
        butBot = root.Q<Button>("botButton");
        butLeft = root.Q<Button>("leftButton");
        butRight = root.Q<Button>("rightButton");

        butTop.clicked += UpButton;
        butBot.clicked += DownButton;
        butLeft.clicked += LeftButton;
        butRight.clicked += RightButton;


        PadField = root.Q<GroupBox>("ControlPad");
        topCross = root.Q<Button>("topCross");
        botCross = root.Q<Button>("botCross");
        leftCross = root.Q<Button>("leftCross");
        rightCross = root.Q<Button>("rightCross");

        butSwipeInput = root.Q<Button>("swipeInput");
        butCrossInput = root.Q<Button>("crossInput");
        butPadInput = root.Q<Button>("padInput");

        BorderPad = root.Q<VisualElement>("vis_border_pad");
        BorderCross = root.Q<VisualElement>("vis_border_cross");
        BorderSwipe = root.Q<VisualElement>("vis_border_swipe");
            
        butSwipeInput.clicked += SwipeInputs;
        butCrossInput.clicked += CrossInputs;
        butPadInput.clicked += PadInputs;

        topCross.clicked += UpCrossButton;
        botCross.clicked += DownCrossButton;
        leftCross.clicked += LeftCrossButton;
        rightCross.clicked += RightCrossButton;

        LoadPrefsInt("MusicIcon");
        LoadPrefsInt("SFXIcon");

        if (LoadPrefsInt("MusicIcon") == 1)
        {
            SoundManager.EnableMusic();
            AlwaysThere.MusicIcon = true;
        }
        else
        {
            SoundManager.DisableMusic();
            AlwaysThere.MusicIcon = false;
        }

        if (LoadPrefsInt("SFXIcon") == 1)
        {
            SoundManager.EnableSfx();
            AlwaysThere.SFXIcon = true;
        }
        else
        {
            SoundManager.DisableSfx();
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

        if (C_SettingsLevel._swipeInput)
        {
            swipeManager.enabled = true;
            CrossField.style.display = DisplayStyle.None;
            PadField.style.display = DisplayStyle.None;
        }
        else if (C_SettingsLevel._crossInput)
        {
            swipeManager.enabled = false;
            CrossField.style.display = DisplayStyle.Flex;
            PadField.style.display = DisplayStyle.None;
        }
        else if (C_SettingsLevel._padInput)
        {
            swipeManager.enabled = false;
            CrossField.style.display = DisplayStyle.None;
            PadField.style.display = DisplayStyle.Flex;
        }

        //butBottle = root.Q<Button>("but_bottle");
        //visShield = root.Q<VisualElement>("vis_shield");

        butPause.clicked += Pause;
        butConfirm.clicked += Confirm;

        Timer = AlwaysThere.time;     
        if (AlwaysThere.firstPlayed1) visControls.style.display = DisplayStyle.None;
    }

    private void Update()
    {
        
        Timer = Timer + Time.deltaTime;

    }

    void Confirm()
    {
        visControls.style.display = DisplayStyle.None;
        AlwaysThere.firstPlayed1 = true;
    }

    void Pause()
    {
        AlwaysThere.Wasserstand = waterSlider.style.height.value.value;
        SwipeManager.tapping = false;
        AlwaysThere.time = (int)Timer;
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenPause();
    }

    public void UpButton()
    {
        upTap = true;
        Invoke("ResetTap", 0.1f);
    }
    public void DownButton()
    {
        downTap = true;
        Invoke("ResetTap", 0.1f);
    }
    public void RightButton()
    {
        rightTap = true;
        Invoke("ResetTap", 0.1f);
    }
    public void LeftButton()
    {
        leftTap = true;
        Invoke("ResetTap", 0.1f);
    }
    private void ResetTap()
    {
        upTap = false;
        downTap = false;
        rightTap = false;
        leftTap = false;
    }

    public void UpCrossButton()
    {
        upCrossTap = true;
        Invoke("ResetCrossTap", 0.1f);
    }
    public void DownCrossButton()
    {
        downCrossTap = true;
        Invoke("ResetCrossTap", 0.1f);
    }
    public void LeftCrossButton()
    {
        leftCrossTap = true;
        Invoke("ResetCrossTap", 0.1f);
    }
    public void RightCrossButton()
    {
        rightCrossTap = true;
        Invoke("ResetCrossTap", 0.1f);
    }
    private void ResetCrossTap()
    {
        upCrossTap = false;
        downCrossTap = false;
        leftCrossTap = false;
        rightCrossTap = false;
    }

    private void CrossInputs()
    {
        _crossInput = true;
        _swipeInput = false;
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

    private void SwipeInputs()
    {      
        _crossInput = false;
        _swipeInput = true;
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

    private void PadInputs()
    {       
        _crossInput = false;
        _swipeInput = false;
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
  