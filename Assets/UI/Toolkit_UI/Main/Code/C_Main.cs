using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Main : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreen;

    public Button butPlayLast;
    public Button butMainLevel;
    public Button butWorld1;

    //public Button butBack;
    public Button butStore;
    public Button butHelp;
    public Button butSettings;

    public Button butArtist;
    public Button butAlbert;
    public Button butCarl;
    public Button butDenis;
    public Button butJulius;
    public Button butPatty;


    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butAlbert = root.Q<Button>("LV_albert");
        butArtist = root.Q<Button>("LV_artist");
        butDenis = root.Q<Button>("LV_denis");
        butJulius = root.Q<Button>("LV_julius");
        butPatty = root.Q<Button>("LV_patty");
        butCarl = root.Q<Button>("LV_carl");

        butHelp = root.Q<Button>("but_help");
        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");

        butPlayLast = root.Q<Button>("PlayLast");
        butMainLevel = root.Q<Button>("MainLv");
        butWorld1 = root.Q<Button>("but_W1");


        butAlbert.clicked += Albert;
        butArtist.clicked += Artist;
        butDenis.clicked += Denis;
        butJulius.clicked += Julius;
        butPatty.clicked += Patty;
        butCarl.clicked += Carl;
        butHelp.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;
        butPlayLast.clicked += PlayLast;
        butMainLevel.clicked += MainLevel;
        butWorld1.clicked += W1;


    }

    void Albert()
    {
        C_UI_OpenOther.ToAlbert();

    }

    void Artist()
        {
        C_UI_OpenOther.ToArtists();

    }

    void Julius()
        {
        C_UI_OpenOther.ToJulius();

    }

    void Denis()
        {
        C_UI_OpenOther.ToDenis();

    }

    void Patty ()
        {
        C_UI_OpenOther.ToPatty();

    }

    void Carl()
        {
        C_UI_OpenOther.ToCarl();

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
        C_UI_OpenOther.ToLastLevel();
    }

    void MainLevel()
    {
        C_UI_OpenOther.ToMain_Level();
    }

}

