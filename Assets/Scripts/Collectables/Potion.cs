using System;
using UnityEngine;

public class Potion : MonoBehaviour, ISpawmer,ICollectable 
{
    public TileMapController tilemap { set; private get; }
    [SerializeField] private SpawnData SpawnData;    
    private Tile currentTile;
    private SpriteRenderer sr;
    private bool isActive;

    public static event Action ActivePowerUp;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        PowerUp.EndPowerUp += SetActive;
        ActivePowerUp+=SetActive;
    }

    private void OnDisable()
    {
        PowerUp.EndPowerUp -= SetActive;
        ActivePowerUp+=SetActive;
    }

    public void Spawn(TileMapController map)
    {
        tilemap = map;
        sr.enabled = true;
        tilemap.RandSpawnObject( out currentTile);
        gameObject.transform.position = currentTile.pos;
    }
    
    public int GetAmount()
    {
        return SpawnData.Amount;
    }

    public void GetObject()
    {
        if (isActive) return;
        ActivePowerUp?.Invoke();
        gameObject.SetActive(false);
    }

    private void SetActive()
    {
        isActive = !isActive;
    }
    
}
