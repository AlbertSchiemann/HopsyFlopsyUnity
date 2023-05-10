using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelScrpit : MonoBehaviour


{
    public static GameObject ActiveMenu;

    [SerializeField] GameObject beforeMenu;
    [SerializeField] GameObject playingMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject looseMenu;
    // Start is called before the first frame update
    void Start()
    {
        ActiveMenu = beforeMenu;
    }

 public void OpenBefore()
    {
        beforeMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = beforeMenu;


    }
 public void OpenPlaying()
    {

        playingMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = playingMenu;
    }

    public void OpenPause()
    {
        pauseMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = pauseMenu;


    }
    public void OpeWin()
    {

        winMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = winMenu;
    }
    public void OpenLoose()
    {

        looseMenu.SetActive(true);
        ActiveMenu.SetActive(false);
        ActiveMenu = looseMenu;
    }
 
}
