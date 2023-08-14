using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;    // reference to the player's transform
    [SerializeField] private GameObject goalTrigger;      // reference to the goal trigger
    // How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.02f;
	private float decreaseFactor = 1.0f;                // lowering of the shaketime per second
    public float smoothTime = 0.3f;                     // time taken for camera to smoothly follow player
    
    public Vector3 offset = new(0, 1, -2);              // initial offset between camera and player
    private Vector3 velocity = Vector3.zero;
    public bool ShowCameraRide = true;

    private Vector3 CameraStartBeforeGoalTrigger = new(2f,10f,5f);

    //(21f,10f,121f)

    private Vector3 CameraPointOverGoalTrigger = new(0f,8f,-9f);

    //(24f,8f,108f)
    private Vector3 CameraBehindPlayer = new(4f,4f,-2.5f);  

    //(25f,11f,-3.5f)
    private Vector3 CameraAngleDefault = new(50f, 0f, 0f);
    private Vector3 CameraRideAngleStart = new(10f, 0f, 0f);
    private Vector3 CameraRideAngleBehindPlayer = new(30f, 0f, 0f);

    private Vector3 CameraTransformAtGoal = new(0f, 4f, 1f);

    private bool UpdateDelay = false;
    
    private static float DelayTillCameraangleChangesFromLighthouse = 1.1f;
    private static float DelayTillCameraMovesAwayFromLighthouse = 3f;
    private static float TimeFromWinToBehindPlayer = 7f;
    private static float TimeFromCameraRideFromBehindToPlayer = 2f;
    public static float TotalDelayForCameraRide = TimeFromCameraRideFromBehindToPlayer + TimeFromWinToBehindPlayer + DelayTillCameraMovesAwayFromLighthouse + DelayTillCameraangleChangesFromLighthouse;

    void Start()
    {
        if (ShowCameraRide == true)
        {
            transform.position = goalTrigger.transform.position + CameraStartBeforeGoalTrigger;
            transform.rotation = Quaternion.Euler(CameraRideAngleStart);

            transform.DOMove(goalTrigger.transform.position + CameraPointOverGoalTrigger, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse);
            transform.DORotate(CameraAngleDefault, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse);

            transform.DORotate(CameraAngleDefault, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse - 1f);

            transform.DOMove(playerTransform.position + CameraBehindPlayer, TimeFromWinToBehindPlayer).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
            transform.DORotate(CameraRideAngleBehindPlayer, TimeFromWinToBehindPlayer).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);

            transform.DOMove(playerTransform.position + offset, TimeFromCameraRideFromBehindToPlayer).SetDelay(TimeFromWinToBehindPlayer + DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
            transform.DORotate(CameraAngleDefault, TimeFromCameraRideFromBehindToPlayer).SetDelay(TimeFromWinToBehindPlayer + DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
            
            Invoke("UpdateDelaying", TimeFromWinToBehindPlayer + TimeFromCameraRideFromBehindToPlayer + DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
        }
        else 
        {
            UpdateDelaying();
        }
        
    }
    private void UpdateDelaying ()
    {
        UpdateDelay = true;
    }

    public void GoalCameraride() 
    {
        UpdateDelay = false;
        transform.DOMove(playerTransform.position + CameraTransformAtGoal, 1f);



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
