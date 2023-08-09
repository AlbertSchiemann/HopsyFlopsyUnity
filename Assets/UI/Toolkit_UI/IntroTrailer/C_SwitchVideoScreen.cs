using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class C_SwitchVideoScreen : MonoBehaviour
{
    [SerializeField] UIDocument TK_Video;
    [SerializeField] UIDocument TK_Pause;


    public static UIDocument ActiveDocument;
    void Start()
    {
        TK_Video.gameObject.SetActive(true);
        TK_Pause.gameObject.SetActive(false);

        ActiveDocument = TK_Video;
    }

    public void OpenPause()
    {

        TK_Pause.gameObject.SetActive(true);
        if (TK_Pause != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_Pause;

        //Time.timeScale = 0f;
    }
    public void OpenPlaying()
    {
        //GameObject gameStateManager = GameObject.Find("GameStateManager");   //This searches and finds the GameStateManager Object
        //gameStateManager.GetComponent<GameStateManagerScript>().StartGame(); //This executes a function in the script component of the found Object

        // Time.timeScale = 1f;

        TK_Video.gameObject.SetActive(true);
        if (TK_Video != ActiveDocument) ActiveDocument.gameObject.SetActive(false);
        ActiveDocument = TK_Video;

    }
}
