using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_HelpLevel : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butBack;
    Button butStore;
    Button butSettings;
    Button Level1;
    Button IntroVideo;
    Button ControlExp;

    VisualElement vis_ControlExp;

    [SerializeField] private AudioClip[] _UISound;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");
        butBack = root.Q<Button>("but_back");
        Level1 = root.Q<Button>("but_Level1");
        IntroVideo = root.Q<Button>("but_IntroVideo");
        ControlExp = root.Q<Button>("but_controlExpl");

        vis_ControlExp = root.Q<VisualElement>("vis_eplanationControls");

        butStore.clicked += Store;
        butSettings.clicked += Settings;
        butBack.clicked += Back;
        //Level1.clicked += Level_1;
        //IntroVideo.clicked += Intro;
        ControlExp.clicked += Explanation;

        vis_ControlExp.style.display = DisplayStyle.None;

    }



        void Store()
        {
            SoundManager.Instance.PlaySound(_UISound);
            switchScreen.OpenStore();
        }

        void Settings()
        {
            SoundManager.Instance.PlaySound(_UISound);
            switchScreen.OpenSettings();
        }

        void Back()
        {
            SoundManager.Instance.PlaySound(_UISound);
            switchScreen.OpenPause();
        }

    //void Level_1()   //macht keinen sinn, soll szene nicht verlassen, muss wahrscheinlich das prefab ge�ndert werden/ein anderes ui document eingef�gt werden
    //{
    //    C_UI_OpenOther.ToLevel1();

    //}

    //void Intro()
    //{
    //     C_UI_OpenOther.ToVideo();

    //}

    void Explanation()
    {
        //animation - kn�pfe nach oben
        //vis_exp animation entweder rein vo seite / oder langsam erscheinen
        vis_ControlExp.style.display = DisplayStyle.Flex;

    }


}




