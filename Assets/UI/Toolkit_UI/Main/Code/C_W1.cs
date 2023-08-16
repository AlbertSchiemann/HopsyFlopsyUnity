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
     Button butLevel4;


     Button butBack;
     Button butStore;
     Button butHelpi;
     Button butSettings;

    VisualElement LoadingFish;
    VisualElement LoadingFish_;

    VisualElement s11;
    VisualElement s12;
    VisualElement s13;

    VisualElement s21;
    VisualElement s22;
    VisualElement s23;

    VisualElement s31;
    VisualElement s32;
    VisualElement s33;

    VisualElement s41;
    VisualElement s42;
    VisualElement s43;

    Label txtCurrency;
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        txtCurrency = root.Q<Label>("txt_currency");

        butHelpi = root.Q<Button>("but_help");
        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");
        butBack = root.Q<Button>("Back");

        butLevel1 = root.Q<Button>("Level1");
        butLevel2 = root.Q<Button>("Level2");
        butLevel3 = root.Q<Button>("Level3");

        LoadingFish = root.Q<VisualElement>("vis_load");
        LoadingFish_ = root.Q<VisualElement>("vis_load_");

        s11 = root.Q<VisualElement>("vis_star11");
        s12 = root.Q<VisualElement>("vis_star12");
        s13 = root.Q<VisualElement>("vis_star13");

        s21 = root.Q<VisualElement>("vis_star21");
        s22 = root.Q<VisualElement>("vis_star22");
        s23 = root.Q<VisualElement>("vis_star23");

        s31 = root.Q<VisualElement>("vis_star31");
        s32 = root.Q<VisualElement>("vis_star32");
        s33 = root.Q<VisualElement>("vis_star33");

        s41 = root.Q<VisualElement>("vis_star41");
        s42 = root.Q<VisualElement>("vis_star42");
        s43 = root.Q<VisualElement>("vis_star43");

        butHelpi.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;
        butLevel1.clicked += Level1;
        butLevel2.clicked += Level2;
        butLevel3.clicked += Level3;
        butLevel4.clicked += Level4;
        butBack.clicked += Back;

        LoadingFish.style.display = DisplayStyle.None;


        if (!AlwaysThere.level2Unlocked) butLevel2.style.unityBackgroundImageTintColor = new Color(0.5f, 0.5f, 0.5f, 1f);
        if (!AlwaysThere.level3Unlocked) butLevel3.style.unityBackgroundImageTintColor = new Color(0.5f, 0.5f, 0.5f, 1f);
        if (!AlwaysThere.level4Unlocked) butLevel3.style.unityBackgroundImageTintColor = new Color(0.5f, 0.5f, 0.5f, 1f);

        if (!AlwaysThere.level2Unlocked) s11.style.unityBackgroundImageTintColor = new Color(0.34f, 0.34f, 0.34f, 1f);
        if (AlwaysThere.TimeStar) s12.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        if (AlwaysThere.CurrencyStar) s13.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);

        if (!AlwaysThere.level3Unlocked) s21.style.unityBackgroundImageTintColor = new Color(0.34f, 0.34f, 0.34f, 1f);
        if (AlwaysThere.TimeStar2) s22.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        if (AlwaysThere.CurrencyStar2) s23.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);

        if (!AlwaysThere.level4Unlocked) s31.style.unityBackgroundImageTintColor = new Color(0.34f, 0.34f, 0.34f, 1f);
        if (AlwaysThere.TimeStar3) s32.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        if (AlwaysThere.CurrencyStar3) s33.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);

        if (!AlwaysThere.level5Unlocked) s31.style.unityBackgroundImageTintColor = new Color(0.34f, 0.34f, 0.34f, 1f);
        if (AlwaysThere.TimeStar4) s32.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
        if (AlwaysThere.CurrencyStar4) s33.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);

        txtCurrency.text = AlwaysThere.FishMoney.ToString();
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
        switchScreenW1.OpenMain();
    }

    void Level1()
    {
        LoadingFish.style.display = DisplayStyle.Flex;
        LoadingFish_.style.rotate = new Rotate(90);
        C_UI_OpenOther.ToLevel1();
    }
    void Level2()
    {

        if (AlwaysThere.level2Unlocked) 
        { 
            C_UI_OpenOther.ToLevel2(); 
            LoadingFish.style.display = DisplayStyle.Flex;
            LoadingFish_.style.rotate = new Rotate(90);
        }
    }
    void Level3()
    {
        if (AlwaysThere.level3Unlocked)
        {
            C_UI_OpenOther.ToLevel3();
            LoadingFish.style.display = DisplayStyle.Flex;
            LoadingFish_.style.rotate = new Rotate(90);
        }
    }
    void Level4()
    {
        if (AlwaysThere.level4Unlocked)
        {
            C_UI_OpenOther.ToLevel4();
            LoadingFish.style.display = DisplayStyle.Flex;
            LoadingFish_.style.rotate = new Rotate(90);
        }
    }
}

   

