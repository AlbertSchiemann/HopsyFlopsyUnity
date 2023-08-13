using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Main : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreen;

    Button butPlayLast;
    Button butMainLevel;
    Button butWorld1;

    //public Button butBack;
    Button butStore;
    Button butHelp;
    Button butSettings;


    VisualElement LoadingFish;
    VisualElement LoadingFish_;

    Label txtCurrency;
   
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

        txtCurrency = root.Q<Label>("txt_currency");

        butHelp.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;
        butPlayLast.clicked += PlayLast;
        butMainLevel.clicked += MainLevel;
        butWorld1.clicked += W1;

        LoadingFish.style.display = DisplayStyle.None;
        
        
    }


    private void Start()
    {
        txtCurrency.text = AlwaysThere.FishMoney.ToString();
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
        LoadingFish.style.display = DisplayStyle.Flex;
        butPlayLast.style.display = DisplayStyle.None;
        LoadingFish_.style.rotate = new Rotate(90);
        C_UI_OpenOther.ToLastLevel();
    }

    void MainLevel()
    {
        LoadingFish.style.display = DisplayStyle.Flex;
        butPlayLast.style.display = DisplayStyle.None;
        LoadingFish_.style.rotate = new Rotate(90);
        C_UI_OpenOther.ToMain_Level();
    }

}

