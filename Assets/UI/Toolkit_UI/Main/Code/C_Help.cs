using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Help : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreenW1;

    Button butBack;
    Button butStore;
    Button butSettings;


    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;


        //butStore = root.Q<Button>("but_store");
        //butSettings = root.Q<Button>("but_settings");
        //butBack = root.Q<Button>("but_back");


        //butStore.clicked += Store;
        //butSettings.clicked += Settings;
        //butBack.clicked += Back;

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


}




