using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Clean_SwitchScreens : MonoBehaviour
{
    public static UIDocument ActiveDocument;

    [SerializeField] UIDocument TK_mainMenu;
    [SerializeField] UIDocument TK_helpMenu;
    [SerializeField] UIDocument TK_settingsMenu;
    [SerializeField] UIDocument TK_storeMenu;
    [SerializeField] UIDocument TK_w1Menu;
    void Start()
    {
        
        TK_mainMenu.gameObject.SetActive(true);
        TK_helpMenu.gameObject.SetActive(false);
        TK_settingsMenu.gameObject.SetActive(false);
        TK_storeMenu.gameObject.SetActive(false);
        TK_w1Menu.gameObject.SetActive(false);

        ActiveDocument = TK_mainMenu;

        if      (AlwaysThere.MainMenu_Index == 1) OpenHelp();  //with these if (elses) you can directly open other canvasses from other scenes
        else if (AlwaysThere.MainMenu_Index == 2) OpenSettings();
        else if (AlwaysThere.MainMenu_Index == 3) OpenStore();
        else if (AlwaysThere.MainMenu_Index == 4) OpenW1();

        AlwaysThere.MainMenu_Index = 0;
    }
    public void OpenMain()
    {

        TK_mainMenu.gameObject.SetActive(true);
        if (TK_mainMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false); //if the canvas already is open then dont close it
        ActiveDocument = TK_mainMenu;


    }
    public void OpenHelp()
    {

        TK_helpMenu.gameObject.SetActive(true);
        if (TK_helpMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_helpMenu;

    }


    public void OpenSettings()
    {
        TK_settingsMenu.gameObject.SetActive(true);
        if (TK_settingsMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_settingsMenu;
    }

   
    public void OpenStore()
    {

        TK_storeMenu.gameObject.SetActive(true);
        if (TK_storeMenu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_storeMenu;
    }


    public void OpenW1()
    {

        TK_w1Menu.gameObject.SetActive(true);
        if (TK_w1Menu != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_w1Menu;
    }

}
