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

    public int MaxTime = 50;
    public int NotNeededCookies = 8;
    int lessCookies;
    int nextLevelIndex;

    [SerializeField] private AudioClip[] _UISound;

    VisualElement LoadingFish;
    VisualElement LoadingFish_;
    int currentScene;

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

        LoadingFish = root.Q<VisualElement>("vis_load");
        LoadingFish_ = root.Q<VisualElement>("vis_load_");


        visCorner4.style.display = DisplayStyle.None;
        LoadingFish.style.display = DisplayStyle.None;


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
            currentScene = SceneManager.GetActiveScene().buildIndex;
            if (currentScene ==1) 
            {
                if (AlwaysThere.CurrencyStar) allCollected = true; 
                if (AlwaysThere.TimeStar) inTime = true;
            }
            if (currentScene == 2)
            {
                if (AlwaysThere.CurrencyStar2) allCollected = true;
                if (AlwaysThere.TimeStar2) inTime = true;
            }
            if (currentScene == 3)
            {
                if (AlwaysThere.CurrencyStar3) allCollected = true;
                if (AlwaysThere.TimeStar3) inTime = true;
            }
            if (currentScene == 4)
            {
                if (AlwaysThere.CurrencyStar4) allCollected = true;
                if (AlwaysThere.TimeStar4) inTime = true;
            }
            //Debug.Log("beginning: " + inTime);
            if (AlwaysThere.time <= MaxTime) inTime = true;
            //Debug.Log("after compared to level: " + inTime);
            //Debug.Log("after compared to always: " + inTime);
            //Debug.Log("after Collected " + allCollected);

            lessCookies = C_Currency.CurrencyTotal - NotNeededCookies;
            if (lessCookies <= C_Currency.CurrencyAmount) { allCollected = true; }
 
            Stars();
            inTime = false;

   

                C_Currency.CurrencyTotal = 0;
            AlwaysThere.FishMoney += C_Currency.CurrencyAmount;
            C_Currency.CurrencyAmount = 0;
            AlwaysThere.shieldThere = false;
            AlwaysThere.bottleThere = false;

            nextLevelIndex =(SceneManager.GetActiveScene().buildIndex + 1);
            if (nextLevelIndex == 2) { AlwaysThere.level2Unlocked = true; }
            else if (nextLevelIndex == 3) { AlwaysThere.level3Unlocked = true; }
            else if (nextLevelIndex == 4) { AlwaysThere.level4Unlocked = true; }
            else if (nextLevelIndex == 5) { AlwaysThere.level5Unlocked = true; }
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
            if (currentScene == 1)
            {
            AlwaysThere.TimeStar = true;
            AlwaysThere.CurrencyStar = true;
            }
            else if (currentScene == 2)
            {
                AlwaysThere.TimeStar2 = true;
                AlwaysThere.CurrencyStar2 = true;
            }
            else if(currentScene == 3)
            {
                AlwaysThere.TimeStar3 = true;
                AlwaysThere.CurrencyStar3 = true;
            }
            else if(currentScene == 4)
            {
                AlwaysThere.TimeStar4 = true;
                AlwaysThere.CurrencyStar4 = true;
            }

        }
        else if (allCollected||inTime)
        {
            //animaition star1
            star2.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            //aniamtion star2
            if (currentScene == 1)
            {
                if (allCollected) AlwaysThere.CurrencyStar = true;
                else AlwaysThere.TimeStar = true;
            }
            else if (currentScene == 2)
            {
                if (allCollected) AlwaysThere.CurrencyStar2 = true;
                else AlwaysThere.TimeStar2 = true;
            }
            else if (currentScene == 3)
            {
                if (allCollected) AlwaysThere.CurrencyStar3 = true;
                else AlwaysThere.TimeStar3 = true;
            }
            else if (currentScene == 4)
            {
                if (allCollected) AlwaysThere.CurrencyStar4 = true;
                else AlwaysThere.TimeStar4 = true;
            }
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
        LoadingFish.style.display = DisplayStyle.Flex;
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