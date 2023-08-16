using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.MessageBox;

public class C_Pause : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butStore;
    Button butHelp;
    Button butSettings;

    Button butResume;
    Button butRestart;
    Button butMain;

    Button butHide;
    Button butShow;

    VisualElement visCorner4;

    private GameStateManagerScript GameStateManagerScript;

    [SerializeField] private AudioClip[] _UISound;



    Button butBottle;
    VisualElement visShield;

    VisualElement waterSlider;
    VisualElement waterGlas;
    VisualElement wave;
    VisualElement bubbles;
    VisualElement bubbleground;
    int Warning = 0;

    Label txtCurrency;
    public Sprite DrunkWater;

    [SerializeField] private SwipeManager swipeManager;


    private void Awake()
    {
        GameObject GameStateManager = GameObject.Find("GameStateManager");
        GameStateManagerScript = GameStateManager.GetComponent<GameStateManagerScript>();
    }
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        GameStateManagerScript.PauseGame();

        butHelp = root.Q<Button>("but_help");
        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");

        butMain = root.Q<Button>("but_main");
        butResume = root.Q<Button>("but_playOn");
        butRestart = root.Q<Button>("but_restart");

        butHide = root.Q<Button>("but_hide");
        butShow = root.Q<Button>("but_show");

        visCorner4 = root.Q<VisualElement>("vis_4inCorner");


        waterSlider = root.Q<VisualElement>("Foreground");
        bubbleground = root.Q<VisualElement>("Bubbleground");
        waterGlas = root.Q<VisualElement>("waterbar_back");
        wave = root.Q<VisualElement>("wave");
        bubbles = root.Q<VisualElement>("bubbles");

        visShield = root.Q<VisualElement>("vis_shield");
        butBottle = root.Q<Button>("but_bottle");

        txtCurrency = root.Q<Label>("txt_currency");

        txtCurrency.text = C_Currency.CurrencyAmount.ToString() + " / " + C_Currency.CurrencyTotal.ToString();

        visCorner4.style.display = DisplayStyle.None;


        butHelp.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;

        butMain.clicked += Main;
        butResume.clicked += Resume;
        butRestart.clicked += Restart;

        butHide.clicked += Hide;
        butShow.clicked += Show;

        if(AlwaysThere.Drunk) waterSlider.style.backgroundImage = new StyleBackground(DrunkWater);

        SetHealth(AlwaysThere.Wasserstand);
        Debug.Log("alwaysBottle: " + AlwaysThere.bottleThere);
        if (!AlwaysThere.bottleThere) { butBottle.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f); }
        if (!AlwaysThere.shieldThere) visShield.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);

    }
    public void SetHealth(float health)
    {
        waterSlider.style.height = Length.Percent(health);
        bubbleground.style.height = Length.Percent(health - 3);
        if (health < 15 && Warning == 1)
        {
            waterGlas.style.unityBackgroundImageTintColor = new Color(1f, 0f, 0f, 0.7f);
            Warning++;

        }
        else if (health < 35 && Warning == 0)
        {
            waterGlas.style.unityBackgroundImageTintColor = new Color(0.7f, 0f, 0f, 0.7f);
            Warning++;

        }
        else if (health > 35 && Warning != 0)
        {
            waterGlas.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            Warning = 0;
        }
        // Debug.Log("Slider: " +waterSlider.style.height);
    }

    void Help()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenHelp();
        swipeManager.enabled = false;
    }

    void Store()
    {

        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenStore();
        swipeManager.enabled = false;
    }

    void Settings()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenSettings();
        swipeManager.enabled = false;

    }

    void Main()
    {
        C_Currency.CurrencyTotal = 0;
        AlwaysThere.FishMoney += C_Currency.CurrencyAmount;
        C_Currency.CurrencyAmount = 0;
        AlwaysThere.shieldThere = false;
        AlwaysThere.bottleThere = false;
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMainMenu();
    }

    void Restart()
    {
        C_Currency.CurrencyAmount = 0;
        AlwaysThere.shieldThere = false;
        AlwaysThere.bottleThere = false;
        C_Currency.CurrencyTotal = 0;
        SoundManager.Instance.PlaySound(_UISound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Resume()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenPlaying();
    }

    void Hide()
    {
        SoundManager.Instance.PlaySound(_UISound);
        butShow.style.display = DisplayStyle.Flex;
        //animation of hiding + vis_4inCorner.display=none;
        visCorner4.style.display = DisplayStyle.None;
        swipeManager.enabled = false;
    }

    void Show()
    {
        SoundManager.Instance.PlaySound(_UISound);
        //animation of hiding + vis_4inCorner.display=none;
        visCorner4.style.display = DisplayStyle.Flex;
        butShow.style.display = DisplayStyle.None;
        swipeManager.enabled = false;
    }
}