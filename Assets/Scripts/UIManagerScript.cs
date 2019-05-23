using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] finishObjects;
    private GameObject[] hideOnFinishObjects;
    private Snake playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag(EnumsSet.Tags.ShowOnPause.ToString());
        hidePaused();
        //gets all objects with tag ShowOnFinish
        finishObjects = GameObject.FindGameObjectsWithTag(EnumsSet.Tags.ShowOnGameOver.ToString());
        hideFinished();
        hideOnFinishObjects = GameObject.FindGameObjectsWithTag(EnumsSet.Tags.HideOnGameOver.ToString());
        
        //Checks to make sure MainLevel is the loaded level
        if(Application.loadedLevelName == "MainLevel")
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Snake>();
    }

    // Update is called once per frame
    void Update()
    {
        //shows finish gameobjects if player is dead and timescale = 0
        if (Time.timeScale == 0 && playerController.alive == false){
            showFinished();
            hideObjectsOnGameOver();
        }
    }
    
    public void pauseControl(){
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        } else if (Time.timeScale == 0){
            Time.timeScale = 1;
            hidePaused();
        }
    }
    
    //shows objects with ShowOnPause tag
    public void showPaused(){
        foreach(GameObject g in pauseObjects){
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused(){
        foreach(GameObject g in pauseObjects){
            g.SetActive(false);
        }
    }
    
    public void showFinished(){
        foreach(GameObject g in finishObjects){
            g.SetActive(true);
        }
    }
    
    //hides objects with ShowOnFinish tag
    public void hideFinished(){
        foreach(GameObject g in finishObjects){
            g.SetActive(false);
        }
    }
    
    public void hideObjectsOnGameOver(){
        foreach(GameObject g in hideOnFinishObjects){
            g.SetActive(false);
        }
    }
    
    //loads inputted level
    public void SoundControl()
    {
        StatisticsControl.Instance.SavedSettings.IsSoundOn = !StatisticsControl.Instance.SavedSettings.IsSoundOn;
    }
    public void MusicControl()
    {
        StatisticsControl.Instance.SavedSettings.IsMusicOn = !StatisticsControl.Instance.SavedSettings.IsMusicOn;
    }
    public void LogInControl()
    {
        StatisticsControl.Instance.SavedSettings.IsLoggedInWithGoogle = !StatisticsControl.Instance.SavedSettings.IsLoggedInWithGoogle;
    }
    public void CreditsControl()
    {
        Application.LoadLevel(EnumsSet.Scenes.Credits.ToString());
    }
    
    public void LoadLevel(string level){
        Application.LoadLevel(level);
    }
    
    public void Reload(){
        Application.LoadLevel(Application.loadedLevel);
    }
}
