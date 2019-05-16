using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour
{
    // Tail Prefab
    public GameObject tailPrefab;
    
    // Current Movement Direction
    // (by default it moves to the right)
    Vector2 dir = Vector2.right;
    
    // Keep Track of Tail
    List<Transform> tail = new List<Transform>();

    bool ate = false;
    
    public bool alive;
    
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        // Move the Snake every 300ms
        InvokeRepeating("Move", 0.3f, 0.1f);
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

        // Ate something? Then insert new Element into gap
        if (ate) {
            // Load Prefab into the world
            GameObject g =(GameObject)Instantiate(tailPrefab,
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
                var lastSection = (int) tailLenght / 5;
                
                for (int i = tailLenght-1; tail.Count > tailLenght - lastSection; i--)
                {
                    Destroy(tail[i].gameObject);
                    tail.RemoveAt(i);
                }
                
                // Remove the Food
                Destroy(coll.gameObject);
            }
            
            // Collided with Tail, Border or Bad Food
        else {
            //Pauses gameplay
            alive = false;
            Time.timeScale = 0;         
        }
    }
}
