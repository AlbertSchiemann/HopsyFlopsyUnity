using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_PowerUps : MonoBehaviour
{
    Button butBottle;
    Button visShield;


    [SerializeField] Shield shield;
    [SerializeField] PowerUpManager powerUpManager;

  

    public C_Playing playing;


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        visShield = root.Q<Button>("vis_shield");
        butBottle = root.Q<Button>("but_bottle");

        // Test = root.Q<Button>("test");
        // Test.clicked += UseBottle;
       
        butBottle.clicked += UseBottle;
        if (!AlwaysThere.shieldThere) OpacityShieldDown();
        if (!AlwaysThere.bottleThere) OpacityBottleDown();

        if (AlwaysThere.bottleThere) PickUpBottle();
        if (AlwaysThere.shieldThere) PickUpShield();
    }

    public  void PickUpBottle()
    {
        OpacityBottleUp();
        AlwaysThere.bottleThere = true;
    }

    public void UseBottle()
    {
        SwipeManager.tapping = false;
        if (AlwaysThere.bottleThere)
        {
            powerUpManager.Refill();
            AlwaysThere.bottleThere = false;
            OpacityBottleDown();
        }
    }
    public void PickUpShield()
    {
        OpacityShiedUp();
        AlwaysThere.shieldThere = true;

    }

    public void UseShield()
    {
        if (AlwaysThere.shieldThere)
        {
            AlwaysThere.shieldThere = false;
            OpacityShieldDown();

        }

    }

    public void OpacityBottleDown()
    {
        butBottle.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);
    }
    public void OpacityBottleUp()
    {
        butBottle.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
    }
    public void OpacityShieldDown()
    {
        visShield.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 0.5f);
    }
    public void OpacityShiedUp()
    {
        visShield.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
    }


}
