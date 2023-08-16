using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class C_Help : MonoBehaviour
{
    public C_Clean_SwitchScreens switchScreenW1;

    Button butBack;
    Button butStore;
    Button butSettings;
    Button Level1;
    Button IntroVideo;
    Button ControlExp, Prev, Next;

    VisualElement vis_ControlExp;

    VisualElement underMain, Small;

    public Sprite Tut1, Tut2, Tut3;

    [SerializeField] private AudioClip[] _UISound;
    int switcher = 0;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");
        butBack = root.Q<Button>("but_back");
        Level1 = root.Q<Button>("but_Level1");
        IntroVideo = root.Q<Button>("but_IntroVideo");
        ControlExp = root.Q<Button>("but_controlExpl");

        Next = root.Q<Button>("but_switcherNext");
        Prev = root.Q<Button>("but_switcherPrev");

        vis_ControlExp = root.Q<VisualElement>("vis_eplanationControls");
        Small = root.Q<VisualElement>("vis_small");
        underMain = root.Q<VisualElement>("vis_main");

        butStore.clicked += Store;
        butSettings.clicked += Settings;
        butBack.clicked += Back;
        Level1.clicked += Level_1;
        IntroVideo.clicked += Intro;
        ControlExp.clicked += Explanation;
        Next.clicked += NextPage;
        Prev.clicked += PrevPage;

        vis_ControlExp.style.display = DisplayStyle.None;
        Small.style.display = DisplayStyle.None;
        Next.style.display = DisplayStyle.None;
        Prev.style.display = DisplayStyle.None;

    }



        void Store()
        {
            SoundManager.Instance.PlaySound(_UISound);
            switchScreenW1.OpenStore();
        }

        void Settings()
        {
            SoundManager.Instance.PlaySound(_UISound);
            switchScreenW1.OpenSettings();
        }

        void Back()
        {
            SoundManager.Instance.PlaySound(_UISound);
            Debug.Log("afterr");
            switchScreenW1.OpenMain();
        }

    void Level_1()
    {
        C_UI_OpenOther.ToLevel1();

    }

    void Intro()
    {
         C_UI_OpenOther.ToVideo();

    }

    void Explanation()
    {
        vis_ControlExp.style.display = DisplayStyle.Flex;
        vis_ControlExp.style.backgroundImage = new StyleBackground(Tut1);
        ControlExp.style.display = DisplayStyle.None;
        Small.style.display = DisplayStyle.Flex;
        underMain.style.display = DisplayStyle.None;
        Next.style.display = DisplayStyle.Flex;
        //animation - kn�pfe nach oben
        //vis_exp animation entweder rein vo seite / oder langsam erscheinen

    }

    void NextPage()
    {
        if (switcher == 0)
        {
            vis_ControlExp.style.backgroundImage = new StyleBackground(Tut2);
            Prev.style.display = DisplayStyle.Flex;
        }
        else
        {
            vis_ControlExp.style.backgroundImage = new StyleBackground(Tut3);
            Next.style.display = DisplayStyle.None; ;
        }
        switcher++;
    }

    void PrevPage()
    {
        if (switcher == 1)
        {
            vis_ControlExp.style.backgroundImage = new StyleBackground(Tut1);
            Prev.style.display = DisplayStyle.None;
        }
        else
        {
            vis_ControlExp.style.backgroundImage = new StyleBackground(Tut2);
            Next.style.display = DisplayStyle.Flex;
        }
        switcher--;
    }


}




