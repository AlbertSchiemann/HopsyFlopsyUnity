using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CameraRide : MonoBehaviour
{
    [SerializeField] private GameObject goalTrigger;      // reference to the goal trigger
    [SerializeField] private GameObject playerPrefab;     // reference to the player prefab
    public Transform playerTransform;    // reference to the player's transform

    public Vector3 offset = new(0f, 7f, -3.5f);

    private int LevelIndex;

    public int HowOftenShowCameraRide = 1;

    public bool ShowCameraRideLevel1 = true;
    public bool ShowCameraRideLevel2 = true;
    public bool ShowCameraRideLevel3 = true;
    public bool ShowCameraRideLevel4 = true;

    private int WasCameraRideShownLevel1 = 0;
    private int WasCameraRideShownLevel2 = 0;
    private int WasCameraRideShownLevel3 = 0;
    private int WasCameraRideShownLevel4 = 0;

    internal bool UpdateDelay = false;

    public Ease animEaseJump = Ease.InOutExpo;

    private Vector3 cameraPosAtFallingDeath = new(0f, -7, 3.5f);
    

    //Camera Positions Level 1
    private Vector3 CameraStartBeforeGoalTrigger = new(2f,10f,5f);
    private Vector3 CameraPointOverGoalTrigger = new(0f,8f,-9f);
    private Vector3 CameraBehindPlayer = new(4f,4f,-2.5f);  
    private Vector3 CameraTransformAtGoal = new(0f, 4f, 1f);


    //Camera Positions Level 2
    private Vector3 CameraStartBeforeGoalTriggerLevel2 = new(36f,4f,134f);
    private Vector3 CameraPointOverGoalTriggerLevel2 = new(0f,6f,-9f);
    private Vector3 CameraBehindPlayerLevel2 = new(2f,4f,-4.5f);

    //Camera Positions Level 3
    private Vector3 CameraStartBeforeGoalTriggerLevel3 = new(3f,2f,33.5f);
    private Vector3 CameraPointOverGoalTriggerLevel3 = new(5.5f,2f,31f);
    private Vector3 CameraBehindPlayerLevel3 = new(2f,3f,-2f);


    //Player Positions Level 2
    private Vector3 PlayerStartLevel2 = new(24.5f,0.58f,-3.09f);
    private Vector3 PlayerGridStartLevel2 = new(23f,1f,1f);

    //Player Positions Level 3
    private Vector3 PlayerStartLevel3 = new(5.8f,1.5f,-6.6f);
    private Vector3 PlayerCraneEndLevel3 = new(5.8f,1.5f,-1f);
    private Vector3 PlayerGridStartLevel3 = new(6f,1f,1f);


    //Rotations
    private Vector3 CameraAngleDefault = new(50f, 0f, 0f);
    private Vector3 CameraRideAngleStart = new(10f, 0f, 0f);
    private Vector3 CameraRideAngleBehindPlayer = new(20f, 0f, 0f);

    //Rotations Level 2
    private Vector3 CameraRideAngleStartLevel2 = new(16f, -35f, 0f);
    
    //Rotations Level 3
    private Vector3 CameraRideAngleStartLevel3 = new(16f, 35f, 0f);
    private Vector3 CameraRideAngleBehindPlayerLevel3 = new(35f, 0f, 0f);
    

    //Delays   
    private static float DelayTillCameraangleChangesFromLighthouse = 1.1f;
    private static float DelayTillCameraMovesAwayFromLighthouse = 3f;
    private static float TimeFromWinToBehindPlayer = 7f;
    private static float TimeFromCameraRideFromBehindToPlayer = 2f;

    internal float TotalDelayForCameraRide = TimeFromCameraRideFromBehindToPlayer + TimeFromWinToBehindPlayer + DelayTillCameraMovesAwayFromLighthouse + DelayTillCameraangleChangesFromLighthouse;
    internal float ShortDelayForCameraRide = TimeFromCameraRideFromBehindToPlayer;


    public void CameraRideDecider ()
    {
        // decides if the camera ride should be shown or not, according to the number of times it was shown yet
        if (LevelIndex == 1){if (WasCameraRideShownLevel1 >= HowOftenShowCameraRide || !ShowCameraRideLevel1) {ShowCameraRideLevel1 = false;} else {ShowCameraRideLevel1 = true;};}
        if (LevelIndex == 2){if (WasCameraRideShownLevel2 >= HowOftenShowCameraRide || !ShowCameraRideLevel2) {ShowCameraRideLevel2 = false;} else {ShowCameraRideLevel2 = true;};}
        if (LevelIndex == 3){if (WasCameraRideShownLevel3 >= HowOftenShowCameraRide || !ShowCameraRideLevel3) {ShowCameraRideLevel3 = false;} else {ShowCameraRideLevel2 = true;};}
        if (LevelIndex == 4){if (WasCameraRideShownLevel4 >= HowOftenShowCameraRide || !ShowCameraRideLevel4) {ShowCameraRideLevel4 = false;} else {ShowCameraRideLevel2 = true;};}
    }

    void Start()
    {
        LevelIndex = SceneManager.GetActiveScene().buildIndex;
        CameraRideDecider();
        CameraRideFunction();
    }

    private void DelayOfShownAdd1 ()
    {WasCameraRideShownLevel1++;}
    private void DelayOfShownAdd2 ()
    {WasCameraRideShownLevel2++;}
    private void DelayOfShownAdd3 ()
    {WasCameraRideShownLevel3++;}
    private void DelayOfShownAdd4 ()
    {WasCameraRideShownLevel4++;}

    public void CameraRideFunction()
    {

        if (LevelIndex == 1)
        {

            if (ShowCameraRideLevel1 == true)
            {
                Debug.Log("In Start in if  " + ShowCameraRideLevel1);
                transform.position = goalTrigger.transform.position + CameraStartBeforeGoalTrigger;
                transform.rotation = Quaternion.Euler(CameraRideAngleStart);

                transform.DOMove(goalTrigger.transform.position + CameraPointOverGoalTrigger, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse);
                transform.DORotate(CameraAngleDefault, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse);

                transform.DORotate(CameraAngleDefault, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse - 1f);

                transform.DOMove(playerTransform.position + CameraBehindPlayer, TimeFromWinToBehindPlayer).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
                transform.DORotate(CameraRideAngleBehindPlayer, TimeFromWinToBehindPlayer).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);

                transform.DOMove(playerTransform.position + offset, TimeFromCameraRideFromBehindToPlayer).SetDelay(TimeFromWinToBehindPlayer + DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
                transform.DORotate(CameraAngleDefault, TimeFromCameraRideFromBehindToPlayer).SetDelay(TimeFromWinToBehindPlayer + DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
                
                Invoke("DelayOfShownAdd1", 1f);
                CameraRideDecider();
                
                Invoke("UpdateDelaying", TotalDelayForCameraRide);
            }
            else if (ShowCameraRideLevel1 == false)
            {
                transform.position =  playerTransform.position + CameraBehindPlayer;
                transform.rotation = Quaternion.Euler(CameraRideAngleBehindPlayer);

                transform.DOMove(playerTransform.position + offset, TimeFromCameraRideFromBehindToPlayer);
                transform.DORotate(CameraAngleDefault, TimeFromCameraRideFromBehindToPlayer);
                
                Invoke("UpdateDelaying", ShortDelayForCameraRide);
            }
            else Debug.LogError("ShowCameraRideLevel1-bool doesnt work in CameraFollow Script");
        }
        else if (LevelIndex == 2)
        {
            if (ShowCameraRideLevel2 == true)
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
                
                Invoke("DelayOfShownAdd2", 1f);
                CameraRideDecider();
                Invoke("UpdateDelaying", TotalDelayForCameraRide);
            }
            else if (ShowCameraRideLevel2 == false)
            {
                transform.position =  PlayerStartLevel2 + CameraBehindPlayerLevel2;
                transform.rotation = Quaternion.Euler(CameraRideAngleStartLevel2);

                playerPrefab.transform.DOMove(PlayerGridStartLevel2, 1.5f);

                transform.DOMove(PlayerGridStartLevel2 + offset, TimeFromCameraRideFromBehindToPlayer);
                transform.DORotate(CameraAngleDefault, TimeFromCameraRideFromBehindToPlayer);
                
                Invoke("UpdateDelaying", ShortDelayForCameraRide);
            }
            else Debug.LogError("ShowCameraRideLevel2-bool doesnt work in CameraFollow Script");
        } 
        else if (LevelIndex == 3)
        {
            if (ShowCameraRideLevel3 == true)
            {
                transform.position = CameraStartBeforeGoalTriggerLevel3;
                transform.rotation = Quaternion.Euler(CameraRideAngleStartLevel3);
                playerPrefab.transform.position = PlayerStartLevel3;

                transform.DOMove(CameraPointOverGoalTriggerLevel3, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse);
                transform.DORotate(CameraRideAngleStart, DelayTillCameraMovesAwayFromLighthouse).SetDelay(DelayTillCameraangleChangesFromLighthouse);

                transform.DOMove(PlayerStartLevel3 + CameraBehindPlayerLevel3, TimeFromWinToBehindPlayer).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse);
                transform.DORotate(CameraRideAngleBehindPlayerLevel3, TimeFromWinToBehindPlayer).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse );

                playerPrefab.transform.DOMove(PlayerCraneEndLevel3, 1f).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse + TimeFromWinToBehindPlayer).SetEase(Ease.Linear);
                playerPrefab.transform.DOMove(PlayerGridStartLevel3, 1f).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse + TimeFromWinToBehindPlayer + 1f).SetEase(animEaseJump);

                transform.DOMove(PlayerGridStartLevel3 + offset, TimeFromCameraRideFromBehindToPlayer).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse + TimeFromWinToBehindPlayer);
                transform.DORotate(CameraAngleDefault, TimeFromCameraRideFromBehindToPlayer).SetDelay(DelayTillCameraangleChangesFromLighthouse + DelayTillCameraMovesAwayFromLighthouse + TimeFromWinToBehindPlayer);
            
                Invoke("DelayOfShownAdd3", 1f);
                CameraRideDecider();
                Invoke("UpdateDelaying", TotalDelayForCameraRide);
            }
            else if (ShowCameraRideLevel3 == false)
            {
                transform.position =  PlayerStartLevel3 + CameraBehindPlayerLevel3;
                transform.rotation = Quaternion.Euler(CameraRideAngleStartLevel3);

                playerPrefab.transform.DOMove(PlayerGridStartLevel3, 1.5f);

                transform.DOMove(PlayerGridStartLevel3 + offset, TimeFromCameraRideFromBehindToPlayer);
                transform.DORotate(CameraAngleDefault, TimeFromCameraRideFromBehindToPlayer);
                
                Invoke("UpdateDelaying", ShortDelayForCameraRide);
            }
            else Debug.LogError("ShowCameraRideLevel3-bool doesnt work in CameraFollow Script");
        }
        else if (LevelIndex == 4)
        {
            if (ShowCameraRideLevel4 == true)
            {
                Invoke("DelayOfShownAdd4", 1f);
                CameraRideDecider();
                Invoke("UpdateDelaying", TotalDelayForCameraRide);
            }
            else if (ShowCameraRideLevel4 == false)
            {
                
                
                Invoke("UpdateDelaying", ShortDelayForCameraRide);
            }
            else Debug.LogError("ShowCameraRideLevel4-bool doesnt work in CameraFollow Script");
        }
        else Debug.LogError("LevelIndex screwed up in Camera Follow Script");
    }

    private void UpdateDelaying ()
    {
        UpdateDelay = true;
    }

    public void GoalCameraride() 
    {
        transform.DOMove(playerPrefab.transform.position + CameraTransformAtGoal, 1f);
        UpdateDelay = false;
    }

    public void DeathCamera()
    {
        UpdateDelay = false;
    }

    public void FallingCamera ()
    {
        transform.DOMove(playerPrefab.transform.position + cameraPosAtFallingDeath, .5f);
        UpdateDelay = false;
    }
}
