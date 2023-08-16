using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_WinTrigger_Script : MonoBehaviour
{
    public C_LevelSwitchScreens levelScript;
    [SerializeField] private GameStateManagerScript gameStateManagerScript;
    [SerializeField] private CameraRide cameraRide;

    private void Start()
    {
        GameObject levelUIObject = GameObject.Find("Level_UI");
        levelScript = levelUIObject.GetComponent<C_LevelSwitchScreens>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraRide.GoalCameraride();
            other.GetComponent<GridPlayerMovement>().CallOfPlayerWin();
            AlwaysThere.time = (int)C_Playing.Timer;
            other.GetComponent<GridPlayerMovement>().PreventMovement();
            //Debug.Log(AlwaysThere.time + " and " + C_Playing.Timer);
            Invoke("Goalscreen", 3f);
        }
      
    }

    private void Goalscreen()
    {
        levelScript.OpenWin();
        gameStateManagerScript.PauseGame();
    }
}
