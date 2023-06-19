using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UI_SoundOnOf : MonoBehaviour
{

    [SerializeField] GameObject soundOn;
    [SerializeField] GameObject soundOf;

    public static GameObject SoundOf;
    public static GameObject SoundOn;

    public void Sound_On()
    {
        soundOn.SetActive(true);
        soundOf.SetActive(false);
    }
    public void Sound_Of()
    {
        soundOn.SetActive(false);
        soundOf.SetActive(true);
    }
}
