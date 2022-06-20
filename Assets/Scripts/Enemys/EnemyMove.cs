using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour,ISpawmer
{
    [SerializeField] private SpawnData SpawnData;
    [SerializeField]private TileMapController tilemap;
    private Tile currentTile;
    private bool gameOver;
    
    private Rigidbody2D rb;
    private TileMapController.Direction _direction;
    [SerializeField] private float timeToMove;
    private float time;

    private void OnEnable()
    {
        UI.SendGameOver += SetGameOver;
    }

    private void OnDisable()
    {
        UI.SendGameOver -= SetGameOver;
    }
    
    private void SetGameOver()
    {
        gameOver = true;
    }

    public void Spawn()
    {
        rb = GetComponent<Rigidbody2D>();
        _direction = (TileMapController.Direction)Random.Range(0, 4);
        gameObject.SetActive(true);
        currentTile = gameObject.AddComponent<Tile>();
        tilemap.RandSpawnCharacters(currentTile);
        rb.position = currentTile.pos;
        
    }
    
    public int Amount()
    {
        return SpawnData.Amount;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (gameOver) return;
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
