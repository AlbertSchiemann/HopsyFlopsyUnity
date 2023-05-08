using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript2 : MonoBehaviour


{


    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject helpMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 public void OpenMain()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);


    }
 public void OpenHelp()
    {

        helpMenu.SetActive(true);
        mainMenu.SetActive(false);
        Debug.Log("-..");
    }
}
