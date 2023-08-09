using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;    // reference to the player's transform
    // How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.02f;
	private float decreaseFactor = 1.0f;                // lowering of the shaketime per second
    public float smoothTime = 0.3f;                     // time taken for camera to smoothly follow player
    public Vector3 offset = new(0, 1, -2);              // initial offset between camera and player
    public Vector3 cameraAngle = new(50f, 0f, 0f);
    public Vector3 cameraRideGoal = new(0f, 7f, 70f);

    private Vector3 velocity = Vector3.zero;

    private Vector3 CameraRide = new(25f,15f,-7.5f);           // camera position when starting
    private Vector3 CameraRideAngle = new(0f, 0f, 0f);                             // camera angle when starting
    private bool UpdateDelay = false;
    public static float DelayTillCameraRideStart = 1f;
    public static float CameraRideTime = 3f;
    public static float CameraRideTimer = CameraRideTime + DelayTillCameraRideStart;

    void Start()
    {
        transform.position = CameraRide;
        transform.rotation = Quaternion.Euler(CameraRideAngle);
        transform.DOMove(playerTransform.position + offset, CameraRideTime).SetDelay(DelayTillCameraRideStart);
        transform.DORotate(cameraAngle, CameraRideTime).SetDelay(DelayTillCameraRideStart);
        Invoke("UpdateDelaying", DelayTillCameraRideStart + CameraRideTime);
    }
    private void UpdateDelaying ()
    {
        UpdateDelay = true;
    }

    public void GoalCameraride() 
    {
        UpdateDelay = false;
        transform.DOMove(playerTransform.position + cameraRideGoal, 1f);



    }



    void Update()
    {
        if (UpdateDelay == false)
        {return;}
        
        
        // set the target position as the player's position plus the offset
        Vector3 targetPosition = playerTransform.position + offset;

        if (shakeDuration == 0)
        {
            // smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            transform.rotation = Quaternion.Euler(cameraAngle);
        }

        else if (shakeDuration > 0)
		{
			transform.position = Vector3.SmoothDamp(transform.position , targetPosition , ref velocity, smoothTime) + Random.insideUnitSphere * shakeAmount;
            transform.rotation = Quaternion.Euler(cameraAngle.x, Random.Range(-.2f, .2f), Random.Range(-.3f, .3f));
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
		} 
    }
}
