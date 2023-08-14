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
    public Sprite waveImage11;
    public Sprite waveImage12;
    public Sprite waveImage13;
    public Sprite waveImage14;
    public Sprite waveImage15;
    public Sprite waveImage16;
    public Sprite waveImage17;
    public Sprite waveImage18;
    public Sprite waveImage19;
    public Sprite waveImage20;
    public Sprite waveImage21;
    public Sprite waveImage22;
    public Sprite waveImage23;
    public Sprite waveImage24;
    public Sprite waveImage25;
    public Sprite waveImage26;
    public Sprite waveImage27;
    public Sprite waveImage28;


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
    public Sprite bubbles11;
    public Sprite bubbles12;
    public Sprite bubbles13;
    public Sprite bubbles14;
    public Sprite bubbles15;
    public Sprite bubbles16;
    public Sprite bubbles17;
    public Sprite bubbles18;
    public Sprite bubbles19;
    public Sprite bubbles20; 
    public Sprite bubbles21;
    public Sprite bubbles22;
    public Sprite bubbles23;
    public Sprite bubbles24;
    public Sprite bubbles25;
    public Sprite bubbles26;
    public Sprite bubbles27;
    public Sprite bubbles28;

    public Sprite DrunkWater;
    public Sprite NormalWater;


    float time = 0f;
    float TimeDelay=0.15f / 2;
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

        if (time >= TimeDelay)
        {
            if (switcher == 0) Animation(waveImage0, bubbles0);
            else if (switcher == 1) Animation(waveImage1, bubbles1);
            else if (switcher == 2) Animation(waveImage2, bubbles2);
            else if (switcher == 3) Animation(waveImage3, bubbles3);
            else if (switcher == 4) Animation(waveImage4, bubbles4);
            else if (switcher == 5) Animation(waveImage5, bubbles5);
            else if (switcher == 6) Animation(waveImage6, bubbles6);
            else if (switcher == 7) Animation(waveImage7, bubbles7);
            else if (switcher == 8) Animation(waveImage8, bubbles8);
            else if (switcher == 9) Animation(waveImage9, bubbles9);
            else if (switcher == 10) Animation(waveImage10, bubbles10);
            else if (switcher == 11) Animation(waveImage11, bubbles11);
            else if (switcher == 12) Animation(waveImage12, bubbles12);
            else if (switcher == 13) Animation(waveImage13, bubbles13);
            else if (switcher == 14) Animation(waveImage14, bubbles14);
            else if (switcher == 15) Animation(waveImage15, bubbles15);
            else if (switcher == 16) Animation(waveImage16, bubbles16);
            else if (switcher == 17) Animation(waveImage17, bubbles17);
            else if (switcher == 18) Animation(waveImage18, bubbles18);
            else if (switcher == 19) Animation(waveImage19, bubbles19);
            else if (switcher == 20) Animation(waveImage20, bubbles20);
            else if (switcher == 21) Animation(waveImage21, bubbles21);
            else if (switcher == 22) Animation(waveImage22, bubbles22);
            else if (switcher == 23) Animation(waveImage23, bubbles23);
            else if (switcher == 24) Animation(waveImage24, bubbles24);
            else if (switcher == 25) Animation(waveImage25, bubbles25);
            else if (switcher == 26) Animation(waveImage26, bubbles26);
            else if (switcher == 27) Animation(waveImage27, bubbles27);
            else if (switcher == 28) { Animation(waveImage28, bubbles28); switcher = 0; }
            
        }

    }

    //IEnumerator ExecuteAfterTime(float time)
    //{
    //    yield return new WaitForSeconds(time);

    //    // Code to execute after the delay
    //}

    public void Animation(Sprite waveImage, Sprite bubbles)
    {
        time = 0f;
        switcher++;
        Waving(waveImage);
        Bubbling(bubbles);
    }

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
        bubbleground.style.height = Length.Percent(100-3);

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
    public void Drunk()
    {
        waterSlider.style.backgroundImage = new StyleBackground(DrunkWater);
     //   wave.style.unityBackgroundImageTintColor = Color.gray;
        Invoke(nameof(ColorToNormal), 12f);

    }
    public void ColorToNormal()
    {
        waterSlider.style.backgroundImage = new StyleBackground(NormalWater);
     //   wave.style.unityBackgroundImageTintColor = Color.white;
        AlwaysThere.Drunk = false;


    }

}
