using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    private Text text;
    // Use this for initialization
    void Start () {
        text = gameObject.GetComponent<Text>();
        text.text = "Score: 0";
    }

    // Update is called once per frame
    void Update () {
        text.text = "Score: " + scoreCounter.score;
    }

}
