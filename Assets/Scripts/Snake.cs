using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine.Serialization;

public class Snake : MonoBehaviour
{
    public class RotationTimer
    {
        public int _element_index;
        public float _timer;
        public Quaternion _rotation;

        public RotationTimer(float time, Quaternion rotation)
        {
            _element_index = FirstTailPart;
            _timer = time;
            _rotation = rotation;
        }
    }
    
    // Tail Prefab
    public GameObject tailPrefab;
    public GameObject tailFirst;
    public GameObject tailSecond;
    //public GameObject end;
    public ScoreCounter counter;

    private Transform headTransform;

    //private int startBodySize = 4;
    
    [SerializeField]
    private const float Speed = 80f;
    private const int FirstTailPart = 1;
    public float MaxTimeTillRotation;
    

    private float _distanceBetweenParts;

    List<Transform> Tail = new List<Transform>();
    List<RotationTimer> Timers = new List<RotationTimer>();
    
    private Transform currentTailPart;
    private Transform previousTailPart;
    
    Vector2 dir = Vector2.down;

    bool ate = false;
    public bool alive;
    
    // Start is called before the first frame update
    void Start()
    {
        Tail.Add(gameObject.transform);
        Tail.Add(tailFirst.transform);
        Tail.Add(tailSecond.transform);

        alive = true;
        headTransform = transform;

        _distanceBetweenParts = tailPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
        

        MaxTimeTillRotation = _distanceBetweenParts / Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    /*void AddBodyPart()
    {
        Transform newBody = (Instantiate(tailPrefab, Tail[Tail.Count - 1].position + Vector3.up*30,
            Tail[Tail.Count - 1].rotation) as GameObject).transform;
        newBody.SetParent(transform.parent);
        Tail.Add(newBody);
    }*/
    
    
    
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            headTransform.Rotate(0, 0f, 90f);
            Timers.Add(new RotationTimer(MaxTimeTillRotation, headTransform.rotation));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            headTransform.Rotate(0, 0f, -90f);
            Timers.Add(new RotationTimer(MaxTimeTillRotation, headTransform.rotation));
        }


        foreach (var tailPart in Tail)
        {
            tailPart.Translate(Vector2.down * Speed * Time.deltaTime);
        }
        
        
        if (Tail.Any())
        {
            RotateTailParts(Time.deltaTime);
        }
    }


    private void RotateTailParts(float delta)
    {
        for (var i = 0; i < Timers.Count;)
        {
            var rotationTimer = Timers[i];
            if (rotationTimer._element_index == Tail.Count)
            {
                Timers.Remove(rotationTimer);
                continue;
            }
            else
            {
                i++;
            }

            rotationTimer._timer -= delta;
            if (rotationTimer._timer<0)
            {
                
                
                // Tail[rotationTimer._element_index].Translate(Vector2.up * Speed * rotationTimer._timer);
                Tail[rotationTimer._element_index].rotation = rotationTimer._rotation;
                rotationTimer._element_index++;
                rotationTimer._timer = MaxTimeTillRotation;
                
            }
        }
    }
    
    //Rewrite in accordance with new move algorithm
    void OnTriggerEnter2D(Collider2D coll) {
        
        // Food?
        if(coll.gameObject.CompareTag(EnumsSet.Tags.Food.ToString())){
            // Get longer in next Move call
            ate = true;
            // Remove the Food
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.CompareTag(EnumsSet.Tags.Bonus.ToString()) && Tail.Count >=5)
        {
            //Shortening the snake by 20%
            int tailLenght = Tail.Count;
            int lastSection = tailLenght / 5;
                
            for (int i = tailLenght-1; Tail.Count > tailLenght - lastSection; i--)
            {
                Destroy(Tail[i].gameObject);
                Tail.RemoveAt(i);
            }
                
            // Remove the Food
            Destroy(coll.gameObject);
            //    end.transform.position = new Vector3(tail.Last().position.x, tail.Last().position.y, -0.01f);
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