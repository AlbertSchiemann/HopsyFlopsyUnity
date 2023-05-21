using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManagerScript : MonoBehaviour
{
    public delegate void OnGameStart();
    public static event OnGameStart onGameStart;

    public delegate void OnGamePaused();
    public static event OnGamePaused onGamePaused;

    void Start()
    {
        PauseGame();
    }

    public void StartGame()
    {
        onGameStart?.Invoke();
    }

    public void PauseGame()
    {
        onGamePaused?.Invoke();
    }
}
