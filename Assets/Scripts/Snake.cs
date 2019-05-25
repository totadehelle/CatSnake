using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour
{
    // Tail Prefab
    public GameObject tailPrefab;
    public GameObject tailFirst;
    public GameObject end;
    public ScoreCounter counter;
    
    
    // Current Movement Direction
    // (by default it moves to the right)
    Vector2 dir = new Vector2(16,0);
    //Vector3 dir2 = new Vector3(32,0, 0);

    
    // Keep Track of Tail
    List<Transform> tail = new List<Transform>();

    bool ate = false;
    
    public bool alive;
    
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        //var w = GetComponent<SpriteRenderer>().sprite.rect.width/transform.localScale.x;
        //Debug.Log(w);
        
        tail.Add(tailFirst.transform);
        end.transform.position = new Vector3(tail.Last().position.x, tail.Last().position.y, -0.01f);
        
        // Move the Snake every 300ms
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            dir = Vector2.Perpendicular(dir);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            dir = -Vector2.Perpendicular(dir);
        }
    }
    
    void Move() {
        // Save current position (gap will be here)
        Vector2 v = transform.position;

        // Move head into new direction (now there is a gap)
        transform.Translate(dir);
        //var newPos = transform.position + Vector3.up*16;
        //transform.position = newPos;
        //return;    
        // Ate something? Then insert new Element into gap
        if (ate) {
            // Load Prefab into the world
            GameObject g =Instantiate(tailPrefab,
                v,
                Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }
        // Do we have a Tail?
        else if (tail.Count > 0) {
            
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count-1);

            end.transform.position = new Vector3(tail.Last().position.x, tail.Last().position.y, -0.01f);
        }
    }
    
    void OnTriggerEnter2D(Collider2D coll) {
        // Food?
            if(coll.gameObject.CompareTag(EnumsSet.Tags.Food.ToString())){
            // Get longer in next Move call
            ate = true;
            // Remove the Food
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.CompareTag(EnumsSet.Tags.Bonus.ToString()) && tail.Count >=5)
            {
                //Shortening the snake by 20%
                int tailLenght = tail.Count;
                int lastSection = tailLenght / 5;
                
                for (int i = tailLenght-1; tail.Count > tailLenght - lastSection; i--)
                {
                    Destroy(tail[i].gameObject);
                    tail.RemoveAt(i);
                }
                
                // Remove the Food
                Destroy(coll.gameObject);
                end.transform.position = new Vector3(tail.Last().position.x, tail.Last().position.y, -0.01f);
            }
            
            // Collided with Tail, Border or Bad Food
        else {
            //Pauses gameplay
            alive = false;
            Time.timeScale = 0;
            SaveResults(counter);
        }
    }

    void SaveResults(ScoreCounter counter)
    {
        if (counter.score > StatisticsControl.Instance.SavedStats.BestScore)
        {
            StatisticsControl.Instance.SavedStats.BestScore = counter.score;
        }

        StatisticsControl.Instance.SavedStats.TotalScore += counter.score;
        
        if (counter.bonuses > StatisticsControl.Instance.SavedStats.BestBonus)
        {
            StatisticsControl.Instance.SavedStats.BestBonus = counter.bonuses;
        }
        
        StatisticsControl.Instance.SavedStats.TotalBonuses += counter.bonuses;
        
        StatisticsControl.Instance.SaveData();
    }
}
