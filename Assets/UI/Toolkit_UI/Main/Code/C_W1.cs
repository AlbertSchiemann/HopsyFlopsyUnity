using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_W1 : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreenW1;

     Button butLevel1;

     Button butBack;
     Button butStore;
     Button butHelpi;
     Button butSettings;


    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butHelpi = root.Q<Button>("but_help");
        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");
        butBack = root.Q<Button>("Back");

        butLevel1 = root.Q<Button>("Level1");

        butHelpi.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;
        butLevel1.clicked += Level1;
        butBack.clicked += Back;



    }


    void Help()
    {
        Debug.Log("before");
        switchScreenW1.OpenHelp();
        Debug.Log("after");
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
}

   

