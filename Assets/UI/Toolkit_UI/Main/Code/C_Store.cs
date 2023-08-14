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

    public Button butBack;
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

    VisualElement UpperCorner;

    [SerializeField] private AudioClip[] _UISound;

    Label txtCurrency;

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
        }
        txtCurrency.text = AlwaysThere.FishMoney.ToString();
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
        SoundManager.Instance.PlaySound(_UISound);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin1;
    }
    public void EquipSkin2()
    {
        SoundManager.Instance.PlaySound(_UISound);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin2;
    }
    public void EquipSkin3()
    {
        SoundManager.Instance.PlaySound(_UISound);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin3;
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