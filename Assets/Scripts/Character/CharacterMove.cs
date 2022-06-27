using System;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] private float speed;
    [SerializeField]private TileMapController tilemap;
    private Tile currentTile;
    private bool gameOver;
    private bool isMove;
    private Vector2 initPos;

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

        if (Input.GetKeyDown(KeyCode.W))
            Movement(Direction.Dir.Up);

        if (Input.GetKeyDown(KeyCode.S))
            Movement(Direction.Dir.Down);

        if (Input.GetKeyDown(KeyCode.A))
            Movement(Direction.Dir.Left);
        
        if (Input.GetKeyDown(KeyCode.D))
            Movement(Direction.Dir.Right);
    }

    private void Movement(Direction.Dir direction)
    {
        if (gameOver || isMove) return;
        tilemap.CheckMove( ref currentTile, direction);
        rb.position = currentTile.pos;
        
        // rb.position = Vector2.Lerp(rb.position,currentTile.pos,Time.fixedDeltaTime*speed);
    }

   
}
