using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public int bonuses;

    // Use this for initialization
    void Start () {
        score = 0;
        bonuses = 0;
    }

    //checks for entering a trigger
    void OnTriggerEnter2D(Collider2D other){
        //checks other collider's tag
        if(other.gameObject.tag == EnumsSet.Tags.Food.ToString()){
            score += 10;								//increments score
        }
        else if (other.gameObject.tag == EnumsSet.Tags.Bonus.ToString())
        {
            score += 20;
            bonuses++;
        }
    }
}
