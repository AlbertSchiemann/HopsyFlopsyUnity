using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // The target to follow (in this case, the player)
    public float smoothTime = 0.3f; // The time it takes for the camera to smoothly move to the target position

    private Vector3 velocity = Vector3.zero; // The velocity used by SmoothDamp

    void LateUpdate()
    {
        // Smoothly move the camera position to the target position
        Vector3 targetPosition = target.position;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = smoothPosition;

        // Keep the camera rotation fixed
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
