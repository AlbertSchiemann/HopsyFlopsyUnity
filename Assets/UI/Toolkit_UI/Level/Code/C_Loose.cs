using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_Loose : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butStore;
    Button butHelp;
    Button butSettings;

    Button butRestart;
    Button butMain;

    Button butHide;
    Button butShow;

    VisualElement visCorner4;

    private GameStateManagerScript GameStateManagerScript;

    [SerializeField] private AudioClip[] _UISound;

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
        butRestart = root.Q<Button>("but_restart");


        butHide = root.Q<Button>("but_hide");
        butShow = root.Q<Button>("but_show");


        visCorner4 = root.Q<VisualElement>("vis_4inCorner");
        visCorner4.style.display = DisplayStyle.None;


        butHelp.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;

        butMain.clicked += Main;
        butRestart.clicked += Restart;

        butHide.clicked += Hide;
        butShow.clicked += Show;

        TimeShow();

        C_Currency.CurrencyTotal = 0;

    }

    void TimeShow()
    {
        //displying needed time
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