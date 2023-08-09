using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_Ad : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butYes;
    Button butNo;
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

        butYes = root.Q<Button>("but_yes");
        butNo = root.Q<Button>("but_no");

        butNo.clicked += No;
        butYes.clicked += Yes;

        C_LevelSwitchScreens.AdWatched = true;
    }

    void Yes()
    {
        SoundManager.Instance.PlaySound(_UISound);
        //OpenAdvertisement;
    }

    void No()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenLoose();
    }
}
