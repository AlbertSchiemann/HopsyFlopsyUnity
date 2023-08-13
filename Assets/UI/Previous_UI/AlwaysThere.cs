using Unity.VisualScripting;
using UnityEngine;

public static class AlwaysThere
{
    public static int MainMenu_Index = 0; //for opening the right canvas in main menu from different scenes
    public static int LastLevel = 0;      //for the button 'last level'
    public enum Skin
    {
        Skin1,
        Skin2,
        Skin3,
        Skin4,
    }
    public static int currentSkin;

    public static bool bottleThere = false;
    public static bool shieldThere = false;

    public static int FishMoney = 0;

    public static bool MusicIcon = true;
    public static bool SFXIcon = true;

    public static int time = 0;

    public static bool TimeStar = false;     //of lv 1
    public static bool CurrencyStar = false; //of lv 1

    public static bool TimeStar2 = false;     //of lv 2
    public static bool CurrencyStar2 = false; //of lv 2

    public static bool TimeStar3 = false;     //of lv 3
    public static bool CurrencyStar3 = false; //of lv 3

    public static bool level2Unlocked = false;
    public static bool level3Unlocked = false;
    public static bool level4Unlocked = false;

    public static bool skin2Bought = false;
    public static bool skin3Bought = false;

    public static bool firstPlayed1 = false;
    public static bool firstPlayed2 = false;
    public static bool firstPlayed3 = false;
}