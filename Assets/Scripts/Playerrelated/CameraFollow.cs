using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;    // reference to the player's transform
    public CameraRide cameraRide;        // reference to the cameraRide script
    
    // How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.02f;
	private float decreaseFactor = 1.0f;                // lowering of the shaketime per second
    public float smoothTime = 0.3f;                     // time taken for camera to smoothly follow player
    
    public Vector3 offset = new(0, 1, -2);              // initial offset between camera and player
    private Vector3 velocity = Vector3.zero;


    private Vector3 CameraAngleDefault = new(50f, 0f, 0f);

    void Update()
    {
        if (cameraRide.UpdateDelay == false)
        {return;}
        // set the target position as the player's position plus the offset
        Vector3 targetPosition = playerTransform.position + offset;

        if (shakeDuration >= 0)
        {
            // smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            transform.rotation = Quaternion.Euler(CameraAngleDefault);
        }

        else if (shakeDuration > 0)
		{
			transform.position = Vector3.SmoothDamp(transform.position , targetPosition , ref velocity, smoothTime) + Random.insideUnitSphere * shakeAmount;
            transform.rotation = Quaternion.Euler(CameraAngleDefault.x, Random.Range(-.2f, .2f), Random.Range(-.3f, .3f));
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
		} 
    }
}
