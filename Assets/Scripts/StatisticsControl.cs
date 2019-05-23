using UnityEngine;

public class StatisticsControl : MonoBehaviour
{
    public static StatisticsControl Instance;

    public Statistics savedStats;
    public Settings SavedSettings;
    
    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            Instance.savedStats = new Statistics();
            Instance.SavedSettings = new Settings();
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }

}
