using System;
using UnityEngine;

public class Potion : MonoBehaviour, ICollectible
{   
    [SerializeField]private int score;
    [SerializeField]private TileMapController tilemap;
    private Tile currentTile;
    private SpriteRenderer sr;

    public static event Action ActivePowerUp;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Spawn()
    {
        sr.enabled = true;
        currentTile = gameObject.AddComponent<Tile>(); // preguntar sergio
        tilemap.RandSpawnPoint(currentTile);
        gameObject.transform.position = currentTile.pos;
    }

    public void Destroy()
    {
        ActivePowerUp?.Invoke();
        gameObject.SetActive(false);
    }
}
