using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera PortCamera;
    [SerializeField] private Camera LandCamera;
    private ScreenOrientation currentOrientation;
    private bool rotated;

    private void FixedUpdate()
    {
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            if (!rotated)
            {
                LandCamera.enabled = false;
                PortCamera.enabled = true;
                rotated = true;
            }
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            if (!rotated)
            {
                PortCamera.enabled = false;
                LandCamera.enabled = true;
                rotated = true;
            }
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            if (!rotated)
            {
                PortCamera.enabled = false;
                LandCamera.enabled = true;
                rotated = true;
            }
        }
        rotated = false;
    }
}
