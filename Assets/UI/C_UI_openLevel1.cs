using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class C_UI_openLevel1 : MonoBehaviour
{
    public bool switcher;
    public void PlayLevel()
    {
          //SceneManager.LoadScreen("Level1Blockout");

    }

    public void QuitGame()
    {
        //  ScreenManager.LoadScreen("Level1Blockout");
        Application.Quit();
    }
}