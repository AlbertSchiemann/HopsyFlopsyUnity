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
void Update()
    {
         if (AlwaysThere.OpenLevelLoose==true) 
        {
            OpenLoose();
            AlwaysThere.OpenLevelLoose = false;
        }

        if (AlwaysThere.OpenLevelWin == true)
        {
            OpenWin();
            AlwaysThere.OpenLevelWin = false;
        }
    }
 public void OpenBefore()
    {
        darkerBackground.SetActive(true);
        beforeMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = beforeMenu;


    }
 public void OpenPlaying()
    {
        darkerBackground.SetActive(false);
        playingMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = playingMenu;
        Time.timeScale = 1f;
    }

    public void OpenPause()
    {
        darkerBackground.SetActive(true);
        pauseMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = pauseMenu;
        Time.timeScale = 0f;

    }
    public void OpenWin()
    {
        darkerBackground.SetActive(true);
        winMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = winMenu;
        
    }
    public void OpenLoose()
    {
        darkerBackground.SetActive(true);
        looseMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = looseMenu;
    }
 
}
