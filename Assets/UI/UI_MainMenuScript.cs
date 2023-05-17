using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UI_MainMenuScript : MonoBehaviour


{
    public static GameObject ActiveMenu;
    public static GameObject ActiveSettings;


    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject helpMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject storeMenu;
    [SerializeField] GameObject w1Menu;

    [SerializeField] GameObject settingsCredits;
    [SerializeField] GameObject settingsSound;
    [SerializeField] GameObject settingsContact;
    [SerializeField] GameObject settingsLanguage;

    public static GameObject MainMenu;
    public static GameObject HelpMenu;
    public static GameObject SettingsMenu;
    public static GameObject StoreMenu;
    public static GameObject W1Menu;

    public static GameObject SettingsSound;
    public static GameObject SettingsCredits;
    public static GameObject StoreContact;
    public static GameObject StoreLanguage;
    // Start is called before the first frame update
    void Start()
    {
        ActiveMenu = mainMenu;
        ActiveSettings = settingsSound;
        
        if (AlwaysThere.MainMenu_Index == 1) OpenHelp();
        else if (AlwaysThere.MainMenu_Index == 2) OpenSettings();
        else if(AlwaysThere.MainMenu_Index == 3) OpenStore();
        else if(AlwaysThere.MainMenu_Index == 4) OpenW1();
  
        AlwaysThere.MainMenu_Index = 0;

    }

 public void OpenMain()
    {
        mainMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = mainMenu;


    }
 public void OpenHelp()
    {

        helpMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = helpMenu;
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        //helpMenu.SetActive(false);
        //mainMenu.SetActive(false);
        //storeMenu.SetActive(false);
        //w1Menu.SetActive(false);
        ActiveMenu.SetActive(false);
        ActiveMenu = settingsMenu;

        settingsContact.SetActive(false);
        settingsCredits.SetActive(false);
        settingsLanguage.SetActive(false);
        settingsSound.SetActive(true);


    }       
    
                public void OpenSettingsSound()
                {
                settingsSound.SetActive(true);
                if (ActiveSettings != settingsSound)
                {
                    ActiveSettings.SetActive(false);
                    ActiveSettings = settingsSound;
                }
                }

                 public void OpenSettingsLanguage()
                {

                    settingsLanguage.SetActive(true);
                    if (ActiveSettings != settingsLanguage)
                    {
                        ActiveSettings.SetActive(false);
                        ActiveSettings = settingsLanguage;
                    }
                }
                public void OpenSettingsCredits()
                {

                    settingsCredits.SetActive(true);
                    if (ActiveSettings != settingsCredits)
                    {
                        ActiveSettings.SetActive(false);
                        ActiveSettings = settingsCredits;
                    }
                }
                public void OpenSettingsContact()
                {

                    settingsContact.SetActive(true);
                    if (ActiveSettings != settingsContact)
                    {
                        ActiveSettings.SetActive(false);
                        ActiveSettings = settingsContact;
                    }
                }
               
    public void OpenStore()
    {

        storeMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = storeMenu;
    }

 
    public void OpenW1()
    {

        w1Menu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = w1Menu;
    }
 
}
