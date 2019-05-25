using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Serialization;

public class StatisticsControl : MonoBehaviour
{
    public static StatisticsControl Instance;

    public Statistics SavedStats;
    public Settings   SavedSettings;

    
    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            Instance.SavedStats = new Statistics();
            Instance.SavedSettings = new Settings();
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }

        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt ("sound", SavedSettings.IsSoundOn);
        PlayerPrefs.SetInt ("music", Instance.SavedSettings.IsMusicOn);
        PlayerPrefs.SetInt ("loggedin", Instance.SavedSettings.IsLoggedInWithGoogle);
        PlayerPrefs.SetInt ("bestscore", Instance.SavedStats.BestScore);
        PlayerPrefs.SetInt ("totalscore", Instance.SavedStats.TotalScore);
        PlayerPrefs.SetInt ("bestbonus", Instance.SavedStats.BestBonus);
        PlayerPrefs.SetInt ("totalbonuses", Instance.SavedStats.TotalBonuses);
        PlayerPrefs.Save ();
    }

    public void LoadData()
    {
        #region SETTINGS

        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetInt("sound", 1);
            Instance.SavedSettings.IsSoundOn = 1;
            PlayerPrefs.Save ();
        }
        else
        {
            Instance.SavedSettings.IsSoundOn = PlayerPrefs.GetInt("sound");
        }
        
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            Instance.SavedSettings.IsSoundOn = 1;
            PlayerPrefs.Save ();
        }
        else
        {
            Instance.SavedSettings.IsMusicOn = PlayerPrefs.GetInt("music");
        }
        
        if (!PlayerPrefs.HasKey("loggedin"))
        {
            PlayerPrefs.SetInt("loggedin", 0);
            Instance.SavedSettings.IsLoggedInWithGoogle = 0;
            PlayerPrefs.Save ();
        }
        else
        {
            Instance.SavedSettings.IsLoggedInWithGoogle = PlayerPrefs.GetInt("loggedin");
        }
        #endregion

        #region STATS
        if (!PlayerPrefs.HasKey("bestscore"))
        {
            PlayerPrefs.SetInt("bestscore", 0);
            Instance.SavedStats.BestScore = 0;
            PlayerPrefs.Save ();
        }
        else
        {
            Instance.SavedStats.BestScore = PlayerPrefs.GetInt("bestscore");
        }
        
        if (!PlayerPrefs.HasKey("totalscore"))
        {
            PlayerPrefs.SetInt("totalscore", 0);
            Instance.SavedStats.TotalScore = 0;
            PlayerPrefs.Save ();
        }
        else
        {
            Instance.SavedStats.TotalScore = PlayerPrefs.GetInt("totalscore");
        }
        
        if (!PlayerPrefs.HasKey("bestbonus"))
        {
            PlayerPrefs.SetInt("bestbonus", 0);
            Instance.SavedStats.BestBonus = 0;
            PlayerPrefs.Save ();
        }
        else
        {
            Instance.SavedStats.BestBonus = PlayerPrefs.GetInt("bestbonus");
        }
        
        if (!PlayerPrefs.HasKey("totalbonuses"))
        {
            PlayerPrefs.SetInt("totalbonuses", 0);
            Instance.SavedStats.TotalBonuses = 0;
            PlayerPrefs.Save ();
        }
        else
        {
            Instance.SavedStats.TotalBonuses = PlayerPrefs.GetInt("totalbonuses");
        }

        #endregion
    }

}
