using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour,ISpawmer
{
    [SerializeField] private SpawnData SpawnData;
    [SerializeField]private TileMapController tilemap;
    [SerializeField] private float lerpTime;
    private Tile currentTile;
    private bool gameOver;
    
    private Rigidbody2D rb;  
    private SpriteRenderer sr;
    private Direction.Dir _direction;
    [SerializeField] private float timeToMove;
    private float time;

    private void Awake()
    {
      rb = GetComponent<Rigidbody2D>();
      sr = GetComponent<SpriteRenderer>();
    }

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
        gameOver = !gameOver;
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        _direction = (Direction.Dir)Random.Range(0, 4);
        tilemap.RandSpawnCharacters( out currentTile);
        rb.position = currentTile.pos;        
    }
    
    public int GetAmount()
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
            bool check = tilemap.CheckMove( ref currentTile, _direction);
        
            while (!check)
            {
                _direction = (Direction.Dir)Random.Range(0, 4);
                check = tilemap.CheckMove( ref currentTile, _direction);
            }
        }
        
        if (_direction == Direction.Dir.Left) sr.flipX = true;
        if (_direction == Direction.Dir.Right) sr.flipX = false;
        
        rb.MovePosition(Vector2.Lerp(rb.position,currentTile.pos,lerpTime));
    }
}
