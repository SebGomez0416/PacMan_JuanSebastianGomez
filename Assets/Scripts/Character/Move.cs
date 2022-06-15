using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    [SerializeField] private float speed;
    private Vector2 movement;
    
    private Camera cam;
    private Vector3 size;
    private Vector3 max;
    private Vector3 min;
   
   
    private Tile currentTile;
    private TileMapController tilemap;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cam= Camera.main;
    }

    private void Update()
    {
        movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            movement.y = 1;
        if (Input.GetKey(KeyCode.S))
            movement.y = -1;
        if (Input.GetKey(KeyCode.A))
            movement.x = -1;
        if (Input.GetKey(KeyCode.D))
            movement.x = 1;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        rb.position += movement.normalized * speed * Time.fixedDeltaTime;

        ScreenLimit();
        rb.MovePosition( movement);
    }

    private void ScreenLimit()
    {
        max = cam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        min = cam.ScreenToWorldPoint(Vector3.zero);

        size = sr.bounds.size;
        size.x /= 2;
        size.y /= 2;

        movement.x = Mathf.Clamp(rb.position.x,(min.x+size.x),(max.x-size.x));
        movement.y=  Mathf.Clamp(rb.position.y,(min.y+size.y),(max.y-size.y));
    }

    
}
