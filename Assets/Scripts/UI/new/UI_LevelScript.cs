using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UI_LevelScript : MonoBehaviour


{
    public static GameObject ActiveMenu;
    public static GameObject ActiveSettings;
    [SerializeField] UI_Script_WaterBar waterBar;

    [SerializeField] GameObject beforeMenu;
    [SerializeField] GameObject playingMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject looseMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject helpMenu;

    [SerializeField] GameObject settingsCredits;
    [SerializeField] GameObject settingsSound;
    [SerializeField] GameObject settingsContact;
    [SerializeField] GameObject settingsLanguage;

    [SerializeField] GameObject darkerBackground;

    [SerializeField] GameObject winCurrencyText;

    public static bool WinCurrencyText = false;

    private bool WON = false;
    // Start is called before the first frame update
    void Start()
    {
        C_UI_OpenOther.SaveLastLevel(); //for opening the last level

        ActiveMenu = beforeMenu;
        ActiveMenu.SetActive(true);   //this block of code makes it unimportant which inspectors of the whole prefab you have turned on right now
        playingMenu.SetActive(false);
        pauseMenu.SetActive(false);
        looseMenu.SetActive(false);
        winMenu.SetActive(false);
        settingsMenu.SetActive(false);
        helpMenu.SetActive(false);
    }

 public void OpenBefore()
    {
        darkerBackground.SetActive(true);
        beforeMenu.SetActive(true);
        if (beforeMenu!=ActiveMenu) ActiveMenu.SetActive(false);
        ActiveMenu = beforeMenu;


    }
 public void OpenPlaying()
    {
        GameObject gameStateManager = GameObject.Find("GameStateManager");   //This searches and finds the GameStateManager Object
        gameStateManager.GetComponent<GameStateManagerScript>().StartGame(); //This executes a function in the script component of the found Object

        darkerBackground.SetActive(false);
        playingMenu.SetActive(true);
        if (playingMenu != ActiveMenu) ActiveMenu.SetActive(false);
        ActiveMenu = playingMenu;
        Time.timeScale = 1f;
    }

    public void OpenPause()
    {
        // GameObject gameStateManager = GameObject.Find("GameStateManager"); 
        // gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        darkerBackground.SetActive(true);
        pauseMenu.SetActive(true);
        if (pauseMenu != ActiveMenu) ActiveMenu.SetActive(false);
        ActiveMenu = pauseMenu;
        Time.timeScale = 0f;

    }
    public void OpenWin()
    {
        Debug.Log("1st win");

        GameObject gameStateManager = GameObject.Find("GameStateManager");
        gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        Debug.Log("LALALALA");

        darkerBackground.SetActive(true);
        winMenu.SetActive(true);
        if (winMenu != ActiveMenu) ActiveMenu.SetActive(false);
        ActiveMenu = winMenu;

        if (WinCurrencyText==true) winCurrencyText.SetActive(true);
        else winCurrencyText.SetActive(false);

       // WON = true;

    }
    public void OpenLoose()
    {
        if (!WON)
        {
            GameObject gameStateManager = GameObject.Find("GameStateManager");
            gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

            darkerBackground.SetActive(true);
            looseMenu.SetActive(true);
            if (looseMenu != ActiveMenu) ActiveMenu.SetActive(false);
            ActiveMenu = looseMenu;
        }
    }
    public void OpenLevelSettings()
    {
        GameObject gameStateManager = GameObject.Find("GameStateManager");
        gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        darkerBackground.SetActive(true);
        settingsMenu.SetActive(true);
        if (settingsMenu != ActiveMenu) ActiveMenu.SetActive(false);
        ActiveMenu = settingsMenu;
        ActiveSettings = settingsSound;

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

    public void OpenLevelHelp()
    {
        GameObject gameStateManager = GameObject.Find("GameStateManager");
        gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        darkerBackground.SetActive(true);
        helpMenu.SetActive(true);
        if (helpMenu != ActiveMenu) ActiveMenu.SetActive(false);
        ActiveMenu = helpMenu;
    }
}
