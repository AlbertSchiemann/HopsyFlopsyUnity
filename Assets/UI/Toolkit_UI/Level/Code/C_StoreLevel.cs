using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
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
    Button butEquip4;

    public GameObject skinToEquip1;
    public GameObject skinToEquip2;
    public GameObject skinToEquip3;
    public GameObject skinToEquip4;
    private SkinLoader player;

    [SerializeField] private AudioClip[] _UISound;
    
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

        player = GameObject.Find("Player3D Grid").GetComponent<SkinLoader>();

        butEquip1.clicked += EquipSkin1;
        butEquip2.clicked += EquipSkin2;
        butEquip3.clicked += EquipSkin3;
        butEquip4.clicked += EquipSkin4;

    }

    public void EquipSkin1()
    {
        SoundManager.Instance.PlaySound(_UISound);
        player.ChangeSkin(skinToEquip1);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin1;
    }
    public void EquipSkin2()
    {
        SoundManager.Instance.PlaySound(_UISound);
        player.ChangeSkin(skinToEquip2);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin2;
    }
    public void EquipSkin3()
    {
        SoundManager.Instance.PlaySound(_UISound);
        player.ChangeSkin(skinToEquip3);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin3;
    }
    public void EquipSkin4()
    {
        SoundManager.Instance.PlaySound(_UISound);
        player.ChangeSkin(skinToEquip4);
        AlwaysThere.currentSkin = (int)AlwaysThere.Skin.Skin4;
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
        switchScreenStore.OpenPause();
    }
}