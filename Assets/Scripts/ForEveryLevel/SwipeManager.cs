using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown, shortTap; // Check for touch-input
    private bool isDraging = false; // check for mouse-input
    private Vector2 startTouch, swipeDelta;
    private float tapTimeThreshold = 0.2f;
    private float tapTime;
    public static bool tapping = true;

    bool isTappingAllowed = true;

    private void Update()
    {
        if (tapping)
        {
            tap = swipeDown = swipeUp = swipeLeft = swipeRight = shortTap = false;

            // Calculate the distance
            swipeDelta = Vector2.zero;
            if (isDraging)
            {
                if (Input.touches.Length < 0)
                    swipeDelta = Input.touches[0].position - startTouch;
                else if (Input.GetMouseButton(0))
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }

            // Check the distance for the swipe
            if (swipeDelta.magnitude > 100)
            {
                isTappingAllowed = false;
                // Determine direction
                float x = swipeDelta.x;
                float y = swipeDelta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    // Left or Right
                    if (x < 0)
                        swipeLeft = true;
                    else if (x >  0)
                        swipeRight = true;
                }
                else
                {
                    // Up or Down
                    if (y < 0)
                        swipeDown = true;
                    else if (y > 0)
                        swipeUp = true;
                }

                Reset();
                Invoke("AllowTapping", tapTimeThreshold);
                return; // Exit Update early, we already have a swipe
            }
            if (!isTappingAllowed) { return; }
            // Desktop Input
            if (Input.GetMouseButtonDown(0))
            {
                tap = true;
                isDraging = true;
                startTouch = Input.mousePosition;
                tapTime = Time.time;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDraging = false;
                float timeDelta = Time.time - tapTime;
                if (timeDelta <= tapTimeThreshold && !swipeLeft && !swipeRight && !swipeUp && !swipeDown)
                    shortTap = true;
                Reset();
            }

            // Mobile Input
            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    tap = true;
                    isDraging = true;
                    startTouch = Input.touches[0].position;
                    tapTime = Time.time;
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    isDraging = false;
                    float timeDelta = Time.time - tapTime;
                    if (timeDelta <= tapTimeThreshold && !swipeLeft && !swipeRight && !swipeUp && !swipeDown)
                        shortTap = true;
                    Reset();
                }
            }
        }
        tapping = true;
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
    private void AllowTapping()
    {
        isTappingAllowed = true;
    }
}
