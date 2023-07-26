using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_PowerUps : MonoBehaviour
{
    Button butBottle;
        Button Test;
    VisualElement visShield;


    [SerializeField] Shield shield;
    [SerializeField] Waterbottle waterbottle;

    static bool bottleThere = false;
    static bool shieldThere = false;

    public C_Playing playing;


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        visShield = root.Q<VisualElement>("vis_shield");
        butBottle = root.Q<Button>("but_bottle");
      //   Test = root.Q<Button>("test");


        
//Test.clicked += UseBottle;
       
        butBottle.clicked += UseBottle;
        OpacityShieldDown();
        OpacityBottleDown();
    }

    public  void PickUpBottle()
    {
        OpacityBottleUp();
        bottleThere = true;
    }

    public void UseBottle()
    { 
        Debug.Log("UseBottle");
        if (bottleThere)
        {
        waterbottle.Refill();
        bottleThere = false;
        OpacityBottleDown();
        }
    }
    public void PickUpShield()
    {
        OpacityShiedUp();
        shieldThere = true;

    }

    public void UseShield()
    {
        if (shieldThere)
        {
            shieldThere = false;
           OpacityShieldDown();

        }

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


}
