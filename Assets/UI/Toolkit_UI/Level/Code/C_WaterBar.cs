using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class C_WaterBar : MonoBehaviour
{
    VisualElement waterSlider;
    VisualElement waterGlas;
    VisualElement wave;

    //float water;

    public Sprite waveImage0;
    public Sprite waveImage1;
    public Sprite waveImage2;
    public Sprite waveImage3;
    public Sprite waveImage4;
    public Sprite waveImage5;
    public Sprite waveImage6;
    public Sprite waveImage7;
    public Sprite waveImage8;
    public Sprite waveImage9;
    public Sprite waveImage10;


    float time = 0f;
    float TimeDelay=0.15f;
    int switcher=0;


    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;


        waterSlider = root.Q<VisualElement>("Foreground");
        waterGlas = root.Q<VisualElement>("waterbar_back");
        wave = root.Q<VisualElement>("wave");
        SetMaxHealth();
        //water = waterSlider.style.height.value.value;
        //Debug.Log("slider: " + water);

        //waveImage5 = database/Assets/UI/Toolkit_UI/pictures/waterbar/wave.png?fileID=581892226&amp;guid=3ee65a67c4b3eb14cb23bc0b1fc83f29&amp;type=3#wave_0&apos;);

    }

    private void FixedUpdate()
    {
        time = time + 1f * Time.deltaTime;
        //Invoke("Waving(waveImage2)",1);
        //Invoke("Waving(waveImage1)", 1);
        if (time >= TimeDelay&&switcher==0)
        {
            time = 0f;
            switcher++;
            Waving(waveImage0);
        }
        if (time >= TimeDelay && switcher==1)
        {
            time = 0f;
            switcher++;
            Waving(waveImage1);
        }
        if (time >= TimeDelay && switcher == 2)
        {
            time = 0f;
            switcher++;
            Waving(waveImage2);
        }
        if (time >= TimeDelay && switcher == 3)
        {
            time = 0f;
            switcher++;
            Waving(waveImage3);
        }
        if (time >= TimeDelay && switcher == 4)
        {
            time = 0f;
            switcher++;
            Waving(waveImage4);
        }
        if (time >= TimeDelay && switcher == 5)
        {
            time = 0f;
            switcher++;
            Waving(waveImage5);
        }
        if (time >= TimeDelay && switcher == 6)
        {
            time = 0f;
            switcher++;
            Waving(waveImage6);
        }
        if (time >= TimeDelay && switcher == 7)
        {
            time = 0f;
            switcher++;
            Waving(waveImage7);
            //Debug.Log("wave7");
        }
        if (time >= TimeDelay && switcher == 8)
        {
            time = 0f;
            switcher++;
            Waving(waveImage8);
        }
        if (time >= TimeDelay && switcher == 10)
        {
            time = 0f;
            switcher=0;
            Waving(waveImage10);
            //Debug.Log("wave10");
        }
        if (time >= TimeDelay && switcher == 9)
        {
            time = 0f;
            switcher++;
            Waving(waveImage9);
            //Debug.Log("wave9");
        }
        //// 10 frames later

    }

    //IEnumerator ExecuteAfterTime(float time)
    //{
    //    yield return new WaitForSeconds(time);

    //    // Code to execute after the delay
    //}

    public void Waving(Sprite waveImage)
    {
        wave.style.backgroundImage = new StyleBackground(waveImage);

    }


    public void SetMaxHealth()
    {
        waterSlider.style.height = Length.Percent(100);

    }

    public void SetHealth(float health)
    {
        waterSlider.style.height = Length.Percent(health);
        if (health < 10)
        {
            waterGlas.style.unityBackgroundImageTintColor = new Color(1f, 0f, 0f, 0.7f);

        }
        else if (health < 25)
        {
            waterGlas.style.unityBackgroundImageTintColor = new Color(0.7f, 0f, 0f, 0.7f); 

        }
       // Debug.Log("Slider: " +waterSlider.style.height);
    }

}
