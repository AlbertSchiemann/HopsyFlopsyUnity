using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TK_controller : MonoBehaviour
{

    public Button playBut;
    public Button messageBut;
    public Label messageText;

    
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        playBut = root.Q<Button>("play_but");
        messageBut = root.Q<Button>("message_but");
        messageText = root.Q<Label>("message_text");

        playBut.clicked += StartButtonPressed;
        messageBut.clicked += MessageButtonPressed;
    }


    void StartButtonPressed()
    {
        SceneManager.LoadScene("Main_Level");


    }

    // Update is called once per frame
    void MessageButtonPressed()
    {
        messageText.text = "blabla";
        messageText.style.display = DisplayStyle.Flex;
    }
}
