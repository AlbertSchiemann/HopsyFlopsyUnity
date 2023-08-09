using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class C_Before : MonoBehaviour
{
    public C_LevelSwitchScreens switchScreen;

    Button butStore;
    Button butHelp;
    Button butSettings;

    Button butPlay;
    Button butMain;

    private GameStateManagerScript GameStateManagerScript;

    public GameObject skinToEquip1;
    public GameObject skinToEquip2;
    public GameObject skinToEquip3;
    public GameObject skinToEquip4;

    GameObject currentSkin;

    private SkinLoader player;

    [SerializeField] private AudioClip[] _UISound;

    private void Awake()
    {
        GameObject GameStateManager = GameObject.Find("GameStateManager");
        GameStateManagerScript = GameStateManager.GetComponent<GameStateManagerScript>();
    }
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        player = GameObject.Find("Player3D Grid").GetComponent<SkinLoader>();

        GameStateManagerScript.PauseGame();

        butHelp = root.Q<Button>("but_help");
        butStore = root.Q<Button>("but_store");
        butSettings = root.Q<Button>("but_settings");

        butMain = root.Q<Button>("but_back");
        butPlay = root.Q<Button>("but_play");


        butHelp.clicked += Help;
        butStore.clicked += Store;
        butSettings.clicked += Settings;

        butMain.clicked += Main;
        butPlay.clicked += Play;

        if (AlwaysThere.currentSkin == 0) currentSkin = skinToEquip1;
        else if (AlwaysThere.currentSkin == 1) currentSkin = skinToEquip2;
        else if (AlwaysThere.currentSkin == 2) currentSkin = skinToEquip3;
        else if (AlwaysThere.currentSkin == 3) currentSkin = skinToEquip4;
        

        player.ChangeSkin(currentSkin);
    }


    void Help()
    {
        SwipeManager.tapping = false;
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMain_Help();
    }

    void Store()
    {
        SwipeManager.tapping = false;
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMain_Store();

    }

    void Settings()
    {
        SwipeManager.tapping = false;
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMain_Settings();

    }

    void Main()
    {
        SwipeManager.tapping = false;
        SoundManager.Instance.PlaySound(_UISound);
        C_UI_OpenOther.ToMainMenu();
    }

    void Play()
    {
        SwipeManager.tapping = false;
        SoundManager.Instance.PlaySound(_UISound);
        switchScreen.OpenPlaying();
    }
}