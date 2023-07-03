using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_StoreLevel : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreenStore;

    public Button butBack;
    Button butHelpi;
    Button butSettings;


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butHelpi = root.Q<Button>("but_help");
        butSettings = root.Q<Button>("but_settings");
        butBack = root.Q<Button>("but_back");

        butHelpi.clicked += Help;
        butSettings.clicked += Settings;
        butBack.clicked += Back;

    }


    void Help()
    {
        switchScreenStore.OpenHelp();
    }

    void Settings()
    {
        switchScreenStore.OpenSettings();

    }

    void Back()
    {
        switchScreenStore.OpenPause();
    }
}