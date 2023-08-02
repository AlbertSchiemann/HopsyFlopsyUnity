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

    Button butBottle;
    VisualElement visShield;

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

        //butBottle = root.Q<Button>("but_bottle");
        //visShield = root.Q<VisualElement>("vis_shield");

        butPause.clicked += Pause;

        
    }

    

    void Pause()
    {
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenPause();
    }
}
  