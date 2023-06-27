using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Main : MonoBehaviour
{
    public Button butPlayLast;
    public Button butMainLevel;
    public Button butWorld1;

    //public Button butBack;
    public Button butStore;
    public Button butHelp;
    public Button butSettings;

    public Button butArtist;
    public Button butAlbert;
    public Button butCarl;
    public Button butDenis;
    public Button butJulius;
    public Button butPatty;


    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butAlbert = root.Q<Button>("LV_albert");
        butArtist = root.Q<Button>("LV_artist");
        butDenis = root.Q<Button>("LV_denis");
        butJulius = root.Q<Button>("LV_julius");
        butPatty = root.Q<Button>("LV_patty");
        butCarl = root.Q<Button>("LV_carl");

        butHelp = root.Q<Button>("but_help");
        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");

        butSettings = root.Q<Button>("but_settings");
        butSettings = root.Q<Button>("but_settings");

        //playBut.clicked += StartButtonPressed;
        //messageBut.clicked += MessageButtonPressed;
    }


}
