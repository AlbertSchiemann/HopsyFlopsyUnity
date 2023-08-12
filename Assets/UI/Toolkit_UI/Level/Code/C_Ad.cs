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

    public ISScript AdScript;

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

    }

    public void Yes()
    {
        SoundManager.Instance.PlaySound(_UISound);
        C_LevelSwitchScreens.AdWatched = true;
        //OpenAdvertisement;
        //Debug.Log("load banner function called");
        AdScript.ShowRewardedAd();
        switchScreen.OpenPlaying();
    }

    public void No()
    {
        AlwaysThere.time = (int)C_Playing.Timer;
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenLoose();
    }
}
