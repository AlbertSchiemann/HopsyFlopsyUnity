using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script_WaterBar : MonoBehaviour
{

    public Slider waterSlider;

    public void SetMaxHealth (float health)
    {
        waterSlider.maxValue=health;
        waterSlider.value=health;

    }
    
    public void SetHealth(float health)
    {

        waterSlider.value = health;
        Debug.Log("slider: " +waterSlider.value);
        Debug.Log("health: "+health);
    }

    
}
