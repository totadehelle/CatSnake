using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public enum Skins
    {
        basic,
    }

    public enum FoodSets
    {
        basic,
    }
    
    public bool IsSoundOn = true;
    public bool IsMusicOn = true;
    public bool IsLoggedInWithGoogle = false;
    public Skins Skin = Skins.basic;
    public FoodSets FoodSet = FoodSets.basic;
}
