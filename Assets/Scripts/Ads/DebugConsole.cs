using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugConsole : MonoBehaviour
{
    public bool showConsole = false;
    private string output = "";
    private Vector2 scrollPosition;

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        output += logString + "\n";
    }

    void OnGUI()
    {
        if (!showConsole) return;

        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(600), GUILayout.Height(400));
        GUILayout.Label(output);
        GUILayout.EndScrollView();
    }
}

