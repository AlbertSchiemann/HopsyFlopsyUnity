using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;    // reference to the player's transform
    public float smoothTime = 0.3f;      // time taken for camera to smoothly follow player
    public Vector3 offset = new(0, 3, -2);               // initial offset between camera and player

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // set the target position as the player's position plus the offset
        Vector3 targetPosition = playerTransform.position + offset;

        // smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
