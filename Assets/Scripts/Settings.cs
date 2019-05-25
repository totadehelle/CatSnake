using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
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

    public int IsSoundOn
    {
         get
         {
             
             return (_isSoundOn == -1) ? (_isSoundOn = PlayerPrefs.GetInt("sound")) : _isSoundOn;
         }
         set
         {
             _isSoundOn = value ;
              PlayerPrefs.SetInt("sound",value);
             
         }
    }

    public int IsMusicOn;
    public int IsLoggedInWithGoogle;
    public Skins Skin;
    public FoodSets FoodSet;
    private int _isSoundOn = -1;
}
