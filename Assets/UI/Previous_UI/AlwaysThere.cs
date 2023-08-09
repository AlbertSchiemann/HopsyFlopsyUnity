public static class AlwaysThere
{
    public static int MainMenu_Index = 0; //for opening the right canvas in main menu from different scenes
    public static int LastLevel = 0;  //for the button 'last level'
    public  enum Skin { 
    
        Skin1,
        Skin2,
        Skin3,
        Skin4,
        }
    public static int currentSkin;

    public static bool bottleThere = false;
    public static bool shieldThere = false;

    public static bool MusicIcon = true;
    public static bool SFXIcon = true;

    public static int time = 0;

    public static bool TimeStar = false;
    public static bool CurrencyStar = false;

}