using UnityEngine;


public class Tile : MonoBehaviour
{   
    public int x         { get; set; }
    public int y         { get; set; }
    public Vector2 pos   { get; private set; } 
    public bool occupied { get; set; }
    public bool wall     { get; set; }

     private void Awake()
    {
        pos = transform.position;
    }

   
}
