using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISScript : MonoBehaviour
{
#if UNITY_ANDROID
    string appkey = "1acc4ae55";
#elif UNITY_IOS
string appkey = "1acc52165";
#endif

    //string appkey = "1acc4ae55";
    // Start is called before the first frame update
    void Start()
    {
        IronSource.Agent.init(appkey);
    }

    private void OnEnable()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
    }

    void OnApplicationPause(bool isPaused)
    {
        IronSource.Agent.onApplicationPause(isPaused);
    }


    private void SdkInitializationCompletedEvent() 
    {
        IronSource.Agent.validateIntegration();
    }

    //Banner Callbacks


    //Full Size Callbacks


    //Rewarded Callbacks
}
