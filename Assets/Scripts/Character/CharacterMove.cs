using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    [SerializeField] private float speed;
    [SerializeField]private TileMapController tilemap;
    private Tile currentTile;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        sr.enabled = true;
        currentTile = gameObject.AddComponent<Tile>(); // preguntar sergio
        currentTile.occupied = true;
        tilemap.RandSpawnPoint(currentTile);
        rb.position = currentTile.pos;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
            Movement(TileMapController.Direction.Up);

        if (Input.GetKeyDown(KeyCode.S))
            Movement(TileMapController.Direction.Down);

        if (Input.GetKeyDown(KeyCode.A))
            Movement(TileMapController.Direction.Left);
        
        if (Input.GetKeyDown(KeyCode.D))
            Movement(TileMapController.Direction.Right);
    }

    private void Movement(TileMapController.Direction direction)
    {
        tilemap.CheckMove(currentTile, direction);
        rb.position = currentTile.pos;
        
        // rb.position = Vector2.Lerp(rb.position,currentTile.pos,Time.fixedDeltaTime*speed);
    }

   

    
}
