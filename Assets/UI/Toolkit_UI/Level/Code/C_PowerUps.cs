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

    //Waterbottle waterobject = new Waterbottle();


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butShield = root.Q<Button>("but_shield");
        butBottle = root.Q<Button>("but_bottle");

        butShield.clicked += UseShield;
        butBottle.clicked += UseBottle;
    }

    public static void PickUpBottle()
    {
        //opacity = 100%
        bottleThere = true;
    }

    public void UseBottle()
    { 
        if (bottleThere)
        {
        waterbottle.Refill();
        //waterbottle.DeleteBottle();
        bottleThere = false;
        //opacity = lower

        }


    }
    public static void PickUpShiel()
    {
        //opacity = 100%
        shieldThere = true;

    }

    public void UseShield()
    {
        if (shieldThere)
        {
            //shield.Refill();
            //waterbottle.DeleteBottle();
            shieldThere = false;
            //opacity = lower

        }

    }


}
