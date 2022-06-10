using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] private float speed;
    private Camera cam;
    private Vector3 size;
    private Vector3 max;
    private Vector3 min;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cam= Camera.main;
    }

    private void FixedUpdate()
    {
        Movement();
    }
    
    private void Movement()
    {
        Vector2 movement;
        movement.x = Input.GetAxisRaw("Horizontal")*speed* Time.fixedDeltaTime;
        movement.y= Input.GetAxisRaw("Vertical")*speed* Time.fixedDeltaTime;
        rb.position += movement;

        max = cam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        min = cam.ScreenToWorldPoint(Vector3.zero);

        size = sr.bounds.size;
        size.x /= 2;
        size.y /= 2;

        movement.x = Mathf.Clamp(rb.position.x,(min.x+size.x),(max.x-size.x));
        movement.y=  Mathf.Clamp(rb.position.y,(min.y+size.y),(max.y-size.y));

        rb.MovePosition(movement);
    }

    
}
