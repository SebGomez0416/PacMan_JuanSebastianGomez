using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] private float lerpTime;
    [SerializeField]private TileMapController tilemap;
    [SerializeField] private float timeToMove;
    private Tile currentTile;
    private bool gameOver;
    private bool isMove;
    private Vector2 initPos;
    private float time;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        initPos = rb.position;
    }

    private void Start()
    {
        sr.enabled = true;
        tilemap.SpawnPoint( out currentTile);
        rb.position = currentTile.pos;
    }
    
    private void OnEnable()
    {
        CharacterDeath.NotifyDeath += ResetPosition;
        CharacterDeath.NotifyDeath += Spawn;       
        UI.SendGameOver += SetGameOver;
    }

    private void OnDisable()
    {
        CharacterDeath.NotifyDeath -= ResetPosition;
        CharacterDeath.NotifyDeath -= Spawn;
        UI.SendGameOver -= SetGameOver;
    }

    private void Spawn()
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
        Debug.Log("entras aca");
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
