using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WinTrigger_Script : MonoBehaviour
{
    public UI_LevelScript levelScript;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger scrpit 1st");
        levelScript.OpenWin();
        Debug.Log("trigger scrpit last");
    }
}
