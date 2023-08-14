using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;    // reference to the player's transform
    [SerializeField] private GameObject goalTrigger;      // reference to the goal trigger
    [SerializeField] private GameObject playerPrefab;     // reference to the player prefab
    // How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.02f;
	private float decreaseFactor = 1.0f;                // lowering of the shaketime per second
    public float smoothTime = 0.3f;                     // time taken for camera to smoothly follow player
    
    public Vector3 offset = new(0, 1, -2);              // initial offset between camera and player
    private Vector3 velocity = Vector3.zero;

    private int LevelIndex;

    public bool ShowCameraRide = true;
    private bool UpdateDelay = false;

    public Ease animEaseJump = Ease.InOutExpo;

    //Camera Positions Level 1
    private Vector3 CameraStartBeforeGoalTrigger = new(2f,10f,5f);
    private Vector3 CameraPointOverGoalTrigger = new(0f,8f,-9f);
    private Vector3 CameraBehindPlayer = new(4f,4f,-2.5f);  
    private Vector3 CameraTransformAtGoal = new(0f, 4f, 1f);


    //Camera Positions Level 2
    private Vector3 CameraStartBeforeGoalTriggerLevel2 = new(36f,4f,134f);
    private Vector3 CameraPointOverGoalTriggerLevel2 = new(0f,6f,-9f);
    private Vector3 CameraBehindPlayerLevel2 = new(2f,4f,-4.5f);

    //Player Positions Level 2
    private Vector3 PlayerStartLevel2 = new(24.5f,0.58f,-3.09f);
    private Vector3 PlayerGridStartLevel2 = new(23f,1f,1f);

    //Rotations
    private Vector3 CameraAngleDefault = new(50f, 0f, 0f);
    private Vector3 CameraRideAngleStart = new(10f, 0f, 0f);
    private Vector3 CameraRideAngleBehindPlayer = new(30f, 0f, 0f);

    //Rotations Level 2
    private Vector3 CameraRideAngleStartLevel2 = new(16f, -35f, 0f);
    

    //Delays   
    private static float DelayTillCameraangleChangesFromLighthouse = 1.1f;
    private static float DelayTillCameraMovesAwayFromLighthouse = 3f;
    private static float TimeFromWinToBehindPlayer = 7f;
    private static float TimeFromCameraRideFromBehindToPlayer = 2f;

    public static float TotalDelayForCameraRide = TimeFromCameraRideFromBehindToPlayer + TimeFromWinToBehindPlayer + DelayTillCameraMovesAwayFromLighthouse + DelayTillCameraangleChangesFromLighthouse;

    void Start()
    {
        LevelIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (ShowCameraRide == true)
        {
            if (LevelIndex == 1)
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
            else if (LevelIndex == 2)
            {
                transform.position = CameraStartBeforeGoalTriggerLevel2;
                transform.rotation = Quaternion.Euler(CameraRideAngleStartLevel2);
                playerPrefab.transform.position = PlayerStartLevel2;

                transform.DOMove(goalTrigger.transform.position + CameraPointOverGoalTriggerLevel2, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse);
                transform.DORotate(CameraAngleDefault, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse);

                transform.DORotate(CameraAngleDefault, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse - 1f);

                transform.DOMove(PlayerStartLevel2 + CameraBehindPlayerLevel2, TimeFromWinToBehindPlayer).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
                transform.DORotate(CameraRideAngleBehindPlayer, TimeFromWinToBehindPlayer).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);

                playerPrefab.transform.DOMove(PlayerGridStartLevel2, 1.5f).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse + TimeFromWinToBehindPlayer - .2f).SetEase(animEaseJump);

                transform.DOMove(PlayerGridStartLevel2 + offset, TimeFromCameraRideFromBehindToPlayer).SetDelay(TimeFromWinToBehindPlayer + DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
                transform.DORotate(CameraAngleDefault, TimeFromCameraRideFromBehindToPlayer).SetDelay(TimeFromWinToBehindPlayer + DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
                
                Invoke("UpdateDelaying", TimeFromWinToBehindPlayer + TimeFromCameraRideFromBehindToPlayer + DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
            
            } 
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
