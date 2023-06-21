using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//namespace TK
//{
public class C_ScreenSwitching : MonoBehaviour


    {
        public static GameObject TK_ActiveMenu;



        [SerializeField] UIDocument TK_mainMenu;
        [SerializeField] UIDocument TK_helpMenu;
        [SerializeField] UIDocument TK_settingsMenu;
        [SerializeField] GameObject TK_storeMenu;
        [SerializeField] GameObject TK_w1Menu;


        void Start () {

        VisualElement Settings;
     //   TK_settingsMenu.enabled=false;
     //   TK_mainMenu.enabled = false;

        UIDocument x = GetComponent<UIDocument>();

        VisualElement root = TK_mainMenu.rootVisualElement;
        VisualElement main = root.Q<VisualElement>("Main");
        main.style.display = DisplayStyle.None;

        //TK_mainMenu.SetActive(true); TK_helpMenu.SetActive(false);
    }
    }
//}

        
//        void Start()
//        {
//            ActiveMenu = mainMenu;

//            mainMenu.SetActive(true);  //this block of code makes it unimportant which inspectors of the whole prefab you have turned on right now
//            helpMenu.SetActive(false);
//            settingsMenu.SetActive(false);
//            storeMenu.SetActive(false);
//            w1Menu.SetActive(false);


//            //if (AlwaysThere.MainMenu_Index == 1) OpenHelp();  //with these if (elses) you can directly open other canvasses from other scenes
//            //else if (AlwaysThere.MainMenu_Index == 2) OpenSettings();
//            //else if (AlwaysThere.MainMenu_Index == 3) OpenStore();
//            //else if (AlwaysThere.MainMenu_Index == 4) OpenW1();

//            //AlwaysThere.MainMenu_Index = 0;

//        }

//        public void OpenMain()
//        {
//            mainMenu.SetActive(true);
//            if (mainMenu != ActiveMenu) ActiveMenu.SetActive(false); //if the canvas already is open then dont close it
//            ActiveMenu = mainMenu;


//        }
//        public void OpenHelp()
//        {

//            helpMenu.SetActive(true);
//            if (helpMenu != ActiveMenu) ActiveMenu.SetActive(false);
//            ActiveMenu = helpMenu;

//        }


//        public void OpenSettings()
//        {
//            settingsMenu.SetActive(true);
//            if (settingsMenu != ActiveMenu) ActiveMenu.SetActive(false);
//            ActiveMenu = settingsMenu;

//        }

//        public void OpenStore()
//        {

//            storeMenu.SetActive(true);
//            if (storeMenu != ActiveMenu) ActiveMenu.SetActive(false);
//            ActiveMenu = storeMenu;
//        }


//        public void OpenW1()
//        {

//            w1Menu.SetActive(true);
//            if (storeMenu != ActiveMenu) ActiveMenu.SetActive(false);
//            ActiveMenu = w1Menu;
//        }

//    }

//}