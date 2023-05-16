using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenuScript : MonoBehaviour


{
    public static GameObject ActiveMenu;
    public static GameObject ActiveSettings;


    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject helpMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject storeMenu;
    [SerializeField] GameObject w1Menu;

    [SerializeField] GameObject settingsMain;
    [SerializeField] GameObject settingsCredits;
    [SerializeField] GameObject settingsSound;
    [SerializeField] GameObject settingsContact;

    public static GameObject MainMenu;
    public static GameObject HelpMenu;
    public static GameObject SettingsMenu;
    public static GameObject StoreMenu;
    public static GameObject W1Menu;

    public static GameObject SettingsSound;
    public static GameObject SettingsMain;
    public static GameObject SettingsCredits;
    public static GameObject StoreContact;
    // Start is called before the first frame update
    void Start()
    {
        ActiveMenu = mainMenu;
        ActiveSettings = settingsMenu;
        
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
        ActiveMenu.SetActive(false);
        ActiveMenu = settingsMenu;
        settingsSound.SetActive(false);


    }       
    
                public void OpenSound()
                {

                    settingsSound.SetActive(true);
                   // ActiveMenu.SetActive(false);
                    ActiveSettings = settingsSound;
                }

                public void OpenSettingsMain()
                {

                    settingsMain.SetActive(true);
                    ActiveMenu.SetActive(false);
                    ActiveMenu = settingsMain;
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
