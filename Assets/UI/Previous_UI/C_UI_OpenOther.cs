using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class C_UI_OpenOther : MonoBehaviour
{
    public static void ToMain_Level()
    {
        SceneManager.LoadScene("World1Level1");
    }
  
    public static void ToLevel1() {        
        SceneManager.LoadScene("World1Level1");
    }
    public static void ToLevel2()
    {
         SceneManager.LoadScene("World1Level2");
    }
    public static void ToLevel3()
    {
         SceneManager.LoadScene("World1Level4");
    }
    public static void ToLevel4()
    {
        SceneManager.LoadScene("World1Level3");
    }
    public static void ToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void ToLastLevel() {
        SceneManager.LoadScene(AlwaysThere.LastLevel);
    }
    public static void ToRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void ToVideo()
    {
        SceneManager.LoadScene("Video");
    }

    public static void ToMainMenu() {
        SceneManager.LoadScene("TK_MainMenu");
    }

                public static void ToMain_Help() 
                {
                    AlwaysThere.MainMenu_Index = 1;
                    ToMainMenu();
                }
                public static void ToMain_Settings()
                {
                    AlwaysThere.MainMenu_Index = 2;
                    ToMainMenu();
                }
                public static void ToMain_Store()
                {
                    AlwaysThere.MainMenu_Index = 3;
                    ToMainMenu();
                }
                public static void ToMain_W1()
                {
                    AlwaysThere.MainMenu_Index = 4;
                    ToMainMenu();
                }

   
    public static void SaveLastLevel()  
    {
        AlwaysThere.LastLevel = SceneManager.GetActiveScene().buildIndex;
    }
}