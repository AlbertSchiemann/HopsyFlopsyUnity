using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_SettingsLevel : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butBack;
    Button butStore;
    Button butHelp;

    Button butCredits;
    Button butSound;
    Button butContact;


    VisualElement visCredits;
    VisualElement visSound;
    Label txtContact;

    void OnEnable()
    {
        VisualElement rootSettings = GetComponent<UIDocument>().rootVisualElement;

        butHelp = rootSettings.Q<Button>("but_help");
        butStore = rootSettings.Q<Button>("but_store");
        butBack = rootSettings.Q<Button>("but_back");

        butCredits = rootSettings.Q<Button>("but_Credits");
        butSound = rootSettings.Q<Button>("but_Sound");
        butContact = rootSettings.Q<Button>("but_contact");

        visCredits = rootSettings.Q<VisualElement>("vis_credits");
        visSound = rootSettings.Q<VisualElement>("vis_sound");
        txtContact = rootSettings.Q<Label>("txt_contact");



        butCredits.clicked += Credits;
        butSound.clicked += Sound;
        butContact.clicked += Contact;

        butHelp.clicked += Help;
        butStore.clicked += Store;
        butBack.clicked += Back;

        Sound();

    }

    void Credits()
    {
        visCredits.style.display = DisplayStyle.Flex;
        visSound.style.display = DisplayStyle.None;
        txtContact.style.display = DisplayStyle.None;
    }
    void Sound()
    {
        visCredits.style.display = DisplayStyle.None;
        visSound.style.display = DisplayStyle.Flex;
        txtContact.style.display = DisplayStyle.None;
    }
    void Contact()
    {
        txtContact.style.display = DisplayStyle.Flex;
        visSound.style.display = DisplayStyle.None;
        visCredits.style.display = DisplayStyle.None;
    }


    void Help()
    {
        switchScreen.OpenHelp();
    }

    void Store()
    {
        switchScreen.OpenStore();

    }

    void Back()
    {
        switchScreen.OpenPause();
    }


}



