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

    VisualElement visCorner4;


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

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

    }


    void Help()
    {
        switchScreen.OpenHelp();
    }

    void Store()
    {
        switchScreen.OpenStore();

    }

    void Settings()
    {
        switchScreen.OpenSettings();

    }

    void Main()
    {
        C_UI_OpenOther.ToMainMenu();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Resume()
    {
        switchScreen.OpenPlaying();
    }

    void Hide()
    {
        butShow.style.display = DisplayStyle.Flex;
        //animation of hiding + vis_4inCorner.display=none;
        visCorner4.style.display = DisplayStyle.None;
    }

    void Show()
    {
        //animation of hiding + vis_4inCorner.display=none;
        visCorner4.style.display = DisplayStyle.Flex;
        butShow.style.display = DisplayStyle.None;
    }
}