using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnumsSet
{
    public enum Tags
    {
        Player,
        Obstacle,
        Food,
        Bonus,
        ShowOnPause,
        ShowOnGameOver,
        HideOnGameOver,
    }
    
    public enum Scenes
    {
        MainLevel,
        MainMenu,
        Profile,
        Settings,
        Credits,
    }
}
