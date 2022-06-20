using System;
using UnityEngine;

public class Potion : MonoBehaviour, ISpawmer,ICollectable 
{
    [SerializeField] private SpawnData SpawnData;
    [SerializeField]private TileMapController tilemap;
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

    public void Spawn()
    {
        sr.enabled = true;
        currentTile = gameObject.AddComponent<Tile>();// preguntar sergio
        tilemap.RandSpawnObject(currentTile);
        gameObject.transform.position = currentTile.pos;
    }
    
    public int Amount()
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
