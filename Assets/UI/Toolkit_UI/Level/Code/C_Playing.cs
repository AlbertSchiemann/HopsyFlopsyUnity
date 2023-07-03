using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_Playing : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butPause;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butPause = root.Q<Button>("but_pause");

        butPause.clicked += Pause;
    }

    void Pause()
    {
        switchScreen.OpenPause();
    }
}
