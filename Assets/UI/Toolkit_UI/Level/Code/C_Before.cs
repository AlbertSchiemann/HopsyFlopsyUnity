using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_Before : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butStore;
    Button butHelp;
    Button butSettings;

    Button butPlay;
    Button butMain;


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butHelp = root.Q<Button>("but_help");
        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");

        butMain = root.Q<Button>("but_back");
        butPlay = root.Q<Button>("but_play");


        butHelp.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;

        butMain.clicked += Main;
        butPlay.clicked += Play;

    }


    void Help()
    {
        C_UI_OpenOther.ToMain_Help();
    }

    void Store()
    {
        C_UI_OpenOther.ToMain_Store();

    }

    void Settings()
    {
        C_UI_OpenOther.ToMain_Settings();

    }

    void Main()
    {
        C_UI_OpenOther.ToMainMenu();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Play()
    {
        switchScreen.OpenPlaying();
    }
}