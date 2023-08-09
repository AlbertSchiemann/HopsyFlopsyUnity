using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.MessageBox;

public class C_Video_Pause : MonoBehaviour
{
    public C_SwitchVideoScreen switchScreen;

    Button butResume;
    Button butRestart;
    Button butMain;

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

        GameStateManagerScript.PauseGame();

    
        butMain = root.Q<Button>("but_main");
        butResume = root.Q<Button>("but_playOn");
        butRestart = root.Q<Button>("but_restart");


        butMain.clicked += Main;
        butResume.clicked += Resume;
        butRestart.clicked += Restart;

    }


    void Main()
    {
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMainMenu();
    }

    void Restart()
    {
        C_Currency.CurrencyTotal = 0;
        SoundManager.Instance.PlaySound(_UISound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Resume()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenPlaying();
    }


}