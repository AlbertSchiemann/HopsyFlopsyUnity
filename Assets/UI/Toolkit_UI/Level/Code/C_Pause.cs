using System.Collections;
using System.Collections.Generic;
using System.Net;
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

    public float MaxTime = 200;

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
        butResume = root.Q<Button>("but_playOn");
        butRestart = root.Q<Button>("but_restart");

        butHide = root.Q<Button>("but_hide");
        butShow = root.Q<Button>("but_show");

        visCorner4 = root.Q<VisualElement>("vis_4inCorner");


        visCorner4.style.display = DisplayStyle.None;


        butHelp.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;

        butMain.clicked += Main;
        butResume.clicked += Resume;
        butRestart.clicked += Restart;

        butHide.clicked += Hide;
        butShow.clicked += Show;
        if (AlwaysThere.time < MaxTime) { Debug.Log("Yes");Debug.Log(AlwaysThere.time); }
        else { Debug.Log("No"); Debug.Log(AlwaysThere.time); }

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

    void Settings()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenSettings();

    }

    void Main()
    {
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMainMenu();
    }

    void Restart()
    {
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
    }

    void Show()
    {
        SoundManager.Instance.PlaySound(_UISound);
        //animation of hiding + vis_4inCorner.display=none;
        visCorner4.style.display = DisplayStyle.Flex;
        butShow.style.display = DisplayStyle.None;
    }
}