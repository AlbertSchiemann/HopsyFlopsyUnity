using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class C_UI_OpenOther : MonoBehaviour
{
    public bool switcher;
    public void ToLevel1()
    {
        
          SceneManager.LoadScene("UI testing 1");

    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("UI testing");

    }
    public void ToLevel2()
    {
       // SceneManager.LoadScene("UI testing");

    }
}