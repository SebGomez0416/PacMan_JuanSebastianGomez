using System;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    [SerializeField] private float speed;
    [SerializeField]private Tile currentTile;
    [SerializeField]private TileMapController tilemap;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        rb.position = currentTile.pos;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
            tilemap.CheckMove(currentTile, TileMapController.Direction.Up);

        if (Input.GetKeyDown(KeyCode.S))
            tilemap.CheckMove(currentTile, TileMapController.Direction.Down);

        if (Input.GetKeyDown(KeyCode.A))
            tilemap.CheckMove(currentTile, TileMapController.Direction.Left);
        
        if (Input.GetKeyDown(KeyCode.D))
            tilemap.CheckMove(currentTile, TileMapController.Direction.Right);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
      // rb.position = Vector2.Lerp(rb.position,currentTile.pos,Time.fixedDeltaTime*speed);
      rb.position = currentTile.pos;
    }

   

    
}
