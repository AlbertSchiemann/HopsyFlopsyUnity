using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class C_WaterBar : MonoBehaviour
{
    VisualElement waterSlider;
    StyleLength WaterMax;
    float water;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;


        waterSlider = root.Q<VisualElement>("Foreground");
        SetMaxHealth();
        water = waterSlider.style.height.value.value;
        Debug.Log("slider: " + water);

    }



    public void SetMaxHealth()
    {
        waterSlider.style.height = Length.Percent(100);

    }

    public void SetHealth(float health)
    {
      //  int value = health / water * 100;
        waterSlider.style.height = Length.Percent(health);
        Debug.Log("Slider: " +waterSlider.style.height);
        //Debug.Log("health: "+health);
    }

}
