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
    [SerializeField] private List<Tile> roadMap;

    private Vector3 position;
    private int id;

    private void Awake()
    {
        tilemap = new Tile[height, width];
        CreateGrid();
        CreateRoadMap();
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

    private void CreateRoadMap()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (!tilemap[i, j].wall)                   
                      roadMap.Add(tilemap[i, j]);                                                 
            }
        }
    }

    public bool CheckMove( ref Tile t, Direction direction)
    { 
        switch (direction)
        {
            case Direction.Up:
               
                if (CheckLimits(t.x-1,t.y))
                {
                    t = tilemap[t.x - 1, t.y];                    
                    return true;
                }                
                break;
            
            case Direction.Down:
                if (CheckLimits(t.x+1,t.y))
                {
                    t = tilemap[t.x + 1, t.y];
                    return true;
                }                
                break;
            
            case Direction.Left:
                if (CheckLimits(t.x,t.y-1))
                {
                    t = tilemap[t.x , t.y-1];
                    return true;
                }                
                break;
            
            case Direction.Right:
                if (CheckLimits(t.x,t.y+1))
                {
                    t = tilemap[t.x, t.y+1];
                    return true;
                }                
                break;
        }

       return false;
    }

    public void RandSpawnObject(ref Tile t)
    {
        int rand;       

        do
        {
            rand = Random.Range(0, roadMap.Count);            
            
        } while (roadMap[rand].occupied|| roadMap[rand].wall);

        t = roadMap[rand];
        roadMap[rand].occupied = true;
    }
    
    public void RandSpawnCharacters( ref Tile t)
    {
        int rand;

        do
        {
            rand = Random.Range(0, roadMap.Count);

        } while ( roadMap[rand].wall);

        t = roadMap[rand];
    }

    public void SpawnPoint( ref Tile t)
    {
        t=tilemap[0,0];
        tilemap[0, 0].occupied = true;
    }    
   
    
    private bool CheckLimits(int x, int y)
    {   
        if (x < 0 || y < 0 || x == height || y == width)
            return false;
        else return !tilemap[x, y].wall;
    }
    
    

    
}
