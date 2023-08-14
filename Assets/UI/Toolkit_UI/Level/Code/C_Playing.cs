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

    Button butBottle;
    VisualElement visShield;

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

   private void Awake()
    {
        GameObject GameStateManager = GameObject.Find("GameStateManager");
        GameStateManagerScript = GameStateManager.GetComponent<GameStateManagerScript>();
    }

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        GameStateManagerScript.StartGame();

        butPause = root.Q<Button>("but_pause");

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
        topCross.clicked += UpCrossButton;
        botCross.clicked += DownCrossButton;
        leftCross.clicked += LeftCrossButton;
        rightCross.clicked += RightCrossButton;

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

        Timer = AlwaysThere.time;       
    }

    private void Update()
    {
        
        Timer = Timer + Time.deltaTime;

    }

    void Pause()
    {
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
}
  