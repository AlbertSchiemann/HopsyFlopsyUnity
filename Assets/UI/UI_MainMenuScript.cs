using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenuScript : MonoBehaviour


{
    public static GameObject ActiveMenu;

    

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject helpMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject storeMenu;
    [SerializeField] GameObject w1Menu;
    
    public static GameObject MainMenu;
    public static GameObject HelpMenu;
    public static GameObject SettingsMenu;
    public static GameObject StoreMenu;
    public static GameObject W1Menu;
    // Start is called before the first frame update
    void Start()
    {
        ActiveMenu = mainMenu;
        
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
