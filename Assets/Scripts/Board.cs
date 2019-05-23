using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    
    private const int Height = 16;
    private const int Width = 8;
        
    private const float TileSize = 0.4f;
        
    public static int[,] Tiles = new int[Height,Width];
    
 
    
    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Tiles[x, y] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}