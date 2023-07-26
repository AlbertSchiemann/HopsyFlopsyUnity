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
    VisualElement bubbles;
    VisualElement bubbleground;

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

    public Sprite bubbles0;
    public Sprite bubbles1;
    public Sprite bubbles2;
    public Sprite bubbles3;
    public Sprite bubbles4;
    public Sprite bubbles5;
    public Sprite bubbles6;
    public Sprite bubbles7;
    public Sprite bubbles8;
    public Sprite bubbles9;
    public Sprite bubbles10;

    float time = 0f;
    float TimeDelay=0.05f;
    int switcher=0;
    int Warning = 0;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;


        waterSlider = root.Q<VisualElement>("Foreground");
        bubbleground = root.Q<VisualElement>("Bubbleground");
        waterGlas = root.Q<VisualElement>("waterbar_back");
        wave = root.Q<VisualElement>("wave");
        bubbles = root.Q<VisualElement>("bubbles");
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
            Bubbling(bubbles0);
        }
        if (time >= TimeDelay && switcher==1)
        {
            time = 0f;
            switcher++;
            Waving(waveImage1);
            Bubbling(bubbles1);
        }
        if (time >= TimeDelay && switcher == 2)
        {
            time = 0f;
            switcher++;
            Waving(waveImage2);
            Bubbling(bubbles2);
        }
        if (time >= TimeDelay && switcher == 3)
        {
            time = 0f;
            switcher++;
            Waving(waveImage3);
            Bubbling(bubbles3);
        }
        if (time >= TimeDelay && switcher == 4)
        {
            time = 0f;
            switcher++;
            Waving(waveImage4);
            Bubbling(bubbles4);
        }
        if (time >= TimeDelay && switcher == 5)
        {
            time = 0f;
            switcher++;
            Waving(waveImage5);
            Bubbling(bubbles5);
        }
        if (time >= TimeDelay && switcher == 6)
        {
            time = 0f;
            switcher++;
            Waving(waveImage6);
            Bubbling(bubbles6);
        }
        if (time >= TimeDelay && switcher == 7)
        {
            time = 0f;
            switcher++;
            Waving(waveImage7);
            Bubbling(bubbles7);
            //Debug.Log("wave7");
        }
        if (time >= TimeDelay && switcher == 8)
        {
            time = 0f;
            switcher++;
            Waving(waveImage8);
            Bubbling(bubbles8);
        }
        if (time >= TimeDelay && switcher == 10)
        {
            time = 0f;
            switcher=0;
            Waving(waveImage10);
            Bubbling(bubbles10);
            //Debug.Log("wave10");
        }
        if (time >= TimeDelay && switcher == 9)
        {
            time = 0f;
            switcher++;
            Waving(waveImage9);
            Bubbling(bubbles9);
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
    public void Bubbling(Sprite bubblesImage)
    {
        bubbles.style.backgroundImage = new StyleBackground(bubblesImage);

    }


    public void SetMaxHealth()
    {
        waterSlider.style.height = Length.Percent(100);
        bubbleground.style.height = Length.Percent(100);

    }

    public void SetHealth(float health)
    {
        waterSlider.style.height = Length.Percent(health);
        bubbleground.style.height = Length.Percent(health-3);
        if (health < 15&&Warning==1)
        {
            waterGlas.style.unityBackgroundImageTintColor = new Color(1f, 0f, 0f, 0.7f);
            Warning++;

        }
        else if (health < 35 && Warning == 0)
        {
            waterGlas.style.unityBackgroundImageTintColor = new Color(0.7f, 0f, 0f, 0.7f); 
            Warning++;

        }
        else if (health >35 && Warning != 0) {
            waterGlas.style.unityBackgroundImageTintColor = new Color(1f, 1f, 1f, 1f);
            Warning=0;
        }
       // Debug.Log("Slider: " +waterSlider.style.height);
    }

}
