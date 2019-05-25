using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class StatsUpdater : MonoBehaviour
{
    private GameObject bestScore;
    private GameObject totalScore;
    private GameObject bestBonus;
    
    
    // Start is called before the first frame update
    void Start()
    {
        bestScore = GameObject.Find("BestScoreText");
        totalScore = GameObject.Find("TotalScoreText");
        bestBonus = GameObject.Find("BestBonusText");
        
        bestScore.GetComponent<Text>().text = "Best Score: " + StatisticsControl.Instance.SavedStats.BestScore;

        totalScore.GetComponent<Text>().text = "Total Score: " + StatisticsControl.Instance.SavedStats.TotalScore;
        
        bestBonus.GetComponent<Text>().text = "Best Bonus: " + StatisticsControl.Instance.SavedStats.BestBonus;
    }
}
