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

        StarReachedCollectible();

    }

    void StarReachedCollectible()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        star1 = root.Q<VisualElement>("vis_star1");
        var tempColor = star1.style.unityBackgroundImageTintColor;
        Debug.Log(tempColor);
        //tempColor.a = 1f;
        star1.style.opacity = star1.resolvedStyle.opacity + 255 ;
        star1.style.unityBackgroundImageTintColor = Color.grey;
        // -unity-background-image-tint-color: rgba(178, 178, 178, 0.34);
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
    void Next()
    {
        C_UI_OpenOther.ToNextLevel();
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