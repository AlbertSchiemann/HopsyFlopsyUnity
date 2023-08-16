using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class C_StoreLevel : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreenStore;

    Button butBack;
    Button butHelpi;
    Button butSettings;

    Button butEquip1;
    Button butEquip2;
    Button butEquip3;

    Button butBuy2;
    Button butBuy3;

    public GameObject skinToEquip1;
    public GameObject skinToEquip2;
    public GameObject skinToEquip3;

    public Sprite Equip, Equiped;

    VisualElement UpperCorner;
    GameObject UpperCorner2;
    private SkinLoader player;

    VisualElement visPrice3, visPrice2;
    VisualElement Lock2, Lock3;
    bool bought2 = false;
    bool bought3 = false;

    [SerializeField] private AudioClip[] _UISound;
    Label txtCurrency;

    VisualElement Main;
    [SerializeField] private SwipeManager swipeManager;

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

        visPrice2 = root.Q<Label>("txt_price2");
        visPrice3 = root.Q<Label>("txt_price3");

        Lock2 = root.Q<VisualElement>("vis_lock2");
        Lock3 = root.Q<VisualElement>("vis_lock3");

        Main = root.Q<VisualElement>("vis_store");

        Main.style.unityBackgroundImageTintColor = new Color(0f, 0f, 0f, 0f);

        butHelpi.clicked += Help;
        butSettings.clicked += Settings;
        butBack.clicked += Back;

        player = GameObject.Find("Player3D Grid").GetComponent<SkinLoader>();

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
        Debug.Log("");

        if (AlwaysThere.skin3Bought) bought3 = true;

    }
    public void Buy2()
    {
        swipeManager.enabled = false;
        if (AlwaysThere.FishMoney >= 100)
        {
            butBuy2.style.display = DisplayStyle.None;
            butEquip2.style.display = DisplayStyle.Flex;
            AlwaysThere.skin2Bought = true;
            AlwaysThere.FishMoney -= 100;
            txtCurrency.text = AlwaysThere.FishMoney.ToString();
            visPrice2.style.display = DisplayStyle.None;
            Lock2.style.display = DisplayStyle.None;
        }
        else
        {
            butBuy2.style.unityBackgroundImageTintColor = Color.red;
            UpperCorner.style.unityBackgroundImageTintColor = Color.red;
            Invoke(nameof(ColorToNormal2), 0.3f);
        }
    }
    public void Buy3()
    {
        swipeManager.enabled = false;
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

    void ColorToNormal2()
    {
        butBuy2.style.unityBackgroundImageTintColor = Color.white;
        UpperCorner.style.unityBackgroundImageTintColor = Color.white;
    }
    void ColorToNormal3()
    {
        butBuy3.style.unityBackgroundImageTintColor = Color.white;
        UpperCorner.style.unityBackgroundImageTintColor = Color.white;
    }
    public void EquipSkin1()
    {
        swipeManager.enabled = false;
        SoundManager.Instance.PlaySound(_UISound);
        player.ChangeSkin(skinToEquip1);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin1;
        butEquip1.style.backgroundImage = new StyleBackground(Equiped);
        if (bought2) butEquip2.style.backgroundImage = new StyleBackground(Equip);
        if (bought3) butEquip3.style.backgroundImage = new StyleBackground(Equip);
    }
    public void EquipSkin2()
    {
        swipeManager.enabled = false;
        SoundManager.Instance.PlaySound(_UISound);
        player.ChangeSkin(skinToEquip2);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin2;
        butEquip1.style.backgroundImage = new StyleBackground(Equip);
        if (bought2) butEquip2.style.backgroundImage = new StyleBackground(Equiped);
        if (bought3) butEquip3.style.backgroundImage = new StyleBackground(Equip);
    }
    public void EquipSkin3()
    {
        swipeManager.enabled = false;
        SoundManager.Instance.PlaySound(_UISound);
        player.ChangeSkin(skinToEquip3);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin3;
        butEquip1.style.backgroundImage = new StyleBackground(Equip);
        if (bought2) butEquip2.style.backgroundImage = new StyleBackground(Equip);
        if (bought3) butEquip3.style.backgroundImage = new StyleBackground(Equiped);
    }

    public void Help()
    {
        swipeManager.enabled = false;
        SoundManager.Instance.PlaySound(_UISound);
        switchScreenStore.OpenHelp();
    }

    public void Settings()
    {
        swipeManager.enabled = false;
        SoundManager.Instance.PlaySound(_UISound);
        switchScreenStore.OpenSettings();
    }

    public void Back()
    {
        swipeManager.enabled = false;
        SoundManager.Instance.PlaySound(_UISound);
        switchScreenStore.OpenPause();
    }
}