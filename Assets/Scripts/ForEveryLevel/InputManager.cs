using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private SwipeManager Swiper;
    [SerializeField] private CrossTapManager Tapper;
    [SerializeField] private GameObject TapPattern;
    
    private void Start()
    {
        Swiper.enabled = true;
        Tapper.enabled = false;
        TapPattern.SetActive(false);
    }
    
    public void SwipeController()
    {
        Swiper.enabled = true;
        Tapper.enabled = false;
    }

    public void TapController()
    {
        Tapper.enabled = true;
        Swiper.enabled = false;
        TapPattern.SetActive(true);
    }
}
