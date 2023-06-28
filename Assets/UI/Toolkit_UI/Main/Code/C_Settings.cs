using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Settings : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreenW1;

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
        Debug.Log("before");
        switchScreenW1.OpenHelp();
        Debug.Log("after");
    }

    void Store()
    {
        switchScreenW1.OpenStore();

    }

    void Back()
    {
        Debug.Log("afterr");
        switchScreenW1.OpenMain();
    }


}



