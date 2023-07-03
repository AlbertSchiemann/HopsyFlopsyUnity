using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_SettingsLevel : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butBack;
    Button butStore;
    Button butHelpi;


    void OnEnable()
    {
        VisualElement rootSettings = GetComponent<UIDocument>().rootVisualElement;

        butHelpi = rootSettings.Q<Button>("but_help");
        butStore = rootSettings.Q<Button>("but_store");
        butBack = rootSettings.Q<Button>("but_back");

        butHelpi.clicked += Help;
        butStore.clicked += Store;
        butBack.clicked += Back;

    }


    void Help()
    {
        switchScreen.OpenHelp();
    }

    void Store()
    {
        switchScreen.OpenStore();

    }

    void Back()
    {
        switchScreen.OpenPause();
    }


}



