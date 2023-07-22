using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_PowerUps : MonoBehaviour
{
    Button butBottle;
    VisualElement visShield;


    Shield shield;
    Waterbottle waterbottle;

    static bool bottleThere = false;
    static bool shieldThere = false;

    public C_Playing playing;


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        visShield = root.Q<VisualElement>("vis_shield");
        butBottle = root.Q<Button>("but_bottle");

       // visShield.clicked += UseShield;
        butBottle.clicked += UseBottle;
    }

    public  void PickUpBottle()
    {
        playing.OpacityBottleUp();
        bottleThere = true;
    }

    public void UseBottle()
    { 
        if (bottleThere)
        {
        waterbottle.Refill();
        bottleThere = false;
        playing.OpacityBottleDown();

        }


    }
    public void PickUpShield()
    {
        playing.OpacityShiedUp();
        shieldThere = true;

    }

    public void UseShield()
    {
        if (shieldThere)
        {
            shieldThere = false;
           playing.OpacityShieldDown();

        }

    }


}
