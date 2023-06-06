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

    private void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = shortTap = false;
        
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
       

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // check the distance for the swipe
        if (swipeDelta.magnitude > 100)
        {
            //Which direction to move
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }

    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
