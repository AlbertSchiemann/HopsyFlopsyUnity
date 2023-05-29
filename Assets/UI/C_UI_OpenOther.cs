using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class C_UI_OpenOther : MonoBehaviour
{
    public void ToMain_Level()
    {
        SceneManager.LoadScene("Main_level");
    }
    public void ToJulius()
    {
        SceneManager.LoadScene("Julius-Level1Blockout");
    }
    public void ToDenis()
    {
        SceneManager.LoadScene("Denis-Level1Blockout");
    }
    public void ToPatty()
    {
        SceneManager.LoadScene("Nyra-Level1Blockout");
    }
    public void ToAlbert()
    {
        SceneManager.LoadScene("Albert-Level1Blockout");
    }
    public void ToCarl()
    {
        SceneManager.LoadScene("Carl-Level1Blockout");
    }
    public void ToArtists()
    {
        SceneManager.LoadScene("Artist_Level");
    }
    public void ToLevel1() {        
        SceneManager.LoadScene("Main_Level");
    }
    public void ToLevel2()
    {
        // SceneManager.LoadScene("UI testing");
    }
    public void ToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToLastLevel() {
        SceneManager.LoadScene(AlwaysThere.LastLevel);
    }
    public void ToRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu() {
        SceneManager.LoadScene("UI testing");
    }

                public void ToMain_Help() 
                {
                    AlwaysThere.MainMenu_Index = 1;
                    ToMainMenu();
                }
                public void ToMain_Settings()
                {
                    AlwaysThere.MainMenu_Index = 2;
                    ToMainMenu();
                }
                public void ToMain_Store()
                {
                    AlwaysThere.MainMenu_Index = 3;
                    ToMainMenu();
                }
                public void ToMain_W1()
                {
                    AlwaysThere.MainMenu_Index = 4;
                    ToMainMenu();
                }

   
    public static void SaveLastLevel()  
    {
        AlwaysThere.LastLevel = SceneManager.GetActiveScene().buildIndex;
    }
}