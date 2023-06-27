using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Store : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreenStore;

    public Button butBack;
    Button butHelpi;
    Button butSettings;


    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        //butHelpi = root.Q<Button>("but_help");
        
        //butSettings = root.Q<Button>("but_settings");
        //butBack = root.Q<Button>("but_back");



        //butHelpi.clicked += Help;
        
        //butSettings.clicked += Settings;

        //butBack.clicked += Back;



    }


    void Help()
    {
        Debug.Log("before");
        switchScreenStore.OpenHelp();
        Debug.Log("after");
    }

    void Settings()
    {
        switchScreenStore.OpenSettings();

    }

    void Back()
    {
        Debug.Log("afterr");
        switchScreenStore.OpenMain();
    }
}