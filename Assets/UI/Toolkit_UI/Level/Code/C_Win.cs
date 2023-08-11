using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.MessageBox;

public class C_Win : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butStore;
    Button butHelp;
    Button butSettings;

    Button butNext;
    Button butRestart;
    Button butMain;

    Button butHide;
    Button butShow;

    VisualElement visCorner4;
    VisualElement star1;
    VisualElement star2;
    VisualElement star3;

    Label txtCollextible;
    Label txtTime;

    public static bool allCollected = false;
    public static bool inTime = false;

    public int MaxTime = 60;

    int nextLevelIndex;

    [SerializeField] private AudioClip[] _UISound;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butHelp = root.Q<Button>("but_help");
        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");

        butMain = root.Q<Button>("but_main");
        butNext = root.Q<Button>("but_nextLevel");
        butRestart = root.Q<Button>("but_restart");

        butHide = root.Q<Button>("but_hide");
        butShow = root.Q<Button>("but_show");

        txtCollextible = root.Q<Label>("txt_collectibles");
        txtTime = root.Q<Label>("txt_time");


        visCorner4 = root.Q<VisualElement>("vis_4inCorner");

        star1 = root.Q<VisualElement>("vis_star1");
        star2 = root.Q<VisualElement>("vis_star2");
        star3 = root.Q<VisualElement>("vis_star3");


        visCorner4.style.display = DisplayStyle.None;


        butHelp.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;

        butMain.clicked += Main;
        butNext.clicked += Next;
        butRestart.clicked += Restart;

        butHide.clicked += Hide;
        butShow.clicked += Show;

        if (switchScreen.WON)
        {
            Debug.Log("beginning: " + inTime);
            if (AlwaysThere.time <= MaxTime) inTime = true;
            Debug.Log("after compared to level: " + inTime);
            if (AlwaysThere.CurrencyStar) allCollected = true;
            if (AlwaysThere.TimeStar) inTime = true;
            Debug.Log("after compared to always: " + inTime);
            //Debug.Log("after Collected " + allCollected);

            Stars();
            inTime = false;


            C_Currency.CurrencyTotal = 0;

            nextLevelIndex=(SceneManager.GetActiveScene().buildIndex + 1);
            if (nextLevelIndex == 2) { AlwaysThere.level2Unlocked = true; }
            else if (nextLevelIndex == 3) { AlwaysThere.level3Unlocked = true; }
            else if (nextLevelIndex == 4) { Debug.Log("next level coming soon"); }
        }
    }

    void StarReachedCollectible()
    {
    //    VisualElement root = GetComponent<UIDocument>().rootVisualElement;
    //    star1 = root.Q<VisualElement>("vis_star1");
    //    var tempColor = star1.style.unityBackgroundImageTintColor;
    //    Debug.Log(tempColor);
    //    //tempColor.a = 1f;
    //    star2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
    //    star3.style.unityBackgroundImageTintColor = Color.grey;
    //    star1.style.unityBackgroundImageTintColor = new Color(0.35f, 0.35f, 0.35f, 1f);
    //    // -unity-background-image-tint-color: rgba(178, 178, 178, 0.34);
    }
    void Stars()
    {
        if (allCollected&&inTime)
        {
            //aniamtion star1
            star2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            //animation star2
            star3.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            //animation star3
            AlwaysThere.TimeStar = true;
            AlwaysThere.CurrencyStar = true;
        }
        else if (allCollected||inTime)
        {
            //animaition star1
            star2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            //aniamtion star2
            if (allCollected) AlwaysThere.CurrencyStar = true;
            else AlwaysThere.TimeStar = true;
        }
        else
        {
            //aniamtion star1
        }
        txtTime.text = AlwaysThere.time + " / " + MaxTime;
        txtCollextible.text = C_Currency.CurrencyAmount + " / " + C_Currency.CurrencyTotal;
        AlwaysThere.time = 0;

    }


    void Help()
    {
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMain_Help();
    }

    void Store()
    {
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMain_Store();

    }

    void Settings()
    {
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMain_Settings();

    }

    void Main()
    {
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMainMenu();
    }

    void Restart()
    {
        SoundManager.Instance.PlaySound(_UISound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Next()
    {
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToNextLevel();
    }
        void Hide()
    {
        SoundManager.Instance.PlaySound(_UISound);
        butShow.style.display = DisplayStyle.Flex;
        //animation of hiding + vis_4inCorner.display=none;
        visCorner4.style.display = DisplayStyle.None;
    }

    void Show()
    {
        SoundManager.Instance.PlaySound(_UISound);
        //animation of hiding + vis_4inCorner.display=none;
        visCorner4.style.display = DisplayStyle.Flex;
        butShow.style.display = DisplayStyle.None;
    }
}