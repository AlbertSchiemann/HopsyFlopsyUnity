using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_Video : MonoBehaviour
{
    public C_SwitchVideoScreen switchScreen;

    Button butPause;

    private GameStateManagerScript GameStateManagerScript;

    [SerializeField] private AudioClip[] _UISound;


    private void Awake()
    {
        GameObject GameStateManager = GameObject.Find("GameStateManager");
        GameStateManagerScript = GameStateManager.GetComponent<GameStateManagerScript>();
    }

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        GameStateManagerScript.StartGame();

        butPause = root.Q<Button>("but_pause");


        butPause.clicked += Pause;

    }



    void Pause()
    {
        SwipeManager.tapping = false;

        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenPause();
    }
}
