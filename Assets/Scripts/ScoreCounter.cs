using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score;

    // Use this for initialization
    void Start () {
        score = 0;
    }

    //checks for entering a trigger
    void OnTriggerEnter2D(Collider2D other){
        //checks other collider's tag
        if(other.gameObject.tag == EnumsSet.Tags.Food.ToString() 
           || other.gameObject.tag == EnumsSet.Tags.Bonus.ToString()){
            score += 10;								//increments score
        }
    }
}
