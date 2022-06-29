using UnityEngine;

public class CharacterMove : MonoBehaviour,ISpawmer
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] private float lerpTime;
    private TileMapController tilemap;
    [SerializeField] private SpawnData SpawnData;
    [SerializeField] private float timeToMove;
    private Tile currentTile;
    private bool gameOver;
    private bool isMove;
    private Vector2 initPos;
    private float time;

    public void Spawn(TileMapController map)
    {
        tilemap = map;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        initPos = rb.position;
        sr.enabled = true;
        tilemap.SpawnPoint(out currentTile);
        rb.position = currentTile.pos;
    }
    
    public int GetAmount()
    {
        return SpawnData.Amount;
    }

    private void OnEnable()
    {
        CharacterDeath.NotifyDeath += ResetPosition;
        CharacterDeath.NotifyDeath += SpawnCharacter;
        UI.SendGameOver += SetGameOver;
    }

    private void OnDisable()
    {
        CharacterDeath.NotifyDeath -= ResetPosition;
        CharacterDeath.NotifyDeath -= SpawnCharacter;
        UI.SendGameOver -= SetGameOver;
    }

    private void SpawnCharacter()
    { 
        Invoke("ReSpawn",2);
    }

    private void ReSpawn()
    {
        sr.enabled = true;
        tilemap.SpawnPoint( out currentTile);
        rb.position = currentTile.pos;
        isMove = false;
    }

    private void ResetPosition()
    {   
        sr.enabled = false;
        rb.position = initPos;
        isMove = true;
    }

    private void SetGameOver()
    {
        gameOver = !gameOver;
    }

    private void Update()
    {
        time += 1 * Time.deltaTime;

        if (time >= timeToMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
                Movement(Direction.Dir.Up);

            if (Input.GetKeyDown(KeyCode.S))
                Movement(Direction.Dir.Down);

            if (Input.GetKeyDown(KeyCode.A))
                Movement(Direction.Dir.Left);
        
            if (Input.GetKeyDown(KeyCode.D))
                Movement(Direction.Dir.Right);
        }
        
        if (gameOver || isMove) return;
        rb.MovePosition(Vector2.Lerp(rb.position, currentTile.pos, lerpTime));
    }

    private void Movement(Direction.Dir direction)
    {
        if (direction == Direction.Dir.Left) sr.flipX = true;
        if (direction == Direction.Dir.Right) sr.flipX = false;

        if (gameOver || isMove) return;
        time = 0;
        tilemap.CheckMove( ref currentTile, direction);
    }
}
