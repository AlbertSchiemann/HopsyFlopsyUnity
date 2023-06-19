using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
   public UI_LevelScript levelScript;

    private void OnTriggerEnter(Collider other)
    {
        levelScript.OpenWin();
    }

}
