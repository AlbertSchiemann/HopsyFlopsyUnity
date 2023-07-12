using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private SwipeManager Swiper;
    [SerializeField] private CrossTapManager Tapper;
    [SerializeField] private JoyStickManager Joysticker;
    
    [SerializeField] private GameObject TapPattern;
    [SerializeField] private GameObject JoystickPattern;
    
    private void Start()
    {
        Swiper.enabled = true;
        Tapper.enabled = false;
        Joysticker.enabled = false;
        TapPattern.SetActive(false);
        JoystickPattern.SetActive(false);
    }
    
    public void SwipeController()
    {
        Swiper.enabled = true;
        Tapper.enabled = false;
        Joysticker.enabled = false;
        TapPattern.SetActive(false);
        JoystickPattern.SetActive(false);
    }

    public void TapController()
    {
        Tapper.enabled = true;
        Swiper.enabled = false;
        Joysticker.enabled = false;
        TapPattern.SetActive(true);
        JoystickPattern.SetActive(false);
    }

    public void JoystickController()
    {
        Joysticker.enabled = true;
        Tapper.enabled = false;
        Swiper.enabled = false;
        TapPattern.SetActive(false);
        JoystickPattern.SetActive(true);
    }
}
