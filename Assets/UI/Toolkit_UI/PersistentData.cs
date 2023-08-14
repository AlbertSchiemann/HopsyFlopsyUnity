using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public void Awake()
    {
        //PlayerPrefs.DeleteAll(); //wenn man alles löschen möchte

        AlwaysThere.currentSkin = LoadPrefsInt("currentSkin");
        AlwaysThere.LastLevel = LoadPrefsInt("LastLevel");
        AlwaysThere.FishMoney = LoadPrefsInt("FishMoney");
        Debug.Log("after data loaded: " + AlwaysThere.currentSkin);


        if (LoadPrefsInt("TimeStar") == 1) AlwaysThere.TimeStar = true;
        if (LoadPrefsInt("CurrencyStar") == 1) AlwaysThere.CurrencyStar = true;

        if (LoadPrefsInt("TimeStar2") == 1) AlwaysThere.TimeStar2 = true;
        if (LoadPrefsInt("CurrencyStar2") == 1) AlwaysThere.CurrencyStar2 = true;

        if (LoadPrefsInt("TimeStar3") == 1) AlwaysThere.TimeStar3 = true;
        if (LoadPrefsInt("CurrencyStar3") == 1) AlwaysThere.CurrencyStar3 = true;



        if (LoadPrefsInt("level2Unlocked") == 1) AlwaysThere.level2Unlocked = true;
        if (LoadPrefsInt("level3Unlocked") == 1) AlwaysThere.level3Unlocked = true;

        if (LoadPrefsInt("skin2Bought") == 1) AlwaysThere.skin2Bought = true;
        if (LoadPrefsInt("skin3Bought") == 1) AlwaysThere.skin3Bought = true;

        if (LoadPrefsInt("firstPlayed1") == 1) AlwaysThere.firstPlayed1 = true;
        if (LoadPrefsInt("firstPlayed2") == 1) AlwaysThere.firstPlayed2 = true;
        if (LoadPrefsInt("firstPlayed3") == 1) AlwaysThere.firstPlayed3 = true;

        Debug.Log("Data Loaded");
    }

    public static void SavePrefsInt(string Key, int value)
    {
        PlayerPrefs.SetInt(Key, value);
        PlayerPrefs.Save();
    }
    public static void SavePrefsFloat(string Key, float value)
    {
        PlayerPrefs.SetFloat(Key, value);
        PlayerPrefs.Save();
    }
    public static void SavePrefsString(string Key, string value)
    {
        PlayerPrefs.SetString(Key, value);
        PlayerPrefs.Save();
    }

    public static int LoadPrefsInt(string Key)
    {
        int x = PlayerPrefs.GetInt(Key, 0);
        return x;
    }
    public static float LoadPrefsFloat(string Key)
    {
        float x = PlayerPrefs.GetFloat(Key, 0);
        return x;
    }
    public static string LoadPrefsString(string Key)
    {
        string x = PlayerPrefs.GetString(Key, "");
        return x;
    }

    public void OnDestroy()
    {
        SavePrefsInt("currentSkin", AlwaysThere.currentSkin);
        SavePrefsInt("LastLevel", AlwaysThere.LastLevel);
        SavePrefsInt("FishMoney", AlwaysThere.FishMoney);
        Debug.Log("after data saved: " + AlwaysThere.currentSkin);

        if (AlwaysThere.TimeStar == true) SavePrefsInt("TimeStar", 1);
        if (AlwaysThere.CurrencyStar == true) SavePrefsInt("CurrencyStar", 1);

        if (AlwaysThere.TimeStar2 == true) SavePrefsInt("TimeStar", 1);
        if (AlwaysThere.CurrencyStar2 == true) SavePrefsInt("CurrencyStar", 1);

        if (AlwaysThere.TimeStar3 == true) SavePrefsInt("TimeStar", 1);
        if (AlwaysThere.CurrencyStar3 == true) SavePrefsInt("CurrencyStar", 1);


        if (AlwaysThere.skin2Bought == true) SavePrefsInt("skin2Bought", 1);
        if (AlwaysThere.skin3Bought == true) SavePrefsInt("skin3Bought", 1);

        if (AlwaysThere.level2Unlocked == true) SavePrefsInt("level2Unlocked", 1);
        if (AlwaysThere.level3Unlocked == true) SavePrefsInt("level3Unlocked", 1);


        if (AlwaysThere.firstPlayed1 == true) SavePrefsInt("firstPlayed1", 1);
        if (AlwaysThere.firstPlayed2 == true) SavePrefsInt("firstPlayed2", 1);
        if (AlwaysThere.firstPlayed3 == true) SavePrefsInt("firstPlayed3", 1);

        Debug.Log("Data Saved");
    }
}

