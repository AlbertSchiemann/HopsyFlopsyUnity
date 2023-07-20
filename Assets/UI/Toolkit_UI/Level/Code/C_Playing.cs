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

        butBottle = root.Q<Button>("but_bottle");
        visShield = root.Q<VisualElement>("vis_shield");

        butPause.clicked += Pause;

        OpacityShieldDown();
        OpacityBottleDown();
    }

    public void OpacityBottleDown()
    {
        butBottle.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.3f);
    }
    public void OpacityBottleUp()
    {
        butBottle.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
    }
    public void OpacityShieldDown()
    {
        visShield.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.3f);
    }
    public void OpacityShiedUp()
    {
        visShield.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
    }

    void Pause()
    {
        switchScreen.OpenPause();
    }
}
  