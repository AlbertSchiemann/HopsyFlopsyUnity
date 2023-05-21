using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelScript : MonoBehaviour


{
    public static GameObject ActiveMenu;

    [SerializeField] GameObject beforeMenu;
    [SerializeField] GameObject playingMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject looseMenu;

    [SerializeField] GameObject darkerBackground;
    // Start is called before the first frame update
    void Start()
    {

        ActiveMenu = beforeMenu;
        ActiveMenu.SetActive(true);
        playingMenu.SetActive(false);
        pauseMenu.SetActive(false);
        looseMenu.SetActive(false);
        winMenu.SetActive(false);
    }
//void Update()
//    {
//         if (AlwaysThere.OpenLevelLoose==true) 
//        {
//            OpenLoose();
//            AlwaysThere.OpenLevelLoose = false;
//        }

//        if (AlwaysThere.OpenLevelWin == true)
//        {
//            OpenWin();
//            AlwaysThere.OpenLevelWin = false;
//        }
//    }
 public void OpenBefore()
    {
        darkerBackground.SetActive(true);
        beforeMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = beforeMenu;


    }
 public void OpenPlaying()
    {
        GameObject gameStateManager = GameObject.Find("GameStateManager");   //This searches and finds the GameStateManager Object
        gameStateManager.GetComponent<GameStateManagerScript>().StartGame(); //This executes a function in the script component of the found Object

        darkerBackground.SetActive(false);
        playingMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = playingMenu;
        Time.timeScale = 1f;
    }

    public void OpenPause()
    {
        GameObject gameStateManager = GameObject.Find("GameStateManager"); 
        gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        darkerBackground.SetActive(true);
        pauseMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = pauseMenu;
        Time.timeScale = 0f;

    }
    public void OpenWin()
    {
        GameObject gameStateManager = GameObject.Find("GameStateManager");
        gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        darkerBackground.SetActive(true);
        winMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = winMenu;
        
    }
    public void OpenLoose()
    {
        GameObject gameStateManager = GameObject.Find("GameStateManager");
        gameStateManager.GetComponent<GameStateManagerScript>().PauseGame();

        darkerBackground.SetActive(true);
        looseMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = looseMenu;
    }
 
}
