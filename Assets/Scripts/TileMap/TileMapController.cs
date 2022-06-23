using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.IO;

public class TileMapController : MonoBehaviour
{
    public enum Direction {Up,Down,Left,Right}

    [SerializeField] private int height;
    [SerializeField] private int width;

    [SerializeField] private string level;
    
    [SerializeField] private SpriteRenderer sizeTile;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject door;
    
    private Tile[,] tilemap;
    private List<Tile> roadMap;
    private Vector3 position;

    private void Awake()
    {
       tilemap = new Tile[height, width];
       roadMap = new List<Tile>();
       Spawn();
       CreateRoadMap();
    }
    
    private void Spawn()
    {
        FileStream file = File.Open("Assets/Data/"+level+".dat", FileMode.Open);
        BinaryReader br = new BinaryReader(file);
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {   
                if(j!=0)
                    position.x += sizeTile.bounds.size.x;
                if(i!=0)
                    position.y = sizeTile.transform.position.y - sizeTile.bounds.size.y *i;
                if (i != 0 && j == 0)
                    position.x = sizeTile.transform.position.x;

                bool isWall = br.ReadBoolean();
                InitTile(isWall ? wallPrefab : groundPrefab, i, j, isWall);
            }
        }
        br.Close();
        file.Close();
        SpawnDoor();
    }

    private void SpawnDoor()
    {
        Instantiate(door, tilemap[0, height / 2].pos, gameObject.transform.rotation, transform);

    }
    
    private void InitTile( GameObject obj ,int i ,int j, bool wall)
    {
      tilemap[i, j] =Instantiate(obj, position, sizeTile.gameObject.transform.rotation, transform).GetComponent<Tile>();
      tilemap[i, j].x = i;
      tilemap[i, j].y= j;
      tilemap[i, j].wall= wall;
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

    public void RandSpawnObject(out Tile t)
    {
        int rand;       

        do
        {
            rand = Random.Range(0, roadMap.Count);            
            
        } while (roadMap[rand].occupied|| roadMap[rand].wall);

        t = roadMap[rand];
        roadMap[rand].occupied = true;
    }
    
    public void RandSpawnCharacters( out Tile t)
    {
        int rand;

        do
        {
            rand = Random.Range(0, roadMap.Count);

        } while ( roadMap[rand].wall);

        t = roadMap[rand];
    }

    public void SpawnPoint( out Tile t)
    {
        t=tilemap[0,height/2];
    }

    private bool CheckLimits(int x, int y)
    {   
        if (x < 0 || y < 0 || x == height || y == width)
            return false;
        else return !tilemap[x, y].wall;
    }

}
