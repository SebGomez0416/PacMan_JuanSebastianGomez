using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour,ISpawmer
{
    [SerializeField]private int score;
    [SerializeField]private TileMapController tilemap;
    private Tile currentTile;
    
    private Rigidbody2D rb;
    private TileMapController.Direction _direction;
    [SerializeField] private float timeToMove;
    [SerializeField] private float time;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _direction = (TileMapController.Direction)Random.Range(0, 4);
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        currentTile = gameObject.AddComponent<Tile>();
        currentTile.occupied = true;
        tilemap.RandSpawnPoint(currentTile);
        rb.position = currentTile.pos;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        time += 1 * Time.deltaTime;

        if (time >= timeToMove)
        {
            time = 0;
            bool check = tilemap.CheckMove(currentTile, _direction);
        
            while (!check)
            {
                _direction = (TileMapController.Direction)Random.Range(0, 4);
                check = tilemap.CheckMove(currentTile, _direction);
            }
        
            rb.position = currentTile.pos;
        }
    }
}
