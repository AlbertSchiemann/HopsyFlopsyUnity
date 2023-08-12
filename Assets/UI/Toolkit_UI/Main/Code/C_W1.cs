using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_W1 : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreenW1;

     Button butLevel1;
     Button butLevel2;
     Button butLevel3;


       Button butBack;
     Button butStore;
     Button butHelpi;
     Button butSettings;


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butHelpi = root.Q<Button>("but_help");
        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");
        butBack = root.Q<Button>("Back");

        butLevel1 = root.Q<Button>("Level1");
        butLevel2 = root.Q<Button>("Level2");
        butLevel3 = root.Q<Button>("Level3");

        butHelpi.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;
        butLevel1.clicked += Level1;
        butLevel2.clicked += Level2;
        butLevel3.clicked += Level3;
        butBack.clicked += Back;



        if (!AlwaysThere.level2Unlocked) butLevel2.style.unityBackgroundImageTintColor = new Color(0.5f, 0.5f, 0.5f, 1f);
        if (!AlwaysThere.level3Unlocked) butLevel2.style.unityBackgroundImageTintColor = new Color(0.5f, 0.5f, 0.5f, 1f);

    }


    void Help()
    {
        switchScreenW1.OpenHelp();
    }

    void Store()
    {
        switchScreenW1.OpenStore();

    }

    void Settings()
    {
        switchScreenW1.OpenSettings();

    }

    void Back()
    {
        Debug.Log("afterr");
        switchScreenW1.OpenMain();
    }

    void Level1()
    {
        C_UI_OpenOther.ToLevel1();
    }
    void Level2()
    {
        if (AlwaysThere.level2Unlocked) C_UI_OpenOther.ToLevel2();
    }
    void Level3()
    {
        if (AlwaysThere.level3Unlocked) C_UI_OpenOther.ToLevel3();
    }
}

   

