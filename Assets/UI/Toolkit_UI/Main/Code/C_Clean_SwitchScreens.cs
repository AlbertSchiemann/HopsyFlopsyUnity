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

        TK_mainMenu.enabled = true;
        TK_helpMenu.enabled = false;
        TK_settingsMenu.enabled = false;
        TK_storeMenu.enabled = false;
        TK_w1Menu.enabled = false;


        if      (AlwaysThere.MainMenu_Index == 1) OpenHelp();  //with these if (elses) you can directly open other canvasses from other scenes
        else if (AlwaysThere.MainMenu_Index == 2) OpenSettings();
        else if (AlwaysThere.MainMenu_Index == 3) OpenStore();
        else if (AlwaysThere.MainMenu_Index == 4) OpenW1();

        AlwaysThere.MainMenu_Index = 0;
        ActiveDocument = TK_mainMenu;
    }
    public void OpenMain()
    {

        TK_mainMenu.enabled=true;
        if (TK_mainMenu != ActiveDocument) ActiveDocument.enabled=false; //if the canvas already is open then dont close it
        ActiveDocument = TK_mainMenu;


    }
    public void OpenHelp()
    {

        TK_helpMenu.enabled = true;
        if (TK_helpMenu != ActiveDocument) ActiveDocument.enabled = false;
        ActiveDocument = TK_helpMenu;

    }


    public void OpenSettings()
    {
        TK_settingsMenu.enabled = true;
        if (TK_settingsMenu != ActiveDocument) ActiveDocument.enabled = false;
        ActiveDocument = TK_settingsMenu;
    }

   
    public void OpenStore()
    {

        TK_storeMenu.enabled = true;
        if (TK_storeMenu != ActiveDocument) ActiveDocument.enabled = false;
        ActiveDocument = TK_storeMenu;
    }


    public void OpenW1()
    {

        TK_w1Menu.enabled = true;
        if (TK_storeMenu != ActiveDocument) ActiveDocument.enabled = false;
        ActiveDocument = TK_w1Menu;
    }

}
