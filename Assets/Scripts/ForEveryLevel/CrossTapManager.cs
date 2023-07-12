using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossTapManager : MonoBehaviour
{
    public static bool upTap, downTap, rightTap, leftTap = false;

    private void Update() {
        //Empty Update Function to disable script
    }

    public void UpButton()
    {
        upTap = true;
        Invoke("Reset", 0.1f);
    }
    public void DownButton()
    {
        downTap = true;
        Invoke("Reset", 0.1f);
    }
    public void RightButton()
    {
        rightTap = true;
        Invoke("Reset", 0.1f);
    }
    public void LeftButton()
    {
        leftTap = true;
        Invoke("Reset", 0.1f);
    }
    private void Reset()
    {
        upTap = false;
        downTap = false;
        rightTap = false;
        leftTap = false;
    }
}
