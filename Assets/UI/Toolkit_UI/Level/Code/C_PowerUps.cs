using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_PowerUps : MonoBehaviour
{
    Button butBottle;
    Button butShield;


    Shield shield;
    Waterbottle waterbottle;

    static bool bottleThere = false;
    static bool shieldThere = false;

    public C_Playing playing;


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butShield = root.Q<Button>("but_shield");
        butBottle = root.Q<Button>("but_bottle");

        butShield.clicked += UseShield;
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
