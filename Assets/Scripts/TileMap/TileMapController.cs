using System;
using System.Collections.Generic;
using UnityEngine;

public class TileMapController : MonoBehaviour
{
    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private SpriteRenderer ground;
    private Tile[,] tilemap;
    [SerializeField] private List<Tile> map;
    private Vector3 position;
    private int id;

    private void Awake()
    {
        tilemap = new Tile[height, width];
        CreateGrid();
    }

    private void Spawn()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {   
                if(j!=0)
                    position.x += ground.bounds.size.x;
                if(i!=0)
                    position.y = ground.transform.position.y - ground.bounds.size.y *i;
                if (i != 0 && j == 0)
                    position.x = ground.transform.position.x;

            }
        }
    }
    
    private void CreateGrid()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                tilemap[i, j] = map[id];
                tilemap[i, j].ID = id;
                id++;
            }
        }
    }

    
}
