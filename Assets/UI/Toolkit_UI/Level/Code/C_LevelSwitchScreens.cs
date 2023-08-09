using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class C_LevelSwitchScreens : MonoBehaviour
{
    public static UIDocument ActiveDocument;

    [SerializeField] UIDocument TK_beforeMenu;
    [SerializeField] UIDocument TK_playingMenu;
    [SerializeField] UIDocument TK_winMenu;
    [SerializeField] UIDocument TK_looseMenu;
    [SerializeField] UIDocument TK_pauseMenu;  
    
    [SerializeField] UIDocument TK_helpMenu;
    [SerializeField] UIDocument TK_settingsMenu;
    [SerializeField] UIDocument TK_storeMenu;


    private bool WON = false;

    void Start()
    {
        C_UI_OpenOther.SaveLastLevel();

        TK_beforeMenu.gameObject.SetActive(true);
        TK_helpMenu.gameObject.SetActive(false);
        TK_settingsMenu.gameObject.SetActive(false);
        TK_storeMenu.gameObject.SetActive(false);
        TK_playingMenu.gameObject.SetActive(false);
        TK_winMenu.gameObject.SetActive(false);
        TK_looseMenu.gameObject.SetActive(false);
        TK_pauseMenu.gameObject.SetActive(false);

        ActiveDocument = TK_beforeMenu;
    }
    public void OpenBefore()
    {
        //GameObject gameStateManager = GameObject.Find("GameStateManager");
        //gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        TK_beforeMenu.gameObject.SetActive(true);
        if (TK_beforeMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false); //if the canvas already is open then dont close it
        ActiveDocument = TK_beforeMenu;


    }
    public void OpenHelp()
    {
        //GameObject gameStateManager = GameObject.Find("GameStateManager");
        //gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        TK_helpMenu.gameObject.SetActive(true);
        if (TK_helpMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_helpMenu;

    }


    public void OpenSettings()
    {
        //GameObject gameStateManager = GameObject.Find("GameStateManager");
        //gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        TK_settingsMenu.gameObject.SetActive(true);
        if (TK_settingsMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_settingsMenu;
    }


    public void OpenStore()
    {
        //GameObject gameStateManager = GameObject.Find("GameStateManager");
        //gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        TK_storeMenu.gameObject.SetActive(true);
        if (TK_storeMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_storeMenu;
    }


    public void OpenPlaying()
    {
        //GameObject gameStateManager = GameObject.Find("GameStateManager");   //This searches and finds the GameStateManager Object
        //gameStateManager.GetComponent<GameStateManagerScript>().StartGame(); //This executes a function in the script component of the found Object

       // Time.timeScale = 1f;

        TK_playingMenu.gameObject.SetActive(true);
        if (TK_playingMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_playingMenu;

    }


    public void OpenWin()
    {
        //GameObject gameStateManager = GameObject.Find("GameStateManager");
        //gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        TK_winMenu.gameObject.SetActive(true);
        if (TK_winMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_winMenu;

        //if (WinCurrencyText == true) winCurrencyText.SetActive(true);  //mit uiToolkit textfeld
        //else winCurrencyText.SetActive(false);

        WON = true;
    }
    public void OpenLoose()
    {
        if (!WON)
        {
            //GameObject gameStateManager = GameObject.Find("GameStateManager");
            //gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

            TK_looseMenu.gameObject.SetActive(true);
            if (TK_looseMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
            ActiveDocument = TK_looseMenu;
        }

    }
    public void OpenPause()
    {

        TK_pauseMenu.gameObject.SetActive(true);
        if (TK_pauseMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_pauseMenu;

        //Time.timeScale = 0f;
    }

}

