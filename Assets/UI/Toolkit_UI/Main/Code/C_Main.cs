using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Main : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreen;

    public Button butPlayLast;
    public Button butMainLevel;
    public Button butWorld1;

    //public Button butBack;
    public Button butStore;
    public Button butHelp;
    public Button butSettings;


    public VisualElement LoadingFish;
    public VisualElement LoadingFish_;

    bool Loading = false;
    float time = 0f;
    float TimeDelay = 0.5f;
    int switcher = 0;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butHelp = root.Q<Button>("but_help");
        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");

        butPlayLast = root.Q<Button>("PlayLast");
        butMainLevel = root.Q<Button>("MainLv");
        butWorld1 = root.Q<Button>("but_W1");

        LoadingFish = root.Q<VisualElement>("vis_load");
        LoadingFish_ = root.Q<VisualElement>("vis_load_");


        butHelp.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;
        butPlayLast.clicked += PlayLast;
        butMainLevel.clicked += MainLevel;
        butWorld1.clicked += W1;

        LoadingFish.style.display = DisplayStyle.None;
    }

        //private void FixedUpdate()
        //{
        // if (Loading)
        // {
        //    time = time + 1f * Time.deltaTime;

        //    if (time >= TimeDelay)
        //    {
        //        if (switcher == 0) Roataion(360);
        //        else if (switcher == 1) Roataion(315);
        //        else if (switcher == 2) Roataion(270);
        //        else if (switcher == 3) Roataion(225);
        //        else if (switcher == 4) Roataion(180);
        //        else if (switcher == 5) Roataion(135);
        //        else if (switcher == 6) Roataion(90);
        //        else if (switcher == 7) { Roataion(45); switcher = 0; }
        //    }
           
        // }

        //}

    void Roataion(int degree)
    {
        switcher++;
        LoadingFish.style.rotate = new Rotate(degree);
        time = 0;
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
 
    void W1()
    {
        switchScreen.OpenW1();
    }

    void PlayLast()
    {
        Loading = true;
        LoadingFish.style.display = DisplayStyle.Flex;
        butPlayLast.style.display = DisplayStyle.None;
        LoadingFish_.style.rotate = new Rotate(90);
        C_UI_OpenOther.ToLastLevel();
    }

    void MainLevel()
    {

        Loading = true;
        LoadingFish.style.display = DisplayStyle.Flex;
        butPlayLast.style.display = DisplayStyle.None;
        LoadingFish_.style.rotate = new Rotate(90);
        C_UI_OpenOther.ToMain_Level();
    }

}

