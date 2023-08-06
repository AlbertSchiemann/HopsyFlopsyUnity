using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WinTrigger_Script : MonoBehaviour
{
    public C_LevelSwitchScreens levelScript;

    private void Start()
    {
        GameObject levelUIObject = GameObject.Find("Level_UI");
        levelScript = levelUIObject.GetComponent<C_LevelSwitchScreens>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AlwaysThere.time = (int)C_Playing.Timer;
        Debug.Log(AlwaysThere.time + " and " + C_Playing.Timer);
        levelScript.OpenWin();
      
    }
}
