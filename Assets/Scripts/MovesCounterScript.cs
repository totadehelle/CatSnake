using UnityEngine;

public class MovesCounterScript : MonoBehaviour
{
    public int movesCount;
    // Use this for initialization
    void Start () {
        movesCount = 1;
    }

    //checks for entering a trigger
    void OnTriggerEnter2D(Collider2D other){
        //checks other collider's tag
        if(other.gameObject.tag == EnumsSet.Tags.Food.ToString()){
            movesCount ++;	//increments moves counter
        }
    }
}
