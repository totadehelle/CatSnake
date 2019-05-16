using UnityEngine;
namespace DefaultNamespace
{
    public class SpawnFood : MonoBehaviour
    {
        // Food Prefabs
        public GameObject GoodFoodPrefab;
        public GameObject BadFoodPrefab;
        public GameObject BonusFoodPrefab;
    
        // Borders
        public Transform borderTop;
        public Transform borderBottom;
        public Transform borderLeft;
        public Transform borderRight;

        public MovesCounterScript movesCounter;
        private int currentMove;
        private System.Random random = new System.Random();
    
        // Start is called before the first frame update
        void Start()
        {
            // Spawn food every 4 seconds, starting in 3
            //InvokeRepeating(nameof(Spawn), 3, 4);
            Spawn(GoodFoodPrefab);
            currentMove = 1;
        }
        
        
        // Update is called once per frame
        void Update ()
        {
            if (currentMove != movesCounter.movesCount)
            {
                int dice = random.Next(10);
                if (movesCounter.movesCount > 10)
                {
                    if (dice < 3) // 30 % chance
                    {
                        Spawn(BadFoodPrefab);
                    }
                    else if (dice > 7) // 20 % chance
                    {
                        Spawn(BonusFoodPrefab);
                    }
                    Spawn(GoodFoodPrefab);
                }
                else if (movesCounter.movesCount > 5)
                {
                    if (dice < 3)
                    {
                        Spawn(BadFoodPrefab);
                    }
                    Spawn(GoodFoodPrefab);
                }
                else
                {
                    Spawn(GoodFoodPrefab);
                }

                currentMove = movesCounter.movesCount;
            }
        }
    
        // Spawn one piece of food
        void Spawn(GameObject foodPrefab)
        {
            // x position between left & right border
            int x = (int)Random.Range(borderLeft.position.x+2,
                borderRight.position.x);

            // y position between top & bottom border
            int y = (int)Random.Range(borderBottom.position.y+2,
                borderTop.position.y);

            // Instantiate the food at (x, y)
            Instantiate(foodPrefab,
                new Vector2(x, y),
                Quaternion.identity); // default rotation
        }
    }
}