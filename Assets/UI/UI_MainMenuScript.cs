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
    // Start is called before the first frame update
    void Start()
    {
        ActiveMenu = mainMenu;
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
