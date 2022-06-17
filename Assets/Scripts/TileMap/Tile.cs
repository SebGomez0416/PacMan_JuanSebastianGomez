using UnityEngine;

public class Tile : MonoBehaviour
{   
    public int x{ get; set;}
    public int y{ get; set;}
    public Vector2 pos { get;  set; }
    public bool wall;
    private SpriteRenderer sr;

    private void Awake()
    {
        pos = transform.position;
        sr = GetComponent<SpriteRenderer>();
        if (wall) sr.enabled = false;
    }

   
}
