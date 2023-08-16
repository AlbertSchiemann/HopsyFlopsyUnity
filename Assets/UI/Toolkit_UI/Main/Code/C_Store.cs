using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Store : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreenStore;

    Button butBack;
    Button butHelpi;
    Button butSettings;

    Button butEquip1;
    Button butEquip2;
    Button butEquip3;


    Button butBuy2;
    Button butBuy3;

    bool bought2 =false;
    bool bought3 = false;

    float Time =0;

    public Sprite Equip, Equiped;

    VisualElement UpperCorner;
    VisualElement Lock2, Lock3;

    [SerializeField] private AudioClip[] _UISound;

    Label txtCurrency;
    VisualElement visPrice3, visPrice2;


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butHelpi = root.Q<Button>("but_help");
        butSettings = root.Q<Button>("but_settings");
        butBack = root.Q<Button>("but_back");

        butEquip1 = root.Q<Button>("but_itemEquip1");
        butEquip2 = root.Q<Button>("but_itemEquip2");
        butEquip3 = root.Q<Button>("but_itemEquip3");

        butBuy2 = root.Q<Button>("but_buy2");
        butBuy3 = root.Q<Button>("but_buy3");

        txtCurrency = root.Q<Label>("txt_currency");

        UpperCorner = root.Q<VisualElement>("vis_fish");

        Lock2 = root.Q<VisualElement>("vis_lock2");
        Lock3 = root.Q<VisualElement>("vis_lock3");

        visPrice2 = root.Q<Label>("txt_price2");
        visPrice3 = root.Q<Label>("txt_price3");

        butHelpi.clicked += Help;
        butSettings.clicked += Settings;
        butBack.clicked += Back;

     //   player = GameObject.Find("Player3D Grid").GetComponent<SkinLoader>();

        butEquip1.clicked += EquipSkin1;
        butEquip2.clicked += EquipSkin2;
        butEquip3.clicked += EquipSkin3;

        butBuy2.clicked += Buy2;
        butBuy3.clicked += Buy3;

        if (!bought2)
        {
            butBuy2.style.display = DisplayStyle.Flex;
            butEquip2.style.display = DisplayStyle.None;
        }
        else
        {
            butBuy2.style.display = DisplayStyle.None;
            butEquip2.style.display = DisplayStyle.Flex;
            visPrice2.style.display = DisplayStyle.None;
            Lock2.style.display = DisplayStyle.None;
        }

        if (!bought3)
        {
            butBuy3.style.display = DisplayStyle.Flex;
            butEquip3.style.display = DisplayStyle.None;
        }
        else
        {
            butBuy3.style.display = DisplayStyle.None;
            butEquip3.style.display = DisplayStyle.Flex;
            visPrice3.style.display = DisplayStyle.None;
            Lock3.style.display = DisplayStyle.None;
        }
        txtCurrency.text = AlwaysThere.FishMoney.ToString();

        if (AlwaysThere.currentSkin == 0) EquipSkin1();
        else if (AlwaysThere.currentSkin == 1) EquipSkin2();
        else if (AlwaysThere.currentSkin == 2) EquipSkin3();
    }

    private void Start()
    {
       
        
        if (AlwaysThere.skin2Bought) bought2 = true;
        
        if (AlwaysThere.skin3Bought) bought3 = true;

    }
    public void Buy2()
    {
        if (AlwaysThere.FishMoney >= 100)
        {
            butBuy2.style.display = DisplayStyle.None;
            butEquip2.style.display = DisplayStyle.Flex;
            AlwaysThere.skin2Bought = true;
            AlwaysThere.FishMoney -= 100;
            txtCurrency.text = AlwaysThere.FishMoney.ToString();
            visPrice2.style.display = DisplayStyle.None;
            Lock3.style.display = DisplayStyle.None;
        }
        else
        {
            butBuy2.style.unityBackgroundImageTintColor =  Color.red;
            UpperCorner.style.unityBackgroundImageTintColor = Color.red;
            Invoke(nameof(ColorToNormal2), 0.3f);
        }
    }
     void ColorToNormal2()
    {
        butBuy2.style.unityBackgroundImageTintColor = Color.white;
        UpperCorner.style.unityBackgroundImageTintColor = Color.white;
    }
    public void Buy3()
    {
        if (AlwaysThere.FishMoney >= 200)
        {
            butBuy3.style.display = DisplayStyle.None;
            butEquip3.style.display = DisplayStyle.Flex;
            AlwaysThere.skin3Bought = true;
            AlwaysThere.FishMoney -= 200;
            txtCurrency.text = AlwaysThere.FishMoney.ToString();
            visPrice3.style.display = DisplayStyle.None;
            Lock3.style.display = DisplayStyle.None;
        }
        else
        {
            butBuy3.style.unityBackgroundImageTintColor = Color.red;
            UpperCorner.style.unityBackgroundImageTintColor = Color.red;
            Invoke(nameof(ColorToNormal3), 0.3f);
        }
    }
    void ColorToNormal3()
    {
        butBuy3.style.unityBackgroundImageTintColor = Color.white;
        UpperCorner.style.unityBackgroundImageTintColor = Color.white;
    }
    public void EquipSkin1()
    {
        //SoundManager.Instance.PlaySound(_UISound);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin1;
        butEquip1.style.backgroundImage = new StyleBackground(Equiped);
        if (bought2) butEquip2.style.backgroundImage = new StyleBackground(Equip);
        if (bought3) butEquip3.style.backgroundImage = new StyleBackground(Equip);
    }
    public void EquipSkin2()
    {
        SoundManager.Instance.PlaySound(_UISound);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin2;
        butEquip1.style.unityBackgroundImageTintColor = Color.white;
        butEquip1.style.backgroundImage = new StyleBackground(Equip);
        butEquip2.style.backgroundImage = new StyleBackground(Equiped);
        if (bought3) butEquip3.style.backgroundImage = new StyleBackground(Equip);
    }
    public void EquipSkin3()
    {
        SoundManager.Instance.PlaySound(_UISound);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin3;
        butEquip1.style.backgroundImage = new StyleBackground(Equip);
        if (bought2) butEquip2.style.backgroundImage = new StyleBackground(Equip);
        butEquip3.style.backgroundImage = new StyleBackground(Equiped);
    }

    public void Help()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreenStore.OpenHelp();
    }

    public void Settings()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreenStore.OpenSettings();

    }

    public void Back()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreenStore.OpenMain();
    }
}