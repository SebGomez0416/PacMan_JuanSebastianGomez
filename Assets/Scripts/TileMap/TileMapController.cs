using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileMapController : MonoBehaviour
{
    public enum Direction {Up,Down,Left,Right}
    
    [SerializeField] private int height;
    [SerializeField] private int width;
    
    [SerializeField] private SpriteRenderer ground;
    
    private Tile[,] tilemap;
    [SerializeField] private List<Tile> map;
    private List<Tile> groundMap;
   
    private Vector3 position;
    private int id;

    private void Awake()
    {
        groundMap = new List<Tile>();
        tilemap = new Tile[height, width];
        CreateGrid();
        CreatedGroundMap();
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
                tilemap[i, j].x = i;
                tilemap[i, j].y = j;
                id++;
            }
        }
    }

    private void CreatedGroundMap()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if(!tilemap[i, j].wall)
                   groundMap.Add(tilemap[i, j]); 
                
            }
        }
    }
    
    public void CheckMove(Tile t, Direction direction)
    { 
        switch (direction)
        {
            case Direction.Up:
                if (!Check(t.x-1,t.y)) return;
                ChangeTail(t,tilemap[t.x-1 , t.y]);
                break;
            
            case Direction.Down:
                if (!Check(t.x+1,t.y)) return;
                ChangeTail(t,tilemap[t.x+1 , t.y]);
                break;
            
            case Direction.Left:
                if (!Check(t.x,t.y-1)) return;
                ChangeTail(t,tilemap[t.x , t.y-1]);
                break;
            
            case Direction.Right:
                if (!Check(t.x,t.y+1)) return;
                ChangeTail(t,tilemap[t.x , t.y+1]);
                break;
        }
    }

    public void RandSpawnPoint(Tile t)
    {
        ChangeTail(t,groundMap[ Random.Range(0, groundMap.Count)]);
    }

    private void ChangeTail(Tile a, Tile b)
    {
        a.pos = b.pos;
        a.wall = b.wall;
        a.x = b.x;
        a.y = b.y;
    }
    
    private bool Check(int x, int y)
    {
        if (x < 0 || y < 0 || x == height || y == width)
            return false;
        else return !tilemap[x, y].wall;
    }
    
    

    
}
