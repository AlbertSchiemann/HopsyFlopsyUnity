using System.Collections;
using System.Collections.Generic;
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
    Button butEquip4;

    public GameObject skinToEquip1;
    public GameObject skinToEquip2;
    public GameObject skinToEquip3;
    public GameObject skinToEquip4;
    private SkinLoader player;
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butHelpi = root.Q<Button>("but_help");
        butSettings = root.Q<Button>("but_settings");
        butBack = root.Q<Button>("but_back");

        butEquip1 = root.Q<Button>("but_itemEquip1");
        butEquip2 = root.Q<Button>("but_itemEquip2");
        butEquip3 = root.Q<Button>("but_itemEquip3");
        butEquip4 = root.Q<Button>("but_itemEquip4");

        butHelpi.clicked += Help;
        butSettings.clicked += Settings;
        butBack.clicked += Back;

        butEquip1.clicked += EquipSkin1;
        butEquip2.clicked += EquipSkin2;
        butEquip3.clicked += EquipSkin3;
        butEquip4.clicked += EquipSkin4;

    }

    private void Awake()
    {
        player = GameObject.Find("Player3D Grid").GetComponent<SkinLoader>();
    }
    public void EquipSkin1()
    {
        Debug.Log("skin changed");
        player.ChangeSkin(skinToEquip1);
        Debug.Log("skin changed");
    }
    public void EquipSkin2()
    {
        player.ChangeSkin(skinToEquip2);
    }
    public void EquipSkin3()
    {
        player.ChangeSkin(skinToEquip3);
    }
    public void EquipSkin4()
    {
        player.ChangeSkin(skinToEquip4);
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
        switchScreenStore.OpenMain();
    }
}